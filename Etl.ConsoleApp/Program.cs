using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Etl.ConsoleApp;
using Etl.ConsoleApp.Framework;
using Etl.ConsoleApp.Util;

namespace Etl
{
    class Program
    {

        static void Main(string[] args) {

            // adding IOC to provie loose coupling. implemented only for logger but could be implemented by etl services/tasks 
            Ioc.RegisterIoc();

            var etlJobId = 1; // this corresponds to a job in files/etl.jobs.json  

            // basd on ID, the servie should be able to use appropriate config data
            new EtlService().RunEtlJob(etlJobId);

            /* 
               Tasks/       - concrete implementation
               Framework/   - Etl Framework
               files/       - etl job configuratio, and source csv 
            */

            //     ctrl+f5 => output should look like this (or show any issues)
            /*
            INFO: CsvExtractor starting
            INFO: CsvExtractor finished in 0.216203 seconds
            INFO: SqlLoader starting
            INFO: SqlLoader finished in 0.052604 seconds
            */
        }
    }
}
