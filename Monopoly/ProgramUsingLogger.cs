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

namespace Monopoly
{
    class ProgramUsingLogger
    {
        private AIDecider aiDecider = new AIDecider();

        [Dependency]
        public SpelController controller { get; set; }
//        private SpelController controller = new SpelController();
        [Dependency]
        public ILogger myLogger { get; set; }

        internal void run()
        {
            myLogger.initialize();
            AddDecisions();
            Monopolyspel spel = CreateGame();
            controller.StartSpel();
            int i = 0;
            while (!spel.SpelBeeindigd && i < 1000)
            {
                myLogger.rondeInfo(++i);
                SpeelRonde(spel);
                //Console.Write("<stand>");
                spel.Spelers.ForEach(s => 
                    //Console.Write("<speler naam='" + s + "'>" + 
                    //    "<kasgeld>" +  s.Bezittingen.Kasgeld + "</kasgeld>" + 
                    //    "<straten>" + s.Bezittingen.AantalHypotheekvelden() + "</straten>" +
                    //    "<hypotheken>" + s.Bezittingen.AantalVeldenMetHypotheek() + "</hypotheken>" +
                    //    "<huizen>" + s.Bezittingen.AantalHuizen() + "</huizen>" +
                    //    "</speler>")
                    myLogger.spelerTussenstand(s)
                );
                //Console.Write("</stand>");
                //Console.Write("</ronde>");
            }
            myLogger.finalize();
        }

        private void SpeelRonde(Monopolyspel spel)
        {
            for (int i = 0; i < spel.Spelers.Count; i++)
            {
                //Console.Write("<beurt speler='" + spel.HuidigeSpeler.Spelernaam + "'>");
                myLogger.spelerBeurt(spel.HuidigeSpeler.Spelernaam);
                SpeelSpelersRonde(spel);
                controller.EindeBeurt();
                //Console.Write("</beurt>");
                if (spel.SpelBeeindigd)
                    break;
            }
        }

        private Monopolyspel CreateGame()
        {
            Monopolyspel spel = controller.MaakSpel();
            controller.VoegSpelerToe("Chris");
            controller.VoegSpelerToe("Roel");
            controller.VoegSpelerToe("Piet");
            return spel;
        }

        private void AddDecisions()
        {
            aiDecider.AddDecision(Gebeurtenisnamen.KOOP_HUIS, new KoopHuisDecision());
            aiDecider.AddDecision(Gebeurtenisnamen.DOE_BOD_OPANDERMANSTRAAT, new DoeBodOpAndermansStraatDecision());
        }
        
        private void SpeelSpelersRonde(Monopolyspel spel)
        {
            Speler huidigeSpeler = spel.HuidigeSpeler;
            while (huidigeSpeler.BeurtGebeurtenissen.BevatNogUitTeVoerenGebeurtenissen())
            {
                string gebeurtenisnaam = aiDecider.Decide(spel);
                controller.SpeelGebeurtenis(gebeurtenisnaam);
            }
            foreach (Gebeurtenisresult result in huidigeSpeler.BeurtGebeurtenissen.VerwijderGebeurtenisResult())
            {
                myLogger.logGebeurtenis(result.ResultTekst);
//                Console.Write("<gebeurtenis>" + result.ResultTekst + "</gebeurtenis>");
            }
        }



    }
}
