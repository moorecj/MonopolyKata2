using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

namespace Monopoly.Core.Bank.Properties
{
    public interface IPropertyOwnershipManager
    {
        Player GetOwner(PropertySpace property);
        bool IsMortgaged(PropertySpace property);
        void SetOwner(PropertySpace property, Player buyer);
        void Mortgage(PropertySpace property);
        void Unmortgage(PropertySpace property);
    }
}