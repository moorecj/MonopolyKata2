using Monopoly.Core.Bank;
using Monopoly.Core.Bank.Properties;
using Monopoly.Core.Bank.Properties.Decorators;

using Ninject.Modules;

namespace Monopoly.Core.IoC
{
    public class BankModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBanker>().To<Banker>();
            Bind<ITaxCollector>().To<TaxCollector>();

            Bind<IPropertyOwnershipManager>().To<PropertyOwnershipManager>();

            Bind<IRealtor>().To<ValidatesOwnershipRealtor>();
            Bind<IRealtor>().To<ValidatesBalanceRealtor>().WhenInjectedInto<ValidatesOwnershipRealtor>();
            Bind<IRealtor>().To<Realtor>().WhenInjectedInto<ValidatesBalanceRealtor>();
        }
    }
}