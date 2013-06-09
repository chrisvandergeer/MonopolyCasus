using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.builders;
using CRMonopoly.domein.velden;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein
{
    public class Monopolybord : HuurChangeListener
    {
        private SpelinfoLogger Logger { get; set; }
        private List<Veld> Velden;
        private int huidigeMaximumHuur = 0;
        public Gevangenis DeGevangenis { get; private set; }
     
        public Monopolybord()
        {
            Velden = new List<Veld>();
            DeGevangenis = new Gevangenis();
            layoutBord();
            Velden.ForEach(veld => veld.Bord = this);
            Velden.ForEach(veld => veld.addHuurChangeListener(this));
        }

        private void layoutBord()
        {
            layoutBottomRowIncludingCorners();
            layoutLeftRowWithoutCorners();
            layoutTopRowIncludingCorners();
            layoutRightRowWithoutCorners();
        }

        private void layoutRightRowWithoutCorners()
        {
            Velden.Add(RotterdamBuilder.Instance.Rotterdam.getStraatByName(RotterdamBuilder.HOFPLEIN));
            Velden.Add(RotterdamBuilder.Instance.Rotterdam.getStraatByName(RotterdamBuilder.BLAAK));
            Velden.Add(KansEnAlgemeenFondsVeldBuilder.Instance.getAlgemeenFondsVeld(this));
            Velden.Add(RotterdamBuilder.Instance.Rotterdam.getStraatByName(RotterdamBuilder.COOLSINGEL));
            Velden.Add(Stationbuilder.Instance.Oost());
            Velden.Add(KansEnAlgemeenFondsVeldBuilder.Instance.getKansVeld(this));
            Velden.Add(AmsterdamBuilder.Instance.Amsterdam.getStraatByName(AmsterdamBuilder.LEIDSESTRAAT));
            Velden.Add(BelastingVeldenBuilder.Instance.BelastingVelden.getBelastingveldByName(BelastingVeldenBuilder.EXTRAINKOMSTENBELASTING));
            Velden.Add(AmsterdamBuilder.Instance.Amsterdam.getStraatByName(AmsterdamBuilder.KALVERSTRAAT));
        }

        private void layoutTopRowIncludingCorners()
        {
            Velden.Add(new VrijParkeren());
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByName(GroningenBuilder.ALGEMENE_KERKHOF));
            Velden.Add(KansEnAlgemeenFondsVeldBuilder.Instance.getKansVeld(this));
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByName(GroningenBuilder.GROTE_MARKT));
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByName(GroningenBuilder.HEERESTRAAT));
            Velden.Add(Stationbuilder.Instance.Noord());
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByName(DenHaagBuilder.SPUI));
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByName(DenHaagBuilder.PLEIN));
            Velden.Add(NutsbedrijvenBuilder.Instance.NutsBedrijven.getBedrijfByName(NutsbedrijvenBuilder.WATERLEIDING));
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByName(DenHaagBuilder.LANGE_POTEN));
            Velden.Add(new GaNaarGevangenisVeld());
        }

        private void layoutLeftRowWithoutCorners()
        {
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByName(HaarlemBuilder.BARTELJORISSTRAAT));
            Velden.Add(NutsbedrijvenBuilder.Instance.NutsBedrijven.getBedrijfByName(NutsbedrijvenBuilder.ELEKTRICITEITSBEDRIJF));
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByName(HaarlemBuilder.ZIJLWEG));
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT));
            Velden.Add(Stationbuilder.Instance.West());
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByName(UtrechtBuilder.NEUDE));
            Velden.Add(KansEnAlgemeenFondsVeldBuilder.Instance.getAlgemeenFondsVeld(this));
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByName(UtrechtBuilder.BILTSTRAAT));
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByName(UtrechtBuilder.VREEBURG));
        }

        private void layoutBottomRowIncludingCorners()
        {
            Velden.Add(new Start());
            Velden.Add(OnsDorpBuilder.Instance.OnsDorp.getStraatByName(OnsDorpBuilder.DORPSSTRAAT));
            Velden.Add(KansEnAlgemeenFondsVeldBuilder.Instance.getAlgemeenFondsVeld(this));
            Velden.Add(OnsDorpBuilder.Instance.OnsDorp.getStraatByName(OnsDorpBuilder.BRINK));
            Velden.Add(BelastingVeldenBuilder.Instance.BelastingVelden.getBelastingveldByName(BelastingVeldenBuilder.INKOMSTENBELASTING));
            Velden.Add(Stationbuilder.Instance.Zuid());
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByName(ArnhemBuilder.STEENSTRAAT));
            Velden.Add(KansEnAlgemeenFondsVeldBuilder.Instance.getKansVeld(this));
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByName(ArnhemBuilder.KETELSTRAAT));
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByName(ArnhemBuilder.VELPERPLEIN));
            Velden.Add(DeGevangenis);
        }

        internal Veld StartVeld()
        {
            return Velden[0];
        }

        public int GeefPositie(Veld veld)
        {
            return Velden.IndexOf(veld);
        }

        internal Veld GeefVeld(String veldnaam)
        {
            foreach (Veld tempVeld in Velden)
            {
                if (tempVeld.Naam.Equals(veldnaam))
                {
                    return tempVeld;
                }
            }
            return null;
        }
        internal List<Veld> GeefAlleVelden()
        {
            return Velden;
        }

        internal Veld GeefVeld(Veld veld, Worp worp)
        {
            int pos = Velden.IndexOf(veld);
            int nieuwePos = pos + worp.Totaal();
            if (nieuwePos >= Velden.Count)
            {
                nieuwePos = nieuwePos - Velden.Count;
            }
            return Velden[nieuwePos];
        }

        public Straat getBarteljorisstraat()
        {
            int pos = Velden.IndexOf(HaarlemBuilder.Instance.Haarlem.getStraatByName(HaarlemBuilder.BARTELJORISSTRAAT));
            return (Straat) Velden[pos];
        }

        public Straat Straat(string straatnaam)
        {
            int pos = Velden.IndexOf(new Straat(straatnaam));
            return (Straat) Velden[pos];
        }

        public Station GeefStationWest()
        {
            int pos = Velden.IndexOf(Stationbuilder.Instance.West());
            return (Station) Velden[pos];
        }

        public bool IsLangsStartGekomen(Veld nieuwePositie, Veld oudePositie)
        {
            return Velden.IndexOf(nieuwePositie) < Velden.IndexOf(oudePositie);
        }

        public void informHuurChange(int maxVeldHuur)
        {
            if (maxVeldHuur > huidigeMaximumHuur)
            {
                huidigeMaximumHuur = maxVeldHuur;
            }
        }
        public int geefMaximalHuurprijs()
        {
            return huidigeMaximumHuur;
        }
        public Veld GeefVeld(Veld huidigVeld, int aantalStappen)
        {
            int aantalVelden = Velden.Count;
            int huidigePos = GeefPositie(huidigVeld);
            int nieuwePos = huidigePos + aantalStappen;
            if (nieuwePos < 0)
                nieuwePos = aantalVelden + nieuwePos;
            else if (nieuwePos >= aantalVelden)
                nieuwePos = nieuwePos - aantalVelden;
            return Velden[nieuwePos];
        }

        public List<VerkoopbaarVeld> geefMogelijkeAankopenVoorSpeler(Speler huidigeSpeler)
        {
            List<VerkoopbaarVeld> stratenVoorEenBod = new List<VerkoopbaarVeld>();
            foreach(Veld veld in Velden) {
                if (veld is VerkoopbaarVeld)
                {
                    VerkoopbaarVeld verkoopbaarVeld = (VerkoopbaarVeld)veld;
                    if (verkoopbaarVeld.heeftEigenaar() && verkoopbaarVeld.Eigenaar != huidigeSpeler)
                    {
                        stratenVoorEenBod.Add(verkoopbaarVeld);
                    }
                }
            }
            return stratenVoorEenBod;
        }

        internal int geeftAantalStratenInDeStadVanDezeStraatDieInBezitZijnVanSpeler(VerkoopbaarVeld verkoopbaarVeld, Speler speler)
        {
            int aantal = 0;
            if (verkoopbaarVeld is Nutsbedrijf)
            {
                aantal = geefAantalNutsbedrijvenInBezitVanSpeler(speler);
            }
            else if (verkoopbaarVeld is Station)
            {
                aantal = geefAantalStationsInBezitVanSpeler(speler);
            }
            else if (verkoopbaarVeld is Straat)
            {
                aantal = geefAantalStratenInDezelfdeStadInBezitVanSpeler(speler, (Straat) verkoopbaarVeld);
            }
            return aantal;
        }

        private int geefAantalStratenInDezelfdeStadInBezitVanSpeler(Speler speler, Straat straat)
        {
            Stad stad = geeftStadVanDezeStraat(straat);
            int aantal = 0;
            // TODO: Implementeren met ?? macro
            foreach (Straat tempStraat in stad.Straten)
            {
                if (tempStraat.Eigenaar == speler)
                {
                    aantal++;
                }
            }
            return aantal;
        }

        private Stad geeftStadVanDezeStraat(Straat straat)
        {
            if (OnsDorpBuilder.Instance.OnsDorp.Contains(straat))
            {
                return OnsDorpBuilder.Instance.OnsDorp;
            }
            else if (ArnhemBuilder.Instance.Arnhem.Contains(straat))
            {
                return ArnhemBuilder.Instance.Arnhem;
            }
            else if (UtrechtBuilder.Instance.Utrecht.Contains(straat))
            {
                return UtrechtBuilder.Instance.Utrecht;
            }
            else if (HaarlemBuilder.Instance.Haarlem.Contains(straat))
            {
                return HaarlemBuilder.Instance.Haarlem;
            }
            else if (DenHaagBuilder.Instance.DenHaag.Contains(straat))
            {
                return DenHaagBuilder.Instance.DenHaag;
            }
            else if (GroningenBuilder.Instance.Groningen.Contains(straat))
            {
                return GroningenBuilder.Instance.Groningen;
            }
            else if (RotterdamBuilder.Instance.Rotterdam.Contains(straat))
            {
                return RotterdamBuilder.Instance.Rotterdam;
            }
            else if (AmsterdamBuilder.Instance.Amsterdam.Contains(straat))
            {
                return AmsterdamBuilder.Instance.Amsterdam;
            }
            return null;
        }

        private int geefAantalStationsInBezitVanSpeler(Speler speler)
        {
            int aantal = 0;
            // TODO: Implementeren met ?? macro
            foreach (Station station in Stationbuilder.Instance.Stations.Values)
            {
                if (station.Eigenaar == speler)
                {
                    aantal++;
                }
            }
            return aantal;
        }

        private static int geefAantalNutsbedrijvenInBezitVanSpeler(Speler speler)
        {
            int aantal = 0;
            // TODO: Implementeren met ?? macro
            foreach (Nutsbedrijf nutsbedrijf in NutsbedrijvenBuilder.Instance.NutsBedrijven.AlleNutsBedrijven)
            {
                if (nutsbedrijf.Eigenaar == speler)
                {
                    aantal++;
                }
            }
            return aantal;
        }
    }
}
