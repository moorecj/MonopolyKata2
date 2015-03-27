using System.Collections.Generic;

using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

namespace Monopoly.Core.Board
{
    public interface IBoard
    {
        int GetMove(Player player, int start, int numberToMove);
        int GetSpaceLocation<TSpace>() where  TSpace : Space;
        Space GetSpaceAt(int location);
    }
}