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
    public class DoeBodOpAndermansStraatTest
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
        ///A test for DoeBodOpAndermansStraat Constructor
        ///</summary>
        [TestMethod()]
        public void DoeBodOpAndermansStraatConstructorTest()
        {
            Speler speler = new Speler("Eigenaar");
            Straat straat = new Straat("GoingSomewhereLane", 145, new Huur(2,4,6,8,10,12));
            DoeBodOpAndermansStraat target = new DoeBodOpAndermansStraat(straat);
            Assert.IsNotNull(target, "Op dit moment zou de DoeBodOpAndermansStraat gebeurtenis geinstatieerd moeten zijn.");
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitMetPositiefResultaatTest()
        {
            Speler eigenaar = new Speler("Eigenaar");
            Straat straat = new Straat("GoingSomewhereLane", 145, new Huur(2, 4, 6, 8, 10, 12));
//            eigenaar.Add(straat);
            straat.Eigenaar = eigenaar;

            Speler koper = new Speler("Koper");

            DoeBodOpAndermansStraat target = new DoeBodOpAndermansStraat(straat);
            int myOffer = (int) (straat.GeefAankoopprijs() * 1.1);
            target.setBod(myOffer);
            bool expected = true;
            GebeurtenisResult result = target.VoerUit(koper);
            result.LogUitgevoerdeGebeurtenis();
            bool actual = result.IsUitgevoerd;
            Assert.AreEqual(expected, actual, "Het bod zou geaccepteerd moeten zijn.");
            Assert.AreEqual(koper, straat.Eigenaar, "De koper zou nu de eigenaar van de straat moeten zijn.");
            Assert.AreEqual(Speler.SPELER_START_BEDRAG - myOffer, koper.Geldeenheden, "De koper zou een bedrag betaald moeten hebben aan de eigenaar.");
            Assert.AreEqual(Speler.SPELER_START_BEDRAG + myOffer, eigenaar.Geldeenheden, "De eigenaar zou een bedrag betaald moeten hebben gekregen voor de straat.");
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitMetTeWeinigGeldBeschikbaarBijDeKoperTest()
        {
            Speler eigenaar = new Speler("Eigenaar");
            Straat straat = new Straat("GoingSomewhereLane", 145, new Huur(2, 4, 6, 8, 10, 12));
//            eigenaar.Add(straat);
            straat.Eigenaar = eigenaar;

            Speler koper = new Speler("Koper");
            // Dit is een feature in de code die misschien ooit verdwijnt.
            koper.Ontvang(-Speler.SPELER_START_BEDRAG + straat.GeefAankoopprijs());
            int koperStartBezit = koper.Geldeenheden;

            DoeBodOpAndermansStraat target = new DoeBodOpAndermansStraat(straat);
            int myOffer = (int)(straat.GeefAankoopprijs() * 1.1);
            target.setBod(myOffer);
            bool expected = false;
            GebeurtenisResult result = target.VoerUit(koper);
            result.LogUitgevoerdeGebeurtenis();
            bool actual = result.IsUitgevoerd;
            Assert.AreEqual(expected, actual, "Het bod zou niet geaccepteerd mogen zijn.");
            Assert.AreEqual(eigenaar, straat.Eigenaar, "De eigenaar zou nog steeds de eigenaar van de straat moeten zijn.");
            Assert.AreEqual(koperStartBezit, koper.Geldeenheden, "Het geldbedrag van de koper zou niet aangepast moeten zijn..");
            Assert.AreEqual(Speler.SPELER_START_BEDRAG, eigenaar.Geldeenheden, "De eigenaar zou geen geld ontvangen mogen hebben.");
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitMetTeLaagBodTest()
        {
            Speler eigenaar = new Speler("Eigenaar");
            Straat straat = new Straat("GoingSomewhereLane", 145, new Huur(2, 4, 6, 8, 10, 12));
//            eigenaar.Add(straat);
            straat.Eigenaar = eigenaar;

            Speler koper = new Speler("Koper");

            DoeBodOpAndermansStraat target = new DoeBodOpAndermansStraat(straat);
            int myOffer = (int)(straat.GeefAankoopprijs());
            target.setBod(myOffer);
            bool expected = false;
            GebeurtenisResult result = target.VoerUit(koper);
            result.LogUitgevoerdeGebeurtenis();
            bool actual = result.IsUitgevoerd;
            Assert.AreEqual(expected, actual, "Het bod zou niet geaccepteerd mogen zijn.");
            Assert.AreEqual(eigenaar, straat.Eigenaar, "De eigenaar zou nog steeds de eigenaar van de straat moeten zijn.");
            Assert.AreEqual(Speler.SPELER_START_BEDRAG, koper.Geldeenheden, "Het geldbedrag van de koper zou niet aangepast moeten zijn..");
            Assert.AreEqual(Speler.SPELER_START_BEDRAG, eigenaar.Geldeenheden, "De eigenaar zou geen geld ontvangen mogen hebben.");
        }
    }
}
