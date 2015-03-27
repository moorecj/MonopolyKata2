using System;

using Monopoly.Core.Players;

namespace Monopoly.Core.Bank
{
    public class TaxCollector : ITaxCollector
    {
        private readonly IBanker banker;

        public TaxCollector(IBanker banker)
        {
            this.banker = banker;
        }

        public void CollectLuxuryTax(Player player)
        {
            CheckPlayerNotNull(player);

            const int luxuryTaxAmount = 75;

            banker.Charge(player, luxuryTaxAmount);
        }

        public void CollectIncomeTax(Player player)
        {
            CheckPlayerNotNull(player);

            var balance = banker.GetBalanceFor(player);
            var charge = balance > 2000 ? 200 : balance/10;

            banker.Charge(player, charge);
        }

        private static void CheckPlayerNotNull(Player player)
        {
            if (ReferenceEquals(player, null))
                throw new ArgumentNullException("Player cannot be null");
        }
    }
}