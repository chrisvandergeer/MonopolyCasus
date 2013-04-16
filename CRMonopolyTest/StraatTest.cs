using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.builders;

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
        private Straat maakTestStraat()
        {
            string naam = "GoingNowhereStreet";
            int aankoopprijs = 10;
            Huur huurprijzen = new Huur(1, 2, 3, 4, 5, 6);
            Straat straat = new Straat(naam, aankoopprijs, huurprijzen);
            Speler eigenaar = new Speler("koper");
            straat.Eigenaar = eigenaar;
            return straat;
        }


        /// <summary>
        ///A test for Straat Constructor
        ///</summary>
        [TestMethod()]
        public void StraatConstructorTest()
        {
            string naam = "GoingNowhereStreet";
            int aankoopprijs = 10;
            Huur huurprijzen = new Huur(1,2,3,4,5,6);
            Straat target = new Straat(naam, aankoopprijs, huurprijzen);
            Assert.IsNotNull(target, "De straat zou nu geinstantieerd moeten zijn.");
        }

        /// <summary>
        ///A test for Eigenaar
        ///</summary>
        [TestMethod()]
        public void EigenaarEnIsVerkochtTest()
        {
            string naam = "GoingNowhereStreet";
            int aankoopprijs = 10;
            Huur huurprijzen = new Huur(1, 2, 3, 4, 5, 6);
            Straat target = new Straat(naam, aankoopprijs, huurprijzen);

            Assert.IsFalse(target.isVerkocht(), "De straat is op dit moment nog niet verkocht.");

            Speler eigenaar = new Speler("koper");
            target.Eigenaar = eigenaar;

            Assert.IsTrue(target.isVerkocht(), "De straat is op dit moment verkocht.");
        }

        /// <summary>
        ///A test for GeefAantalHuizen
        ///</summary>
        [TestMethod()]
        public void GeefAantalHuizenTest()
        {
            Straat straat = maakTestStraat();
            int expected = 0;
            int actual = straat.GeefAantalHuizen();
            Assert.AreEqual(expected, actual, "Op dit moment zouden er nog geen huizen mogen zijn.");

            // Test later uitbreiden nadat het aankopen van huizen is geimplementeerd.
        }

        /// <summary>
        ///A test for GeefTeBetalenHuur
        ///</summary>
        [TestMethod()]
        public void GeefTeBetalenHuurTest()
        {
            Straat straat = maakTestStraat();
            int expected = 1;
            int actual = straat.GeefTeBetalenHuur();
            Assert.AreEqual(expected, actual, "De huurprijs is niet zoals verwacht.");

            // Test later uitbreiden nadat het aankopen van huizen is geimplementeerd.
        }

        /// <summary>
        ///A test for HeeftHotel
        ///</summary>
        [TestMethod()]
        public void HeeftHotelTest()
        {
            Straat straat = maakTestStraat();
            bool expected = false;
            bool actual = straat.HeeftHotel();
            Assert.AreEqual(expected, actual, "De straat heeft op dit moment nog geen hotel.");

            // Test later uitbreiden nadat het aankopen van huizen is geimplementeerd.
        }

        /// <summary>
        ///A test for bepaalGebeurtenis
        ///</summary>
        [TestMethod()]
        public void bepaalGebeurtenisTest()
        {
            Straat straat = maakTestStraat();
            Speler eigenaar = straat.Eigenaar;
            straat.Eigenaar = null;
            Speler pasant = new Speler("pasant");

            // Een straat zonder eigenaar zou de gebeurtenis koop straat op moeten leveren.
            string expectedNaam = Gebeurtenisnamen.KOOP_STRAAT;
            Gebeurtenis actual = straat.bepaalGebeurtenis(pasant);
            Assert.AreSame(expectedNaam, actual.Gebeurtenisnaam()
                , String.Format("De gebeurtenis zou {0} moeten zijn maar het is {1}.", expectedNaam, actual.Gebeurtenisnaam()));

            // Een straat met eigenaar zou de gebeurtenis betaal huur op moeten leveren.
            expectedNaam = Gebeurtenisnamen.BETAAL_HUUR;
            straat.Eigenaar = eigenaar;
            actual = straat.bepaalGebeurtenis(pasant);
            Assert.AreSame(expectedNaam, actual.Gebeurtenisnaam()
                , String.Format("De gebeurtenis zou {0} moeten zijn maar het is {1}.", expectedNaam, actual.Gebeurtenisnaam()));
        }

        /// <summary>
        ///A test for MagHuisKopen
        ///</summary>
        [TestMethod()]
        public void MagHuisKopenTest()
        {
            Speler speler1 = new Speler("speler1");
            Stad haarlem = new HaarlemBuilder().buildStad();
            Straat houtstraat = haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT);
            haarlem.Straten.ForEach(str => str.Eigenaar = speler1);
            Assert.IsTrue(houtstraat.MagHuisKopen());
            houtstraat.KoopHuis(3);
            Assert.IsTrue(houtstraat.MagHuisKopen());
            houtstraat.KoopHuis();
            Assert.IsFalse(houtstraat.MagHuisKopen());
        }

        /// <summary>
        ///A test for MagHuisKopen
        ///</summary>
        [TestMethod()]
        public void MagHuisKopenTestNietAlleStratenInBezit()
        {
            Speler speler1 = new Speler("speler1");
            Stad haarlem = new HaarlemBuilder().buildStad();
            Straat houtstraat = haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT);
            haarlem.Straten.ForEach(str => str.Eigenaar = speler1);
            haarlem.getStraatByName(HaarlemBuilder.BARTELJORISSTRAAT).Eigenaar = new Speler("Speler 2");
            Assert.IsFalse(houtstraat.MagHuisKopen());
        }

        /// <summary>
        ///A test for MagHotelKopen
        ///</summary>
        [TestMethod()]
        public void MagHotelKopenTest()
        {
            Speler speler1 = new Speler("speler1");
            Stad haarlem = new HaarlemBuilder().buildStad();
            Straat houtstraat = haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT);
            haarlem.Straten.ForEach(str => str.Eigenaar = speler1);
            Assert.IsFalse(houtstraat.MagHotelKopen());
            houtstraat.KoopHuis(3);
            Assert.IsFalse(houtstraat.MagHotelKopen());
            houtstraat.KoopHuis(1);
            Assert.IsTrue(houtstraat.MagHotelKopen());
        }

        /// <summary>
        ///A test for KoopHuis
        ///</summary>
        [TestMethod()]
        public void KoopHuisTest()
        {
            Speler speler1 = new Speler("speler1");
            Stad haarlem = new HaarlemBuilder().buildStad();
            Straat houtstraat = haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT);
            haarlem.Straten.ForEach(str => str.Eigenaar = speler1);
            Assert.IsTrue(houtstraat.KoopHuis());
            Assert.AreEqual(1, houtstraat.GeefAantalHuizen());
            Assert.IsTrue(houtstraat.KoopHuis(3));
            Assert.AreEqual(4, houtstraat.GeefAantalHuizen());
        }

        /// <summary>
        ///A test for KoopHuis
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "Er mogen maximaal 4 huizen gekocht worden en alleen indien alle straten van de stad in bezit zijn")]
        public void KoopHuisTest5Huizen()
        {
            Speler speler1 = new Speler("speler1");
            Stad haarlem = new HaarlemBuilder().buildStad();
            Straat houtstraat = haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT);
            haarlem.Straten.ForEach(str => str.Eigenaar = speler1);
            houtstraat.KoopHuis(4);
            houtstraat.KoopHuis();
        }

        /// <summary>
        ///A test for KoopHuis
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "Er mogen maximaal 4 huizen gekocht worden en alleen indien alle straten van de stad in bezit zijn")]
        public void KoopHuisTestNietAlleStratenInBezit()
        {
            Speler speler1 = new Speler("speler1");
            Stad haarlem = new HaarlemBuilder().buildStad();
            Straat houtstraat = haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT);
            haarlem.Straten.ForEach(str => str.Eigenaar = speler1);
            haarlem.getStraatByName(HaarlemBuilder.BARTELJORISSTRAAT).Eigenaar = new Speler("Speler 2");
            houtstraat.KoopHuis();
        }

        /// <summary>
        ///A test for KoopHotel
        ///</summary>
        [TestMethod()]
        public void KoopHotelTest()
        {
            Speler speler1 = new Speler("speler1");
            Stad haarlem = new HaarlemBuilder().buildStad();
            haarlem.Straten.ForEach(str => str.Eigenaar = speler1);
            Straat houtstraat = haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT);
            houtstraat.KoopHuis(4);
            houtstraat.KoopHotel();
            Assert.AreEqual(0, houtstraat.GeefAantalHuizen());
            Assert.IsTrue(houtstraat.HeeftHotel());
        }

        /// <summary>
        ///A test for KoopHotel
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void KoopHotel2HotelsTest()
        {
            Speler speler1 = new Speler("speler1");
            Stad haarlem = new HaarlemBuilder().buildStad();
            haarlem.Straten.ForEach(str => str.Eigenaar = speler1);
            Straat houtstraat = haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT);
            houtstraat.KoopHuis(4);
            houtstraat.KoopHotel();
            houtstraat.KoopHotel();
        }

        /// <summary>
        ///A test for KoopHuis
        ///</summary>
        [TestMethod()]
        public void KoopHuisTeWeiniggeld()
        {
            Speler speler1 = new Speler("speler1");
            Stad haarlem = new HaarlemBuilder().buildStad();
            haarlem.Straten.ForEach(str => str.Eigenaar = speler1);
            Straat houtstraat = haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT);
            int betaal = speler1.Geldeenheden - (houtstraat.Stad.Huisprijs - 1);
            speler1.Betaal(betaal, Speler.BANK);
            Assert.IsFalse(houtstraat.KoopHuis());
            Assert.AreEqual(0, houtstraat.GeefAantalHuizen());
        }
    }
}
