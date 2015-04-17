using Monopoly.Core.Events;
using Monopoly.Core.Players;

namespace Monopoly.Core.Board.Spaces
{
    public abstract class Space : INotifyLandedOn
    {
        public string Name { get; set; }

        public event NotifyLandedOn LandedOn;

        public virtual void RaiseLandedOn(Player player)
        {
            var handler = this.LandedOn;

            if (handler != null)
                handler(this, new NotifyLandedOnEventArgs(player));
        }

        protected bool Equals(Space other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Space) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}