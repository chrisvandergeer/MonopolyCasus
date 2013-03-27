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
        private Monopolyspel game;
        
        static void Main(string[] args)
        {
            new Program().run();
        }

        public void run()
        {
            init();
            while (!game.ErIsEenVerliezer())
            {
                SpeelRonde();
                Console.ReadLine();
            }
        }

        private void init()
        {
            game = new Monopolyspel();
            game.Add(new Speler("Jan"));
            game.Add(new Speler("Roel"));
            game.Add(new Speler("Chris"));
            game.Start();
        }

        public void SpeelRonde()
        {            
            for (int i = 0; i < game.AantalSpelers(); i++)
            {
                SpeelBeurt();
            }
            game.PrintInfo();
        }

        public void SpeelBeurt()
        {
            Speler speler = game.HuidigeSpeler();
            Worp worp = speler.GooiDobbelstenen();
            speler.Verplaats(worp);
            Console.WriteLine(speler.Name + " gooit " + worp + " en belandt op " + speler.HuidigePositie.Naam);
            Gebeurtenis gebeurtenis = speler.HuidigePositie.bepaalGebeurtenis(speler);
            gebeurtenis.VoerGebeurtenisUit();
            Console.WriteLine(gebeurtenis);
            speler = game.WisselBeurt();
        }
    }

}
