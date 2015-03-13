using System;

using Monopoly.Core.Players;

namespace Monopoly.Core.Events
{
    public delegate void NotifyLandedOn(Object sender, NotifyLandedOnEventArgs eventArgs);

    public class NotifyLandedOnEventArgs : EventArgs
    {
        public Player Player { get; private set; }

        public NotifyLandedOnEventArgs(Player player)
        {
            Player = player;
        }
    }
}