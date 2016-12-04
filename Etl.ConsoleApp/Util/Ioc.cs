using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Etl.ConsoleApp.Util;

namespace Etl.ConsoleApp
{
    // quick and dirty container
    public sealed class Ioc
    {
        private static WindsorContainer _container = new WindsorContainer();
        public static WindsorContainer Container { get { return _container; } }

        public static void RegisterIoc() {
            Container.Register(
                Component.For<ILogger>()
                .ImplementedBy<DebugLogger>()
                );
        }
    }
}
