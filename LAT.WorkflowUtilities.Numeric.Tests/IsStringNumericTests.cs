using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class IsStringNumericTests
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
        public void IsStringNumeric_Integer()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", "5" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IsStringNumeric>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(true, result["IsNumeric"]);
        }

        [TestMethod]
        public void IsStringNumeric_Negative_Integer()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", "-5" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IsStringNumeric>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(true, result["IsNumeric"]);
        }

        [TestMethod]
        public void IsStringNumeric_Long()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", "18446744073709551615" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IsStringNumeric>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(true, result["IsNumeric"]);
        }

        [TestMethod]
        public void IsStringNumeric_Double()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", "1.000" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IsStringNumeric>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(true, result["IsNumeric"]);
        }

        [TestMethod]
        public void IsStringNumeric_Negative_Double()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", "-1.000" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IsStringNumeric>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(true, result["IsNumeric"]);
        }

        [TestMethod]
        public void IsStringNumeric_String()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", "test" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IsStringNumeric>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(false, result["IsNumeric"]);
        }
    }
}