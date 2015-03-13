using Monopoly.Core.Players;

namespace Monopoly.Core.Board.Spaces
{
    public interface ICanBePassedOver
    {
        void PassOver(Player player);
    }
}