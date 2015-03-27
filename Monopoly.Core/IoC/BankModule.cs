using Monopoly.Core.Bank;

using Ninject.Modules;

namespace Monopoly.Core.IoC
{
    public class BankModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBanker>().To<Banker>();
            Bind<ITaxCollector>().To<TaxCollector>();
        }
    }
}