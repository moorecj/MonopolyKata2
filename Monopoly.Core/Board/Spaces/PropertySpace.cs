using System;

namespace Monopoly.Core.Board.Spaces
{
    public class PropertySpace : Space
    {
        public string Group { get; set; }
        public int BaseRent { get; set; }
        public int Price { get; set; }
    }

}