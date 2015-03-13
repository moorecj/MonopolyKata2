using System.Collections.Generic;

using Monopoly.Core.Players;

namespace Monopoly.Core.Games
{
    public interface IPlayerShuffler
    {
        IEnumerable<Player> ShufflePlayers(IEnumerable<Player> players);
    }
}