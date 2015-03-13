using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Monopoly.Core.Players
{
    public class Jailer : IJailer
    {
        private readonly List<Player> detainees;

        public Jailer()
        {
            detainees = new List<Player>();
        }

        public void LockUp(Player player)
        {
            if (HasPrisoner(player))
                throw new PlayerAlreadyJailedException();

            detainees.Add(player);
        }

        public void Release(Player player)
        {
            if (HasPrisoner(player) == false) 
                throw new PlayerNotJailedException();
            
            detainees.Remove(player);
        }

        public bool HasPrisoner(Player player)
        {
            return detainees.Contains(player);
        }

        #region Excetpions

        [Serializable]
        public class PlayerAlreadyJailedException : Exception
        {
            public PlayerAlreadyJailedException()
            {
            }

            public PlayerAlreadyJailedException(string message) : base(message)
            {
            }

            public PlayerAlreadyJailedException(string message, Exception innerException)
                : base(message, innerException)
            {
            }

            protected PlayerAlreadyJailedException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }

        [Serializable]
        public class PlayerNotJailedException : Exception
        {
            public PlayerNotJailedException()
            {
            }

            public PlayerNotJailedException(string message) : base(message)
            {
            }

            public PlayerNotJailedException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected PlayerNotJailedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        #endregion
    }
}