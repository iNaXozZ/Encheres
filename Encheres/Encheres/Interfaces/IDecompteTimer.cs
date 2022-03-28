using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encheres.Interfaces
{
    interface IDecompteTimer
    {
        void Start(TimeSpan CountdownTime);
        void Stop();

        event EventHandler<TimerEventArgs> TicTac;
        event EventHandler Complet;
        event EventHandler Avorte;
    }
}
