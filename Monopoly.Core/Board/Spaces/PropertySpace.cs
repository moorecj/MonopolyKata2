using System;

namespace Monopoly.Core.Board.Spaces
{
    public abstract class PropertySpace : Space
    {
        public string Group { get; protected set; }
        public int BaseRent { get; protected set; }
    }
}