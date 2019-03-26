using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class NthRootTests
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
        public void SquareRoot()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 25 },
                { "RootNumber", 2 },
                { "RoundDecimalPlaces", -1 }
            };

            var xrmFakedContext = new XrmFakedContext();

            const double expected = 5;
            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<NthRoot>(workflowContext, inputs);
            //Assert
            Assert.AreEqual(expected, result["Result"]);
        }

        [TestMethod]
        public void PositveNumber()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 8 },
                { "RootNumber", 3 },
                { "RoundDecimalPlaces", -1 }
            };

            var xrmFakedContext = new XrmFakedContext();

            const double expected = 2;
            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<NthRoot>(workflowContext, inputs);
            //Assert
            Assert.AreEqual(expected, result["Result"]);
        }

        [TestMethod]
        public void PositveRootNumber()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 27 },
                { "RootNumber", 3 },
                { "RoundDecimalPlaces", -1 }
            };

            var xrmFakedContext = new XrmFakedContext();

            const double expected = 3;
            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<NthRoot>(workflowContext, inputs);
            //Assert
            Assert.AreEqual(expected, result["Result"]);
        }

        [TestMethod]
        public void ZeroNumber()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 0 },
                { "RootNumber", 3 },
                { "RoundDecimalPlaces", -1 }
            };

            var xrmFakedContext = new XrmFakedContext();

            const double expected = 0;
            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<NthRoot>(workflowContext, inputs);
            //Assert
            Assert.AreEqual(expected, result["Result"]);
        }


        [TestMethod]
        public void ZeroRootNumber()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 3 },
                { "RootNumber", 0 },
                { "RoundDecimalPlaces", -1 }
            };

            var xrmFakedContext = new XrmFakedContext();

            const double expected = double.PositiveInfinity;
            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<NthRoot>(workflowContext, inputs);
            //Assert
            Assert.AreEqual(expected, result["Result"]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException), "Number under the radical must be positive.")]
        public void NegativeNumber()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", -2 },
                { "RootNumber", 3 },
                { "RoundDecimalPlaces", -1 }
            };

            var xrmFakedContext = new XrmFakedContext();

            //Act
            xrmFakedContext.ExecuteCodeActivity<NthRoot>(workflowContext, inputs);
        }

        [TestMethod]
        public void NegativeRootNumber()
        {
            //Arrange
            var workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 4},
                { "RootNumber", -2 },
                { "RoundDecimalPlaces", 2 }
            };

            var xrmFakedContext = new XrmFakedContext();
            const double expected = 0.5;
            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<NthRoot>(workflowContext, inputs);
            //Assert          
            Assert.AreEqual(expected, result["Result"]);
        }


    }
}
