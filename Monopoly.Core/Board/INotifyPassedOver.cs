using Monopoly.Core.Events;
using Monopoly.Core.Players;

namespace Monopoly.Core.Board
{
    public interface INotifyPassedOver
    {
        event NotifyPassedOver PassedOver;

        void RaisePassedOver(Player player);
    }
}