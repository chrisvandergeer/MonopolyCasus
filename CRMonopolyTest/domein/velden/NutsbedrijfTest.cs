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
            Speler expected = new Speler("SomePlayer", null);
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
            Nutsbedrijf nutsbedrijf = NutsbedrijvenBuilder.Instance.NutsBedrijven.getBedrijfByName(NutsbedrijvenBuilder.ELEKTRICITEITSBEDRIJF);
            Speler eigenaar = new Speler("Eigenaar", null);
            nutsbedrijf.Eigenaar = eigenaar;

            Speler bezoeker = new Speler("Bezoeker", null);
            Worp worp = new Worp();
            worp.Gedobbeldeworp1 = 1;
            worp.Gedobbeldeworp2 = 1;
            bezoeker.WorpenInHuidigeBeurt.Add(worp); 
            int expected = 8;   // Multiplier is 4 en de worp is 2
            int actual = nutsbedrijf.GeefTeBetalenHuur(bezoeker);
            Assert.AreEqual(expected, actual, String.Format("De huur met 1 nutsbedrijf is niet correct. (Exp. {0}; Act: {1}).", expected, nutsbedrijf));

            nutsbedrijf = NutsbedrijvenBuilder.Instance.NutsBedrijven.getBedrijfByName(NutsbedrijvenBuilder.WATERLEIDING);
            nutsbedrijf.Eigenaar = eigenaar;
            expected = 20;
            actual = nutsbedrijf.GeefTeBetalenHuur(bezoeker);
            Assert.AreEqual(expected, actual, String.Format("De huur met 2 nutsbedrijven is niet correct. (Exp. {0}; Act: {1}).", expected, nutsbedrijf));
        }

        /// <summary>
        ///A test for bepaalGebeurtenis
        ///</summary>
        [TestMethod()]
        public void bepaalGebeurtenisTest()
        {
            string naam = "YetAnotherNutsBedrijf";
            Nutsbedrijf nutsBedrijf = new Nutsbedrijf(naam);
            Speler eigenaar = new Speler("SomePlayer", null);

            Speler pasant = new Speler("pasant", null);

            // Een straat zonder eigenaar zou de gebeurtenis koop straat op moeten leveren.
            Gebeurtenis actual = nutsBedrijf.bepaalGebeurtenis(pasant);
            string expectedNaam = Gebeurtenisnamen.KOOP_STRAAT;
            string actualNaam = actual.Gebeurtenisnaam;
            Assert.AreSame(expectedNaam, actualNaam, String.Format("De gebeurtenis zou {0} moeten zijn maar het is {1}.", expectedNaam, actualNaam));

            // Een straat met eigenaar zou de gebeurtenis betaal huur op moeten leveren.
            nutsBedrijf.Eigenaar = eigenaar;
            actual = nutsBedrijf.bepaalGebeurtenis(pasant);
            expectedNaam = Gebeurtenisnamen.BETAAL_HUUR;
            actualNaam = actual.Gebeurtenisnaam;
            Assert.AreSame(expectedNaam, actualNaam, String.Format("De gebeurtenis zou {0} moeten zijn maar het is {1}.", expectedNaam, actualNaam));
        }
        /// <summary>
        ///A test for HuurChangeListener
        ///</summary>
        [TestMethod()]
        public void HuurChangeListenerTest()
        {
            Nutsbedrijf firstNutsbedrijf = new Nutsbedrijf("HuurChangeListenerBedrijf_01");
            TestHuurChangeListener listener = new TestHuurChangeListener();
            firstNutsbedrijf.addHuurChangeListener(listener);

            int expected = 0;
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("In het begin moet de huurprijs {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));
            Speler eigenaar = new Speler("Eigenaar", null);
            firstNutsbedrijf.Eigenaar = eigenaar;
            expected = 4 * 12;
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));

            Nutsbedrijf secondNutsbedrijf = new Nutsbedrijf("HuurChangeListenerBedrijf_02");
            secondNutsbedrijf.addHuurChangeListener(listener);
            secondNutsbedrijf.Eigenaar = eigenaar;
            expected = 10 * 12;
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));
        }
    }
}
