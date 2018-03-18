using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class MultiplyTests
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
        public void Multiply_1_Times_1()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 1 },
                { "Number2", 1 },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 1;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Multiply>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Product"]);
        }

        [TestMethod]
        public void Multiply_1_Times_5()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 1 },
                { "Number2", 5 },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 5;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Multiply>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Product"]);
        }

        [TestMethod]
        public void Multiply_1_Times_5_Point_5_Without_Rounding()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 1 },
                { "Number2", 5.5m },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 5.5m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Multiply>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Product"]);
        }

        [TestMethod]
        public void Multiply_1_Times_Negative_1()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 1 },
                { "Number2", -1 },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = -1;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Multiply>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Product"]);
        }

        [TestMethod]
        public void Multiply_1_Times_Negative_5_Point_5_Without_Rounding()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 1 },
                { "Number2", -5.5m },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = -5.5m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Multiply>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Product"]);
        }

        [TestMethod]
        public void Multiply_1_Times_Negative_5_Point_5_Rounding_2_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 1 },
                { "Number2", -5.555m },
                { "RoundDecimalPlaces", 2 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = -5.56m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Multiply>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Product"]);
        }

        [TestMethod]
        public void Multiply_1_Times_0()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 1 },
                { "Number2", 0 },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 0;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Multiply>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Product"]);
        }
    }
}