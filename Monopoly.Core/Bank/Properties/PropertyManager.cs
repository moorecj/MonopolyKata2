using System;
using System.Collections.Generic;

using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

namespace Monopoly.Core.Bank.Properties
{
    public class PropertyManager
    {
        private List<PropertyOwnership> propertyOwnerships;

        public Player GetOwner(PropertySpace property)
        {
            return null;
        }

        public bool IsMortgaged(PropertySpace property)
        {
            throw new NotImplementedException();
        }

        public void SetOwner(PropertySpace property, Player buyer)
        {
            throw new NotImplementedException();
        }

        public void Mortgage(PropertySpace property)
        {
            throw new NotImplementedException();
        }

        private struct PropertyOwnership
        {
            private PropertySpace space;
            private Player owner;
        }
    }
}