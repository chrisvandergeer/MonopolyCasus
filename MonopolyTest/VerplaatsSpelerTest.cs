using Monopoly.domein.gebeurtenissen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein;
using Monopoly.domein.labels;

namespace MonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for VerplaatsSpelerTest and is intended
    ///to contain all VerplaatsSpelerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VerplaatsSpelerTest
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
        ///A test for CreateVerplaatsAchteruit
        ///</summary>
        [TestMethod()]
        public void CreateVerplaatsAchteruitTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler speler = spel.VoegSpelerToe("Speler X");
            Gebeurtenis verplaats = VerplaatsSpeler.CreateVerplaatsAchteruit("verplaats achteruit", spel.Bord.GeefVeld(Veldnamen.DORPSSTRAAT));
            Assert.AreEqual(0, speler.BeurtGebeurtenissen.Gebeurtenissen.Count);
            verplaats.Voeruit(speler);
            Assert.AreEqual(1, speler.BeurtGebeurtenissen.Gebeurtenissen.Count);
            Assert.IsTrue(speler.BeurtGebeurtenissen.Gebeurtenissen.Exists(g => g.Naam.Equals(Gebeurtenisnamen.KOOP_STRAAT)));
            Assert.IsTrue(speler.Positie.Naam.Equals(Veldnamen.DORPSSTRAAT));
            Assert.AreEqual("verplaats achteruit", speler.BeurtGebeurtenissen.Result[0].ResultTekst);

        }

        /// <summary>
        ///A test for CreateVerplaatsVooruit
        ///</summary>
        [TestMethod()]
        public void CreateVerplaatsVooruitNietLangsStartTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler speler = spel.VoegSpelerToe("Speler X");
            int kasgeld = speler.Bezittingen.Kasgeld;
            IGebeurtenis verplaats = VerplaatsSpeler.CreateVerplaatsVooruit("Verplaats vooruit", 1);
            verplaats.Voeruit(speler);
            Assert.AreEqual(1, speler.BeurtGebeurtenissen.Gebeurtenissen.Count);
            Assert.IsTrue(speler.BeurtGebeurtenissen.Gebeurtenissen.Exists(g => g.Naam.Equals(Gebeurtenisnamen.KOOP_STRAAT)));
            Assert.IsTrue(speler.Positie.Naam.Equals(Veldnamen.DORPSSTRAAT));
            Assert.AreEqual("Verplaats vooruit", speler.BeurtGebeurtenissen.Result[0].ResultTekst);
            Assert.AreEqual(kasgeld, speler.Bezittingen.Kasgeld);
        }

        /// <summary>
        ///A test for CreateVerplaatsVooruit
        ///</summary>
        [TestMethod()]
        public void CreateVerplaatsVooruitOverStartTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler speler = spel.VoegSpelerToe("Speler X");
            speler.Positie = spel.Bord.GeefVeld(Veldnamen.LEIDSCHESTRAAT);
            IGebeurtenis verplaats = VerplaatsSpeler.CreateVerplaatsVooruit("Verplaats vooruit", 6);
            int kasgeld = speler.Bezittingen.Kasgeld;
            verplaats.Voeruit(speler);
            Assert.AreEqual(Veldnamen.BRINK, speler.Positie.Naam);
            Assert.AreEqual(kasgeld + 200, speler.Bezittingen.Kasgeld);
        }

        /// <summary>
        ///A test for CreateVerplaatsVooruitGeenStartgeld
        ///</summary>
        [TestMethod()]
        public void CreateVerplaatsVooruitGeenStartgeldTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler speler = spel.VoegSpelerToe("Speler X");
            speler.Positie = spel.Bord.GeefVeld(Veldnamen.LEIDSCHESTRAAT);
            IGebeurtenis verplaats = VerplaatsSpeler.CreateVerplaatsVooruitGeenStartgeld("Verplaats vooruit", 6);
            int kasgeld = speler.Bezittingen.Kasgeld;
            verplaats.Voeruit(speler);
            Assert.AreEqual(Veldnamen.BRINK, speler.Positie.Naam);
            Assert.AreEqual(kasgeld, speler.Bezittingen.Kasgeld);
        }
    }
}
