using System.Collections.Generic;

using Monopoly.Core.Bank;
using Monopoly.Core.Board;
using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Events.Handlers;
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
        private IBoardFactory boardFactory;

        [SetUp]
        public void Setup()
        {
            player1 = new Player(Token.Automobile);
            banker = new Banker(new List<Player> { player1 });
            boardFactory = new BoardFactory(banker);
            board = boardFactory.Create();
        }

        [Test]
        public void PassingGo_ShouldGivePlayer200()
        {
            var startingBalance = banker.GetBalanceFor(player1);

            board.HandleMove(player1, 39, 1);

            Assert.That(banker.GetBalanceFor(player1), Is.EqualTo(startingBalance + 200));
        }

        [Test]
        public void LandingOnGo_ShouldGivePlayer200()
        {
            var startingBalance = banker.GetBalanceFor(player1);

            board.HandleMove(player1, 39, 0);

            Assert.That(banker.GetBalanceFor(player1), Is.EqualTo(startingBalance + 200));
        }

    }
}