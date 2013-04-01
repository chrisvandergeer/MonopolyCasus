using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein;
using MSMonopoly.domein.gebeurtenis;

namespace MSMonopoly
{
    class Program
    {
        private Monopolyspel Spel { get; set; }
        
        static void Main(string[] args)
        {
            new Program().run();
        }

        public void run()
        {
            init();
            while (!Spel.ErIsEenVerliezer())
            {
                SpeelRonde();
                Console.ReadLine();
            }
        }

        private void init()
        {
            Spel = new Monopolyspel();
            Spel.Add(new Speler("Jan"));
            Spel.Add(new Speler("Roel"));
            Spel.Add(new Speler("Chris"));
            Beurt beurt = Spel.Start();
        }

        public void SpeelRonde()
        {
            for (int i = 0; i < Spel.AantalSpelers(); i++)
            {
                SpeelBeurt();
            }
            Spel.PrintInfo();
        }

        public void SpeelBeurt()
        {
            Beurt beurt = Spel.Beurt;
            Speler speler = beurt.Speler;
            beurt.GooiDobbelstenen();
            Console.WriteLine(beurt.Speler.Name + " gooit " + beurt.GetLaatsteWorp() + " en belandt op " + speler.HuidigePositie.Naam);
            // beurt.VoerVerplichteGebeurtenisUit();
            
            Spel.EindeBeurt();
        }
    }

}
