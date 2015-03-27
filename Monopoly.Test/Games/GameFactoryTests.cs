using System.Collections.Generic;
using System.Linq;

using Monopoly.Core.Errors;
using Monopoly.Core.Games;
using Monopoly.Core.Players;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

namespace Monopoly.Test.Games
{
    [TestFixture]
    public class GameFactoryTests
    {
        private GameFactory gameFactory;
        private IEnumerable<Token> playerTokens;
        private Fixture fixture;
        private Mock<IPlayerShuffler> mockPlayerShuffler;

        [SetUp]
        public void Setup()
        {
            mockPlayerShuffler = new Mock<IPlayerShuffler>();
            gameFactory = new GameFactory(mockPlayerShuffler.Object);
            fixture = new Fixture();
        }

        [Test]
        public void CreateGameGivenOnePlayer_ShouldThrowTooFewPlayersException()
        {
            playerTokens = CreateTokens(1);

            var ex = Assert.Throws<TooFewPlayersException>(() => gameFactory.Create(playerTokens));
            Assert.That(ex.Message, Is.EqualTo("You must not have many friends... :("));
        }

        [Test]
        public void CreateGameGivenNinePlayers_ShouldThrowTooManyPlayersException()
        {
            playerTokens = CreateTokens(9);

            var ex = Assert.Throws<TooManyPlayersException>(() => gameFactory.Create(playerTokens));
            Assert.That(ex.Message, Is.EqualTo("You are too popular... :)"));
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void CreateGame_GivenBetween2And8Players_ShouldReturnAGame(int numberOfPlayers)
        {
            playerTokens = CreateTokens(numberOfPlayers).ToList();
            mockPlayerShuffler.Setup(x => x.ShufflePlayers(It.IsAny<IEnumerable<Player>>()))
                .Returns(playerTokens.Select(token => new Player(token)));

            var game = gameFactory.Create(playerTokens);

            Assert.That(game, Is.Not.Null);

            var gameTokens = game.Players.Select(p => p.Token);
            CollectionAssert.AreEquivalent(playerTokens, gameTokens);
        }

        [Test]
        public void CreateGame_GivenAValidNumberOfPlayers_ShouldShufflethePlayers()
        {
            playerTokens = CreateTokens(3);
            mockPlayerShuffler.Setup(x => x.ShufflePlayers(It.IsAny<IEnumerable<Player>>()))
                .Returns(playerTokens.Select(token => new Player(token)))
                .Verifiable();

            var game = gameFactory.Create(playerTokens);

            mockPlayerShuffler.Verify();
        }

        private IEnumerable<Token> CreateTokens(int numberOftokens)
        {
            for (int i = 0; i < numberOftokens; i++)
                yield return fixture.Create<Token>();
        }
    }
}