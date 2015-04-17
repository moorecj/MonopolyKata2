using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Extensions;
using Monopoly.Core.Players;

namespace Monopoly.Core.Bank.Properties
{
    public class PropertyManager
    {
        private readonly List<PropertyOwnership> propertyOwnerships;

        public PropertyManager()
        {
            propertyOwnerships = new List<PropertyOwnership>();
        }

        public Player GetOwner(PropertySpace property)
        {
            var ownership = GetOwnership(property);
 
            return ownership.Owner;
        }

        public bool IsMortgaged(PropertySpace property)
        {
            var ownership = GetOwnership(property);

            return ownership.IsMortgaged;
        }

        private PropertyOwnership GetOwnership(PropertySpace property)
        {
            return propertyOwnerships.FirstOrDefault(p => p.Space.Equals(property));
        }

        public void SetOwner(PropertySpace property, Player buyer)
        {
            if (GetOwnership(property).Owner != null)
                throw new PropertyAlreadyOwnedException("This property is already owned");

            propertyOwnerships.Add(new PropertyOwnership(buyer, property));
        }

        public void Mortgage(PropertySpace property)
        {
            var ownership = GetOwnership(property);

            if (ownership.IsMortgaged)
                throw new PropertyAlreadyMortgagedException("This prooperty is already mortgaged.");
            
            if (ownership.Owner == null) 
                throw new PropertyNotOwnedException("This property is not owned");

            propertyOwnerships.Replace(ownership,
                new PropertyOwnership(ownership.Owner, ownership.Space) {IsMortgaged = true});
        }

        public void Unmortgage(PropertySpace property)
        {
            var ownership = GetOwnership(property);

            if (ownership.Owner == null)
                throw new PropertyNotOwnedException("This property is not owned");

            if (ownership.IsMortgaged == false)
                throw new PropertyNotMortgagedException("This prooperty is not mortgaged.");

            propertyOwnerships.Replace(ownership,
                new PropertyOwnership(ownership.Owner, ownership.Space) { IsMortgaged = false });
        }

        private struct PropertyOwnership
        {
            public PropertySpace Space { get; private set; }
            public Player Owner { get; private set; }
            public Boolean IsMortgaged { get; set; }

            public PropertyOwnership(Player owner, PropertySpace space) : this()
            {
                Owner = owner;
                Space = space;
                IsMortgaged = false;
            }
        }

        [Serializable]
        public class PropertyAlreadyOwnedException : Exception
        {
            public PropertyAlreadyOwnedException()
            {
            }

            public PropertyAlreadyOwnedException(string message) : base(message)
            {
            }

            public PropertyAlreadyOwnedException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected PropertyAlreadyOwnedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        [Serializable]
        public class PropertyNotOwnedException : Exception
        {
            public PropertyNotOwnedException()
            {
            }

            public PropertyNotOwnedException(string message)
                : base(message)
            {
            }

            public PropertyNotOwnedException(string message, Exception innerException)
                : base(message, innerException)
            {
            }

            protected PropertyNotOwnedException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }

        [Serializable]
        public class PropertyAlreadyMortgagedException : Exception
        {
            public PropertyAlreadyMortgagedException()
            {
            }

            public PropertyAlreadyMortgagedException(string message)
                : base(message)
            {
            }

            public PropertyAlreadyMortgagedException(string message, Exception innerException)
                : base(message, innerException)
            {
            }

            protected PropertyAlreadyMortgagedException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }

        [Serializable]
        public class PropertyNotMortgagedException : Exception
        {
            public PropertyNotMortgagedException()
            {
            }

            public PropertyNotMortgagedException(string message)
                : base(message)
            {
            }

            public PropertyNotMortgagedException(string message, Exception innerException)
                : base(message, innerException)
            {
            }

            protected PropertyNotMortgagedException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }



    }
}