using System.Collections.Generic;

using Monopoly.Core.Board;
using Monopoly.Core.Players;

namespace Monopoly.Core
{
    public class PlayerLocationManager : ILocationManager
    {
        private readonly Dictionary<Player, int> locations;
        private readonly IBoard board;

        public PlayerLocationManager(IEnumerable<Player> players, IBoard board)
        {
            this.board = board;
            locations = new Dictionary<Player, int>();

            foreach (var player in players)
                locations.Add(player, 0);
        }

        public int GetLocation(Player player)
        {
            return locations[player];
        }

        public void Move(Player player, int number)
        {
            var endLocation = board.GetMove(player, locations[player], number);

            locations[player] = endLocation;
        }

        public void MoveTo(Player player, int location)
        {
            locations[player] = board.GetMove(player, location, 0);
        }
    }
}