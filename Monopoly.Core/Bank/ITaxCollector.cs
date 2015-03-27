using Monopoly.Core.Players;

namespace Monopoly.Core.Bank
{
    public interface ITaxCollector
    {
        void CollectLuxuryTax(Player player);
        void CollectIncomeTax(Player player);
    }
}