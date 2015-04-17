using Monopoly.Core.Bank.Properties;
using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

using NUnit.Framework;

using Ploeh.AutoFixture;

namespace Monopoly.Test.Bank.Properties
{
    [TestFixture]
    public class PropertyManagerTests
    {
        private PropertyOwnershipManager propertyOwnershipManager;
        private Fixture fixture;
        private Player player;
        private PropertySpace space;

        [SetUp]
        public void Setup()
        {
            propertyOwnershipManager = new PropertyOwnershipManager();
            fixture = new Fixture();
            player = fixture.Create<Player>();
            space = fixture.Create<PropertySpace>();
        }

        [Test]
        public void GetOwner_WhenThePropertyIsNotOwned_ReturnsNull()
        {
            Assert.That(propertyOwnershipManager.GetOwner(space), Is.Null);
        }

        [Test]
        public void GetOwner_WhenThePropertyIsOwned_ReturnsTheOwner()
        {
            propertyOwnershipManager.SetOwner(space, player);

            Assert.That(propertyOwnershipManager.GetOwner(space), Is.EqualTo(player));
        }

        [Test]
        public void SetOwner_WhenTheSpaceIsOwned_ThrowsASpaceAlreadyOwnedException()
        {
            propertyOwnershipManager.SetOwner(space, fixture.Create<Player>());
            Assert.Throws<PropertyOwnershipManager.PropertyAlreadyOwnedException>(() => propertyOwnershipManager.SetOwner(space, player));
        }

        [Test]
        public void SetOwner_WhenThePropertyIsNotOwned_SetsTheOwner()
        {
            Assert.That(propertyOwnershipManager.GetOwner(space), Is.Null);
            
            propertyOwnershipManager.SetOwner(space, player);

            Assert.That(propertyOwnershipManager.GetOwner(space), Is.EqualTo(player));
        }

        [Test]
        public void MortagingAProperty_ThatIsNotAlreadyMortaged_WillMortageTheProperty()
        {
            propertyOwnershipManager.SetOwner(space, player);
            Assert.That(propertyOwnershipManager.IsMortgaged(space), Is.False);

            propertyOwnershipManager.Mortgage(space);

            Assert.That(propertyOwnershipManager.IsMortgaged(space), Is.True); 
        }

        [Test]
        public void MortgagingAProperty_WhenthePropertyIsAlreadyMortgaged_ThrowsAPropertyAlreadyMortgagedException()
        {
            propertyOwnershipManager.SetOwner(space, fixture.Create<Player>());
            propertyOwnershipManager.Mortgage(space);

            Assert.Throws<PropertyOwnershipManager.PropertyAlreadyMortgagedException>(() => propertyOwnershipManager.Mortgage(space));
        }

        [Test]
        public void MortgagingAProperty_ThatIsNotOwned_ThrowsAPropertyNotOwnedException()
        {
            Assert.Throws<PropertyOwnershipManager.PropertyNotOwnedException>(() => propertyOwnershipManager.Mortgage(space));
        }

        [Test]
        public void UnmortgagingAOwnedProperty_ThatIsNotMortagaged_WillThrowANotMortgagedException()
        {
            propertyOwnershipManager.SetOwner(space, fixture.Create<Player>());
            Assert.Throws<PropertyOwnershipManager.PropertyNotMortgagedException>(() => propertyOwnershipManager.Unmortgage(space));        
        }

        [Test]
        public void UnmortgagingAProperty_ThatIsNotOwned_ThrowsAPropertyNotOwnedException()
        {
            Assert.Throws<PropertyOwnershipManager.PropertyNotOwnedException>(() => propertyOwnershipManager.Unmortgage(space));   
        }

        [Test]
        public void UnmortagingAProperty_ThatIsMortgaged_WillUnmortgageTheProperty()
        {
            propertyOwnershipManager.SetOwner(space,player);
            propertyOwnershipManager.Mortgage(space);
            
            propertyOwnershipManager.Unmortgage(space);

            Assert.That(propertyOwnershipManager.IsMortgaged(space), Is.False);
        }
    }
}