using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.gebeurtenissen
{
    public class EindeBeurt : Gebeurtenis
    {
        public EindeBeurt() : base(Gebeurtenisnamen.EINDE_BEURT) { }

        public override bool IsVerplicht()
        {
            return false;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            return !speler.BeurtGebeurtenissen.BevatNogUitTeVoerenVerplichteGebeurtenissen();
        }

        public override void Voeruit(Speler speler)
        {
            Gebeurtenislijst beurtgebeurtenissen = speler.BeurtGebeurtenissen;
            beurtgebeurtenissen.VerwijderNogUitTeVoerenGebeurtenissen();
            beurtgebeurtenissen.VoegResultToe(Gebeurtenisresult.Create(speler, "heeft beurt beeindigd"));
        }

    }
}
