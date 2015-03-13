namespace Monopoly.Core.Players
{
    public class Player
    {
        public Token Token { get; private set; }

        public Player(Token token)
        {
            Token = token;
        }

        protected bool Equals(Player other)
        {
            return Token == other.Token;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            return (int) Token;
        }
    }
}