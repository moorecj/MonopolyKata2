using Monopoly.Core.Events;
using Monopoly.Core.Players;

namespace Monopoly.Core.Board.Spaces
{
    public abstract class Space : INotifyLandedOn
    {
        public event NotifyLandedOn LandedOn;

        public virtual void RaiseLandedOn(Player player)
        {
            var handler = this.LandedOn;

            if (handler != null)
                handler(this, new NotifyLandedOnEventArgs(player));
        }
    }
}