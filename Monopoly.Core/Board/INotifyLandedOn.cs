using Monopoly.Core.Events;
using Monopoly.Core.Players;

namespace Monopoly.Core.Board
{
    public interface INotifyLandedOn
    {
        event NotifyLandedOn LandedOn;

        void RaiseLandedOn(Player player);
    }
}