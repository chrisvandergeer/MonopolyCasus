using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;
using Monopoly.domein.labels;

namespace Monopoly.domein.gebeurtenissen
{
    public class VerplaatsSpeler : Gebeurtenis
    {
        private Veld NieuwePositie { get; set; }
        private int AantalPosities { get; set; }
        private bool OntvangGeenStartgeld { get; set; }

        private VerplaatsSpeler(string gebeurtenistekst, int aantalPosities) : base(gebeurtenistekst) 
        {
            AantalPosities = aantalPosities;
        }

        private VerplaatsSpeler(string gebeurtenistekst, Veld veld) : base(gebeurtenistekst) 
        {
            NieuwePositie = veld;
        }

        public static VerplaatsSpeler CreateVerplaatsVooruit(string gebeurtenistekst, int aantalPosities)
        {
            return new VerplaatsSpeler(gebeurtenistekst, aantalPosities);
        }

        public static VerplaatsSpeler CreateVerplaatsVooruit(string gebeurtenistekst, Veld veld)
        {
            VerplaatsSpeler gebeurtenis = new VerplaatsSpeler(gebeurtenistekst, veld);
            return gebeurtenis;
        }

        public static VerplaatsSpeler CreateVerplaatsAchteruit(string gebeurtenistekst, int aantalPosities)
        {
            VerplaatsSpeler gebeurtenis = new VerplaatsSpeler(gebeurtenistekst, aantalPosities * -1);
            gebeurtenis.OntvangGeenStartgeld = true;
            return gebeurtenis;
        }

        public static VerplaatsSpeler CreateVerplaatsVooruitGeenStartgeld(string gebeurtenistekst, int aantalPosities)
        {
            VerplaatsSpeler gebeurtenis = new VerplaatsSpeler(gebeurtenistekst, aantalPosities);
            gebeurtenis.OntvangGeenStartgeld = true;
            return gebeurtenis;
        }

        public static VerplaatsSpeler CreateVerplaatsVooruitGeenStartgeld(string gebeurtenistekst, Veld veld)
        {
            VerplaatsSpeler gebeurtenis = new VerplaatsSpeler(gebeurtenistekst, veld);
            gebeurtenis.OntvangGeenStartgeld = true;
            return gebeurtenis;
        }

        public static VerplaatsSpeler CreateVerplaatsAchteruit(string tekst, Veld veld)
        {
            VerplaatsSpeler gebeurtenis = new VerplaatsSpeler(tekst, veld);
            gebeurtenis.OntvangGeenStartgeld = true;
            return gebeurtenis;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            return true;
        }

        public override void Voeruit(Speler speler)
        {
            if (spelerIsGevangene(speler))
            {
                speler.BeurtGebeurtenissen.VoegResultToe(Gebeurtenisresult.Create(Gebeurtenisnamen.SPELER_IS_GEVANGENE_EN_KAN_NIET_VERPLAATSEN));
                return;
            }
            PasseerStartGebeurtenis passeerStart = new PasseerStartGebeurtenis(speler.Positie);
            if (NieuwePositie == null)
            {
                Veld huidigePositie = speler.Positie;
                NieuwePositie = speler.Spel.Bord.GeefVeld(huidigePositie, AantalPosities);
            }
            speler.BeurtGebeurtenissen.VoegResultToe(Gebeurtenisresult.Create(Naam));
            speler.Verplaats(NieuwePositie);
            if (!OntvangGeenStartgeld)
                passeerStart.Voeruit(speler);
        }
        private bool spelerIsGevangene(Speler speler)
        {
            if (speler.BeurtGebeurtenissen.BevatGebeurtenis(Gebeurtenisnamen.IN_DE_GEVANGENIS))
            {
                IGebeurtenis gevangenisGebeurtenis = speler.BeurtGebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.IN_DE_GEVANGENIS);
                if (! gevangenisGebeurtenis.IsUitvoerbaar(speler))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
