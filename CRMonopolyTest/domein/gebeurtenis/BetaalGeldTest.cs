using CRMonopoly.domein.gebeurtenis.kans;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for BetaalGeldTest and is intended
    ///to contain all BetaalGeldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BetaalGeldTest
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
        ///A test for BetaalGeld Constructor
        ///</summary>
        [TestMethod()]
        public void BetaalGeldConstructorTest()
        {
            BetaalGeld target = createBetaalGeldGebeurtenis("BetaalGeldConstructorTest", 110);
            Assert.IsNotNull(target, "De BetaalGeld gebeurtenis instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for IsVerplicht
        ///</summary>
        [TestMethod()]
        public void IsVerplichtTest()
        {
            BetaalGeld target = createBetaalGeldGebeurtenis("IsVerplichtTest", 123);
            bool expected = true;
            bool actual = target.IsVerplicht();
            Assert.AreEqual(expected, actual, "De BetaalGeld gebeurtenis moet verplicht zijn.");
        }

        /// <summary>
        ///A test for Bedrag
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void PropertyTest()
        {
            string txt = "PropertyTest";
            int bedrag = 210;
            BetaalGeld target = createBetaalGeldGebeurtenis(txt, bedrag);
            Assert.AreEqual(txt, target.Gebeurtenisnaam,
                String.Format("De naam van de gebeurtenis is verkeerd (Exp: {0}; Act {1})", txt, target.Gebeurtenisnaam));
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTestSucceeds()
        {
            int teBetalenbedrag = 234;
            BetaalGeld target = createBetaalGeldGebeurtenis("VoerUitTest", teBetalenbedrag);
            Speler speler = new Speler("VoerUitTestSpeler");
            int expectedSpelerBedrag = speler.Geldeenheden - teBetalenbedrag;
            GebeurtenisResult actual = target.VoerUit(speler);
            Assert.AreEqual(true, actual.IsUitgevoerd, "De BetaalGeld gebeurtenis zou uitgevoerd moeten zijn.");
            Assert.AreEqual(expectedSpelerBedrag, speler.Geldeenheden, 
                String.Format("De geldbedrag zou afgeschreven moeten zijn van de speler. (Exp: {0}; Act: {1})", expectedSpelerBedrag, speler.Geldeenheden));
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTestFails()
        {
            BetaalGeld target = createBetaalGeldGebeurtenis("VoerUitTest", 2345);
            Speler speler = new Speler("VoerUitTestSpeler");
            GebeurtenisResult actual = target.VoerUit(speler);
            Assert.AreEqual(false, actual.IsUitgevoerd, "De BetaalGeld gebeurtenis zou niet uitgevoerd moeten zijn.");
        }


        private static BetaalGeld createBetaalGeldGebeurtenis(String gebeurtenisnaam, int bedrag)
        {
            BetaalGeld target = new BetaalGeld(bedrag, gebeurtenisnaam);
            return target;
        }
    }
}
