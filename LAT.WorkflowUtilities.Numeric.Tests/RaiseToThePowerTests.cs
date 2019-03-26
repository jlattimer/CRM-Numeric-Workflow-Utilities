using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class RaiseToThePowerTests
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
        public void PowerOfZero()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 5 },
                { "PowerNumber", 0 },
                { "RoundDecimalPlaces", -1 }
            };

            var xrmFakedContext = new XrmFakedContext();

            const double expected = 1;
            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RaiseToThePower>(workflowContext, inputs);
            //Assert
            Assert.AreEqual(expected, result["Result"]);
        }

        [TestMethod]
        public void NegativePower()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();
            var inputs = new Dictionary<string, object>
            {
                { "Number", 4 },
                { "PowerNumber", -2},
                { "RoundDecimalPlaces", -1 }
            };
            var xrmFakedContext = new XrmFakedContext();
            const double expected = 0.0625;
            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RaiseToThePower>(workflowContext, inputs);
            //Assert
            Assert.AreEqual(expected, result["Result"]);
        }

        [TestMethod]
        public void PositivePower()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();
            var inputs = new Dictionary<string, object>
            {
                { "Number", -4 },
                { "PowerNumber", 2},
                { "RoundDecimalPlaces", -1 }
            };
            var xrmFakedContext = new XrmFakedContext();
            const double expected = 16;
            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RaiseToThePower>(workflowContext, inputs);
            //Assert
            Assert.AreEqual(expected, result["Result"]);
        }

        [TestMethod]
        public void PositiveNumber()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 4 },
                { "PowerNumber", 2},
                { "RoundDecimalPlaces", -1 }
            };

            var xrmFakedContext = new XrmFakedContext();

            const double expected = 16;
            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RaiseToThePower>(workflowContext, inputs);
            //Assert
            Assert.AreEqual(expected, result["Result"]);
        }

        [TestMethod]
        public void NegativeNumber()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", -4 },
                { "PowerNumber", 3},
                { "RoundDecimalPlaces", -1 }
            };

            var xrmFakedContext = new XrmFakedContext();

            const double expected = -64;
            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RaiseToThePower>(workflowContext, inputs);
            //Assert
            Assert.AreEqual(expected, result["Result"]);
        }

    }
}
