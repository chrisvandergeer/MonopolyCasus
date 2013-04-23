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
        private static readonly int INDEX_GEVANGENIS_VELD = 10;
        public static readonly string ALGEMEEN_FONDS_NAAM = "Algemeen Fonds";
        public static readonly string KANS_NAAM = "Kans";

        private SpelinfoLogger Logger { get; set; }
        private List<Veld> Velden;
        private KansEnAlgemeenfondsVeld Kans { get; set; }
        private KansEnAlgemeenfondsVeld AlgemeenFonds { get; set; }


        public Monopolybord()
        {
            Logger = new SpelinfoLogger();
            Velden = new List<Veld>();
            Kans = new KansEnAlgemeenfondsVeld("Kans");
            AlgemeenFonds = new KansEnAlgemeenfondsVeld("Algemeen Fonds");
            layoutBord();
            Velden.ForEach(veld => veld.Bord = this);
            Kans.Kaarten = new KanskaartBuilder(this).build();
            AlgemeenFonds.Kaarten = new AlgemeenFondsBuilder(this).build();
        }

        // Chris: Deze logica zou ik naar een builder verplaatsen en ik zou geen verwijzigingen maken naar de layout van het bord.
        // RdW: Doorgesproken. Consensus: De layout van het bord is kennis die het bord zou kunnen hebben en niet speciaal een builder.
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
            Velden.Add(RotterdamBuilder.Instance.Rotterdam.getStraatByIndex(0));
            Velden.Add(RotterdamBuilder.Instance.Rotterdam.getStraatByIndex(1));
            Velden.Add(AlgemeenFonds);
            Velden.Add(RotterdamBuilder.Instance.Rotterdam.getStraatByIndex(2));
            Velden.Add(Stationbuilder.Instance.Oost());
            Velden.Add(Kans);
            Velden.Add(AmsterdamBuilder.Instance.Amsterdam.getStraatByIndex(0));
            Velden.Add(BelastingVeldenBuilder.Instance.BelastingVelden.getBelastingveldByName(BelastingVeldenBuilder.EXTRAINKOMSTENBELASTING));
            Velden.Add(AmsterdamBuilder.Instance.Amsterdam.getStraatByIndex(1));
        }

        private void layoutTopRowIncludingCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(new VrijParkeren());
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByIndex(0));
            Velden.Add(Kans);
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByIndex(1));
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByIndex(2));
            Velden.Add(Stationbuilder.Instance.Noord());
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByIndex(0));
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByIndex(1));
            Velden.Add(NutsbedrijvenBuilder.Instance.NutsBedrijven.getBedrijfByName(NutsbedrijvenBuilder.WATERLEIDING));
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByIndex(2));
            Velden.Add(new GaNaarGevangenisVeld());
        }

        private void layoutLeftRowWithoutCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByIndex(0));
            Velden.Add(NutsbedrijvenBuilder.Instance.NutsBedrijven.getBedrijfByName(NutsbedrijvenBuilder.ELEKTRICITEITSBEDRIJF));
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByIndex(1));
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByIndex(2));
            Velden.Add(Stationbuilder.Instance.West());
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByIndex(0));
            Velden.Add(AlgemeenFonds);
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByName(UtrechtBuilder.BILTSTRAAT));
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByIndex(2));
        }

        private void layoutBottomRowIncludingCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(new Start());
            Velden.Add(OnsDorpBuilder.Instance.OnsDorp.getStraatByIndex(0));
            Velden.Add(AlgemeenFonds);
            Velden.Add(OnsDorpBuilder.Instance.OnsDorp.getStraatByIndex(1));
            Velden.Add(BelastingVeldenBuilder.Instance.BelastingVelden.getBelastingveldByName(BelastingVeldenBuilder.INKOMSTENBELASTING));
            Velden.Add(Stationbuilder.Instance.Zuid());
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByIndex(0));
            Velden.Add(Kans);
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByIndex(1));
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByIndex(2));
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

        public Veld getGevangenisVeld()
        {
            return Velden[INDEX_GEVANGENIS_VELD];
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
        
        /// <summary>
        /// Verplaatst een speler naar de worp
        /// </summary>
        /// <param name="speler"></param>
        /// <param name="worp"></param>
        /// <returns>true indien lang start gekomen</returns>
        public Gebeurtenis Verplaats(Speler speler, Worp worp)
        {
            Veld huidigePositie = speler.HuidigePositie;
            Veld nieuwePositie = GeefVeld(speler.HuidigePositie, worp);
            Logger.log(speler, "gooit", worp, "en verplaatst naar", nieuwePositie);
            speler.HuidigePositie = nieuwePositie;
            if (Velden.IndexOf(nieuwePositie) < Velden.IndexOf(huidigePositie))
            {
               new OntvangGeld(200, "U bent langs Start gekomen en ontvangt ƒ 200,00").VoerUit(speler);
            }
            return nieuwePositie.bepaalGebeurtenis(speler);
        }

    }
}
