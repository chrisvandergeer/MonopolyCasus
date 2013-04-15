using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.builders;
using CRMonopoly.domein.velden;
using CRMonopoly.domein.gebeurtenis;
using MSMonopoly.builders;

namespace CRMonopoly.domein
{
    public class Monopolybord
    {
        private static readonly int INDEX_GEVANGENIS_VELD = 10;

        public static readonly string ALGEMEEN_FONDS_NAAM   = "Algemeen fonds";
        public static readonly string KANS_NAAM             = "Kans";

        private List<Veld> Velden;

        public Monopolybord()
        {
            Velden = new List<Veld>();
            layoutBord();
            Velden.ForEach(veld => veld.Bord = this);
            //init(); // en even toegevoegd
        }


        private void init()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(new Start());
            Velden.AddRange(builder.BuildAmsterdam().Straten);
            Velden.Add(new VrijParkeren());
            Velden.AddRange(builder.BuildRotterdam().Straten);
            Velden.AddRange(builder.BuildHaarlem().Straten);
            Velden.Add(new GevangenisOpBezoek());
        }

        // Chris: Deze logica zou ik naar een builder verplaatsen en ik zou geen verwijzigingen maken naar de layout van het bord.
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
            Velden.Add(builder.BuildRotterdam().getStraatByIndex(0));
            Velden.Add(builder.BuildRotterdam().getStraatByIndex(1));
            Velden.Add(new KaartVeld(ALGEMEEN_FONDS_NAAM, KaartenBuilder.Instance.getAlgemeenFondsKaarten()));
            Velden.Add(builder.BuildRotterdam().getStraatByIndex(2));
            Velden.Add(new NotImplementedYetVeld("Station oost"));
            Velden.Add(new KaartVeld(KANS_NAAM, KaartenBuilder.Instance.getKansKaarten()));
            Velden.Add(builder.BuildAmsterdam().getStraatByIndex(0));
            Velden.Add(new NotImplementedYetVeld("Extra belasting"));
            Velden.Add(builder.BuildAmsterdam().getStraatByIndex(1));
        }

        private void layoutTopRowIncludingCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(new VrijParkeren());
            Velden.Add(builder.BuildGroningen().getStraatByIndex(0));
            Velden.Add(new KaartVeld(KANS_NAAM, KaartenBuilder.Instance.getKansKaarten()));
            Velden.Add(builder.BuildGroningen().getStraatByIndex(1));
            Velden.Add(builder.BuildGroningen().getStraatByIndex(2));
            Velden.Add(new NotImplementedYetVeld("Station noord"));
            Velden.Add(builder.BuildDenHaag().getStraatByIndex(0));
            Velden.Add(builder.BuildDenHaag().getStraatByIndex(1));
            Velden.Add(new NotImplementedYetVeld("Waterleiding"));
            Velden.Add(builder.BuildDenHaag().getStraatByIndex(2));
            Velden.Add(new NotImplementedYetVeld("Naar de gevangenis"));
        }

        private void layoutLeftRowWithoutCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(builder.BuildHaarlem().getStraatByIndex(0));
            Velden.Add(new NotImplementedYetVeld("Elektriciteitsbedrijf"));
            Velden.Add(builder.BuildHaarlem().getStraatByIndex(1));
            Velden.Add(builder.BuildHaarlem().getStraatByIndex(2));
            Velden.Add(new NotImplementedYetVeld("Station west"));
            Velden.Add(builder.BuildUtrecht().getStraatByIndex(0));
            Velden.Add(new KaartVeld(ALGEMEEN_FONDS_NAAM, KaartenBuilder.Instance.getAlgemeenFondsKaarten()));
            Velden.Add(builder.BuildUtrecht().getStraatByIndex(1));
            Velden.Add(builder.BuildUtrecht().getStraatByIndex(2));
        }

        private void layoutBottomRowIncludingCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(new Start());
            Velden.Add(builder.BuildOnsDorp().getStraatByIndex(0));
            Velden.Add(new KaartVeld(ALGEMEEN_FONDS_NAAM, KaartenBuilder.Instance.getAlgemeenFondsKaarten()));
            Velden.Add(builder.BuildOnsDorp().getStraatByIndex(1));
            Velden.Add(new NotImplementedYetVeld("Inkomstenbelasting"));
            Velden.Add(new NotImplementedYetVeld("Station zuid"));
            Velden.Add(builder.BuildArnhem().getStraatByIndex(0));
            Velden.Add(new KaartVeld(KANS_NAAM, KaartenBuilder.Instance.getKansKaarten()));
            Velden.Add(builder.BuildArnhem().getStraatByIndex(1));
            Velden.Add(builder.BuildArnhem().getStraatByIndex(2));
            Velden.Add(new NotImplementedYetVeld("Gevangenis"));
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
            int pos = Velden.IndexOf(HaarlemBuilder.createBarteljorisstraat());
            return (Straat) Velden[pos];
        }

        public Veld getGevangenisVeld()
        {
            return Velden[INDEX_GEVANGENIS_VELD];
        }

        public Station GeefStationWest()
        {
            int pos = Velden.IndexOf(Stationbuilder.GetInstance().West());
            return (Station) Velden[pos];
        }

        internal bool Verplaats(Speler speler, Worp worp)
        {
            throw new NotImplementedException();
            // new OntvangGeld(300).VoerUit(this);
        }
    }
}
