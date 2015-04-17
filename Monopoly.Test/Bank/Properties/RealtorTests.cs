using Monopoly.Core.Bank;
using Monopoly.Core.Bank.Properties;
using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

namespace Monopoly.Test.Bank.Properties
{
    [TestFixture]
    public class RealtorTests
    {
        private Mock<IPropertyOwnershipManager> mockPropertyOwnershipManager;
        private Mock<IBanker> mockBanker;
        private Realtor realtor;
        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
            mockPropertyOwnershipManager = new Mock<IPropertyOwnershipManager>();
            mockBanker = new Mock<IBanker>();
            realtor = new Realtor(mockPropertyOwnershipManager.Object, mockBanker.Object);
        }

        [Test]
        public void Buy_ShouldSetTheOwnerForTheSpaceToThePlayer()
        {
            var player = fixture.Create<Player>();
            var space = fixture.Create<PropertySpace>();
            mockPropertyOwnershipManager.Setup(x => x.SetOwner(space, player)).Verifiable();

            realtor.Buy(space, player);

            mockPropertyOwnershipManager.Verify();
        }

        [Test]
        public void Buy_ShouldReduceBalanceBySpacePrice()
        {
            var player = fixture.Create<Player>();
            var space = fixture.Create<PropertySpace>();
            
            mockBanker.Setup(x => x.Charge(player, space.Price)).Verifiable();

            realtor.Buy(space, player);

            mockBanker.Verify();        
        }

    }
}