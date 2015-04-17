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
        private PropertyManager propertyManager;
        private Fixture fixture;
        private Player player;
        private PropertySpace space;

        [SetUp]
        public void Setup()
        {
            propertyManager = new PropertyManager();
            fixture = new Fixture();
            player = fixture.Create<Player>();
            space = fixture.Create<PropertySpace>();
        }

        [Test]
        public void GetOwner_WhenThePropertyIsNotOwned_ReturnsNull()
        {
            Assert.That(propertyManager.GetOwner(space), Is.Null);
        }

        [Test]
        public void GetOwner_WhenThePropertyIsOwned_ReturnsTheOwner()
        {
            propertyManager.SetOwner(space, player);

            Assert.That(propertyManager.GetOwner(space), Is.EqualTo(player));
        }

        [Test]
        public void SetOwner_WhenTheSpaceIsOwned_ThrowsASpaceAlreadyOwnedException()
        {
            propertyManager.SetOwner(space, fixture.Create<Player>());
            Assert.Throws<PropertyManager.PropertyAlreadyOwnedException>(() => propertyManager.SetOwner(space, player));
        }

        [Test]
        public void SetOwner_WhenThePropertyIsNotOwned_SetsTheOwner()
        {
            Assert.That(propertyManager.GetOwner(space), Is.Null);
            
            propertyManager.SetOwner(space, player);

            Assert.That(propertyManager.GetOwner(space), Is.EqualTo(player));
        }

        [Test]
        public void MortagingAProperty_ThatIsNotAlreadyMortaged_WillMortageTheProperty()
        {
            propertyManager.SetOwner(space, player);
            Assert.That(propertyManager.IsMortgaged(space), Is.False);

            propertyManager.Mortgage(space);

            Assert.That(propertyManager.IsMortgaged(space), Is.True); 
        }

        [Test]
        public void MortgagingAProperty_WhenthePropertyIsAlreadyMortgaged_ThrowsAPropertyAlreadyMortgagedException()
        {
            propertyManager.SetOwner(space, fixture.Create<Player>());
            propertyManager.Mortgage(space);

            Assert.Throws<PropertyManager.PropertyAlreadyMortgagedException>(() => propertyManager.Mortgage(space));
        }

        [Test]
        public void MortgagingAProperty_ThatIsNotOwned_ThrowsAPropertyNotOwnedException()
        {
            Assert.Throws<PropertyManager.PropertyNotOwnedException>(() => propertyManager.Mortgage(space));
        }

        [Test]
        public void UnmortgagingAOwnedProperty_ThatIsNotMortagaged_WillThrowANotMortgagedException()
        {
            propertyManager.SetOwner(space, fixture.Create<Player>());
            Assert.Throws<PropertyManager.PropertyNotMortgagedException>(() => propertyManager.Unmortgage(space));        
        }

        [Test]
        public void UnmortgagingAProperty_ThatIsNotOwned_ThrowsAPropertyNotOwnedException()
        {
            Assert.Throws<PropertyManager.PropertyNotOwnedException>(() => propertyManager.Unmortgage(space));   
        }

        [Test]
        public void UnmortagingAProperty_ThatIsMortgaged_WillUnmortgageTheProperty()
        {
            propertyManager.SetOwner(space,player);
            propertyManager.Mortgage(space);
            
            propertyManager.Unmortgage(space);

            Assert.That(propertyManager.IsMortgaged(space), Is.False);
        }
    }
}