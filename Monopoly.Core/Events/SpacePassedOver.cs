using Monopoly.Core.Players;

namespace Monopoly.Core.Events
{
    public sealed class SpacePassedOver : IEvent
    {
        public Player Player { get; set; }
    }
}