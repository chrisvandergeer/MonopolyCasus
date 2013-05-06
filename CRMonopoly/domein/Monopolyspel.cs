using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein
{
    public class Monopolyspel
    {
        public List<Speler> Spelers { get; private set; }
        public Monopolybord Bord { get; private set; }
        public MonopolyspelController Beurt { get; private set; }

        public Monopolyspel()
        {
            Bord = new Monopolybord();
            Spelers = new List<Speler>();
        }

        public bool Add(Speler player)
        {
            foreach(Speler speler in Spelers)
            {
                if (speler.Name.Equals(player.Name)) return false;
            }
            Spelers.Add(player);
            player.HuidigePositie = Bord.StartVeld();
            player.Bord = Bord;
            return true;
        }

        internal int AantalSpelers()
        {
            return Spelers.Count;
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
