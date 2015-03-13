using System.Collections.Generic;
using System.Linq;

using Monopoly.Core.Games;
using Monopoly.Core.Players;

using NUnit.Framework;

namespace Monopoly.Test
{
    [TestFixture]
    public class MathRandomPlayerShufflerTests
    {
        [Test]
        public void ShufflePlayers_GivenTwoPlayers_ShouldReturnAllPermutationsInAHundredCalls()
        {
            var playerShuffler = new MathRandomPlayerShuffler();
            var players = new List<Player> {new Player(Token.Cat), new Player(Token.Battleship)};

            var catFirst = 0;
            var battleshipFirst = 0;

            for (int i = 0; i < 100; i++)
            {
                var shuffledPlayers = playerShuffler.ShufflePlayers(players);
                var firstPlayer = shuffledPlayers.First();

                switch (firstPlayer.Token)
                {
                    case Token.Cat:
                        catFirst++;
                        break;
                    case Token.Battleship:
                        battleshipFirst++;
                        break;
                }

                if (catFirst >= 1 && battleshipFirst >= 1) break;
            }

            Assert.That(catFirst, Is.GreaterThanOrEqualTo(1));
            Assert.That(battleshipFirst, Is.GreaterThanOrEqualTo(1));
        }
    }
}