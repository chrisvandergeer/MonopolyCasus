using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.domein;
using Monopoly;
using Monopoly.domein.gebeurtenissen;
using Monopoly.AI;

namespace MonopolyTest
{
    [TestClass]
    public class UseCaseControllerSpelenMet2SpelersTest
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

        [TestMethod]
        public void BeideSpelersLopen3Rondjes()
        {
            //AIDecider aiDecider = new AIDecider();
            SpelController controller = new SpelController();
            Monopolyspel spel = controller.MaakSpel();
            controller.VoegSpelerToe("DoetNix", TypesAI.RiskyStreetBuyer);
            controller.VoegSpelerToe("Jan", TypesAI.RiskyStreetBuyer);

            Speler[] spelers = new Speler[2];
            spelers[0] = spel.Spelers[0];
            spelers[1] = spel.Spelers[1];
            int[] ronde = new int[2];
            int[] positie = new int[2];
            // AbstractPlayerAI ai = new AbstractPlayerAI();

            TestContext.WriteLine("BeideSpelersLopen3Rondjes test starts.");
            controller.StartSpel();
            while (ronde[0] <= 3 && ronde[1] <= 3)
            {
                for(int spelerTeller = 0; spelerTeller < spelers.Count(); spelerTeller++) 
                {
                    Speler huidigeSpeler = spel.HuidigeSpeler;
                    while (huidigeSpeler.BeurtGebeurtenissen.BevatNogUitTeVoerenGebeurtenissen())
                    {
                        string gebeurtenisnaam = huidigeSpeler.Decide();
                        controller.SpeelGebeurtenis(gebeurtenisnaam);
                    }
                    int huidigePositieIndex = huidigeSpeler.Spel.Bord.GeefVeldIndex(huidigeSpeler.Positie);
                    TestContext.WriteLine(String.Format("Speler {0} staat nu op veld {1} (Pos: {2}).", huidigeSpeler.Spelernaam, huidigeSpeler.Positie.Naam, huidigePositieIndex));
                    if (positie[spelerTeller] > huidigePositieIndex)
                    {
                        ++ronde[spelerTeller];
                    }
                    positie[spelerTeller] = huidigePositieIndex;
                    controller.EindeBeurt();
                }
            }
            TestContext.WriteLine("BeideSpelersLopen3Rondjes test finished.");
        }
    }
}
