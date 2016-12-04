using System;
using System.Data;
using System.Text;
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
            DataTable dt = CsvExtractor.GetDataTableFromCsv("./files/sampledata.csv", true);
            Assert.IsNotNull(dt);
            LogTableContents(dt);
            Assert.IsTrue(dt.Rows.Count == 4, $"Expected 4 got {dt.Rows.Count}");
            
        }


        
    }
}
