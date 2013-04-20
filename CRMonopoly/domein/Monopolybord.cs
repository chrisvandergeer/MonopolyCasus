﻿using System;
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

        public static readonly string ALGEMEEN_FONDS_NAAM   = "Algemeen fonds";
        public static readonly string KANS_NAAM             = "Kans";

        private SpelinfoLogger Logger { get; set; }
        private List<Veld> Velden;

        public Monopolybord()
        {
            Logger = new SpelinfoLogger();
            Velden = new List<Veld>();
            layoutBord();
            Velden.ForEach(veld => veld.Bord = this);
            //init(); // en even toegevoegd
        }

/*
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
*/
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
            Velden.Add(new KaartVeld(ALGEMEEN_FONDS_NAAM, KaartenBuilder.Instance.getAlgemeenFondsKaarten()));
            Velden.Add(RotterdamBuilder.Instance.Rotterdam.getStraatByIndex(2));
            Velden.Add(new NotImplementedYetVeld("Station oost"));
            Velden.Add(new KaartVeld(KANS_NAAM, KaartenBuilder.Instance.getKansKaarten()));
            Velden.Add(AmsterdamBuilder.Instance.Amsterdam.getStraatByIndex(0));
            Velden.Add(new NotImplementedYetVeld("Extra belasting"));
            Velden.Add(AmsterdamBuilder.Instance.Amsterdam.getStraatByIndex(1));
        }

        private void layoutTopRowIncludingCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(new VrijParkeren());
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByIndex(0));
            Velden.Add(new KaartVeld(KANS_NAAM, KaartenBuilder.Instance.getKansKaarten()));
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByIndex(1));
            Velden.Add(GroningenBuilder.Instance.Groningen.getStraatByIndex(2));
            Velden.Add(new NotImplementedYetVeld("Station noord"));
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByIndex(0));
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByIndex(1));
            Velden.Add(new NotImplementedYetVeld("Waterleiding"));
            Velden.Add(DenHaagBuilder.Instance.DenHaag.getStraatByIndex(2));
            Velden.Add(new NotImplementedYetVeld("Naar de gevangenis"));
        }

        private void layoutLeftRowWithoutCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByIndex(0));
            Velden.Add(new NotImplementedYetVeld("Elektriciteitsbedrijf"));
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByIndex(1));
            Velden.Add(HaarlemBuilder.Instance.Haarlem.getStraatByIndex(2));
            Velden.Add(new NotImplementedYetVeld("Station west"));
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByIndex(0));
            Velden.Add(new KaartVeld(ALGEMEEN_FONDS_NAAM, KaartenBuilder.Instance.getAlgemeenFondsKaarten()));
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByIndex(1));
            Velden.Add(UtrechtBuilder.Instance.Utrecht.getStraatByIndex(2));
        }

        private void layoutBottomRowIncludingCorners()
        {
            StadBuilder builder = StadBuilder.Instance;
            Velden.Add(new Start());
            Velden.Add(OnsDorpBuilder.Instance.OnsDorp.getStraatByIndex(0));
            Velden.Add(new KaartVeld(ALGEMEEN_FONDS_NAAM, KaartenBuilder.Instance.getAlgemeenFondsKaarten()));
            Velden.Add(OnsDorpBuilder.Instance.OnsDorp.getStraatByIndex(1));
            Velden.Add(new NotImplementedYetVeld("Inkomstenbelasting"));
            Velden.Add(new NotImplementedYetVeld("Station zuid"));
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByIndex(0));
            Velden.Add(new KaartVeld(KANS_NAAM, KaartenBuilder.Instance.getKansKaarten()));
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByIndex(1));
            Velden.Add(ArnhemBuilder.Instance.Arnhem.getStraatByIndex(2));
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
            int pos = Velden.IndexOf(HaarlemBuilder.Instance.Haarlem.getStraatByName(HaarlemBuilder.BARTELJORISSTRAAT));
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
