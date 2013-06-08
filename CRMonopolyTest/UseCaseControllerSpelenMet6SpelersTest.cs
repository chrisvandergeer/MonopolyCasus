using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMonopoly.domein;
using CRMonopoly;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.AI;
using CRMonopoly.domein.velden;

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
        [TestMethod]
        public void TestDrieSpelersDie40RondjesLopen()
        {
            MeerdereSpelersLopenRondjes(3, 40);
        }
        [TestMethod]
        public void TestTweeSpelersDie40RondjesLopen()
        {
            MeerdereSpelersLopenRondjes(2, 40);
        }
        /*        [TestMethod]
                public void TestZesSpelersDieRondjesLopenTotZeBijnaBlutZijn()
                {
                    MeerdereSpelersLopenRondjesTotZeBijnaBlutZijn(6);
                }
        */

        //// Deze test loopt nog niet omdat de spelers niet blut raken.
        //private void MeerdereSpelersLopenRondjesTotZeBijnaBlutZijn(int aantalSpelers)
        //{
        //    Monopolyspel spel = new Monopolyspel();
        //    Speler[] spelers = new Speler[aantalSpelers];
        //    int[] ronde = new int[aantalSpelers];
        //    int[] positie = new int[aantalSpelers];
        //    for (int teller = 0; teller < aantalSpelers; teller++)
        //    {
        //        spelers[teller] = new Speler(String.Format("Speler_{0}", teller + 1));
        //        spel.Add(spelers[teller]);
        //        ronde[teller] = 1;
        //        positie[teller] = 0;
        //    }
        //    MonopolyspelController controller = new MonopolyspelController(spel);
        //    ArtificialPlayerIntelligence ai = new ArtificialPlayerIntelligence();
        //    TestContext.WriteLine("MeerdereSpelersLopenRondjesTotZeBijnaBlutZijn test starts.");
        //    Speler speler = controller.StartSpel();

        //    Speler spelerMetOnvoldoendeGeld = null;
        //    while ((spelerMetOnvoldoendeGeld = everyPlayerHasMadeEnoughMoneyToPlay(spelers, 50)) == null)
        //    {
        //        for (int spelerTeller = 0; spelerTeller < spelers.Length; spelerTeller++)
        //        {
        //            controller.StartBeurt(speler);
        //            while (speler.UitTeVoerenGebeurtenissen.BevatGooiDobbelstenenGebeurtenis())
        //            {
        //                speler.UitTeVoerenGebeurtenissen.GeefDobbelstenenGebeurtenis().VoerUit(speler);
        //                speler.UitTeVoerenGebeurtenissen.LogUitgevoerdeGebeurtenissen();
        //                int huidigePositieIndex = spel.Bord.GeefPositie(speler.HuidigePositie);
        //                TestContext.WriteLine(String.Format("Speler {0} staat nu op veld {1}.", speler.Name, huidigePositieIndex));
        //                if (positie[spelerTeller] > huidigePositieIndex)
        //                {
        //                    ++ronde[spelerTeller];
        //                }
        //                positie[spelerTeller] = huidigePositieIndex;
        //                ai.HandelWorpAf(speler);
        //                speler.UitTeVoerenGebeurtenissen.LogUitgevoerdeGebeurtenissen();
        //                // Controleer of er ernstige gebeurtenissen zijn die aandacht behoeven
        //                Gebeurtenissen majorEvents = speler.UitTeVoerenGebeurtenissen.GeefGebeurtenissenVanType(GebeurtenisType.MayorEvent);
        //                if (majorEvents.GebeurtenissenCount() > 0)
        //                {
        //                    if (majorEvents.GetEnumerator().Current is GeefOp) {
        //                        ((Gebeurtenis)majorEvents.GetEnumerator().Current).VoerUit(speler);
        //                        return;
        //                    }
        //                    Console.WriteLine("Unknown major event: " + ((Gebeurtenis)majorEvents.GetEnumerator().Current).Gebeurtenisnaam);
        //                }
        //                // Nadat de standaard gebeurtenissen zijn afgehandeld zijn eventuele extra gebeurtenissen aan de beurt.
        //                ai.HandelExtraGebeurtenissenBinnenDezeWorpAf(speler, controller);
        //                speler.UitTeVoerenGebeurtenissen.LogUitgevoerdeGebeurtenissen();
        //            }
        //            speler = controller.EindeBeurt(speler);
        //        }
        //    }
        //    SpelinfoLogger.Log(String.Format("Speler {0} heeft onvoldoende geld ({1}).", spelerMetOnvoldoendeGeld.Name, spelerMetOnvoldoendeGeld.Geldeenheden));
        //}

        //private Speler everyPlayerHasMadeEnoughMoneyToPlay(Speler[] spelers, int minimumMoney)
        //{
        //    for (int teller = 0; teller < spelers.Length; teller++)
        //    {
        //        if (spelers[teller].Geldeenheden < minimumMoney)
        //        {
        //            return spelers[teller];
        //        }
        //    }
        //    return null;
        //}
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
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

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

            MonopolyspelController controller = new MonopolyspelController(spel);
            ArtificialPlayerIntelligence ai = new ArtificialPlayerIntelligence();
            TestContext.WriteLine("MeerdereSpelersLopenRondjes test starts.");
            Speler speler = controller.StartSpel();

            while ( (!everyPlayerHasMadeItXTimesAroundTheBord(ronde, aantalRondjes) ) && (! speler.GeeftOp) )
            {
                for (int spelerTeller = 0; spelerTeller < spelers.Length; spelerTeller++)
                {
                    controller.StartBeurt(speler);
                    Gebeurtenissen gebeurtenissen = speler.UitTeVoerenGebeurtenissen;
                    while (gebeurtenissen.BevatGooiDobbelstenenGebeurtenis())
                    {
                        gebeurtenissen.GeefDobbelstenenGebeurtenis().VoerUit(speler);
                        gebeurtenissen.LogUitgevoerdeGebeurtenissen();
                        int huidigePositieIndex = spel.Bord.GeefPositie(speler.HuidigePositie);
                        TestContext.WriteLine(String.Format("Speler {0} staat nu op veld {1}.", speler.Name, huidigePositieIndex));
                        if (positie[spelerTeller] > huidigePositieIndex)
                        {
                            ++ronde[spelerTeller];
                        }
                        positie[spelerTeller] = huidigePositieIndex;
                        ai.HandelWorpAf(speler);
                        gebeurtenissen.LogUitgevoerdeGebeurtenissen();
                        speler.UitTeVoerenGebeurtenissen.LogUitgevoerdeGebeurtenissen();
                        // Nadat de standaard gebeurtenissen zijn afgehandeld zijn eventuele extra gebeurtenissen aan de beurt.
                        ai.HandelExtraGebeurtenissenBinnenDezeWorpAf(speler, controller);
                        speler.UitTeVoerenGebeurtenissen.LogUitgevoerdeGebeurtenissen();
                    }
                    if (speler.GeeftOp)
                    {
                        break;
                    }
                    speler = controller.EindeBeurt(speler);
                }
            }

            // Print status.
            for (int teller = 0; teller < aantalSpelers; teller++)
            {
                SpelinfoLogger.Log(
                    String.Format("Speler {0} heeft {1} aan geld, staat op {2} en heeft {3} rondjes gelopen, heeft {4} straten, daarvan zijn er {5} stations en {6} nutsbedrijven.",
                    spelers[teller].Name, spelers[teller].Geldeenheden, spelers[teller].HuidigePositie.Naam, ronde[teller],
                    spelers[teller].getStraten().Count, spelers[teller].AantalStations(), spelers[teller].AantalNutsbedrijven()));
                SpelinfoLogger.Log(String.Format("\t{0}", getStratenVanSpeler(spelers[teller])));
                spel.Add(spelers[teller]);
                ronde[teller] = 1;
                positie[teller] = 0;
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
        private String getStratenVanSpeler(Speler speler)
        {
            StringBuilder sb = new StringBuilder();
            if (speler.StratenInBezit.Count() == 0)
            {
                sb.Append("-");
            }
            else
            {
                foreach(VerkoopbaarVeld veld in speler.StratenInBezit) {
                    if (sb.Length > 0) sb.Append(", ");
                    sb.Append(veld.Naam);
                }
            }
            return sb.ToString();
        }
    }
}
