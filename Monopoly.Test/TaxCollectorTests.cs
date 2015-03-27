using System;

using Monopoly.Core.Bank;
using Monopoly.Core.Players;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

namespace Monopoly.Test
{
    [TestFixture]
    public class TaxCollectorTests
    {
        private TaxCollector taxCollector;
        private Mock<IBanker> mockBanker;
        private Fixture fixture;
        private Player player;

        [SetUp]
        public void Setup()
        {
            mockBanker = new Mock<IBanker>();
            fixture = new Fixture();
            taxCollector = new TaxCollector(mockBanker.Object);
            player = fixture.Create<Player>();
        }

        [Test]
        public void CollectLuxuryTax_GivenANullPlayer_ShouldThrowAnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => taxCollector.CollectLuxuryTax(null));
        }

        [Test]
        public void CollectLuxuryTax_GivenAValidPlayer_ChargersThatPlayer75()
        {
            mockBanker.Setup(x => x.Charge(player,75)).Verifiable();

            taxCollector.CollectLuxuryTax(player);

            mockBanker.Verify();
        }

        [Test]
        public void CollectIncomeTax_GivenANullPlayer_ShouldThrowAnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => taxCollector.CollectIncomeTax(null));
        }

        [Test]
        public void CollectIncomeTax_WhenPlayerIsWorthLessThan2000_ChargesThem10Percent()
        {
            const int playerBalance = 1000;
            mockBanker.Setup(x => x.GetBalanceFor(player)).Returns(playerBalance);
            mockBanker.Setup(x => x.Charge(player, playerBalance / 10)).Verifiable();

            taxCollector.CollectIncomeTax(player);

            mockBanker.Verify();
        }

        [Test]
        public void CollectIncomeTax_WhenPlayerIsWorthMoreThan2000_ChargesThem200()
        {
            const int playerBalance = 2100;
            mockBanker.Setup(x => x.GetBalanceFor(player)).Returns(playerBalance);
            mockBanker.Setup(x => x.Charge(player, 200)).Verifiable();

            taxCollector.CollectIncomeTax(player);

            mockBanker.Verify();
        }
    }
}