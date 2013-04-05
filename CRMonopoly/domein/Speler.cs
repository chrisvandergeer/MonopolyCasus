using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein
{
    public class Speler
    {
        public int Geldeenheden { get; private set; }
        private List<Straat> StratenInBezit { get; set; }
        public string Name { get; set; }
        public Veld HuidigePositie { get; set; }
        public Monopolybord Bord { get; set; }

        public Speler(string name)
        {
            Name = name;
            Geldeenheden = 1500;
            StratenInBezit = new List<Straat>();
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

        public Gebeurtenis Verplaats(Veld nieuwVeld)
        {
            HuidigePositie = nieuwVeld;
            return nieuwVeld.bepaalGebeurtenis(this);
        }

        public override string ToString()
        {
            return Name + " bezit " + Geldeenheden + " geldeenheden en " + StratenInBezit.Count + " straten";
        }


        public Gebeurtenis Verplaats(Worp worp)
        {
            Veld nieuwePositie = Bord.GeefVeld(HuidigePositie, worp);
            HuidigePositie = nieuwePositie;
            return HuidigePositie.bepaalGebeurtenis(this);
        }
    }
}
