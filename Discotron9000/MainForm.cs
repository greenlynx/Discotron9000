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

using Discotron9000.Midi;
using Discotron9000.NutsAndBolts;
using Discotron9000.Output.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discotron9000
{
    public partial class MainForm : Form
    {
        private DiscoFloor _discoFloor;
        private KeyEventController _keyEventController;
        private MidiController _midiController;
        private ArduinoOutput _arduinoOutput;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _discoFloor = new DiscoFloor(5, 5);

            _midiController = new MidiController(_discoFloor);

            _arduinoOutput = new ArduinoOutput(_discoFloor);
            _arduinoOutput.IsOpenChanged += _arduinoOutput_IsOpenChanged;

            _midiDeviceComboBox.Items.Clear();
            if (_midiController.Devices.Any())
            {
                _midiDeviceComboBox.Items.AddRange(_midiController.Devices.ToArray());
            }
            else
            {
                _midiDeviceComboBox.Items.Add("(No MIDI devices)");
            }

            _midiChannelComboBox.Items.Clear();
            _midiChannelComboBox.Items.Add("(All channels)");
            for (int i = 0; i < 16; i++)
            {
                _midiChannelComboBox.Items.Add(String.Format("Channel {0}", i + 1));
            }

            _serialPortComboBox.Items.Clear();
            for (int i = 1; i <= 9; i++)
            {
                _serialPortComboBox.Items.Add(String.Format("COM{0}", i));
            }

            _midiDeviceComboBox.SelectedIndex = 0;
            _midiChannelComboBox.SelectedIndex = 0;
            _serialPortComboBox.SelectedIndex = 2;

            _keyEventController = new KeyEventController();
            _keyEventController.Form = this;
            _keyEventController.DiscoFloor = _discoFloor;

            _danceFloorView.DiscoFloor = _discoFloor;
        }

        private void _arduinoOutput_IsOpenChanged(object sender, IsOpenChangedEventArgs e)
        {
            var status = (e.IsOpen ? "CONNECTED" : "NOT CONNECTED");
            _serialPortStatusLabel.Text = String.Format("Serial status: {0}", status);
        }

        private void _randomiseButton_Click(object sender, EventArgs e)
        {
            var random = new Random((int)DateTime.Now.Ticks);
            for (int x = 0; x < _discoFloor.Columns; x++)
            {
                for (int y = 0; y < _discoFloor.Rows; y++)
                {
                    _discoFloor.GetSquare(x, y).BaseIntensities =
                        new HsvTriplet(random.NextDouble() * 360, random.NextDouble(), random.NextDouble());
                }
            }
        }

        private void _allOnButton_Click(object sender, EventArgs e)
        {
            _discoFloor.LightAllSquares();
        }

        private void _allOffButton_Click(object sender, EventArgs e)
        {
            _discoFloor.DimAllSquares();
        }

        private void _midiDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _midiController.ActiveMidiDevice = _midiDeviceComboBox.SelectedItem as MidiDevice;
        }

        private void _midiChannelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = _midiChannelComboBox.SelectedIndex;
            if (selectedIndex == 0)
            {
                _midiController.ChannelFilter = null;
            }
            else
            {
                _midiController.ChannelFilter = selectedIndex - 1;
            }
        }

        private void _alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = _alwaysOnTopCheckBox.Checked;
        }

        private void _serialPortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _arduinoOutput.SerialPortName = _serialPortComboBox.SelectedItem as string;
        }
        
        private void _closeSerialButton_Click(object sender, EventArgs e)
        {
            _arduinoOutput.ClosePort();
        }

        private void openSerialButton_Click(object sender, EventArgs e)
        {
            _arduinoOutput.OpenPort();
        }
    }
}