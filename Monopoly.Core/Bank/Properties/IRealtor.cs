using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

namespace Monopoly.Core.Bank.Properties
{
    public interface IRealtor
    {
        void Buy(PropertySpace space, Player player);
    }
}