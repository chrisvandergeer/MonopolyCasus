using Monopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein.velden;
using Monopoly.domein.gebeurtenissen;
using System.Collections.Generic;

namespace MonopolyTest
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
        ///A test for BepaalGebeurtenissenBijAanvangBeurt
        ///</summary>
        [TestMethod()]
        public void BepaalGebeurtenissenBijAanvangBeurtTest()
        {
            Speler speler = new Monopolyspel().VoegSpelerToe("Speler X");
            Gebeurtenislijst lijst =  speler.BepaalGebeurtenissenBijAanvangBeurt();
            Assert.AreEqual(8, lijst.Gebeurtenissen.Count);
            Assert.IsTrue(lijst.BevatGebeurtenis(Gebeurtenisnamen.GOOI_DOBBELSTENEN));
            Assert.IsTrue(lijst.BevatGebeurtenis(Gebeurtenisnamen.LOS_HYPOTHEEK_AF));
            Assert.IsTrue(lijst.BevatGebeurtenis(Gebeurtenisnamen.KOOP_HUIS));
            Assert.IsTrue(lijst.BevatGebeurtenis(Gebeurtenisnamen.VERKOOP_HUIS));
            Assert.IsTrue(lijst.BevatGebeurtenis(Gebeurtenisnamen.NEEM_HYPOTHEEK));
            Assert.IsTrue(lijst.BevatGebeurtenis(Gebeurtenisnamen.DOE_BOD_OPANDERMANSTRAAT));
            Assert.IsTrue(lijst.BevatGebeurtenis(Gebeurtenisnamen.EINDE_BEURT));
            Assert.IsTrue(lijst.BevatGebeurtenis(Gebeurtenisnamen.EINDE_SPEL));
        }

        /// <summary>
        ///A test for IsHuidigespeler
        ///</summary>
        [TestMethod()]
        public void IsHuidigespelerTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler spelerX = spel.VoegSpelerToe("Speler X");
            Speler spelerY = spel.VoegSpelerToe("Speler Y");
            spel.Start();
            Assert.IsTrue(spelerX.IsHuidigespeler());
            Assert.IsFalse(spelerY.IsHuidigespeler());
        }

        /// <summary>
        ///A test for SpeelGebeurtenis
        ///</summary>
        [TestMethod()]
        public void SpeelGebeurtenisTest()
        {
            Speler speler = new Monopolyspel().VoegSpelerToe("Speler X");
            speler.BepaalGebeurtenissenBijAanvangBeurt();
            int gebeurtenisresultAantal = speler.BeurtGebeurtenissen.Result.Count;
            speler.SpeelGebeurtenis(Gebeurtenisnamen.GOOI_DOBBELSTENEN);
            Assert.IsTrue(gebeurtenisresultAantal < speler.BeurtGebeurtenissen.Result.Count);
        }

        /// <summary>
        ///A test for Verplaats
        ///</summary>
        [TestMethod()]
        public void VerplaatsTest()
        {
            Speler speler = new Monopolyspel().VoegSpelerToe("Speler x");
            Worp worp = Worp.GooiDobbelstenen();
            Spelbord bord = speler.Spel.Bord;
            int pos = bord.Velden.IndexOf(speler.Positie);
            speler.Verplaats(worp);
            int nieuwePos = bord.Velden.IndexOf(speler.Positie);
            int aantalOgen = nieuwePos - pos;
            Assert.AreEqual(worp.Totaal(), aantalOgen);
        }

    }
}
