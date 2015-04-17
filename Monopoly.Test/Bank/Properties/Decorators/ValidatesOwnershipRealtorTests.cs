using System;

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
    public class ValidatesOwnershipRealtorTests
    {
        private Mock<IPropertyOwnershipManager> mockPropertyOwnershipManager;
        private Mock<IRealtor> decoratedRealtor;
        private ValidatesOwnershipRealtor realtor;
        private Fixture fixture;
        private Player player;
        private PropertySpace space;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
            mockPropertyOwnershipManager = new Mock<IPropertyOwnershipManager>();
            decoratedRealtor = new Mock<IRealtor>();
            realtor = new ValidatesOwnershipRealtor(mockPropertyOwnershipManager.Object, decoratedRealtor.Object);
            player = fixture.Create<Player>();
            space = fixture.Create<PropertySpace>();
        }

        [Test]
        public void Buy_ShouldCallTheDecoratedBuy()
        {
            decoratedRealtor.Setup(x => x.Buy(space, player));

            realtor.Buy(space, player);

            decoratedRealtor.Verify();
        }

        [Test]
        public void Buy_WhenSpaceIsOwned_ThrowsNotImplementedException()
        {
            mockPropertyOwnershipManager.Setup(x => x.GetOwner(space)).Returns(fixture.Create<Player>());
            
            Assert.Throws<NotImplementedException>(() => realtor.Buy(space, player));
            decoratedRealtor.Verify(x => x.Buy(space, player), Times.Never);
        }
    }
}