using CRMonopoly.AI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest.AI
{
    
    
    /// <summary>
    ///This is a test class for ArtificialPlayerIntelligenceTest and is intended
    ///to contain all ArtificialPlayerIntelligenceTest Unit Tests
    ///</summary>
    [TestClass]
    public class ArtificialPlayerIntelligenceTest
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
        Monopolybord bord;
        Monopolyspel spel;
        Speler speler1;
        Speler speler2;
        MonopolyspelController controller;

        [TestInitialize]
        public void setup()
        {
            spel = new Monopolyspel();
            controller = new MonopolyspelController(spel);
            bord = new Monopolybord();
            spel.Bord = bord;
            speler1 = new Speler("speler_1");
            speler2 = new Speler("speler_2");
            spel.Add(speler1);
            spel.Add(speler2);
        }

        /// <summary>
        ///A test for ArtificialPlayerIntelligence Constructor
        ///</summary>
        [TestMethod]
        public void ArtificialPlayerIntelligenceConstructorTest()
        {
            ArtificialPlayerIntelligence target = new ArtificialPlayerIntelligence();
            Assert.IsNotNull(target, "De instance van ArtificialPlayerIntelligence mag niet null zijn.");
        }

        /// <summary>
        ///A test for HandelWorpAf
        ///</summary>
        [TestMethod]
        public void HandelWorpAf_OntvangGeldTest()
        {
            ArtificialPlayerIntelligence target = new ArtificialPlayerIntelligence();
            speler1.UitTeVoerenGebeurtenissen = new Gebeurtenissen();
            int teOntvangenBedrag = 150;
            speler1.UitTeVoerenGebeurtenissen.Add(new OntvangGeld(teOntvangenBedrag, "Test verwerking"));
            Assert.AreEqual(Speler.SPELER_START_BEDRAG, speler1.Geldeenheden, "De speler moet het start bedrag bezitten.");
            target.HandelWorpAf(speler1);
            int expected = Speler.SPELER_START_BEDRAG + teOntvangenBedrag;
            Assert.AreEqual(expected, speler1.Geldeenheden,
                String.Format("De speler moet geld bijgekregen hebben (Exp: {0}; Act: {1}).", expected, speler1.Geldeenheden));
            speler1.UitTeVoerenGebeurtenissen.LogUitgevoerdeGebeurtenissen();
        }

        /// <summary>
        ///A test for HandelWorpAf
        ///</summary>
        [TestMethod]
        public void HandelWorpAf_OntvangEnBetaalGeldTest()
        {
            ArtificialPlayerIntelligence target = new ArtificialPlayerIntelligence();
            speler1.UitTeVoerenGebeurtenissen = new Gebeurtenissen();
            int teOntvangenBedrag = 199;
            int teBetalenBedrag = 201;
            speler1.UitTeVoerenGebeurtenissen.Add(new BetaalBelasting("TestBelasting", teBetalenBedrag));
            speler1.UitTeVoerenGebeurtenissen.Add(new OntvangGeld(teOntvangenBedrag, "Test verwerking"));
            Assert.AreEqual(2, speler1.UitTeVoerenGebeurtenissen.GebeurtenissenCount(), "Er moeten nu 2 gebeurtenissen beschikbaar zijn.");
            Assert.AreEqual(Speler.SPELER_START_BEDRAG, speler1.Geldeenheden, "De speler moet het start bedrag bezitten.");
            target.HandelWorpAf(speler1);
            int expected = Speler.SPELER_START_BEDRAG + teOntvangenBedrag - teBetalenBedrag;
            Assert.AreEqual(expected, speler1.Geldeenheden,
                String.Format("De hoeveelheid geld van de speler moet verandert zijn (Exp: {0}; Act: {1}).", expected, speler1.Geldeenheden));
            Assert.AreEqual(0, speler1.UitTeVoerenGebeurtenissen.GebeurtenissenCount(), "All gebeurtenissen moeten nu verwerkt zijn.");
            speler1.UitTeVoerenGebeurtenissen.LogUitgevoerdeGebeurtenissen();
        }

        /// <summary>
        ///A test for HandelWorpAf
        ///</summary>
        [TestMethod]
        public void HandelWorpAf_OntvangEnOptioneleBetaalGeldTest() // Wordt in het spel niet gebruikt, mar kan wel werken voor andere verwerkingen.
        {
            ArtificialPlayerIntelligence target = new ArtificialPlayerIntelligence();
            speler1.UitTeVoerenGebeurtenissen = new Gebeurtenissen();
            int teOntvangenBedrag = 199;
            int teBetalenBedrag = 201;
            speler1.UitTeVoerenGebeurtenissen.Add(new OntvangGeld(teOntvangenBedrag, "Test verwerking"));
            BetaalBelasting bel = new OptioneleBetaalBelasting("TestBelasting", teBetalenBedrag);
            speler1.UitTeVoerenGebeurtenissen.Add(bel);
            Assert.AreEqual(2, speler1.UitTeVoerenGebeurtenissen.GebeurtenissenCount(), "Er moeten nu 2 gebeurtenissen beschikbaar zijn.");
            Assert.AreEqual(Speler.SPELER_START_BEDRAG, speler1.Geldeenheden, "De speler moet het start bedrag bezitten.");
            target.HandelWorpAf(speler1);
            int expected = Speler.SPELER_START_BEDRAG + teOntvangenBedrag;
            Assert.AreEqual(expected, speler1.Geldeenheden,
                String.Format("De hoeveelheid geld van de speler moet verandert zijn (Exp: {0}; Act: {1}).", expected, speler1.Geldeenheden));
            Assert.AreEqual(0, speler1.UitTeVoerenGebeurtenissen.GebeurtenissenCount(), "All gebeurtenissen moeten nu verwerkt zijn.");
            Assert.AreEqual(2, speler1.UitTeVoerenGebeurtenissen.GebeurtenissenResultCount(), "All gebeurtenissen hadden hun resultaten moeten teruggeven.");
            speler1.UitTeVoerenGebeurtenissen.LogUitgevoerdeGebeurtenissen();
        }

        ///// <summary>
        /////A test for handelGebeurtenissenAfVanType
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("CRMonopoly.exe")]
        //public void handelGebeurtenissenAfVanTypeTest()
        //{
        //    ArtificialPlayerIntelligence_Accessor target = new ArtificialPlayerIntelligence_Accessor(); // TODO: Initialize to an appropriate value
        //    GebeurtenisType gebeurtenisType = new GebeurtenisType(); // TODO: Initialize to an appropriate value
        //    Speler speler = null; // TODO: Initialize to an appropriate value
        //    bool altijdUitvoeren = false; // TODO: Initialize to an appropriate value
        //    target.handelGebeurtenissenAfVanType(gebeurtenisType, speler, altijdUitvoeren);
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        ///// <summary>
        /////A test for handelVerplichteGebeurtenissenAf
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("CRMonopoly.exe")]
        //public void handelVerplichteGebeurtenissenAfTest()
        //{
        //    ArtificialPlayerIntelligence_Accessor target = new ArtificialPlayerIntelligence_Accessor(); // TODO: Initialize to an appropriate value
        //    Speler speler = null; // TODO: Initialize to an appropriate value
        //    target.handelVerplichteGebeurtenissenAf(speler);
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}
    }

    class OptioneleBetaalBelasting : BetaalBelasting
    {
        public OptioneleBetaalBelasting(string id, int belasting)
            : base(id, belasting)
        {
        }
        public override bool IsVerplicht()
        {
            return false;
        }
    }
}
