using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Etl.ConsoleApp.Util;

namespace Etl
{
    class Program
    {

        static void Main(string[] args) {
            RegisterIoc();

        }


       // adding loose coupling 
        private static void RegisterIoc() {
            Ioc.Container.Register(
                Component.For<ILogger>()
                .ImplementedBy<DebugLogger>()
                );


        }

    }

    // quick and dirty container
    public sealed class Ioc
    {
        private static WindsorContainer _container = new WindsorContainer();
        public static WindsorContainer Container { get { return _container; } }
    }
}
