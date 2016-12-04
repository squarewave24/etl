using System;
using System.Data;
using Etl.ConsoleApp.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Etl.Tests
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void TestLoader() {
            
        }
        [TestMethod]
        public void TestCsvExtractor()
        {
            DataTable dt = CsvExtractor.GetDataTableFromCsv("./files/sampledata.csv", true);
            Assert.IsNotNull(dt);
            Assert.IsTrue(dt.Rows.Count == 4, $"Expected 4 got {dt.Rows.Count}");
            
        }
    }
}
