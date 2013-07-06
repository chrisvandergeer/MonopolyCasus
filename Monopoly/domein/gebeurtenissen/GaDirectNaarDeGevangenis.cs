using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;
using Monopoly.domein.labels;

namespace Monopoly.domein.gebeurtenissen
{
    public class GaDirectNaarDeGevangenis : Gebeurtenis
    {
        public GaDirectNaarDeGevangenis()
            : base(Gebeurtenisnamen.GA_NAAR_DE_GEVANGENIS)
        {
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
            Spelbord bord = speler.Spel.Bord;
            Gevangenis gevangenis = bord.Gevangenis();
            //VerplaatsSpeler.CreateVerplaatsVooruitGeenStartgeld(Gebeurtenisnamen.GA_NAAR_DE_GEVANGENIS, gevangenis).Voeruit(speler);
            speler.Positie = gevangenis;
            gevangenis.NieuweGevangene(speler, Gebeurtenisresult.Create(speler, "is in de gevangenis"));
        }
    }
}
