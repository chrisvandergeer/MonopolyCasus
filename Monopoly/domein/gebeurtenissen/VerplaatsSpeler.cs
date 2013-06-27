using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

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

        public static VerplaatsSpeler CreateVerplaatsAchteruit(string tekst, Veld veld)
        {
            VerplaatsSpeler gebeurtenis = new VerplaatsSpeler(tekst, veld);
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
            PasseerStartGebeurtenis passeerStart = new PasseerStartGebeurtenis(speler.Positie);
            if (NieuwePositie == null)
            {
                Veld huidigePositie = speler.Positie;
                NieuwePositie = speler.Spel.Bord.GeefVeld(huidigePositie, AantalPosities);
            }
            speler.Positie = NieuwePositie;
            speler.BeurtGebeurtenissen.VoegResultToe(Gebeurtenisresult.Create(Naam));
            IGebeurtenis gebeurtenis = NieuwePositie.BepaalGebeurtenis();
            if (gebeurtenis.IsVerplicht())
            {
                gebeurtenis.Voeruit(speler);
            }
            else
            {
                speler.BeurtGebeurtenissen.VoegGebeurtenisToe(gebeurtenis);
            }
            if (!OntvangGeenStartgeld)
                passeerStart.Voeruit(speler);
        }

    }
}
