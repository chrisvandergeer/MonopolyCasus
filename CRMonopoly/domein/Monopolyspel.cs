﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein
{
    class Monopolyspel
    {
        private List<Speler> Spelers { get; set; }
        public Monopolybord Bord { get; private set; }
        public Beurt Beurt { get; private set; }

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

        internal Beurt Start()
        {
            if (Spelers.Count < 2 || Spelers.Count > 8)
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
            Beurt.WisselBeurt(Spelers[posNieuweSpeler]);
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
