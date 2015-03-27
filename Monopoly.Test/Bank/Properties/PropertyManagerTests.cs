using Monopoly.Core.Bank.Properties;
using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

using Moq;

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
            space = new Mock<PropertySpace>().Object;
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
    }
}