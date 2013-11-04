using CommandMessenger;
using Discotron9000.NutsAndBolts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discotron9000.Output.Serial
{
    public class ArduinoOutput
    {
        private enum Command
        {
            Acknowledge,
            Error,
            SetSquareIntensities,
        };

        private readonly DiscoFloor _discoFloor;
        private readonly DiscoSquare _firstSquare;

        private SerialPortManager _serialPortManager;
        private CmdMessenger _cmdMessenger;

        private string _portName;
        public string SerialPortName
        {
            get { return _serialPortManager.CurrentSerialSettings.PortName; }
            set
            {
                ClosePort();
                _portName = value;
                OpenPort();
            }
        }

        private bool _isOpen;
        public bool IsOpen
        {
            get { return _isOpen; }
            private set
            {
                _isOpen = value;
                FireIsOpenChanged(_isOpen);
            }
        }

        public event EventHandler<IsOpenChangedEventArgs> IsOpenChanged;

        private void FireIsOpenChanged(bool isOpen)
        {
            if (this.IsOpenChanged != null)
            {
                this.IsOpenChanged(new object(), new IsOpenChangedEventArgs(isOpen));
            }
        }

        public void ClosePort()
        {
            if (_cmdMessenger != null)
            {
                _cmdMessenger.NewLineSent -= NewLineSent;
                _cmdMessenger.NewLineReceived -= NewLineReceived;

                _cmdMessenger.StopListening();
                _cmdMessenger.Dispose();
                _cmdMessenger = null;

                _serialPortManager.Close();
                _serialPortManager.Dispose();
                _serialPortManager = null;
            }

            IsOpen = false;
        }

        public void OpenPort()
        {
            ClosePort();

            if (string.IsNullOrWhiteSpace(_portName))
            {
                return;
            }

            _serialPortManager = new SerialPortManager
            {
                CurrentSerialSettings = { PortName = _portName, BaudRate = 115200 }
            };

            _cmdMessenger = new CmdMessenger(_serialPortManager);

            AttachCommandCallBacks();

            _cmdMessenger.NewLineReceived += NewLineReceived;
            _cmdMessenger.NewLineSent += NewLineSent;

            IsOpen = _cmdMessenger.StartListening();

            SendCurrentIntensities();
            SendCurrentIntensities();
        }

        private void SendCurrentIntensities()
        {
            if (_firstSquare == null)
            {
                return;
            }

            var rgb = _firstSquare.EffectiveIntensities.ToColor();
            SetIntensities(0, rgb.R, rgb.G, rgb.B);
        }

        public ArduinoOutput(DiscoFloor discoFloor)
        {
            _discoFloor = discoFloor;
            _firstSquare = _discoFloor.GetSquare(0, 0);
            _firstSquare.IntensitiesChanged += _firstSquare_IntensitiesChanged;
        }

        private void AttachCommandCallBacks()
        {
            _cmdMessenger.Attach(OnUnknownCommand);
            _cmdMessenger.Attach((int)Command.Acknowledge, OnAcknowledge);
            _cmdMessenger.Attach((int)Command.Error, OnError);
        }

        void OnUnknownCommand(ReceivedCommand arguments)
        {
            Console.WriteLine(@"Command without attached callback received");
        }

        void OnAcknowledge(ReceivedCommand arguments)
        {
            Console.WriteLine(arguments.ReadBinStringArg());
        }

        void OnError(ReceivedCommand arguments)
        {
            Console.WriteLine(@"Arduino has experienced an error");
        }

        private void NewLineReceived(object sender, EventArgs e)
        {
            Console.WriteLine(@" Received > " + _cmdMessenger.CurrentReceivedLine);
        }

        private void NewLineSent(object sender, EventArgs e)
        {
            Console.WriteLine(@" Sent > " + _cmdMessenger.CurrentSentLine);
        }

        public void SetIntensities(int squareIndex, int red, int green, int blue)
        {
            if (_cmdMessenger == null || !IsOpen)
            {
                return;
            }

            var command = new SendCommand((int)Command.SetSquareIntensities);
            command.AddArgument((byte)red);
            command.AddArgument((byte)green);
            command.AddArgument((byte)blue);

            _cmdMessenger.SendCommand(command);
        }

        private void _firstSquare_IntensitiesChanged(object sender, IntensitiesChangedEventArgs e)
        {
            var rgb = e.Intensities.ToColor();

            SetIntensities(0, rgb.R, rgb.G, rgb.B);
        }
    }
}