using System.Collections.Generic;
using Monopoly.Core.Players;

namespace Monopoly.Core.Games
{
    public interface IGameFactory
    {
        Game Create(IEnumerable<Token> playerTokens);
    }
}