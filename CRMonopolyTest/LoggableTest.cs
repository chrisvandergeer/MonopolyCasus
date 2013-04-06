using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for LoggableTest and is intended
    ///to contain all LoggableTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LoggableTest
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
        ///A test for Worp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void WorpTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Loggable_Accessor target = new Loggable_Accessor(param0); // TODO: Initialize to an appropriate value
            Worp expected = null; // TODO: Initialize to an appropriate value
            Worp actual;
            target.Worp = expected;
            actual = target.Worp;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Speler
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void SpelerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Loggable_Accessor target = new Loggable_Accessor(param0); // TODO: Initialize to an appropriate value
            Speler expected = null; // TODO: Initialize to an appropriate value
            Speler actual;
            target.Speler = expected;
            actual = target.Speler;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Gebeurtenis
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void GebeurtenisTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Loggable_Accessor target = new Loggable_Accessor(param0); // TODO: Initialize to an appropriate value
            Gebeurtenis expected = null; // TODO: Initialize to an appropriate value
            Gebeurtenis actual;
            target.Gebeurtenis = expected;
            actual = target.Gebeurtenis;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Loggable Constructor
        ///</summary>
        [TestMethod()]
        public void LoggableConstructorTest()
        {
            Worp worp = null; // TODO: Initialize to an appropriate value
            Speler speler = null; // TODO: Initialize to an appropriate value
            Gebeurtenis gebeurtenis = null; // TODO: Initialize to an appropriate value
            Loggable target = new Loggable(worp, speler, gebeurtenis);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
