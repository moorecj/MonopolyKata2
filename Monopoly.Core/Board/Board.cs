using System.Collections.Generic;
using System.Linq;

using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Extensions;
using Monopoly.Core.Players;

namespace Monopoly.Core.Board
{
    public class Board : IBoard
    {
        private readonly Dictionary<int, Space> spaces;

        public Board(Dictionary<int, Space> spaces)
        {
            this.spaces = spaces;
        }

        public int Size { get { return spaces.Count; } }

        public void HandleMoveTo(Player player, int location)
        {
            HandleLandedOn(player, spaces[location]);
        }

        public void HandleMove(Player player, int start, int end)
        {
            var inRange = GetSpaceInRange(start, end);
            var pasedOver = inRange as IList<Space> ?? inRange.ToList();

            if (pasedOver.Any())
                HandlePassedOverSpaces(player, pasedOver);

            HandleLandedOn(player, spaces[end]);
        }

        private static void HandlePassedOverSpaces(Player player, IEnumerable<Space> spaces)
        {
            foreach (
                var passedOver in
                    from space in spaces let passedOver = space as INotifyPassedOver where passedOver != null select passedOver)
            {
                passedOver.RaisePassedOver(player);
            }
        }

        private static void HandleLandedOn(Player player, Space space)
        {
            space.RaiseLandedOn(player);
        }

        public Space GetSpaceAt(int location)
        {
            return spaces[location];
        }

        public IEnumerable<Space> GetSpaceInRange(int start, int end, bool inclusive = true)
        {
            return end < start
                ? (spaces.Where(s => s.Key > start).Concat(spaces.Where(s => s.Key < end))).Select(s => s.Value)
                : spaces.Where(s => s.Key.IsBetween(start, end, inclusive)).Select(s => s.Value);
        }
    }
}