using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GebeurtenissenTest and is intended
    ///to contain all GebeurtenissenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GebeurtenissenTest
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

/*
 * De gebeurtenissen class lijkt op dit moment nog net gebruikt te worden.
 * 
        /// <summary>
        ///A test for Gebeurtenissen Constructor
        ///</summary>
        [TestMethod()]
        public void GebeurtenissenConstructorTest()
        {
            Gebeurtenissen target = new Gebeurtenissen();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            Gebeurtenissen target = new Gebeurtenissen(); // TODO: Initialize to an appropriate value
            Gebeurtenis gebeurtenis = null; // TODO: Initialize to an appropriate value
            target.Add(gebeurtenis);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GeefOptioneleGebeurtenissen
        ///</summary>
        [TestMethod()]
        public void GeefOptioneleGebeurtenissenTest()
        {
            Gebeurtenissen target = new Gebeurtenissen(); // TODO: Initialize to an appropriate value
            Gebeurtenissen expected = null; // TODO: Initialize to an appropriate value
            Gebeurtenissen actual;
            actual = target.GeefOptioneleGebeurtenissen();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GeefVerplichteGebeurtenissen
        ///</summary>
        [TestMethod()]
        public void GeefVerplichteGebeurtenissenTest()
        {
            Gebeurtenissen target = new Gebeurtenissen(); // TODO: Initialize to an appropriate value
            Gebeurtenissen expected = null; // TODO: Initialize to an appropriate value
            Gebeurtenissen actual;
            actual = target.GeefVerplichteGebeurtenissen();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Gebeurtenissen target = new Gebeurtenissen(); // TODO: Initialize to an appropriate value
            IEnumerator expected = null; // TODO: Initialize to an appropriate value
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            Gebeurtenissen target = new Gebeurtenissen(); // TODO: Initialize to an appropriate value
            target.VoerUit();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
 */
    }
}
