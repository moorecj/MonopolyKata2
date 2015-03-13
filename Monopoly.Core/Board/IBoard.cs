using System.Collections.Generic;

using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

namespace Monopoly.Core.Board
{
    public interface IBoard
    {
        Space GetSpaceAt(int location);
        IEnumerable<Space> GetSpaceInRange(int start, int end, bool inclusive = true);
        int Size { get; }

        void HandleMove(Player player, int start, int end);
        void HandleMoveTo(Player player, int location);
    }
}