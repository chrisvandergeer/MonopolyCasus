using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;
using Monopoly.domein.labels;

namespace Monopoly.domein.gebeurtenissen
{
    public class VerlaatDeGevangenis : Gebeurtenis
    {
        public VerlaatDeGevangenis() : base(Gebeurtenisnamen.VERLAAT_GEVANGENIS)
        {
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            if (speler.BeurtGebeurtenissen.BevatGebeurtenis(Gebeurtenisnamen.IN_DE_GEVANGENIS))
            {
                GevangenisGebeurtenis gebeurtenis = (GevangenisGebeurtenis)speler.BeurtGebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.IN_DE_GEVANGENIS);
                return (gebeurtenis.SpelerStatus == GevangenisStatus.Gevangene);
            }
            return false;
        }

        public override void Voeruit(Speler speler)
        {
            if (IsUitvoerbaar(speler) && speler.Bezittingen.Kasgeld > 50)
            {
                GevangenisGebeurtenis gebeurtenis = (GevangenisGebeurtenis)speler.BeurtGebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.IN_DE_GEVANGENIS);
                gebeurtenis.SpelerStatus = GevangenisStatus.Bezoek;
                Gebeurtenisresult result = Gebeurtenisresult.Create(speler, "betaalt boete van 50 en verlaat de gevangenis");
                speler.BeurtGebeurtenissen.VoegResultToe(result);
            }
        }
    }
}
