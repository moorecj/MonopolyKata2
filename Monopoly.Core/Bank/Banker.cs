using System.Collections.Generic;

using Monopoly.Core.Players;

namespace Monopoly.Core.Bank
{
    public class Banker : IBanker
    {
        private readonly Dictionary<Player, int> balances;

        public Banker(IEnumerable<Player> players, int initialBalance = 1500)
        {
            balances = new Dictionary<Player, int>();

            foreach (var player in players)
                balances.Add(player, initialBalance);
        }

        public int GetBalanceFor(Player player)
        {
            return balances[player];
        }

        public void Pay(Player player, int amount)
        {
            balances[player] += amount;
        }

        public void Charge(Player player, int amount)
        {
            balances[player] -= amount;
        }
    }
}