using System;
using System.Collections.Generic;
using System.Linq;

using Monopoly.Core.Players;

namespace Monopoly.Core.Games
{
    public class MathRandomPlayerShuffler : IPlayerShuffler
    {
        private static readonly Random _random;

        static MathRandomPlayerShuffler()
        {
            _random = new Random();
        }

        public IEnumerable<Player> ShufflePlayers(IEnumerable<Player> players)
        {
            return
                players.Select(x => new {Number = _random.Next(), Item = x})
                    .OrderBy(x => x.Number)
                    .Select(x => x.Item)
                    .ToList();
        }
    }
}