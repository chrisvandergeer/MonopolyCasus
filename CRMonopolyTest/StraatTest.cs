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
    }
}
