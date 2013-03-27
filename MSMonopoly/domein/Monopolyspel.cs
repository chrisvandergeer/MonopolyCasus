using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    class Monopolyspel
    {
        private Monopolybord Bord { get; set; }
        private List<Speler> Spelers { get; set; }

        public Monopolyspel()
        {
            Bord = new Monopolybord();
            Spelers = new List<Speler>();
        }

        public void Add(Speler player)
        {
            Spelers.Add(player);
            player.Bord = Bord;
            player.HuidigePositie = Bord.StartVeld();
        }
        
        internal void Start()
        {
            if (Spelers.Count == 0)
            {
                throw new ApplicationException("Illegal state, no players added");
            }
            Spelers[0].Beurt = new Dobbelsteen();
        }

        internal Speler HuidigeSpeler()
        {
            foreach (Speler p in Spelers)
            {
                if (p.Beurt != null)
                    return p;
            }
            throw new ApplicationException("Illegal state, game not started");
        }

        public Speler WisselBeurt()
        {
            Speler huidigeSpeler = HuidigeSpeler();
            int pos = Spelers.IndexOf(huidigeSpeler);
            int posNieuweSpeler = pos < Spelers.Count - 1 ? pos + 1 : 0;
            Speler nieuweSpeler = Spelers[posNieuweSpeler];
            nieuweSpeler.Beurt = huidigeSpeler.Beurt;
            huidigeSpeler.Beurt = null;
            return  nieuweSpeler;
        }


        internal int AantalSpelers()
        {
            return Spelers.Count;
        }

        internal void PrintInfo()
        {
            foreach (Speler s in Spelers) 
            {
                Console.WriteLine(s);
            }
        }

        internal bool ErIsEenVerliezer()
        {
            foreach (Speler speler in Spelers) 
            {
                if (speler.Geldeenheden < 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
