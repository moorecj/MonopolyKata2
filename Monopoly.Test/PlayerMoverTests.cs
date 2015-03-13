using System.Collections.Generic;
using System.Linq;

using Monopoly.Core;
using Monopoly.Core.Bank;
using Monopoly.Core.Board;
using Monopoly.Core.Players;

using NUnit.Framework;

namespace Monopoly.Test
{
    [TestFixture]
    public class PlayerMoverTests
    {
        private PlayerMover playerMover;
        private Player player1;
        private Player player2;
        private IEnumerable<Player> players;
        private IBoard board;
        private IBanker banker;
        private IBoardFactory boardFactory;

        [SetUp]
        public void Setup()
        {
            player1 = new Player(Token.Automobile);
            player2 = new Player(Token.Battleship);
            players = new[] { player1, player2 };
            banker = new Banker(players);
            boardFactory = new BoardFactory(banker);
            board = boardFactory.Create();
            playerMover = new PlayerMover(players, board);
        }

        [Test] 
        public void AllPlayersHaveLocationOf0_BeforeAnyMoves()
        {
            foreach (var player in players)
                Assert.That(playerMover.GetLocation(player), Is.EqualTo(0));
        }

        [Test]
        public void PlayerMovementOf_0_ResultsInTheSameLoaction()
        {
            playerMover.Move(player1, 0);

            Assert.That(playerMover.GetLocation(player1), Is.EqualTo(0));
        }
        
        [TestCaseSource("AllPosibleMovesStartingOnZero")]
        public void PlayerStartingOnLocation0_MovingANumberOfSpaces_ShouldResultInALocationThatManySpacesAway(int numbertoMove, int expectedLocation)
        {
            playerMover.Move(player1, numbertoMove);

            Assert.That(playerMover.GetLocation(player1), Is.EqualTo(expectedLocation));   
        }

        [TestCase(39, 7, 6)]
        [TestCase(38, 7, 5)]
        [TestCase(35, 8, 3)]
        public void PlayerMovementPassingEndOfBoard_ShouldWrapToBeginningOfBoard(int startingLocation, int numberToMove, int expectedLocation)
        {
            playerMover.MoveTo(player1, startingLocation);
            
            playerMover.Move(player1, numberToMove);

            Assert.That(playerMover.GetLocation(player1), Is.EqualTo(expectedLocation));   
        }
        
        private IEnumerable<ITestCaseData> AllPosibleMovesStartingOnZero()
        {
            foreach (var move in Enumerable.Range(1, 12))
            {
                yield return new TestCaseData(move, move);
            }
            ;
        }
    }
}