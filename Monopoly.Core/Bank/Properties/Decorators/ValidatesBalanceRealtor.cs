using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

namespace Monopoly.Core.Bank.Properties.Decorators
{
    public class ValidatesBalanceRealtor : IRealtor
    {
        private readonly IRealtor decoratedRealtor;
        private readonly IBanker banker;

        public ValidatesBalanceRealtor(IRealtor decoratedRealtor, IBanker banker)
        {
            this.decoratedRealtor = decoratedRealtor;
            this.banker = banker;
        }

        public void Buy(PropertySpace space, Player player)
        {
            if (banker.GetBalanceFor(player) < space.Price)
            {
                NotifyInsufficientBalance(player, space);
                return;                
            }

            decoratedRealtor.Buy(space, player);
        }

        private void NotifyInsufficientBalance(Player player, PropertySpace space)
        {
            throw new System.NotImplementedException();
        }

    }
}