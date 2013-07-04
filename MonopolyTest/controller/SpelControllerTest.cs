using Monopoly;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein;
using Monopoly.AI;

namespace MonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for SpelControllerTest and is intended
    ///to contain all SpelControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpelControllerTest
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
        ///A test for Spel
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Monopoly.exe")]
        public void SpelTest()
        {
            int aantalBeurten = 0;
            //AIDecider aiDecider = new AIDecider();
            SpelController controller = new SpelController();

            Monopolyspel spel = controller.MaakSpel();
            controller.VoegSpelerToe("Speler 1", TypesAI.RiskyStreetBuyer);
            controller.VoegSpelerToe("Speler 2", TypesAI.RiskyStreetBuyer);
            controller.VoegSpelerToe("Speler 3", TypesAI.RiskyStreetBuyer);
            controller.VoegSpelerToe("Speler 4", TypesAI.RiskyStreetBuyer);
            Speler speler = controller.StartSpel();
            while (!spel.SpelBeeindigd)
            {
                aantalBeurten++;
                while (speler.BeurtGebeurtenissen.BevatNogUitTeVoerenGebeurtenissen()) 
                {
                    string gebeurtenisnaam = speler.Decide();
                    controller.SpeelGebeurtenis(gebeurtenisnaam);
                }
                speler = controller.EindeBeurt();
            }
            Assert.IsTrue(aantalBeurten / spel.Spelers.Count < 500);
        }
    }
}
