using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class DivideTests
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
        public void Divide_1_By_1()
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
            var result = xrmFakedContext.ExecuteCodeActivity<Divide>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Quotient"]);
        }

        [TestMethod]
        public void Divide_1_By_5()
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

            const decimal expected = .2m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Divide>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Quotient"]);
        }

        [TestMethod]
        public void Divide_5_By_5_Point_5_Without_Rounding()
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

            const decimal expected = 0.1818181818181818181818181818m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Divide>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Quotient"]);
        }

        [TestMethod]
        public void Divide_5_By_5_Point_5_Rounding_2_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 1 },
                { "Number2", 5.5m },
                { "RoundDecimalPlaces", 2 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 0.18m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Divide>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Quotient"]);
        }

        [TestMethod]
        public void Divide_By_Negative_5()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 1 },
                { "Number2", -5 },
                { "RoundDecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = -.2m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Divide>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Quotient"]);
        }

        [TestMethod]
        public void Divide_By_Negative_5_Point_5_Without_Rounding()
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

            const decimal expected = -0.1818181818181818181818181818m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Divide>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Quotient"]);
        }

        [TestMethod]
        public void Divide_By_Negative_5_Point_5_Rounding_0_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 1 },
                { "Number2", -5.5m },
                { "RoundDecimalPlaces", 0 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 0;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Divide>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Quotient"]);
        }

        [TestMethod]
        public void Divide_By_Negative_5_Point_5_Rounding_2_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number1", 1 },
                { "Number2", -5.5m },
                { "RoundDecimalPlaces", 2 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = -.18m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Divide>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Quotient"]);
        }

        [TestMethod]
        public void Divide_By_0()
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
            var result = xrmFakedContext.ExecuteCodeActivity<Divide>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Quotient"]);
        }
    }
}