using Monopoly.Core.Board;
using Monopoly.Core.Events.Handlers;

using Ninject.Modules;

namespace Monopoly.Core.IoC
{
    public class SpaceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBoardFactory>().To<BoardFactory>();
            Bind<GoHandler>().ToSelf();
        }
    }
}