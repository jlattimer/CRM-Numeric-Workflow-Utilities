using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.Numeric.Tests
{
    [TestClass]
    public class IntegerToWordsTests
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
        public void Zero()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 0 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "zero";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IntegerToWords>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["NumberInWords"]);
        }

        [TestMethod]
        public void Ones()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "five";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IntegerToWords>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["NumberInWords"]);
        }

        [TestMethod]
        public void Tens()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 15 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "fifteen";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IntegerToWords>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["NumberInWords"]);
        }

        [TestMethod]
        public void Hundreds()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 110 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "one hundred and ten";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IntegerToWords>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["NumberInWords"]);
        }

        [TestMethod]
        public void Thousands()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 1110 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "one thousand one hundred and ten";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IntegerToWords>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["NumberInWords"]);
        }

        [TestMethod]
        public void Millions()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 2300040 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "two million three hundred thousand and forty";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IntegerToWords>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["NumberInWords"]);
        }

        [TestMethod]
        public void Billions()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", 2147483647 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "two billion one hundred and forty-seven million four hundred and eighty-three thousand six hundred and forty-seven";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IntegerToWords>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["NumberInWords"]);
        }

        
        [TestMethod]
        public void Negative()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Number", -505 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "minus five hundred and five";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<IntegerToWords>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["NumberInWords"]);
        }
    }
}