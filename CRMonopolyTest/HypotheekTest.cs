using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.velden;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for HypotheekTest and is intended
    ///to contain all HypotheekTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HypotheekTest
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
        ///A test for Hypotheek Constructor
        ///</summary>
        [TestMethod()]
        public void HypotheekConstructorTest()
        {
            Speler spelerX = new Speler("Speler X", null);
            int koopprijs = 100;
            Straat straatY = new Straat("Straat Y", koopprijs, new Huur(1, 2, 3, 4, 5, 6));
            straatY.Eigenaar = spelerX;
            Hypotheek hypotheek = new Hypotheek(straatY);
            Assert.IsFalse(hypotheek.IsOnderHypotheek);
        }

        /// <summary>
        ///A test for LosHypotheekAf
        ///</summary>
        [TestMethod()]
        public void LosHypotheekAfTest()
        {
            Speler spelerX = new Speler("Speler X", null);
            int koopprijs = 100;
            Straat straatY = new Straat("Straat Y", koopprijs, new Huur(1, 2, 3, 4, 5, 6));
            straatY.Eigenaar = spelerX;
            Hypotheek hypotheek = new Hypotheek(straatY);
            hypotheek.NeemHypotheek();
            int kasgeldVoorAflossing = spelerX.Geldeenheden;
            bool gelukt = hypotheek.LosHypotheekAf();
            Assert.IsTrue(gelukt);
            int hypotheekbedrag = koopprijs / 2;
            int hypotheekafslosbedrag = hypotheekbedrag + (int)(hypotheekbedrag * 0.1);
            Assert.AreEqual(kasgeldVoorAflossing - hypotheekafslosbedrag, spelerX.Geldeenheden);
            Assert.IsFalse(hypotheek.IsOnderHypotheek);
        }

        /// <summary>
        ///A test for NeemHypotheek
        ///</summary>
        [TestMethod()]
        public void NeemHypotheekTest()
        {
            Speler spelerX = new Speler("Speler X", null);
            int koopprijs = 100;
            Straat straatY = new Straat("Straat Y", koopprijs, new Huur(1, 2, 3, 4, 5, 6));
            straatY.Eigenaar = spelerX;
            Hypotheek hypotheek = new Hypotheek(straatY);
            int kasgeldVoorHypotheek = spelerX.Geldeenheden;
            bool gelukt = hypotheek.NeemHypotheek();
            int hypotheekbedrag = koopprijs / 2;
            Assert.IsTrue(gelukt);
            Assert.AreEqual(kasgeldVoorHypotheek + hypotheekbedrag, spelerX.Geldeenheden);
            Assert.IsTrue(hypotheek.IsOnderHypotheek);
        }
    }
}
