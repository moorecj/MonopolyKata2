using System;

using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

namespace Monopoly.Core.Events
{
    public delegate void NotifyLandedOn(Object sender, NotifyLandedOnEventArgs eventArgs);

    public class NotifyLandedOnEventArgs : EventArgs
    {
        public Player Player { get; private set; }

        public Space Space { get; set; }

        public NotifyLandedOnEventArgs(Player player, Space space = default(Space))
        {
            Player = player;
            Space = space;
        }
    }
}