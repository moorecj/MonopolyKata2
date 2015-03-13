using System.Collections.Generic;

using Monopoly.Core.Board;
using Monopoly.Core.Players;

namespace Monopoly.Core
{
    public class PlayerMover : ILocationManager
    {
        private readonly Dictionary<Player, int> locations;
        private readonly int boardSize;
        private readonly IBoard board;

        public PlayerMover(IEnumerable<Player> players, IBoard board)
        {
            this.board = board;
            this.boardSize = board.Size;
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
            var startingLocation = locations[player];
            var endLocation = (locations[player] + number) % boardSize;
            board.HandleMove(player, startingLocation, endLocation);

            locations[player] = endLocation;
        }

        public void MoveTo(Player player, int location)
        {
            locations[player] = location;
            
            board.HandleMoveTo(player, location);
        }
    }
}