using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class ToDecimalTests
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
        public void ToDecimal_10()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "TextToConvert", "10" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected1 = true;
            const decimal expected2 = 10m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ToDecimal>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected1, result["IsValid"]);
            Assert.AreEqual(expected2, result["ConvertedNumber"]);
        }

        [TestMethod]
        public void ToDecimal_10_Point_89()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "TextToConvert", "10.89" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected1 = true;
            const decimal expected2 = 10.89m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ToDecimal>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected1, result["IsValid"]);
            Assert.AreEqual(expected2, result["ConvertedNumber"]);
        }

        [TestMethod]
        public void ToDecimal_Negative_10_Point_89()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "TextToConvert", "-10.89" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected1 = true;
            const decimal expected2 = -10.89m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ToDecimal>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected1, result["IsValid"]);
            Assert.AreEqual(expected2, result["ConvertedNumber"]);
        }

        [TestMethod]
        public void ToDecimal_Invalid()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "TextToConvert", "10d" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected1 = false;
            const decimal expected2 = 0m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ToDecimal>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected1, result["IsValid"]);
            Assert.AreEqual(expected2, result["ConvertedNumber"]);
        }

        [TestMethod]
        public void ToDecimal_Empty_String()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "TextToConvert", "" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected1 = false;
            const decimal expected2 = 0m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ToDecimal>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected1, result["IsValid"]);
            Assert.AreEqual(expected2, result["ConvertedNumber"]);
        }

        [TestMethod]
        public void ToDecimal_Null()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "TextToConvert", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected1 = false;
            const decimal expected2 = 0m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ToDecimal>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected1, result["IsValid"]);
            Assert.AreEqual(expected2, result["ConvertedNumber"]);
        }
    }
}