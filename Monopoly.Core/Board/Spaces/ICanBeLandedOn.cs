using Monopoly.Core.Players;

namespace Monopoly.Core.Board.Spaces
{
    public interface ICanBeLandedOn
    {
        void LandOn(Player player);
    }
}