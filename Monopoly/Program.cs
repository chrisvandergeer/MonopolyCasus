using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Monopoly.domein.gebeurtenissen;
using Monopoly.AI;
using Monopoly.domein.velden;
using Monopoly.domein.labels;

namespace Monopoly
{
    class Program
    {
        private AIDecider aiDecider = new AIDecider();
        private SpelController controller = new SpelController();

        static void Main(string[] args)
        {
            new Program().run();
        }

        private void run()
        {
            AddDecisions();
            Monopolyspel spel = CreateGame();
            controller.StartSpel();
            int i = 0;
            Console.WriteLine("<?xml version=\"1.0\"?>");
            Console.Write("<monopolyspel>");
            while (!spel.SpelBeeindigd && i < 1000)
            {
                Console.Write("<ronde nr='" + ++i + "'>");
                SpeelRonde(spel);
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

        private void SpeelRonde(Monopolyspel spel)
        {
            for (int i = 0; i < spel.Spelers.Count; i++)
            {
                Console.Write("<beurt speler='" + spel.HuidigeSpeler.Spelernaam + "'>");
                SpeelSpelersRonde(spel);
                controller.EindeBeurt();
                Console.Write("</beurt>");
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
                Console.Write("<gebeurtenis>" + result.ResultTekst + "</gebeurtenis>");
            }
        }



    }
}
