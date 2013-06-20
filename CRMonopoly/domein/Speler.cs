using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;
using CRMonopoly.domein.velden;
using CRMonopoly.domein.gebeurtenis.creator;

namespace CRMonopoly.domein
{
    public class Speler
    {
        public static int SPELER_START_BEDRAG = 1500;
        public static Speler BANK = new Speler("Bank");

        public Monopolybord Bord { get; set; }

        public string Name { get; set; }
        public int Geldeenheden { get; private set; }
        public List<VerkoopbaarVeld> StratenInBezit { get; private set; }
        public List<VerlaatDeGevangenis> VerlaatDeGevangenisKaarten { get; private set; }
        public Veld HuidigePositie { get; set; }
        public bool InGevangenis { get; set; }

        public Gebeurtenissen UitTeVoerenGebeurtenissen { get; set; }
        public Worpen WorpenInHuidigeBeurt { get; set; }

        public bool GeeftOp { get; set; }

        public Speler(string name)
        {
            Name = name;
            Geldeenheden = SPELER_START_BEDRAG;
            StratenInBezit = new List<VerkoopbaarVeld>();
            VerlaatDeGevangenisKaarten = new List<VerlaatDeGevangenis>();
            WorpenInHuidigeBeurt = new Worpen();
            GeeftOp = false;
        }

        public bool Betaal(int bedrag, Speler begunstigde)
        {
            if (Betaal(bedrag))
            {
                begunstigde.Ontvang(bedrag);
                return true;
            }
            return false;
        }

        public bool Betaal(int bedrag)
        {
            if (Geldeenheden >= bedrag)
            {
                Geldeenheden -= bedrag;
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
        internal void Remove(VerkoopbaarVeld straat)
        {
            if (StratenInBezit.Contains(straat))
            {
                StratenInBezit.Remove(straat);
            }
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

        public void Verplaats()
        {
            if (!Bord.DeGevangenis.IsGevangene(this))
            {
                if (WorpenInHuidigeBeurt.Is3XDubbelGegooit())
                {
                    UitTeVoerenGebeurtenissen.Add(new GaNaarGevangenis());
                    return;
                }
                Veld oudePositie = HuidigePositie;
                Veld nieuwePositie = Bord.GeefVeld(HuidigePositie, WorpenInHuidigeBeurt.LaatsteWorp());
                HuidigePositie = nieuwePositie;
                if (Bord.IsLangsStartGekomen(nieuwePositie, oudePositie))
                {
                    UitTeVoerenGebeurtenissen.Add(new OntvangGeld(200, "U bent langs Start gekomen en ontvangt ƒ 200,00"));
                }
            }            
            UitTeVoerenGebeurtenissen.Add(HuidigePositie.bepaalGebeurtenis(this));
        }

        /// <summary>
        /// Gooi dobbelstenen
        /// </summary>
        /// <returns>true indien dubbel gegooid</returns>
        internal bool GooiDobbelstenen()
        {
            Worp worp = Worp.GooiDobbelstenen();
            WorpenInHuidigeBeurt.Add(worp);
            return worp.IsDubbelGegooid();
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
            UitTeVoerenGebeurtenissen = GebeurtenissenCreator.Instance().createGebeurtenissen(this);
            return UitTeVoerenGebeurtenissen;
        }

        internal Gebeurtenis GeefVerlaatDeGevangeniskaart()
        {
            return VerlaatDeGevangenisKaarten[0];
        }

        internal bool verwerkBodOpStraat(VerkoopbaarVeld _verkoopbaarVeld, Speler koper, int _bod)
        {
            if (_verkoopbaarVeld.Eigenaar != this)
            {   // A field that is not ours can not be sold.
                return false;
            }
            // Checking earnings
            if (_bod < geeftAcceptableBodOp(_verkoopbaarVeld)) {
                // Not accepting the offer.
                return false;
            }
            // Accepting the offer and handing over the field.
            // For now we handled the finances and the ownership of the field here, but perhaps it's better to have the Bank do it
            if (!koper.Betaal(_bod, this))
            {   // If the buyer can not pay, we do nog accept the offer
                return false;
            }
            // Hand over the field
            _verkoopbaarVeld.Eigenaar = koper;
            return true;
        }

        private int geeftAcceptableBodOp(VerkoopbaarVeld _verkoopbaarVeld)
        {   // For now we accept an offer 10% over the purchaseprice.
            return (int) (_verkoopbaarVeld.GeefAankoopprijs() * 1.1);
        }

    }
}