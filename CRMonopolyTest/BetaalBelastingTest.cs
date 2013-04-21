using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for BetaalBelastingTest and is intended
    ///to contain all BetaalBelastingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BetaalBelastingTest
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
        ///A test for BetaalBelasting Constructor
        ///</summary>
        [TestMethod()]
        public void BetaalBelastingConstructorTest()
        {
            string id = "BetaalBelastingGebeurtenis";
            int belasting = 500;
            BetaalBelasting target = new BetaalBelasting(id, belasting);
            Assert.IsNotNull(target, "De BetaalBelastingGebeurtenis kon niet geinstantieerd worden.");
        }

        /// <summary>
        ///A test for Gebeurtenisnaam
        ///</summary>
        [TestMethod()]
        public void GebeurtenisnaamTest()
        {
            string id = "SomeTax";
            int belasting = 234;
            BetaalBelasting target = new BetaalBelasting(id, belasting);
            string actual = target.Gebeurtenisnaam();
            Assert.AreEqual(Gebeurtenisnamen.BETAAL_BELASTING, target.Gebeurtenisnaam(),
                String.Format("De naam van de gebeurtenis is niet correct. (Exp. {0}; Act: {1}).", Gebeurtenisnamen.BETAAL_BELASTING, target.Gebeurtenisnaam()));
        }

        /// <summary>
        ///A test for IsVerplicht
        ///</summary>
        [TestMethod()]
        public void IsVerplichtTest()
        {
            string id = "verplichteBelasting";
            int belasting = 0;
            BetaalBelasting target = new BetaalBelasting(id, belasting);
            bool expected = true;
            bool actual = target.IsVerplicht();
            Assert.AreEqual(expected, actual, String.Format("Het verplichte karakter van deze gebeurtenis is niet correct. (Exp. {0}; Act: {1}).", expected, target.IsVerplicht()));
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            string id = "VoerUitTax";
            int belasting = 543;
            BetaalBelasting target = new BetaalBelasting(id, belasting);
            Speler speler = new Speler("SomeTaxPayer");
            bool expected = true;
            bool actual = target.VoerUit(speler);
            Assert.AreEqual(expected, actual, String.Format("De uitvoer van deze gebeurtenis zou niet moeten falen. (Exp. {0}; Act: {1}).", expected, actual));
            Assert.AreEqual((Speler.SPELER_START_BEDRAG - belasting), speler.Geldeenheden,
                String.Format("De uitvoer van deze gebeurtenis is niet goed uitgevoerd. Het geld van de speler is niet correct. (Exp. {0}; Act: {1}).", 
                (Speler.SPELER_START_BEDRAG - belasting), speler.Geldeenheden));
        }
    }
}
