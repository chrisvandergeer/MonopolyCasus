﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMonopoly.domein;
using CRMonopoly;

namespace CRMonopolyTest
{
    [TestClass]
    public class UseCaseControllerSpelenMet6SpelersTest
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

        [TestMethod]
        public void TestZesSpelersDie3RondjesLopen()
        {
            MeerdereSpelersLopenRondjes(6, 3);
        }
        [TestMethod]
        public void TestZesSpelersDie10RondjesLopen()
        {
            MeerdereSpelersLopenRondjes(6, 10);
        }
        [TestMethod]
        public void TestZesSpelersDie20RondjesLopen()
        {
            MeerdereSpelersLopenRondjes(6, 20);
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

        private void MeerdereSpelersLopenRondjes(int aantalSpelers, int aantalRondjes)
        {
            SpelinfoLogger logger = new SpelinfoLogger();
            Monopolyspel spel = new Monopolyspel();
            Speler[] spelers = new Speler[aantalSpelers];
            int[] ronde = new int[aantalSpelers];
            int[] positie = new int[aantalSpelers];
            for (int teller = 0; teller < aantalSpelers; teller++)
            {
                spelers[teller] = new Speler(String.Format("Speler_{0}", teller + 1));
                spel.Add(spelers[teller]);
                ronde[teller] = 1;
                positie[teller] = 0;
            }

            Beurt beurt = spel.Start();

            while (! everyPlayerHasMadeItXTimesAroundTheBord(ronde, aantalRondjes))
            {
                for (int spelerTeller = 0; spelerTeller < spelers.Length; spelerTeller++)
                {
                    int huidigePositieIndex = spel.Bord.GeefPositie(beurt.Speler.HuidigePositie);
                    logger.log(String.Format("{0} staat nu op veld {1}.", beurt.Speler.Name, huidigePositieIndex));
                    beurt.GooiDobbelstenen();
                    spel.EindeBeurt();
                    if (positie[spelerTeller] > huidigePositieIndex)
                    {
                        ++ronde[spelerTeller];
                    }
                    positie[spelerTeller] = huidigePositieIndex;
                }
            }
        }

        private bool everyPlayerHasMadeItXTimesAroundTheBord(int[] ronde, int aantalRondjes)
        {
            for (int teller = 0; teller < ronde.Length; teller++)
            {
                if (ronde[teller] < aantalRondjes)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
