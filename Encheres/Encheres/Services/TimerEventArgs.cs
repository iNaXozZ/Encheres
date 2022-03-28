using System;
using System.Collections.Generic;
using System.Text;

namespace Encheres.Services
{
    class TimerEventArgs : EventArgs
    {
        public TimeSpan TempsRestant { get; set; }

    }
}
