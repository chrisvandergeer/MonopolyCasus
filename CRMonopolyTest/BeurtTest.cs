using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for BeurtTest and is intended
    ///to contain all BeurtTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BeurtTest
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
        ///A test for Beurt Constructor
        ///</summary>
        [TestMethod()]
        public void BeurtConstructorTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            Beurt target = new Beurt(speler);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GooiDobbelstenen
        ///</summary>
        [TestMethod()]
        public void GooiDobbelstenenTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            Beurt target = new Beurt(speler); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GooiDobbelstenen();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WisselBeurt
        ///</summary>
        [TestMethod()]
        public void WisselBeurtTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            Beurt target = new Beurt(speler); // TODO: Initialize to an appropriate value
            Speler speler1 = null; // TODO: Initialize to an appropriate value
            target.WisselBeurt(speler1);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for init
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void initTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Beurt_Accessor target = new Beurt_Accessor(param0); // TODO: Initialize to an appropriate value
            Speler speler = null; // TODO: Initialize to an appropriate value
            target.init(speler);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Speler
        ///</summary>
        [TestMethod()]
        public void SpelerTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            Beurt target = new Beurt(speler); // TODO: Initialize to an appropriate value
            Speler expected = null; // TODO: Initialize to an appropriate value
            Speler actual;
            target.Speler = expected;
            actual = target.Speler;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
