using System.Collections.Generic;
using System.Data;
using System.Linq;
using Etl.ConsoleApp.Framework;
using Etl.ConsoleApp.Tasks;
using Etl.ConsoleApp.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Etl.Tests
{
    [TestClass]
    public class TaskTests : TestsBase
    {
        // All tricky implementation  started by getting it to work in tests first to save time. 

        [TestMethod]
        public void TestLoader() {
            
        }
        [TestMethod]
        public void TestCsvExtractor()
        {
            var dt = CsvExtractor.GetDataTableFromCsv("./files/sampledata.csv", true);
            Assert.IsNotNull(dt);
            LogTableContents(dt);

            Assert.IsTrue(dt.Rows.Count == 4, $"Expected 4 got {dt.Rows.Count}");

            foreach (var c in dt.Columns)
                Resolve<ILogger>().Info("co: {0}", (c as DataColumn).ColumnName);

            Assert.IsTrue(dt.Columns[0].ColumnName == "Make", $"Expected Make got {dt.Columns[0].ColumnName}");
            
        }


        [TestMethod]
        public void TestSqlLoader()
        {
            var dt = CsvExtractor.GetDataTableFromCsv("./files/sampledata.csv", true);
            new SqlLoader(1).OnLoad(dt);
        }


        [TestMethod]
        public void TestConfig()
        {
            dynamic config = EtlTask.ParseConfig();
            Assert.IsNotNull(config);
            Assert.IsNotNull(config.jobs);
            Assert.IsNotNull(config.jobs as IEnumerable<dynamic>);

            var j = (config.jobs as IEnumerable<dynamic>).First();
            Assert.IsNotNull(j.jobId);

        }



    }
}
