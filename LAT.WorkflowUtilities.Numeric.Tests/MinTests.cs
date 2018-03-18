using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class MinTests
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
        public void Min_Same_Number()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 5 },
                { "Number2", 5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 5;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Min>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["MinValue"]);
        }

        [TestMethod]
        public void Min_Positives()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 15 },
                { "Number2", 5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 5;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Min>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["MinValue"]);
        }

        [TestMethod]
        public void Min_Negatives()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", -5 },
                { "Number2", -15 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = -15;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Min>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["MinValue"]);
        }

        [TestMethod]
        public void Min_Mixed()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 5 },
                { "Number2", -15 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = -15;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Min>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["MinValue"]);
        }
    }
}