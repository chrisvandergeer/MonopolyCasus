using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for StraatTest and is intended
    ///to contain all StraatTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StraatTest
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
        ///A test for Straat Constructor
        ///</summary>
        [TestMethod()]
        public void StraatConstructorTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int aankoopprijs = 0; // TODO: Initialize to an appropriate value
            Huur huurprijzen = null; // TODO: Initialize to an appropriate value
            Straat target = new Straat(naam, aankoopprijs, huurprijzen);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GeefAantalHuizen
        ///</summary>
        [TestMethod()]
        public void GeefAantalHuizenTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int aankoopprijs = 0; // TODO: Initialize to an appropriate value
            Huur huurprijzen = null; // TODO: Initialize to an appropriate value
            Straat target = new Straat(naam, aankoopprijs, huurprijzen); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GeefAantalHuizen();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GeefTeBetalenHuur
        ///</summary>
        [TestMethod()]
        public void GeefTeBetalenHuurTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int aankoopprijs = 0; // TODO: Initialize to an appropriate value
            Huur huurprijzen = null; // TODO: Initialize to an appropriate value
            Straat target = new Straat(naam, aankoopprijs, huurprijzen); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GeefTeBetalenHuur();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HeeftHotel
        ///</summary>
        [TestMethod()]
        public void HeeftHotelTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int aankoopprijs = 0; // TODO: Initialize to an appropriate value
            Huur huurprijzen = null; // TODO: Initialize to an appropriate value
            Straat target = new Straat(naam, aankoopprijs, huurprijzen); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HeeftHotel();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for bepaalGebeurtenis
        ///</summary>
        [TestMethod()]
        public void bepaalGebeurtenisTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int aankoopprijs = 0; // TODO: Initialize to an appropriate value
            Huur huurprijzen = null; // TODO: Initialize to an appropriate value
            Straat target = new Straat(naam, aankoopprijs, huurprijzen); // TODO: Initialize to an appropriate value
            Speler speler = null; // TODO: Initialize to an appropriate value
            Gebeurtenis expected = null; // TODO: Initialize to an appropriate value
            Gebeurtenis actual;
            actual = target.bepaalGebeurtenis(speler);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for isVerkocht
        ///</summary>
        [TestMethod()]
        public void isVerkochtTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int aankoopprijs = 0; // TODO: Initialize to an appropriate value
            Huur huurprijzen = null; // TODO: Initialize to an appropriate value
            Straat target = new Straat(naam, aankoopprijs, huurprijzen); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.isVerkocht();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Aankoopprijs
        ///</summary>
        [TestMethod()]
        public void AankoopprijsTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int aankoopprijs = 0; // TODO: Initialize to an appropriate value
            Huur huurprijzen = null; // TODO: Initialize to an appropriate value
            Straat target = new Straat(naam, aankoopprijs, huurprijzen); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Aankoopprijs = expected;
            actual = target.Aankoopprijs;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Eigenaar
        ///</summary>
        [TestMethod()]
        public void EigenaarTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int aankoopprijs = 0; // TODO: Initialize to an appropriate value
            Huur huurprijzen = null; // TODO: Initialize to an appropriate value
            Straat target = new Straat(naam, aankoopprijs, huurprijzen); // TODO: Initialize to an appropriate value
            Speler expected = null; // TODO: Initialize to an appropriate value
            Speler actual;
            target.Eigenaar = expected;
            actual = target.Eigenaar;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Huurprijzen
        ///</summary>
        [TestMethod()]
        public void HuurprijzenTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int aankoopprijs = 0; // TODO: Initialize to an appropriate value
            Huur huurprijzen = null; // TODO: Initialize to an appropriate value
            Straat target = new Straat(naam, aankoopprijs, huurprijzen); // TODO: Initialize to an appropriate value
            Huur expected = null; // TODO: Initialize to an appropriate value
            Huur actual;
            target.Huurprijzen = expected;
            actual = target.Huurprijzen;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Stad
        ///</summary>
        [TestMethod()]
        public void StadTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int aankoopprijs = 0; // TODO: Initialize to an appropriate value
            Huur huurprijzen = null; // TODO: Initialize to an appropriate value
            Straat target = new Straat(naam, aankoopprijs, huurprijzen); // TODO: Initialize to an appropriate value
            Stad expected = null; // TODO: Initialize to an appropriate value
            Stad actual;
            target.Stad = expected;
            actual = target.Stad;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
