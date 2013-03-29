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
        public Beurt Beurt { get; private set; }

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
        
        internal Beurt Start()
        {
            if (Spelers.Count < 2)
            {
                throw new ApplicationException("Illegal state, you need minimal 2 players for a game");
            }
            Beurt = new Beurt(Spelers[0]);
            return Beurt;
        }

        public void EindeBeurt()
        {
            int pos = Spelers.IndexOf(Beurt.Speler);
            int posNieuweSpeler = pos < Spelers.Count - 1 ? pos + 1 : 0;
            Beurt.Speler = Spelers[posNieuweSpeler];
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
