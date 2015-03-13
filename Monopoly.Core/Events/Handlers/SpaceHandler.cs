using Monopoly.Core.Board.Spaces;

namespace Monopoly.Core.Events.Handlers
{
    public abstract class SpaceHandler<TSpace> where TSpace : Space
    {
        protected TSpace Space;
    }
}