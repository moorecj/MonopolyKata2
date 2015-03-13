using Monopoly.Core.Events;
using Monopoly.Core.Players;

namespace Monopoly.Core.Board.Spaces
{
    public class Go : Space, INotifyPassedOver
    {
        public event NotifyPassedOver PassedOver;
        public void RaisePassedOver(Player player)
        {
            var handler = PassedOver;

            if (handler != null)
                handler(this, new NotifyPassedOverEventArgs(player));
        }
    }
}