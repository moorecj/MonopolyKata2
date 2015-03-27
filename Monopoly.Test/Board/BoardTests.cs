using System.Collections.Generic;
using System.Linq;

using Monopoly.Core.Bank;
using Monopoly.Core.Board;
using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

namespace Monopoly.Test.Board
{
    [TestFixture]
    public class BoardTests
    {
        private IBoard board;
        private IBoardFactory boardFactory;
        private Mock<IBanker> mockBanker;
        private Mock<IJailer> mockJailer;
        private Mock<ITaxCollector> mockTaxCollector;
        private Fixture fixture;
        private Player player1;
            
        [SetUp]
        public void Setup()
        {
            mockBanker = new Mock<IBanker>();
            mockJailer = new Mock<IJailer>();
            mockTaxCollector = new Mock<ITaxCollector>();
            mockJailer.Setup(x => x.LockUp(It.IsAny<Player>()));
            boardFactory = new BoardFactory(mockBanker.Object, mockJailer.Object, mockTaxCollector.Object);
            board = boardFactory.Create();
            fixture = new Fixture();
            player1 = fixture.Create<Player>();
        }

        [TestCase(39, 7, 6)]
        [TestCase(38, 7, 5)]
        [TestCase(35, 8, 3)]
        public void GetMove_WhenStartPlusNumberIsBiggerThanSize_Wraps(int startingLocation, int numberToMove, int expectedLocation)
        {
            Assert.That(board.GetMove(player1, startingLocation, numberToMove), Is.EqualTo(expectedLocation));   
        }

        [TestCaseSource("AllPosibleMoves")]
        public void GetMove_MovingANumberOfSpaces_ShouldResultInALocationThatManySpacesAway(int numbertoMove, int expectedLocation)
        {
            Assert.That(board.GetMove(player1, 0, numbertoMove), Is.EqualTo(expectedLocation));
        }

        [Test]
        public void GetMove_RaisesNotifyLandedOnForLandedOnSpace()
        {
            var landOnNotified = false;
            var landOnLocation = 5;
            var space = board.GetSpaceAt(landOnLocation);
            space.LandedOn += (sender, args) => { landOnNotified = true; };

            board.GetMove(player1, 0, landOnLocation);

            Assert.That(landOnNotified, Is.True);
        }

        [Test]
        public void GetMoveResultingInGoToJailSpace_ReturnsJustVisitingSpace()
        {
            var goToJailLocation = board.GetSpaceLocation<GoToJail>();
            
            var result = board.GetMove(player1, goToJailLocation - 1, 1);

            Assert.That(result, Is.EqualTo(board.GetSpaceLocation<JustVisiting>()));
        }

        private IEnumerable<ITestCaseData> AllPosibleMoves()
        {
            return Enumerable.Range(1, 12).Select(move => new TestCaseData(move, move));
        }
    }
}