using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.gebeurtenissen
{
    public class PasseerStartGebeurtenis : Gebeurtenis
    {
        private Veld StartPositie { get; set; }

        public PasseerStartGebeurtenis(Veld startPositie) : base(Gebeurtenisnamen.PASSEER_START)
        {
            StartPositie = startPositie;
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
            int startPositie = bord.Velden.IndexOf(StartPositie);
            int nieuwePositie = bord.Velden.IndexOf(speler.Positie);
            if (nieuwePositie < startPositie && nieuwePositie != 0)
            {
                speler.Bezittingen.OntvangGeld(200);
                speler.BeurtGebeurtenissen.VoegResultToe(Gebeurtenisresult.Create(speler, "komt langs Start en ontvangt hfl 200"));
            }
        }
    }
}
