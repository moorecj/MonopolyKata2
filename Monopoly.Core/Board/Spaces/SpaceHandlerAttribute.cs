using System;

namespace Monopoly.Core.Board.Spaces
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SpaceHandlerAttribute : Attribute
    {
        public Type SpaceType { get; private set; }

        public SpaceHandlerAttribute(Type spaceType)
        {
            SpaceType = spaceType;
        }
    }
}