using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    public class Speler
    {
        public int Geldeenheden { get; private set; }
        private List<Straat> StratenInBezit { get; set; }

        public string Name { get; set; }
        public Dobbelsteen Beurt { get; set; }
        public Monopolybord Bord { get; set; }
        public Veld HuidigePositie { get; set; }

        public Speler(string name)
        {
            Name = name;
            Geldeenheden = 150;
            StratenInBezit = new List<Straat>();
        }

        internal Worp GooiDobbelstenen()
        {
            return Beurt.Gooi2Dobbelstenen();
        }

        internal void Verplaats(Worp worp)
        {
            HuidigePositie = Bord.GeefVeld(HuidigePositie, worp);
        }

        internal bool Betaal(int bedrag, Speler begunstigde)
        {
            if (Geldeenheden >= bedrag)
            {
                Geldeenheden -= bedrag;
                begunstigde.Ontvang(bedrag);
                return true;
            }
            return false;
        }

        internal void Ontvang(int bedrag)
        {
            Geldeenheden += bedrag;
        }

        internal void Add(Straat straat)
        {
            StratenInBezit.Add(straat);
        }

        public override string ToString()
        {
            return Name + " bezit " + Geldeenheden + " geldeenheden en " + StratenInBezit.Count + " straten";
        }
    }
}
