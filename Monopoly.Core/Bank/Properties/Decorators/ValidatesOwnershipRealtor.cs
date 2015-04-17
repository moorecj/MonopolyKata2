using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

namespace Monopoly.Core.Bank.Properties.Decorators
{
    public class ValidatesOwnershipRealtor : IRealtor
    {
        private readonly IPropertyOwnershipManager propertyOwnershipManager;
        private readonly IRealtor decoratedRealtor;

        public ValidatesOwnershipRealtor(IPropertyOwnershipManager propertyOwnershipManager, IRealtor decoratedRealtor)
        {
            this.propertyOwnershipManager = propertyOwnershipManager;
            this.decoratedRealtor = decoratedRealtor;
        }

        public void Buy(PropertySpace space, Player player)
        {
            if (propertyOwnershipManager.GetOwner(space) != null)
            {
                NotifyPropertyAlreadyOwned(space);
                return;
            }

            decoratedRealtor.Buy(space, player);
        }

        private void NotifyPropertyAlreadyOwned(PropertySpace space)
        {
            throw new System.NotImplementedException();
        }
    }
}