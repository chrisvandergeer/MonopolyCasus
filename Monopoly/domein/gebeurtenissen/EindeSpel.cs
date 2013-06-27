using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.gebeurtenissen
{
    class EindeSpel : Gebeurtenis
    {
        public EindeSpel() : base(Gebeurtenisnamen.EINDE_SPEL) { }

        public override bool IsVerplicht()
        {
            return false;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            return true;
        }

        public override void Voeruit(Speler speler)
        {
            speler.Spel.Beeindig();
            Gebeurtenislijst gebeurtenissen = speler.BeurtGebeurtenissen;
            gebeurtenissen.VerwijderGebeurtenis(this);
            gebeurtenissen.VoegResultToe(Gebeurtenisresult.Create(speler, "beeindigd het spel en heeft verloren"));
            speler.BeurtGebeurtenissen.VerwijderNogUitTeVoerenGebeurtenissen();
        }
    }
}
