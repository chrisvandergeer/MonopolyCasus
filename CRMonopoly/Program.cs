using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

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
        private Monopolyspel Spel       { get; set; }
        private SpelinfoLogger Logger   { get; set; }
        
        static void Main(string[] args)
        {
            new Program().run();
        }

        public Program()
        {
            Logger = new SpelinfoLogger();
        }

        public void run()
        {
            init();
            while (!Spel.ErIsEenVerliezer())
            {
                // Is het wel nodig om na elke speelRonde een nieuwe Beurt aan te maken?
                Beurt beurt = Spel.Start();
                SpeelRonde(beurt);
                Console.ReadLine();
            }
        }

        private void init()
        {
            Spel = new Monopolyspel();
            Spel.Add(new Speler("Jan"));
            Spel.Add(new Speler("Roel"));
            Spel.Add(new Speler("Chris"));
        }

        public void SpeelRonde(Beurt beurt)
        {
            for (int i = 0; i < Spel.AantalSpelers(); i++)
            {
                //SpeelBeurt(beurt);
                Logger.LogStartBeurt(beurt.HuidigeSpeler);
                beurt.StartBeurt();
                Spel.EindeBeurt();
            }
            Logger.LogSpelInfo(Spel);
        }

        //public void SpeelBeurt(Beurt beurt)
        //{
        //    Logger.LogStartBeurt(beurt.HuidigeSpeler);
        //    beurt.GooiDobbelstenen();
        //    while (beurt.Worp.IsDubbelGegooid() && ! beurt.HuidigeSpeler.InGevangenis)
        //    {
        //        Logger.LogDubbelGegooidBeurt(beurt.HuidigeSpeler);
        //        beurt.GooiDobbelstenen();
        //    }
        //}


    }

}
