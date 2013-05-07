using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.AI;

// Usefull links: 
// Mocking framework Fakes
// http://www.richonsoftware.com/post/2012/04/05/Using-Stubs-and-Shim-to-Test-with-Microsoft-Fakes-in-Visual-Studio-11.aspx
// Mocking framework Moles (voorloper van Fakes)
//  http://research.microsoft.com/en-us/projects/moles/
// Adding Unity to Your Application
// http://msdn.microsoft.com/en-us/library/ff660927%28v=PandP.20%29.aspx

namespace CRMonopoly
{
    class Program
    {
        private MonopolyspelController Controller   { get; set; }
        private Speler HuidigeSpeler                { get; set; }
        
        static void Main(string[] args)
        {
            new Program().run();
        }

        public void run()
        {
            init();
            HuidigeSpeler = Controller.StartSpel();
            while (true)
            {
                SpeelRonde();
                Console.ReadLine();
            }
        }

        private void init()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Jan"));
            spel.Add(new Speler("Roel"));
            spel.Add(new Speler("Chris"));
            Controller = new MonopolyspelController(spel);
        }

        public void SpeelRonde()
        {
            for (int i = 0; i < Controller.Spel.AantalSpelers(); i++)
            {                
                SpelinfoLogger.NewlineLog("Speler", HuidigeSpeler, "start de beurt vanaf ", HuidigeSpeler.HuidigePositie);
                SpeelSpelersbeurt();
            }
            SpelinfoLogger.LogSpelInfo(Controller.Spel);
        }

        public void SpeelSpelersbeurt()
        {
            Gebeurtenissen gebeurtenissen = Controller.StartBeurt(HuidigeSpeler);
            while (gebeurtenissen.bevatGooiDobbelstenenGebeurtenis())
            {
                gebeurtenissen.GeefDobbelstenenGebeurtenis().VoerUit(HuidigeSpeler);
                ArtificialPlayerIntelligence.Instance().HandelWorpAf(gebeurtenissen, HuidigeSpeler);
                gebeurtenissen.LogUitgevoerdeGebeurtenissen();
            }
            HuidigeSpeler = Controller.EindeBeurt(HuidigeSpeler);
        }

    }

}
