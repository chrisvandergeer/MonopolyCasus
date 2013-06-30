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
        public GaDirectNaarDeGevangenis() : base(Veldnamen.GA_NAAR_GEVANGENIS)
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
            VerplaatsSpeler.CreateVerplaatsVooruitGeenStartgeld(Gebeurtenisnamen.GA_NAAR_DE_GEVANGENIS, speler.Spel.Bord.GeefVeld(Veldnamen.GEVANGENIS)).Voeruit(speler);
            IGebeurtenis gebeurtenis = speler.BeurtGebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.IN_DE_GEVANGENIS);
            ((GevangenisGebeurtenis)gebeurtenis).SpelerStatus = GevangenisStatus.Gevangene;
        }
    }
}
