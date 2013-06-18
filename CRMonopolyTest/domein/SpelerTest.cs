using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;
using System.Collections.Generic;
using CRMonopoly.builders;
using CRMonopoly.domein.velden;

namespace CRMonopolyTest
{
    /// <summary>
    ///This is a test class for SpelerTest and is intended
    ///to contain all SpelerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpelerTest
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
        ///A test for Speler Constructor
        ///</summary>
        [TestMethod()]
        public void SpelerConstructorTest()
        {
            string name = "TestSpeler";
            Speler target = new Speler(name);
            Assert.AreSame(name, target.Name, String.Format("De naam van de speler zou {0} moeten zijn.", name));
            Assert.IsTrue(Speler.SPELER_START_BEDRAG == target.Geldeenheden,
                String.Format("Het startbedrag van een nieuwe speler zou {0} moeten zijn.", Speler.SPELER_START_BEDRAG));
        }

        /// <summary>
        ///A test for Betaal
        ///</summary>
        [TestMethod()]
        public void BetaalTest()
        {
            string nameBetalendeSpeler = "BetalendeSpeler";
            Speler betaler = new Speler(nameBetalendeSpeler);
            string nameOntvangenSpeler = "OntvangendeSpeler";
            Speler ontvanger = new Speler(nameOntvangenSpeler);
            int bedrag = 100;
            bool actual = betaler.Betaal(bedrag, ontvanger);
            Assert.IsTrue(actual, String.Format("De betaling van {0} zou geen probleem moeten zijn.", bedrag));
            Assert.IsTrue((Speler.SPELER_START_BEDRAG - bedrag) == betaler.Geldeenheden,
                String.Format("De betalende spelers zou nu {0} in geld moeten hebben.", (Speler.SPELER_START_BEDRAG - bedrag)));
            Assert.IsTrue((Speler.SPELER_START_BEDRAG + bedrag) == ontvanger.Geldeenheden,
                String.Format("De ontvangende spelers zou nu {0} in geld moeten hebben.", (Speler.SPELER_START_BEDRAG + bedrag)));
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            string name = "TestSpeler";
            Speler target = new Speler(name);
            AmsterdamBuilder.Instance.Amsterdam.getStraatByIndex(0).Eigenaar = target;
            Assert.IsTrue(target.getStraten().Count == 1, "De Speler zou nu 1 straat in bezit moeten hebben.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddMultipleStreetsTest()
        {
            string name = "TestSpeler";
            Speler target = new Speler(name);
            AmsterdamBuilder.Instance.Amsterdam.getStraatByIndex(0).Eigenaar = target;
            ArnhemBuilder.Instance.Arnhem.getStraatByIndex(2).Eigenaar = target;
            OnsDorpBuilder.Instance.OnsDorp.getStraatByIndex(1).Eigenaar = target;
            Assert.IsTrue(target.getStraten().Count == 3, "De Speler zou nu 3 straat in bezit moeten hebben.");
        }

        /// <summary>
        ///A test for Ontvang
        ///</summary>
        [TestMethod()]
        public void OntvangTest()
        {
            string name = "TestSpeler";
            Speler target = new Speler(name);
            int bedrag = 250;
            target.Ontvang(bedrag);
            int expected = (Speler.SPELER_START_BEDRAG + bedrag);
            Assert.IsTrue(expected == target.Geldeenheden, String.Format("De speler zou nu {0} aan geld moeten hebben.", expected));
            int tweedeBedrag = 195;
            target.Ontvang(tweedeBedrag);
            expected = (Speler.SPELER_START_BEDRAG + bedrag + tweedeBedrag);
            Assert.IsTrue(expected == target.Geldeenheden, String.Format("De speler zou nu {0} aan geld moeten hebben.", expected));
        }


        /// <summary>
        ///A test for AantalNutsbedrijven
        ///</summary>
        [TestMethod()]
        public void AantalNutsbedrijvenTest()
        {
            Speler speler = new Speler("Piet");
            Assert.AreEqual(0, speler.AantalNutsbedrijven());
            VerkoopbaarVeld elektriciteitsbedrijf =  NutsbedrijvenBuilder.Instance.NutsBedrijven.getBedrijfByName(NutsbedrijvenBuilder.ELEKTRICITEITSBEDRIJF);
            new KoopStraat(elektriciteitsbedrijf).VoerUit(speler);
            Assert.AreEqual(1, speler.AantalNutsbedrijven());
        }

        /// <summary>
        ///A test for AantalStations
        ///</summary>
        [TestMethod()]
        public void AantalStationsTest()
        {
            Speler speler = new Speler("Piet");
            Assert.AreEqual(0, speler.AantalStations());
            VerkoopbaarVeld noord = Stationbuilder.Instance.Noord();
            new KoopStraat(noord).VoerUit(speler);
            Assert.AreEqual(1, speler.AantalStations());
        }

        [TestMethod]
        public void Betaal2Test()
        {
            Speler spelerX = new Speler("speler X");
            int expected = spelerX.Geldeenheden - 10;
            spelerX.Betaal(10);
            Assert.AreEqual(expected, spelerX.Geldeenheden);

        }
    }
}
