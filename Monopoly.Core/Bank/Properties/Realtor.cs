using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

namespace Monopoly.Core.Bank.Properties
{
    public class Realtor : IRealtor
    {
        private readonly IBanker banker;
        private readonly IPropertyOwnershipManager propertyOwnershipManager;

        public Realtor(IPropertyOwnershipManager propertyOwnershipManager, IBanker banker)
        {
            this.propertyOwnershipManager = propertyOwnershipManager;
            this.banker = banker;
        }

        public void Buy(PropertySpace space, Player player)
        {
            propertyOwnershipManager.SetOwner(space,player);
            banker.Charge(player, space.Price);                
        }


    }
}