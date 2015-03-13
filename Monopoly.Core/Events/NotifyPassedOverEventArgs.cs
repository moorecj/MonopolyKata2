using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Monopoly.Core.Players;

namespace Monopoly.Core.Events
{
    public delegate void NotifyPassedOver(Object sender, NotifyPassedOverEventArgs eventArgs);

    public class NotifyPassedOverEventArgs : EventArgs
    {
        public Player Player { get; private set; }

        public NotifyPassedOverEventArgs(Player player)
        {
            Player = player;
        }
    }
}
