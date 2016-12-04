using System.Data;
using Etl.ConsoleApp.Tasks;
using Etl.ConsoleApp.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Etl.Tests
{
    [TestClass]
    public class TaskTests : TestsBase
    {
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
            new SqlLoader().Load(dt);

        }



    }
}
