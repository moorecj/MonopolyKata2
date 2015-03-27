using System.Collections.Generic;

using Monopoly.Core.Bank;
using Monopoly.Core.Board;
using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

using NUnit.Framework;

namespace Monopoly.Test
{
    [TestFixture]
    public class SpaceTests
    {
      
        private Player player1;
        private IBoard board;
        private IBanker banker;
        private IJailer jailer;
        private IBoardFactory boardFactory;

        [SetUp]
        public void Setup()
        {
            player1 = new Player(Token.Automobile);
            banker = new Banker(new List<Player> { player1 });
            jailer = new Jailer();
            boardFactory = new BoardFactory(banker, jailer);
            board = boardFactory.Create();
        }

        [Test]
        public void PassingGo_ShouldGivePlayer200()
        {
            var startingBalance = banker.GetBalanceFor(player1);

            board.GetMove(player1, 39, 2);

            Assert.That(banker.GetBalanceFor(player1), Is.EqualTo(startingBalance + 200));
        }

        [Test]
        public void LandingOnGo_ShouldGivePlayer200()
        {
            var startingBalance = banker.GetBalanceFor(player1);

            board.GetMove(player1, 39, 1);

            Assert.That(banker.GetBalanceFor(player1), Is.EqualTo(startingBalance + 200));
        }

        [Test]
        public void PlayerLandingOnGoToJail_IsJailed()
        {
            var goToJailLocation = board.GetSpaceLocation<GoToJail>();

            board.GetMove(player1, goToJailLocation - 1, 1);

            Assert.That(jailer.HasPrisoner(player1));
        }
    }
}