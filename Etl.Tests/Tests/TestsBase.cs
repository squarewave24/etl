using System.Data;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Etl.ConsoleApp;
using Etl.ConsoleApp.Util;

namespace Etl.Tests
{
    public class TestsBase
    {
         static TestsBase()
        {
            RegisterIoc();  // this way we can see full logs when running tests 
        }

        // adding loose coupling 
        private static void RegisterIoc() {
            Ioc.Container.Register(
                Component.For<ILogger>()
                .ImplementedBy<DebugLogger>()
                );


        }
        protected T Resolve<T>()
        {
            return Ioc.Container.Resolve<T>();
        }

        protected void LogTableContents(DataTable dt) {
            foreach (DataRow dataRow in dt.Rows) {
                var sb = new StringBuilder();
                foreach (var item in dataRow.ItemArray) {
                    sb.Append($"{item}|");
                }
                Resolve<ILogger>().Info(sb.ToString());
            }
        }

    }

    
}

