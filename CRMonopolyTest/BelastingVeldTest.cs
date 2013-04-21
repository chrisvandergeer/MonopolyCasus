using CRMonopoly.domein.velden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for BelastingVeldTest and is intended
    ///to contain all BelastingVeldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BelastingVeldTest
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
        ///A test for BelastingVeld Constructor
        ///</summary>
        [TestMethod()]
        public void BelastingVeldConstructorTest()
        {
            string naam = "JustSomeTax";
            int belasting = 250;
            BelastingVeld target = new BelastingVeld(naam, belasting);
            Assert.AreEqual(naam, target.Naam, String.Format("De naam van de belasting is niet correct. (Exp. {0}; Act: {1}).", naam, target));
        }

        /// <summary>
        ///A test for bepaalGebeurtenis
        ///</summary>
        [TestMethod()]
        public void bepaalGebeurtenisTest()
        {
            string naam = "SomeOtherTax";
            int belasting = 123;
            BelastingVeld target = new BelastingVeld(naam, belasting);
            Speler speler = new Speler("taxPayer");

            Gebeurtenis actual = target.bepaalGebeurtenis(speler);
            Assert.AreEqual(Gebeurtenisnamen.BETAAL_BELASTING, actual.Gebeurtenisnaam(),
                String.Format("De naam van de betaalBelastingGebeurtenis is niet correct. (Exp. {0}; Act: {1}).", Gebeurtenisnamen.BETAAL_BELASTING, actual.Gebeurtenisnaam()));

            actual.VoerUit(speler);
            Assert.IsTrue((Speler.SPELER_START_BEDRAG - belasting) == speler.Geldeenheden,
                String.Format("De BetaalBelasting gebeurtenis voert de taak niet goed uit. De Geldeenheden van de speler zijn niet correct. (Exp. {0}; Act: {1}).",
                (Speler.SPELER_START_BEDRAG - belasting), speler.Geldeenheden));
        }
    }
}
