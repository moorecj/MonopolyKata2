using Monopoly.Core.Games;

using Ninject.Modules;

namespace Monopoly.Core.IoC
{
    public class PlayerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILocationManager>().To<PlayerMover>();
        }
    }
}