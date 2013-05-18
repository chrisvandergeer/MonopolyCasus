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
    public class BetaalHuurTest
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
        ///A test for BetaalHuur Constructor
        ///</summary>
        [TestMethod()]
        public void BetaalHuurConstructorTest()
        {
            Speler speler = new Speler("Eigenaar");
            Straat straat = new Straat("GoingSomewhereLane", 145, new Huur(2,4,6,8,10,12));
            BetaalHuur target = new BetaalHuur(straat);
            Assert.IsNotNull(target, "Op dit moment zou de BetaalHuur gebeurtenis geinstatieerd moeten zijn.");
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            Speler eigenaar = new Speler("Eigenaar");
            Straat straat = new Straat("GoingSomewhereLane", 145, new Huur(2, 4, 6, 8, 10, 12));
            straat.Eigenaar = eigenaar;

            Speler pasant = new Speler("pasant");
            BetaalHuur target = new BetaalHuur(straat);
            bool expected = true;
            bool actual = target.VoerUit(pasant).IsUitgevoerd;

            Assert.AreEqual(expected, actual, "De huur zou betaalt moeten zijn.");

            Assert.AreEqual((Speler.SPELER_START_BEDRAG - 2), pasant.Geldeenheden,
                string.Format("De betalende speler zou nu {0} in geld moeten hebben, maar hij heeft {1}.",
                    (Speler.SPELER_START_BEDRAG - 2), pasant.Geldeenheden));

            Assert.AreEqual((Speler.SPELER_START_BEDRAG + 2), eigenaar.Geldeenheden,
                string.Format("De eigenaar zou nu {0} in geld moeten hebben, maar hij heeft {1}.",
                    (Speler.SPELER_START_BEDRAG + 2), eigenaar.Geldeenheden));
        }
    }
}
