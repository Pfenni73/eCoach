using System;
using DBAccessLayer;
using DBAccessLayer.Interfaces;
using LogicLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_eCoach
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BusinessCaseCoachingModel businessCaseCoachingModel = new BusinessCaseCoachingModel();
            Assert.IsNotNull(businessCaseCoachingModel);
        }

        [TestMethod]
        public void TestBusinessCaseCoachingModelSave()
        {
            BusinessCaseCoachingModel businessCaseCoachingModel = new BusinessCaseCoachingModel();
            businessCaseCoachingModel.IdCustomerFk = 5;
            businessCaseCoachingModel.Topic = "Test";
            businessCaseCoachingModel.Save(new DbAccess());
        }
    }
}
