using System.Collections.Generic;

using Monopoly.Core.Players;

namespace Monopoly.Core.Games
{
    public class Game
    {
        public IEnumerable<Player> Players { get; private set; }

        public Game(IEnumerable<Player> players)
        {
            Players = players;
        }
    }
}