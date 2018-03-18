using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class RoundTests
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
        public void Round_10_Point_1_To_Negative_1_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "NumberToRound", 10.1m },
                { "DecimalPlaces", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 10m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Round>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["RoundedNumber"]);
        }

        [TestMethod]
        public void Round_10_Point_1_To_0_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "NumberToRound", 10.1m },
                { "DecimalPlaces", 0 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 10m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Round>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["RoundedNumber"]);
        }

        [TestMethod]
        public void Round_10_Point_15_To_1_Place()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "NumberToRound", 10.15m },
                { "DecimalPlaces", 1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 10.2m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Round>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["RoundedNumber"]);
        }

        [TestMethod]
        public void Round_10_Point_151_To_2_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "NumberToRound", 10.151m },
                { "DecimalPlaces", 2 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 10.15m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Round>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["RoundedNumber"]);
        }

        [TestMethod]
        public void Round_10_Point_151_To_5_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "NumberToRound", 10.151m },
                { "DecimalPlaces", 5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 10.15100m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Round>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["RoundedNumber"]);
        }
    }
}