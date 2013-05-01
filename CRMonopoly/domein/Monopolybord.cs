using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.builders;
using CRMonopoly.domein.velden;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein
{
    public class Monopolybord
    {
        public static readonly string ALGEMEEN_FONDS_NAAM = "Algemeen Fonds";
        public static readonly string KANS_NAAM = "Kans";

        private SpelinfoLogger Logger { get; set; }
        private List<Veld> Velden;
        private KansEnAlgemeenfondsVeld Kans { get; set; }
        private KansEnAlgemeenfondsVeld AlgemeenFonds { get; set; }
        public Gevangenis DeGevangenis { get; private set; }
        
        public Monopolybord()
        {
            Velden = new List<Veld>();
            Kans = new KansEnAlgemeenfondsVeld("Kans");
            AlgemeenFonds = new KansEnAlgemeenfondsVeld("Algemeen Fonds");
            DeGevangenis = new Gevangenis();
            layoutBord();
            Velden.ForEach(veld => veld.Bord = this);
            Kans.Kaarten = new KanskaartBuilder(this).build();
            AlgemeenFonds.Kaarten = new AlgemeenFondsBuilder(this).build();
        }

        public int getIndex(Veld veld)
        {
            return Velden.IndexOf(veld);
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
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(RotterdamBuilder.Instance.Rotterdam.getStraatByName(RotterdamBuilder.HOFPLEIN));
            Velden.Add(RotterdamBuilder.Instance.Rotterdam.getStraatByName(RotterdamBuilder.BLAAK));
            Velden.Add(AlgemeenFonds);
            Velden.Add(RotterdamBuilder.Instance.Rotterdam.getStraatByName(RotterdamBuilder.COOLSINGEL));
            Velden.Add(Stationbuilder.Instance.Oost());
            Velden.Add(Kans);
            Velden.Add(AmsterdamBuilder.Instance.Amsterdam.getStraatByName(AmsterdamBuilder.LEIDSESTRAAT));
            Velden.Add(BelastingVeldenBuilder.Instance.BelastingVelden.getBelastingveldByName(BelastingVeldenBuilder.EXTRAINKOMSTENBELASTING));
            Velden.Add(AmsterdamBuilder.Instance.Amsterdam.getStraatByName(AmsterdamBuilder.KALVERSTRAAT));
        }

        private void layoutTopRowIncludingCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(new VrijParkeren());
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByName(GroningenBuilder.ALGEMENE_KERKHOF));
            Velden.Add(Kans);
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByName(GroningenBuilder.GROTE_MARKT));
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByName(GroningenBuilder.HEERESTRAAT));
            Velden.Add(Stationbuilder.Instance.Noord());
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByName(DenHaagBuilder.SPUI));
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByName(DenHaagBuilder.PLEIN));
            Velden.Add(NutsbedrijvenBuilder.Instance.NutsBedrijven.getBedrijfByName(NutsbedrijvenBuilder.WATERLEIDING));
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByName(DenHaagBuilder.LANGE_POTEN));
            Velden.Add(DeGevangenis);
        }

        private void layoutLeftRowWithoutCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByName(HaarlemBuilder.BARTELJORISSTRAAT));
            Velden.Add(NutsbedrijvenBuilder.Instance.NutsBedrijven.getBedrijfByName(NutsbedrijvenBuilder.ELEKTRICITEITSBEDRIJF));
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByName(HaarlemBuilder.ZIJLWEG));
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByName(HaarlemBuilder.HOUTSTRAAT));
            Velden.Add(Stationbuilder.Instance.West());
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByName(UtrechtBuilder.NEUDE));
            Velden.Add(AlgemeenFonds);
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByName(UtrechtBuilder.BILTSTRAAT));
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByName(UtrechtBuilder.VREEBURG));
        }

        private void layoutBottomRowIncludingCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(new Start());
            Velden.Add(OnsDorpBuilder.Instance.OnsDorp.getStraatByName(OnsDorpBuilder.DORPSSTRAAT));
            Velden.Add(AlgemeenFonds);
            Velden.Add(OnsDorpBuilder.Instance.OnsDorp.getStraatByName(OnsDorpBuilder.BRINK));
            Velden.Add(BelastingVeldenBuilder.Instance.BelastingVelden.getBelastingveldByName(BelastingVeldenBuilder.INKOMSTENBELASTING));
            Velden.Add(Stationbuilder.Instance.Zuid());
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByName(ArnhemBuilder.STEENSTRAAT));
            Velden.Add(Kans);
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByName(ArnhemBuilder.KETELSTRAAT));
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByName(ArnhemBuilder.VELPERPLEIN));
            Velden.Add(new GevangenisOpBezoek());
        }

        internal Veld StartVeld()
        {
            return Velden[0];
        }

        public int GeefPositie(Veld veld)
        {
            return Velden.IndexOf(veld);
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
    }
}
