using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class TruncateTests
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
        public void Truncate_Negative_2_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "NumberToTruncate", 34.5566m },
                { "DecimalPlaces", -2 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 34m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Truncate>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TruncatedNumber"]);
        }

        [TestMethod]
        public void Truncate_0_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "NumberToTruncate", 34.5566m },
                { "DecimalPlaces", 0 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 34m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Truncate>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TruncatedNumber"]);
        }

        [TestMethod]
        public void Truncate_1_Place()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "NumberToTruncate", 34.5566m },
                { "DecimalPlaces", 1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 34.5m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Truncate>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TruncatedNumber"]);
        }

        [TestMethod]
        public void Truncate_2_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "NumberToTruncate", 34.5566m },
                { "DecimalPlaces", 2 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 34.55m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Truncate>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TruncatedNumber"]);
        }

        [TestMethod]
        public void Truncate_5_Places()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "NumberToTruncate", 34.5566m },
                { "DecimalPlaces", 5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const decimal expected = 34.55660m;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Truncate>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TruncatedNumber"]);
        }
    }
}