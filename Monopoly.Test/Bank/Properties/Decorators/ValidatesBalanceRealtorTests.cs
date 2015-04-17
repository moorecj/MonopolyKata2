using System;

using Monopoly.Core.Bank;
using Monopoly.Core.Bank.Properties;
using Monopoly.Core.Bank.Properties.Decorators;
using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

namespace Monopoly.Test.Bank.Properties.Decorators
{
    [TestFixture]
    public class ValidatesBalanceRealtorTests
    {
        private Mock<IPropertyOwnershipManager> mockPropertyOwnershipManager;
        private Mock<IBanker> mockBanker;
        private Mock<IRealtor> decoratedRealtor;
        private ValidatesBalanceRealtor realtor;
        private Fixture fixture;
        private Player player;
        private PropertySpace space;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
            mockPropertyOwnershipManager = new Mock<IPropertyOwnershipManager>();
            mockBanker = new Mock<IBanker>();
            decoratedRealtor = new Mock<IRealtor>();
            realtor = new ValidatesBalanceRealtor(decoratedRealtor.Object, mockBanker.Object);

            player = fixture.Create<Player>();
            space = fixture.Create<PropertySpace>();
        }

        [Test]
        public void Buy_ShouldCallTheDecoratedBuy()
        {
            decoratedRealtor.Setup(x => x.Buy(space, player)).Verifiable();

            realtor.Buy(space, player);

            decoratedRealtor.Verify();
        }

        [Test]
        public void Buy_ShouldCheckTheBalanceForThePlayer()
        {
            decoratedRealtor.Setup(x => x.Buy(space, player));
            mockBanker.Setup(x => x.GetBalanceFor(player)).Returns(fixture.Create<int>());

            realtor.Buy(space, player);
            
            mockBanker.Verify();
        }

        [Test]
        public void Buy_WithInsufficientBalance_ThrowsNotImplemented()
        {
            decoratedRealtor.Setup(x => x.Buy(space, player));
            mockBanker.Setup(x => x.GetBalanceFor(player)).Returns(space.Price-1);

            Assert.Throws<NotImplementedException>(() => realtor.Buy(space, player));
            decoratedRealtor.Verify(x => x.Buy(space, player), Times.Never);
        }
    }
}