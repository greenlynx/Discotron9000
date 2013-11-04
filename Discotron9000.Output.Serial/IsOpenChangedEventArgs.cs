using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discotron9000.Output.Serial
{
    public class IsOpenChangedEventArgs : EventArgs
    {
        public bool IsOpen { get; private set; }

        public IsOpenChangedEventArgs(bool isOpen)
        {
            IsOpen = isOpen;
        }
    }
}
