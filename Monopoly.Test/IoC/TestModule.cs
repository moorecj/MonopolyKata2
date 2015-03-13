using Monopoly.Core.Games;

using Ninject.Modules;

namespace Monopoly.Test.IoC
{
    public class TestModule : NinjectModule
    {
        public override void Load()
        {
            var gameAssembly = typeof(Game).Assembly;

            Kernel.Load(new[] { gameAssembly });
        }
    }
}