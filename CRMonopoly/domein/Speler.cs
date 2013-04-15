using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;

namespace CRMonopoly.domein
{
    public class Speler
    {
        public static int SPELER_START_BEDRAG = 1500;
        public static Speler BANK = new Speler("Bank");

        private List<Straat> StratenInBezit { get; set; }
        private List<VerlaatDeGevangenis> VerlaatDeGevangenisKaarten { get; set; }

        public int Geldeenheden { get; private set; }       
        public string Name { get; set; }
        public Veld HuidigePositie { get; set; }
        public Monopolybord Bord { get; set; }
        public bool InGevangenis { get; set; }

        public Speler(string name)
        {
            Name = name;
            Geldeenheden = SPELER_START_BEDRAG;
            StratenInBezit = new List<Straat>();
            VerlaatDeGevangenisKaarten = new List<VerlaatDeGevangenis>();
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

        public List<Straat> getStraten()
        {
            return StratenInBezit;
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

        /// <summary>
        /// TODO Beurt.cs de Monopolybord.cs laten aanroepen en Verplaats daarin implemenenteren
        /// </summary>
        /// <param name="worp"></param>
        /// <returns></returns>
        public Gebeurtenis Verplaats(Worp worp)
        {
            Bord.Verplaats(this, worp);
            Veld nieuwePositie = Bord.GeefVeld(HuidigePositie, worp);
            HuidigePositie = nieuwePositie;
            return HuidigePositie.bepaalGebeurtenis(this);
        }

        public void OntvangVerlaatDeGevangenisKaart(VerlaatDeGevangenis kaart)
        {
            VerlaatDeGevangenisKaarten.Add(kaart);
        }

        public bool HeeftVerlaatDeGevangenisKaart()
        {
            return VerlaatDeGevangenisKaarten.Count > 0;
        }

        public void LeverInVerlaatDeGevangenisKaart(VerlaatDeGevangenis verlaatDeGevangenis)
        {
            VerlaatDeGevangenisKaarten.Remove(verlaatDeGevangenis);
        }
    }
}
