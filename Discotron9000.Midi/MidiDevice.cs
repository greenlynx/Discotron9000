using Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discotron9000.Midi
{
    public class MidiDevice
    {
        private InputDevice _inputDevice;

        public string Name
        {
            get { return _inputDevice.Name; }
        }

        internal InputDevice InputDevice
        {
            get { return _inputDevice; }
        }

        internal MidiDevice(InputDevice inputDevice)
        {
            _inputDevice = inputDevice;
        }
    }
}
