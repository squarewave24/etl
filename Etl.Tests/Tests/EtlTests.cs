using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etl.ConsoleApp.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Etl.Tests.Tests
{
    [TestClass]
    public class EtlTests : TestsBase
    {

        [TestMethod]
        public void TestEtlService()
        {
            new EtlService().RunEtlJob(1);
        }
    }
}
