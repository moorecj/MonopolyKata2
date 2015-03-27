using System.Collections.Generic;

using Monopoly.Core;
using Monopoly.Core.Board;
using Monopoly.Core.Players;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

namespace Monopoly.Test.Players
{
    [TestFixture]
    public class PlayerLocationManagerTests
    {
        private PlayerLocationManager playerLocationManager;
        private Player player1;
        private Player player2;
        private IEnumerable<Player> players;
        private Mock<IBoard> mockBoard;
        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
            player1 = new Player(Token.Automobile);
            player2 = new Player(Token.Battleship);
            players = new[] { player1, player2 };
            mockBoard = new Mock<IBoard>();
            playerLocationManager = new PlayerLocationManager(players, mockBoard.Object);
        }

        [Test] 
        public void AllPlayersHaveLocationOf0_BeforeAnyMoves()
        {
            foreach (var player in players)
                Assert.That(playerLocationManager.GetLocation(player), Is.EqualTo(0));
        }

        [Test]
        public void PlayerMovement_UpdatesLocation_BasedOnBoard()
        {
            var endLocation = fixture.Create<int>();
            mockBoard.Setup(x => x.GetMove(It.IsAny<Player>(), It.IsAny<int>(), It.IsAny<int>())).Returns(endLocation);

            foreach (var player in players)
            {
                playerLocationManager.Move(player, It.IsAny<int>());
                Assert.That(playerLocationManager.GetLocation(player), Is.EqualTo(endLocation));
            }
        }
    }
}