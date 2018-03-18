using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class AverageTests
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
        public void Average_Positive_Integers()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 5 },
                { "Number2", 5 },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 5;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Average>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["AverageValue"]);
        }

        [TestMethod]
        public void Average_Negative_Integers()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", -5 },
                { "Number2", -5 },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = -5;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Average>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["AverageValue"]);
        }

        [TestMethod]
        public void Average_Mixed_Integers()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", -5 },
                { "Number2", 5 },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 0;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Average>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["AverageValue"]);
        }

        [TestMethod]
        public void Average_Positive_Doubles()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 5.5m },
                { "Number2", 5 },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 5.25m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Average>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["AverageValue"]);
        }

        [TestMethod]
        public void Average_Positive_Doubles_Without_Rounding()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 5.12435m },
                { "Number2", 5.98678m },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 5.555565m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Average>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["AverageValue"]);
        }

        [TestMethod]
        public void Average_Positive_Doubles_Rounding_2_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 5.12435m },
                { "Number2", 5.98678m },
                { "RoundDecimalPlaces", 2 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 5.56m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Average>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["AverageValue"]);
        }
    }
}