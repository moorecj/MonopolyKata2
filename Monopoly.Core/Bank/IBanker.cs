using Monopoly.Core.Players;

namespace Monopoly.Core.Bank
{
    public interface IBanker
    {
        int GetBalanceFor(Player player);
        void Pay(Player player, int amount);
        void Charge(Player player, int amount);
    }
}