using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMonopoly.domein;
using CRMonopoly;

namespace CRMonopolyTest
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
            Monopolyspel spel = new Monopolyspel();
            Speler[] spelers = new Speler[2];
            spelers[0] = new Speler("DoetNix");
            spelers[1] = new Speler("Jan");
            int[] ronde = new int[2];
            int[] positie = new int[2];
            for (int teller = 0; teller < spelers.Length; teller++)
            {
                spel.Add(spelers[teller]);
                ronde[teller] = 1;
                positie[teller] = 0;
            }

            Beurt beurt = spel.Start();


            while (ronde[0] <= 3 && ronde[1] <= 3)
            {
                for (int spelerTeller = 0; spelerTeller < spelers.Length; spelerTeller++)
                {
                    int huidigePositieIndex = spel.Bord.GeefPositie(beurt.HuidigeSpeler.HuidigePositie);
                    SpelinfoLogger.Log(String.Format("Speler {0} staat nu op veld {1}.", beurt.HuidigeSpeler.Name, huidigePositieIndex));
                    beurt.SpeelBeurt();
                    beurt.EindeBeurt();
                    if (positie[spelerTeller] > huidigePositieIndex)
                    {
                        ++ronde[spelerTeller];
                    }
                    positie[spelerTeller] = huidigePositieIndex;
                }
            }
        }
    }
}
