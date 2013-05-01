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

        private List<VerkoopbaarVeld> StratenInBezit { get; set; }

        private List<VerlaatDeGevangenis> VerlaatDeGevangenisKaarten { get; set; }

        public int Geldeenheden { get; private set; }
        public string Name { get; set; }

        public Monopolybord Bord { get; set; }

        public Worpen WorpenInHuidigeBeurt { get; set; }

        public Veld HuidigePositie { get; set; }
        public bool InGevangenis { get; set; }


        public Speler(string name)
        {
            Name = name;
            Geldeenheden = SPELER_START_BEDRAG;
            StratenInBezit = new List<VerkoopbaarVeld>();
            VerlaatDeGevangenisKaarten = new List<VerlaatDeGevangenis>();
            WorpenInHuidigeBeurt = new Worpen();
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

        internal void Add(VerkoopbaarVeld straat)
        {
            StratenInBezit.Add(straat);
        }

        public List<VerkoopbaarVeld> getStraten()
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

        public Gebeurtenis Verplaats()
        {
            if (!Bord.DeGevangenis.IsGevangene(this))
            {
                if (WorpenInHuidigeBeurt.Is3XDubbelGegooit())
                    return new GaNaarGevangenis();
                Veld oudePositie = HuidigePositie;
                Veld nieuwePositie = Bord.GeefVeld(HuidigePositie, WorpenInHuidigeBeurt.LaatsteWorp());
                HuidigePositie = nieuwePositie;
                if (Bord.IsLangsStartGekomen(nieuwePositie, oudePositie))
                {
                    new OntvangGeld(200, "U bent langs Start gekomen en ontvangt ƒ 200,00").VoerUit(this);
                }
                SpelinfoLogger.Log(this, "staat nu op", HuidigePositie);
            }            
            return HuidigePositie.bepaalGebeurtenis(this);
        }

        internal void GooiDobbelstenen()
        {
            WorpenInHuidigeBeurt.Add(Worp.GooiDobbelstenen());
        }

        internal Boolean IsNogEenKeerGooien()
        {
            bool IsDubbelgegooit = WorpenInHuidigeBeurt.LaatsteWorp().IsDubbelGegooid();
            bool isGevangene = Bord.DeGevangenis.IsGevangene(this);
            return IsDubbelgegooit && !isGevangene;
        }

        internal int AantalNutsbedrijven()
        {
            return StratenInBezit.Count(veld => veld is Nutsbedrijf);
        }

        internal int AantalStations()
        {
            return StratenInBezit.Count(veld => veld is Station);
        }

        internal Gebeurtenissen BepaalStartgebeurtenissen()
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            if (InGevangenis && VerlaatDeGevangenisKaarten.Count > 0)
            {
                gebeurtenissen.Add(VerlaatDeGevangenisKaarten[0]);
                VerlaatDeGevangenisKaarten.RemoveAt(0);
            }
            // if speler heeft stad compleet --> Add KoopHuisGebeurtenis
            // if speler heeft straat --> Add NeemHypotheekGebeurtenis
            return gebeurtenissen;
        }
    }
}