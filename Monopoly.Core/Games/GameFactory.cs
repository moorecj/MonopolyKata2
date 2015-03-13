using System.Collections.Generic;
using System.Linq;

using Monopoly.Core.Errors;
using Monopoly.Core.Players;

namespace Monopoly.Core.Games
{
    public class GameFactory : IGameFactory
    {
        private IPlayerShuffler playerShuffler;

        public GameFactory(IPlayerShuffler playerShuffler)
        {
            this.playerShuffler = playerShuffler;
        }

        public Game Create(IEnumerable<Token> playerTokens)
        {
            if(playerTokens.ToList().Count < 2)
                throw new TooFewPlayersException("You must not have many friends... :(");

            if (playerTokens.ToList().Count > 8)
                throw new TooManyPlayersException("You are too popular... :)");

            var players = playerShuffler.ShufflePlayers(playerTokens.Select(token => new Player(token)));

            return new Game(players);
        }
    }
}