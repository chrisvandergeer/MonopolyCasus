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
        private SpelinfoLogger Logger { get; set; }
        
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
            Monopolybord bord = Spel.Bord;
            Worp worp = beurt.GooiDobbelstenen();            
            Veld huidigePositie = speler.HuidigePositie;
            Veld nieuwePositie = bord.GeefVeld(huidigePositie, worp);
            Gebeurtenis gebeurtenis = speler.Verplaats(nieuwePositie);
            Logger.log(speler.Name, " gooit ", worp, " en verplaatst van ", huidigePositie, " naar ", nieuwePositie);
            if (gebeurtenis.VoerUit())
                Logger.log(gebeurtenis);
            Spel.EindeBeurt();
            
        }
    }

}
