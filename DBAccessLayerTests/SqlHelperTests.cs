using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccessLayer.Tests
{
    [TestClass()]
    public class SqlHelperTests
    {
        [TestMethod()]
        public void GetSqlStringTest()
        {
            int? testInput = null;
            Assert.AreEqual("null", SqlHelper.GetSqlString(testInput));
        }
    }
}