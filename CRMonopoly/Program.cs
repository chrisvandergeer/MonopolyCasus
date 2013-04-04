using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace MSMonopoly
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
            Spel.PrintInfo();
        }

        public void SpeelBeurt(Beurt beurt)
        {
            beurt.GooiDobbelstenen();
            Speler speler = beurt.Speler;   
            Monopolybord bord = Spel.Bord;
            Logger.log(beurt.GooiDobbelstenen());            
            //Veld huidigePositie = speler.HuidigePositie;
            //Veld nieuwePositie = bord.GeefVeld(huidigePositie, worp);
            //Gebeurtenis gebeurtenis = speler.Verplaats(nieuwePositie);
            //Logger.log(speler.Name, " gooit ", worp, " en verplaatst van ", huidigePositie, " naar ", nieuwePositie);
            //if (gebeurtenis.VoerUit())
            //    Logger.log(gebeurtenis);            
        }


    }

}
