using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Monopoly.domein.gebeurtenissen;
using Monopoly.AI;
using Monopoly.domein.velden;
using Monopoly.domein.labels;
using Monopoly.logger;
using Microsoft.Practices.Unity;

// Usefull links: 
// Mocking framework Fakes
// http://www.richonsoftware.com/post/2012/04/05/Using-Stubs-and-Shim-to-Test-with-Microsoft-Fakes-in-Visual-Studio-11.aspx
// Mocking framework Moles (voorloper van Fakes)
//  http://research.microsoft.com/en-us/projects/moles/
// Adding Unity to Your Application
// http://msdn.microsoft.com/en-us/library/ff660927%28v=PandP.20%29.aspx
// CodeCoverage troubleshooting
// http://msdn.microsoft.com/en-us/library/jj159523.aspx

namespace Monopoly
{
    class Program
    {
        //private AIDecider aiDecider = new AIDecider();
        [Dependency]
        public SpelController controller { get; set; }
        //private SpelController controller = new SpelController();
        [Dependency]
        public ILogger myLogger { get; set; }

        static void Main(string[] args)
        {
            // Implemented Unity: 4 Singleton objects are managed by unity atm.
            // Program: This is done so Unity can inject the dependencies Controller and ai
            // MonopolyspelController: Gets injected into Program. Monopolyspel gets injected into the controller constructor.
            // Monopolyspel is used in MonopolyspelController and gets Monopolybord injected.
            // That last bit is not happening anymore. We decided against injecting the board.

            IUnityContainer container = new UnityContainer();
            container.RegisterType<Monopolyspel>("Spel");
            container.RegisterType<SpelController>("controller");
            //container.RegisterType<Spelbord>("Bord");
            container.RegisterType<Program>();
            container.RegisterType<Program>();
            container.RegisterType<ILogger, XmlLogger>();
            //container.RegisterType<ILogger, PlainTextLogger>();

            container.Resolve<Program>().run();
            Console.ReadKey();
        }

        internal void run()
        {
            myLogger.initialize();
            Monopolyspel spel = CreateGame();
            controller.StartSpel();
            int i = 0;
            while (!spel.SpelBeeindigd && i < 1000)
            {
                myLogger.rondeInfo(++i);
                SpeelRonde(spel);
                spel.Spelers.ForEach(s =>
                    myLogger.spelerTussenstand(s)
                );
            }
            myLogger.finalize();
        }
        private void SpeelRonde(Monopolyspel spel)
        {
            for (int i = 0; i < spel.Spelers.Count; i++)
            {
                myLogger.spelerBeurt(spel.HuidigeSpeler.Spelernaam);
                SpeelSpelersRonde(spel);
                controller.EindeBeurt();
                if (spel.SpelBeeindigd)
                    break;
            }
        }
        private void SpeelSpelersRonde(Monopolyspel spel)
        {
            Speler huidigeSpeler = spel.HuidigeSpeler;
            while (huidigeSpeler.BeurtGebeurtenissen.BevatNogUitTeVoerenGebeurtenissen())
            {
                string gebeurtenisnaam = huidigeSpeler.Decide();
                controller.SpeelGebeurtenis(gebeurtenisnaam);
            }
            foreach (Gebeurtenisresult result in huidigeSpeler.BeurtGebeurtenissen.VerwijderGebeurtenisResult())
            {
                myLogger.logGebeurtenis(result.ResultTekst);
            }
        }

        private void runTheOldWay()
        {
            //AddDecisions();
            Monopolyspel spel = CreateGame();
            controller.StartSpel();
            int i = 0;
            Console.WriteLine("<?xml version=\"1.0\"?>");
            Console.Write("<monopolyspel>");
            while (!spel.SpelBeeindigd && i < 1000)
            {
                Console.Write("<ronde nr='" + ++i + "'>");
                SpeelRondeTheOldWay(spel);
                Console.Write("<stand>");
                spel.Spelers.ForEach(s => 
                    Console.Write("<speler naam='" + s + "'>" + 
                        "<kasgeld>" +  s.Bezittingen.Kasgeld + "</kasgeld>" + 
                        "<straten>" + s.Bezittingen.AantalHypotheekvelden() + "</straten>" +
                        "<hypotheken>" + s.Bezittingen.AantalVeldenMetHypotheek() + "</hypotheken>" +
                        "<huizen>" + s.Bezittingen.AantalHuizen() + "</huizen>" +
                        "</speler>")
                );
                Console.Write("</stand>");
                Console.Write("</ronde>");
            }
            Console.Write("</monopolyspel>");
        }

        private void SpeelRondeTheOldWay(Monopolyspel spel)
        {
            for (int i = 0; i < spel.Spelers.Count; i++)
            {
                Console.Write("<beurt speler='" + spel.HuidigeSpeler.Spelernaam + "'>");
                SpeelSpelersRondeTheOldWay(spel);
                controller.EindeBeurt();
                Console.Write("</beurt>");
                if (spel.SpelBeeindigd)
                    break;
            }
        }
        private void SpeelSpelersRondeTheOldWay(Monopolyspel spel)
        {
            Speler huidigeSpeler = spel.HuidigeSpeler;
            while (huidigeSpeler.BeurtGebeurtenissen.BevatNogUitTeVoerenGebeurtenissen())
            {
                string gebeurtenisnaam = huidigeSpeler.Decide();
                controller.SpeelGebeurtenis(gebeurtenisnaam);
            }
            foreach (Gebeurtenisresult result in huidigeSpeler.BeurtGebeurtenissen.VerwijderGebeurtenisResult())
            {
                Console.Write("<gebeurtenis>" + result.ResultTekst + "</gebeurtenis>");
            }
        }

        private Monopolyspel CreateGame()
        {
            controller.MaakSpel();
            Monopolyspel spel = controller.Spel;
            controller.VoegSpelerToe("Chris", TypesAI.RiskyStreetBuyer);
            controller.VoegSpelerToe("Roel", TypesAI.RiskyStreetBuyer);
            controller.VoegSpelerToe("Piet", TypesAI.CarefullHouseBuilder);
            return spel;
        }

        //private void AddDecisions()
        //{
        //    aiDecider.AddDecision(Gebeurtenisnamen.KOOP_HUIS, new KoopHuisDecision());
        //    aiDecider.AddDecision(Gebeurtenisnamen.DOE_BOD_OPANDERMANSTRAAT, new DoeBodOpAndermansStraatDecision());
        //}
        
    }
}
