using Ninject;
using Ninject.MockingKernel.Moq;

namespace Monopoly.Test.IoC
{
    public static class NinjectKernelFactory
    {
        public static IKernel CreateStandardIntegrationKernel()
        {
            using (var integrationTestsModule = new TestModule())
            {
                return new StandardKernel(new NinjectSettings(), integrationTestsModule);
            }
        }

        public static IKernel CreateMockingIntegrationKernel()
        {
            using (var integrationTestsModule = new TestModule())
            {
                return new MoqMockingKernel(new NinjectSettings(), integrationTestsModule);
            }
        }
    } 
}
