using MSMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for WorpTest and is intended
    ///to contain all WorpTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WorpTest
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
        ///A test for Worp Constructor
        ///</summary>
        [TestMethod()]
        public void WorpConstructorTest()
        {
            int d1 = 0; // TODO: Initialize to an appropriate value
            int d2 = 0; // TODO: Initialize to an appropriate value
            Worp target = new Worp(d1, d2);
            Assert.IsNotNull(target);
        }

        [TestMethod()]
        public void WorpTotaalTest()
        {
            Assert.IsTrue(10 == new Worp(3, 7).Totaal());
        }

        [TestMethod()]
        public void WorpIsDubbelTest()
        {
            Assert.IsFalse(new Worp(3, 7).IsDubbelGegooid());
            Assert.IsTrue(new Worp(3, 3).IsDubbelGegooid());
        }
    }
}
