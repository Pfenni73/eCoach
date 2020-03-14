using System;
using DBAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDBAccessLayer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetSqlStringWithNullInt()
        {
            int? testInput = null;
            Assert.AreEqual("null", SqlHelper.GetSqlString(testInput));
        }
    }
}
