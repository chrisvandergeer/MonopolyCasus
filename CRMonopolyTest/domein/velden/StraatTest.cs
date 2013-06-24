using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.builders;
using CRMonopoly.domein.velden;

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
            Straat straat = maakTestStraatZonderEigenaar();
            Speler eigenaar = new Speler("koper", null);
            straat.Eigenaar = eigenaar;
            return straat;
        }

        private static Straat maakTestStraatZonderEigenaar()
        {
            string naam = "GoingNowhereStreet";
            int aankoopprijs = 10;
            Huur huurprijzen = new Huur(1, 2, 3, 4, 5, 6);
            Straat straat = new Straat(naam, aankoopprijs, huurprijzen);
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

            Speler eigenaar = new Speler("koper", null);
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
            int actual = straat.GeefTeBetalenHuur(null);
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
            Straat straat = maakTestStraatZonderEigenaar();
//            straat.Eigenaar = null;
            Speler pasant = new Speler("pasant", null);

            // Een straat zonder eigenaar zou de gebeurtenis koop straat op moeten leveren.
            string expectedNaam = Gebeurtenisnamen.KOOP_STRAAT;
            Gebeurtenis actual = straat.bepaalGebeurtenis(pasant);
            Assert.AreSame(expectedNaam, actual.Gebeurtenisnaam
                , String.Format("De gebeurtenis zou {0} moeten zijn maar het is {1}.", expectedNaam, actual.Gebeurtenisnaam));

            // Een straat met eigenaar zou de gebeurtenis betaal huur op moeten leveren.
            expectedNaam = Gebeurtenisnamen.BETAAL_HUUR;
            Speler eigenaar = new Speler("straatEigenaar", null);
            straat.Eigenaar = eigenaar;
            actual = straat.bepaalGebeurtenis(pasant);
            Assert.AreSame(expectedNaam, actual.Gebeurtenisnaam
                , String.Format("De gebeurtenis zou {0} moeten zijn maar het is {1}.", expectedNaam, actual.Gebeurtenisnaam));
        }

        /// <summary>
        ///A test for MagHuisKopen
        ///</summary>
        [TestMethod()]
        public void MagHuisKopenTest()
        {
            Speler speler1 = new Speler("speler1", null);
            Stad arnhem = ArnhemBuilder.Instance.Arnhem;
            Straat ketelstraat = arnhem.getStraatByName(ArnhemBuilder.KETELSTRAAT);
            arnhem.Straten.ForEach(str => str.Eigenaar = speler1);
            Assert.IsTrue(ketelstraat.MagHuisKopen());
            ketelstraat.KoopHuis(3);
            Assert.IsTrue(ketelstraat.MagHuisKopen());
            ketelstraat.KoopHuis();
            Assert.IsFalse(ketelstraat.MagHuisKopen());
        }

        /// <summary>
        ///A test for MagHuisKopen
        ///</summary>
        [TestMethod()]
        public void MagHuisKopenTestNietAlleStratenInBezit()
        {
            Speler speler1 = new Speler("speler1", null);
            Stad haarlem = HaarlemBuilder.Instance.Haarlem;
            Straat houtstraat = haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT);
            haarlem.Straten.ForEach(str => str.Eigenaar = speler1);
            haarlem.getStraatByName(HaarlemBuilder.BARTELJORISSTRAAT).Eigenaar = new Speler("Speler 2", null);
            Assert.IsFalse(houtstraat.MagHuisKopen());
        }

        /// <summary>
        ///A test for MagHotelKopen
        ///</summary>
        [TestMethod()]
        public void MagHotelKopenTest()
        {
            Speler speler1 = new Speler("speler1", null);
            Stad amsterdam = AmsterdamBuilder.Instance.Amsterdam;
            Straat leidsestraat = amsterdam.getStraatByName(AmsterdamBuilder.LEIDSESTRAAT);
            amsterdam.Straten.ForEach(str => str.Eigenaar = speler1);
            Assert.IsFalse(leidsestraat.MagHotelKopen());
            leidsestraat.KoopHuis(3);
            Assert.IsFalse(leidsestraat.MagHotelKopen());
            leidsestraat.KoopHuis(1);
            Assert.IsTrue(leidsestraat.MagHotelKopen());
        }

        /// <summary>
        ///A test for KoopHuis
        ///</summary>
        [TestMethod()]
        public void KoopHuisTest()
        {
            Speler speler1 = new Speler("speler1", null);
            Stad denHaag = DenHaagBuilder.Instance.DenHaag;
            Straat langePoten = denHaag.getStraatByName(DenHaagBuilder.LANGE_POTEN);
            denHaag.Straten.ForEach(str => str.Eigenaar = speler1);
            Assert.IsTrue(langePoten.KoopHuis());
            Assert.AreEqual(1, langePoten.GeefAantalHuizen());
            Assert.IsTrue(langePoten.KoopHuis(3));
            Assert.AreEqual(4, langePoten.GeefAantalHuizen());
        }

        /// <summary>
        ///A test for KoopHuis
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "Er mogen maximaal 4 huizen gekocht worden en alleen indien alle straten van de stad in bezit zijn")]
        public void KoopHuisTest5Huizen()
        {
            Speler speler1 = new Speler("speler1", null);
            Stad haarlem = HaarlemBuilder.Instance.Haarlem;
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
            Speler speler1 = new Speler("speler1", null);
            Stad haarlem = HaarlemBuilder.Instance.Haarlem;
            Straat houtstraat = haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT);
            haarlem.Straten.ForEach(str => str.Eigenaar = speler1);
            haarlem.getStraatByName(HaarlemBuilder.BARTELJORISSTRAAT).Eigenaar = new Speler("Speler 2", null);
            houtstraat.KoopHuis();
        }

        /// <summary>
        ///A test for KoopHotel
        ///</summary>
        [TestMethod()]
        public void KoopHotelTest()
        {
            Speler speler1 = new Speler("speler1", null);
            Stad utrecht = UtrechtBuilder.Instance.Utrecht;
            utrecht.Straten.ForEach(str => str.Eigenaar = speler1);
            Straat biltstraat = utrecht.getStraatByName(UtrechtBuilder.BILTSTRAAT);
            biltstraat.KoopHuis(4);
            biltstraat.KoopHotel();
            Assert.AreEqual(0, biltstraat.GeefAantalHuizen());
            Assert.IsTrue(biltstraat.HeeftHotel());
        }

        /// <summary>
        ///A test for KoopHotel
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void KoopHotel2HotelsTest()
        {
            Speler speler1 = new Speler("speler1", null);
            Stad haarlem = HaarlemBuilder.Instance.Haarlem;
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
            Speler speler1 = new Speler("speler1", null);
            Stad onsDorp = OnsDorpBuilder.Instance.OnsDorp;
            onsDorp.Straten.ForEach(str => str.Eigenaar = speler1);
            Straat brink = onsDorp.getStraatByName(OnsDorpBuilder.BRINK);
            int betaal = speler1.Geldeenheden - (brink.Stad.Huisprijs - 1);
            speler1.Betaal(betaal, Speler.BANK);
            Assert.IsFalse(brink.KoopHuis());
            Assert.AreEqual(0, brink.GeefAantalHuizen());
        }

        /// <summary>
        ///A test for HuurChangeListener
        ///</summary>
        [TestMethod()]
        public void HuurChangeListenerTest()
        {
            Stad stad = new Stad("MyLittleTown", 150);
            Straat target = new Straat("HuurChangeListenerStraat", 100, new Huur(10, 20, 30, 40, 50, 60));
            stad.Add(target);
            TestHuurChangeListener listener = new TestHuurChangeListener();
            target.addHuurChangeListener(listener);

            int expected = 0;
            Assert.AreEqual(expected, listener.huurprijsFromVeld, 
                String.Format("In het begin moet de huurprijs {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));
            Speler eigenaar = new Speler("Eigenaar", null);
            target.Eigenaar = eigenaar;
//            eigenaar.Add(target);
            expected = 10;
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));

            target.KoopHuis();
            expected = 20;
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));

            target.KoopHuis();
            expected = 30;
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));

            target.KoopHuis();
            expected = 40;
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));

            target.KoopHuis();
            expected = 50;
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));

            target.KoopHotel();
            expected = 60;
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));
        }

    }
    class TestHuurChangeListener : HuurChangeListener
    {
        internal int huurprijsFromVeld = 0;
        public void informHuurChange(int huurprijs)
        {
            huurprijsFromVeld = huurprijs;
            Console.WriteLine(String.Format("Nieuwe huurprijs is {0}.", huurprijs));
        }
    }
}
