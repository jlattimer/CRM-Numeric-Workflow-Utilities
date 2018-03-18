using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class AbsValueTests
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
        public void AbsValue_Positive_Integer()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                    { "Number", 1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const double expected = 1;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<AbsValue>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["AbsoluteValue"]);
        }

        [TestMethod]
        public void AbsValue_Negative_Integer()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", -6 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const double expected = 6;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<AbsValue>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["AbsoluteValue"]);
        }

        [TestMethod]
        public void AbsValue_Positive_Double()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 3.45 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const double expected = 3.45;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<AbsValue>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["AbsoluteValue"]);
        }

        [TestMethod]
        public void AbsValue_Negative_Double()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", -3.45 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const double expected = 3.45;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<AbsValue>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["AbsoluteValue"]);
        }

        [TestMethod]
        public void AbsValue_Zero()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 0 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const double expected = 0;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<AbsValue>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["AbsoluteValue"]);
        }
    }
}