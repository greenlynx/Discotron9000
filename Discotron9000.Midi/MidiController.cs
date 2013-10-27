/*
 * Copyright 2013 PoWWow Pedal Power
 * 
 * This file is part of Discotron 9000.
 * 
 * Discotron 9000 is free software: you can redistribute it and/or modify it under the terms of the
 * GNU General Public License as published by the Free Software Foundation, either version 3 of the License,
 * or (at your option) any later version.
 * 
 * Discotron 9000 is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even
 * the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public
 * License for more details.
 * 
 * You should have received a copy of the GNU General Public License along with Discotron 9000. If not, see
 * http://www.gnu.org/licenses/.
 */

using Discotron9000.NutsAndBolts;
using Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discotron9000.Midi
{
    public class MidiController
    {
        private const int MAXIMUM_MIDI_VELOCITY = 127;
        private const int MAXIMUM_MIDI_PITCH_BEND = 16383;

        private const int FIRST_MIDI_CONTROL_CHANGE = 10;

        private InputDevice _inputDevice;
        private MidiDevice _activeMidiDevice;

        public MidiDevice ActiveMidiDevice
        {
            get { return _activeMidiDevice; }
            set
            {
                _activeMidiDevice = value;
                InitialiseMidi();
            }
        }

        public DiscoFloor DiscoFloor { get; private set; }

        public int? ChannelFilter { get; set; }
        public bool IsActive { get; private set; }

        private void ShutdownMidi()
        {
            if (_inputDevice == null)
            {
                return;
            }
            
            _inputDevice.StopReceiving();

            _inputDevice.ControlChange -= _inputDevice_ControlChange;
            _inputDevice.PitchBend -= _inputDevice_PitchBend;
            _inputDevice.NoteOff -= _inputDevice_NoteOff;
            _inputDevice.NoteOn -= _inputDevice_NoteOn;
            
            if (_inputDevice.IsOpen)
            {
                _inputDevice.Close();
            }

            IsActive = false;
        }

        private void InitialiseMidi()
        {
            ShutdownMidi();

            if (_activeMidiDevice == null)
            {
                return;
            }

            _inputDevice = _activeMidiDevice.InputDevice;
            _inputDevice.Open();
            
            _inputDevice.NoteOn += _inputDevice_NoteOn;
            _inputDevice.NoteOff += _inputDevice_NoteOff;
            _inputDevice.PitchBend += _inputDevice_PitchBend;
            _inputDevice.ControlChange += _inputDevice_ControlChange;

            _inputDevice.StartReceiving(null);

            IsActive = true;
        }

        public IEnumerable<MidiDevice> Devices
        {
            get
            {
                return InputDevice.InstalledDevices.Select(x => new MidiDevice(x));
            }
        }

        private DiscoSquare GetSquareForNote(NoteMessage msg)
        {
            return DiscoFloor.GetSquare(msg.Pitch.PositionInOctave(), msg.Pitch.Octave() - 2);
        }

        private static int ClampValue(int value, int maximum, int minimum = 0)
        {
            return Math.Max(minimum, Math.Min(value, maximum));
        }

        private static double MapClampedValueToFraction(int value, int sourceMaximum, int destinationMaximum)
        {
            double doubleValue = (double)value;
            double doubleMaximum = (double)sourceMaximum;

            return (destinationMaximum / doubleMaximum) * doubleValue;
        }

        private static double ClampMidiValue(int velocity, int maximum)
        {
            int clampedVelocity = ClampValue(velocity, MAXIMUM_MIDI_VELOCITY);
            return MapClampedValueToFraction(clampedVelocity, MAXIMUM_MIDI_VELOCITY, maximum);
        }

        private static int PitchBendToHueShift(int value)
        {
            int clampedValue = ClampValue(value, MAXIMUM_MIDI_VELOCITY);
            return (int)(((double)720 / MAXIMUM_MIDI_PITCH_BEND) * value - 360);
        }

        private bool ProcessMessage(ChannelMessage message)
        {
            if (ChannelFilter.HasValue && (int)message.Channel != ChannelFilter)
            {
                return false;
            }

            return true;
        }

        private void _inputDevice_NoteOn(NoteOnMessage msg)
        {
            if (!ProcessMessage(msg))
            {
                return;
            }

            var square = GetSquareForNote(msg);
            var lightness = ClampMidiValue(msg.Velocity, 1);

            square.TurnOnWithLightness(lightness);
        }

        private void _inputDevice_NoteOff(NoteOffMessage msg)
        {
            if (!ProcessMessage(msg))
            {
                return;
            }

            var square = GetSquareForNote(msg);
            square.IsLit = false;
        }

        private void _inputDevice_PitchBend(PitchBendMessage msg)
        {
            if (!ProcessMessage(msg))
            {
                return;
            }

            DiscoFloor.GlobalHueShift = PitchBendToHueShift(msg.Value);
        }

        private void _inputDevice_ControlChange(ControlChangeMessage msg)
        {
            if (!ProcessMessage(msg))
            {
                return;
            }

            switch (msg.Control)
            {
                case Control.Volume:
                    {
                        DiscoFloor.GlobalScalingFactor = ClampMidiValue(msg.Value, 1);
                        break;
                    }
                case Control.AllNotesOff:
                    {
                        DiscoFloor.DimAllSquares();
                        break;
                    }
                default:
                    {
                        int squareIndex = (int)msg.Control - FIRST_MIDI_CONTROL_CHANGE;

                        if (squareIndex < 0 || squareIndex >= 50)
                        {
                            // Ignore the message
                            break;
                        }

                        bool isHue = (squareIndex % 2 == 0);
                        int x = squareIndex % 10 / 2;
                        int y = (int)(squareIndex / 5);
                        
                        var square = DiscoFloor.GetSquare(x, y);
                        if (isHue)
                        {
                            square.BaseIntensities = square.BaseIntensities.WithHue(ClampMidiValue(msg.Value, 360));
                        }
                        else
                        {
                            square.BaseIntensities = square.BaseIntensities.WithSaturation(ClampMidiValue(msg.Value, 1));
                        }

                        break;
                    }
            }
        }
        
        public MidiController(DiscoFloor discoFloor)
        {
            DiscoFloor = discoFloor;

            InitialiseMidi();
        }
    }
}
