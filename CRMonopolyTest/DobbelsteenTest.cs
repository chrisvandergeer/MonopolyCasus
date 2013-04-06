using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for DobbelsteenTest and is intended
    ///to contain all DobbelsteenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DobbelsteenTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Dobbelsteen Constructor
        ///</summary>
        [TestMethod()]
        public void DobbelsteenConstructorTest()
        {
            Dobbelsteen target = new Dobbelsteen();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Gooi
        ///</summary>
        [TestMethod()]
        public void GooiTest()
        {
            Dobbelsteen target = new Dobbelsteen(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Gooi();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
