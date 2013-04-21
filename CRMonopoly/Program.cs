using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

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
                SpeelBeurt(beurt);
                Spel.EindeBeurt();
            }
            Logger.LogSpelInfo(Spel);
        }

        public void SpeelBeurt(Beurt beurt)
        {
            Logger.LogStartBeurt(beurt.Speler);
            beurt.GooiDobbelstenen();
        }


    }

}
