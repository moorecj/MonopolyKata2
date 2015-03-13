using Monopoly.Core.Players;

namespace Monopoly.Core.Events
{
    public sealed class SpaceLandedOn : IEvent
    {
        public Player Player{get; set; }
            
    }
}