using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein
{
    public class Speler
    {
        public static int SPELER_START_BEDRAG = 1500;
        public static Speler BANK = new Speler("Bank");

        private List<Straat> StratenInBezit { get; set; }
        private List<Nutsbedrijf> NutsbedrijvenInBezit { get; set; }
        private List<Station> StationsInBezit { get; set; }

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
            NutsbedrijvenInBezit = new List<Nutsbedrijf>();
            StationsInBezit = new List<Station>();
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
        internal void Add(Nutsbedrijf nutsbedrijf)
        {
            NutsbedrijvenInBezit.Add(nutsbedrijf);
        }
        internal void Add(Station station)
        {
            StationsInBezit.Add(station);
        }

        public List<Straat> getStraten()
        {
            return StratenInBezit;
        }
        public List<Nutsbedrijf> getNutsbedrijven()
        {
            return NutsbedrijvenInBezit;
        }
        public List<Station> getStations()
        {
            return StationsInBezit;
        }


        public Gebeurtenis Verplaats(Veld nieuwVeld)
        {
            HuidigePositie = nieuwVeld;
            return nieuwVeld.bepaalGebeurtenis(this);
        }

        public override string ToString()
        {
            return Name;
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

        internal int getAantalOgenDezeBeurt()
        {
            // For now
            return 1;
        }
    }
}
