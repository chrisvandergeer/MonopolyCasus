using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for BetaalHuurTest and is intended
    ///to contain all BetaalHuurTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BetaalHuurTest
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
        ///A test for BetaalHuur Constructor
        ///</summary>
        [TestMethod()]
        public void BetaalHuurConstructorTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            Straat straat = null; // TODO: Initialize to an appropriate value
            BetaalHuur target = new BetaalHuur(speler, straat);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Gebeurtenisnaam
        ///</summary>
        [TestMethod()]
        public void GebeurtenisnaamTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            Straat straat = null; // TODO: Initialize to an appropriate value
            BetaalHuur target = new BetaalHuur(speler, straat); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Gebeurtenisnaam();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsVerplicht
        ///</summary>
        [TestMethod()]
        public void IsVerplichtTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            Straat straat = null; // TODO: Initialize to an appropriate value
            BetaalHuur target = new BetaalHuur(speler, straat); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsVerplicht();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            Straat straat = null; // TODO: Initialize to an appropriate value
            BetaalHuur target = new BetaalHuur(speler, straat); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            Straat straat = null; // TODO: Initialize to an appropriate value
            BetaalHuur target = new BetaalHuur(speler, straat); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.VoerUit();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Huurbetaler
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void HuurbetalerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            BetaalHuur_Accessor target = new BetaalHuur_Accessor(param0); // TODO: Initialize to an appropriate value
            Speler expected = null; // TODO: Initialize to an appropriate value
            Speler actual;
            target.Huurbetaler = expected;
            actual = target.Huurbetaler;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VerhuurdeStraat
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void VerhuurdeStraatTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            BetaalHuur_Accessor target = new BetaalHuur_Accessor(param0); // TODO: Initialize to an appropriate value
            Straat expected = null; // TODO: Initialize to an appropriate value
            Straat actual;
            target.VerhuurdeStraat = expected;
            actual = target.VerhuurdeStraat;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
