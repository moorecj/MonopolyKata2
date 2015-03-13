using System;

using Monopoly.Core.Bank;
using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

namespace Monopoly.Core.Events.Handlers
{
    [SpaceHandler(typeof(Go))]
    public class GoHandler : SpaceHandler<Go>
    {
        private readonly IBanker banker;

        internal GoHandler(IBanker banker, Go go)
        {
            this.banker = banker;
            this.Space = go;
            Space.LandedOn += GoOnLandedOn;
            Space.PassedOver += GoOnPassedOver;
        }

        private void GoOnPassedOver(object sender, NotifyPassedOverEventArgs eventArgs)
        {
            Pay(eventArgs.Player);
        }

        private void GoOnLandedOn(object sender, NotifyLandedOnEventArgs eventArgs)
        {
            Pay(eventArgs.Player);
        }

        private void Pay(Player player)
        {
            const int goAmount = 200;
            banker.Pay(player, goAmount);
        }
    }
}