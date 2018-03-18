using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class RandomNumberBetweenTests
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
        public void RandomNumberBetween_Same_Numbers()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "MinValue", 2 },
                { "MaxValue", 2 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const int expected = 2;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RandomNumberBetween>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, (int)result["GeneratedNumber"]);
        }

        [TestMethod]
        public void RandomNumberBetween_Negative_And_Positive()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "MinValue", -2 },
                { "MaxValue", 1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RandomNumberBetween>(workflowContext, inputs);

            //Assert
            Assert.IsTrue((int)result["GeneratedNumber"] >= 0 && (int)result["GeneratedNumber"] <= 1);
        }

        [TestMethod]
        public void RandomNumberBetween_1_And_Negative_1()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "MinValue", 1 },
                { "MaxValue", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const int expected = 1;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RandomNumberBetween>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, (int)result["GeneratedNumber"]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException), "Max Value must be greater than Min Value.")]
        public void RandomNumberBetween_5_And_2()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "MinValue", 5 },
                { "MaxValue", 2 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            xrmFakedContext.ExecuteCodeActivity<RandomNumberBetween>(workflowContext, inputs);
        }

        [TestMethod]
        public void RandomNumberBetween_1_And_3()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "MinValue", 1 },
                { "MaxValue", 3 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RandomNumberBetween>(workflowContext, inputs);

            //Assert
            Assert.IsTrue((int)result["GeneratedNumber"] >= 1 && (int)result["GeneratedNumber"] <= 3);
        }
    }
}