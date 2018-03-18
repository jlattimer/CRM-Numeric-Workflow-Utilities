using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class RandomNumbersTests
    {
        #region Test Initialization and Cleanup
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext) { }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void ClassCleanup() { }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void TestMethodInitialize() { }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestMethodCleanup() { }
        #endregion

        [TestMethod]
        public void RandomNumbers_Negative_5_Max()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "MaxValue", -5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RandomNumber>(workflowContext, inputs);

            //Assert
            Assert.IsTrue((int)result["GeneratedNumber"] < 1);
        }

        [TestMethod]
        public void RandomNumbers_0_Max()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "MaxValue", 0 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RandomNumber>(workflowContext, inputs);

            //Assert
            Assert.IsTrue((int)result["GeneratedNumber"] < 1);
        }

        [TestMethod]
        public void RandomNumbers_5_Max()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "MaxValue", 5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RandomNumber>(workflowContext, inputs);

            //Assert
            Assert.IsTrue((int)result["GeneratedNumber"] < 5);
        }

        [TestMethod]
        public void RandomNumbers_50000_Max()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "MaxValue", 50000 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RandomNumber>(workflowContext, inputs);

            //Assert
            Assert.IsTrue((int)result["GeneratedNumber"] < 50000);
        }
    }
}