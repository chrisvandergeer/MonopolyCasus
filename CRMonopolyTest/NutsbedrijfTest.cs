using CRMonopoly.domein.velden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using System.Collections.Generic;
using CRMonopoly.builders;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for NutsbedrijfTest and is intended
    ///to contain all NutsbedrijfTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NutsbedrijfTest
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
        ///A test for GeefTeBetalenHuur
        ///</summary>
        [TestMethod()]
        public void ConstructorTest()
        {
            string naam = "SomeNutsBedrijf";
            Nutsbedrijf target = new Nutsbedrijf(naam);
            Assert.IsNotNull(target);
            Assert.AreEqual(naam, target.Naam, String.Format("De naam van het nutsbedrijf is niet correct. (Exp. {0}; Act: {1}).", naam, target));
        }
        /// <summary>
        ///A test for GeefAankoopprijs
        ///</summary>
        [TestMethod()]
        public void GeefAankoopprijsTest()
        {
            string naam = "JustSomeNutsBedrijf";
            Nutsbedrijf target = new Nutsbedrijf(naam);
            int expected = 150;
            int actual = target.GeefAankoopprijs();
            Assert.AreEqual(expected, actual, String.Format("De aankoopprijs is niet correct. (Exp. {0}; Act: {1}).", expected, target));
        }
        /// <summary>
        ///A test for GeefEigenaar
        ///</summary>
        [TestMethod()]
        public void GeefEigenaarTest()
        {
            string naam = "AnotherNutsBedrijf";
            Nutsbedrijf target = new Nutsbedrijf(naam);
            Speler expected = new Speler("SomePlayer");
            target.Eigenaar = expected;

            Speler actual = target.GeefEigenaar();
            Assert.AreEqual(expected, actual, String.Format("De eigenaar is niet correct. (Exp. {0}; Act: {1}).", expected, target));

            actual = target.Eigenaar;
            Assert.AreEqual(expected, actual, String.Format("De eigenaar is niet correct. (Exp. {0}; Act: {1}).", expected, target));
        }

        /// <summary>
        ///A test for GeefTeBetalenHuur
        ///</summary>
        [TestMethod()]
        public void GeefTeBetalenHuurTest()
        {
            Nutsbedrijf target = NutsbedrijvenBuilder.Instance.NutsBedrijven.getBedrijfByName(NutsbedrijvenBuilder.ELEKTRICITEITSBEDRIJF);
            Speler somePlayer = new Speler("Speler");
            target.Eigenaar = somePlayer;
            somePlayer.getNutsbedrijven().Add(target);
            int expected = 4;
            int actual = target.GeefTeBetalenHuur();
            Assert.AreEqual(expected, actual, String.Format("De huur met 1 nutsbedrijf is niet correct. (Exp. {0}; Act: {1}).", expected, target));

            target = NutsbedrijvenBuilder.Instance.NutsBedrijven.getBedrijfByName(NutsbedrijvenBuilder.WATERLEIDING);
            target.Eigenaar = somePlayer;
            somePlayer.getNutsbedrijven().Add(target);
            expected = 10;
            actual = target.GeefTeBetalenHuur();
            Assert.AreEqual(expected, actual, String.Format("De huur met 2 nutsbedrijven is niet correct. (Exp. {0}; Act: {1}).", expected, target));
        }

        /// <summary>
        ///A test for bepaalGebeurtenis
        ///</summary>
        [TestMethod()]
        public void bepaalGebeurtenisTest()
        {
            string naam = "YetAnotherNutsBedrijf";
            Nutsbedrijf nutsBedrijf = new Nutsbedrijf(naam);
            Speler eigenaar = new Speler("SomePlayer");

            Speler pasant = new Speler("pasant");

            // Een straat zonder eigenaar zou de gebeurtenis koop straat op moeten leveren.
            Gebeurtenis actual = nutsBedrijf.bepaalGebeurtenis(pasant);
            string expectedNaam = Gebeurtenisnamen.KOOP_NUTSBEDRIJF;
            string actualNaam = actual.Gebeurtenisnaam;
            Assert.AreSame(expectedNaam, actualNaam, String.Format("De gebeurtenis zou {0} moeten zijn maar het is {1}.", expectedNaam, actualNaam));

            // Een straat met eigenaar zou de gebeurtenis betaal huur op moeten leveren.
            nutsBedrijf.Eigenaar = eigenaar;
            actual = nutsBedrijf.bepaalGebeurtenis(pasant);
            expectedNaam = Gebeurtenisnamen.BETAAL_HUUR;
            actualNaam = actual.Gebeurtenisnaam;
            Assert.AreSame(expectedNaam, actualNaam, String.Format("De gebeurtenis zou {0} moeten zijn maar het is {1}.", expectedNaam, actualNaam));
        }
    }
}
