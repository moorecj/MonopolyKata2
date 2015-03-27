using System.Collections.Generic;

using Monopoly.Core.Bank;
using Monopoly.Core.Players;

using NUnit.Framework;

namespace Monopoly.Test.Bank
{
    [TestFixture]
    public class BankerTests
    {
        private Banker banker;
        private Player player1;
        private Player player2;
        private IEnumerable<Player> players;
        private const int InitialBalance = 100;

        [SetUp]
        public void Setup()
        {
            player1 = new Player(Token.Automobile);
            player2 = new Player(Token.Battleship);
            players = new[] { player1, player2 };
            banker = new Banker(players, InitialBalance);
        }

        [Test]
        public void AllPlayerHave_GivenInitialBalance()
        {
            foreach (var player in players)
            {
                Assert.That(banker.GetBalanceFor(player), Is.EqualTo(InitialBalance));
            }  
        }

        [Test]
        public void PayingAPlayer_IncreasesTheirBalance_ByGivenAmount()
        {
            Assert.That(banker.GetBalanceFor(player1), Is.EqualTo(InitialBalance));

            const int payAmount = 10;

            banker.Pay(player1, payAmount);

            Assert.That(banker.GetBalanceFor(player1), Is.EqualTo(InitialBalance+payAmount));
        }

        [Test]
        public void ChargingAPlayer_DecreasesTheirBalance_ByGivenAmount()
        {
            Assert.That(banker.GetBalanceFor(player1), Is.EqualTo(InitialBalance));

            const int chargeAmount = 10;

            banker.Charge(player1, chargeAmount);

            Assert.That(banker.GetBalanceFor(player1), Is.EqualTo(InitialBalance - chargeAmount));
        }
    }
}