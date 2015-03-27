using System.Collections.Generic;
using System.Linq;

using Monopoly.Core.Players;

using Moq;

using NUnit.Framework;

namespace Monopoly.Test.Players
{
    [TestFixture]
    public class JailerTests
    {
        private Jailer jailer;

        [SetUp]
        public void SetUp()
        {
            jailer = new Jailer();
        }

        [Test]
        public void HasPrisoner_WhenPlayerIsNull_ReturnsFalse()
        {
            Assert.That(jailer.HasPrisoner(null), Is.False);
        }

        [Test]
        public void HasPrisoner_WhenNoOneInJail_ReturnsFalse()
        {
            Assert.That(jailer.HasPrisoner(It.IsAny<Player>()), Is.False);
        }

        [Test]
        [TestCaseSource("AllPlayers")]
        public void HasPrisoner_WhenSomeoneIsJailed_ReturnsTrue(Player player)
        {
            jailer.LockUp(player);

            Assert.That(jailer.HasPrisoner(player));
        }

        [Test]
        [TestCaseSource("AllPlayers")]
        public void HasPrisoner_WhenThePlayerHasJustBeenReleased_ReturnsFalse(Player player)
        {
            jailer.LockUp(player);
            Assert.That(jailer.HasPrisoner(player));

            jailer.Release(player);

            Assert.That(jailer.HasPrisoner(player), Is.False);
        }

        [Test]
        public void HasPrisoner_WhenPlayerOneOfMultiplePrisoners_ReturnsTrue()
        {
            var allPlayers = AllPlayers().ToList();
            allPlayers.ForEach(p => jailer.LockUp(p));

            var player1 = allPlayers.First();

            Assert.That(jailer.HasPrisoner(player1));
        }

        [Test]
        [TestCaseSource("AllPlayers")]
        public void LockUp_WhenPlayerIsAlreadyJailed_ThrowsAPlayerAlreadyJailedException(Player player)
        {
            jailer.LockUp(player);

            Assert.Throws<Jailer.PlayerAlreadyJailedException>(() => jailer.LockUp(player));
        }

        [Test]
        [TestCaseSource("AllPlayers")]
        public void Release_WhenPlayerIsNotJailed_ThrowsAPlayerNotJailedException(Player player)
        {
            Assert.Throws<Jailer.PlayerNotJailedException>(() => jailer.Release(player));
        }

        [Test]
        [TestCaseSource("AllPlayers")]
        public void Release_WhenMultiplePrisoners_LeavesOtherPrisonersLockedUp(Player player)
        {
            var otherPlayers = AllPlayers().Where(p => p.Equals(player) == false).ToList();
            otherPlayers.ForEach(p => jailer.LockUp(p));
            jailer.LockUp(player);

            jailer.Release(player);

            Assert.That(jailer.HasPrisoner(player), Is.False);
            otherPlayers.ForEach(p => Assert.That(jailer.HasPrisoner(p)));
        }

        private static IEnumerable<Player> AllPlayers()
        {
            return from object token in System.Enum.GetValues(typeof(Token)) select new Player((Token)token);
        }
    }
}