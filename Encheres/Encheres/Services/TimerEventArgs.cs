using System;
using System.Collections.Generic;
using System.Text;

namespace Encheres.Services
{
    public class TimerEventArgs : EventArgs
    {
        public TimeSpan TempsRestant { get; set; }

    }
}
