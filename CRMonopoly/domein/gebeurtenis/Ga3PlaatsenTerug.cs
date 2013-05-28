using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    public class Ga3PlaatsenTerug : AbstractGebeurtenis
    {
        public Ga3PlaatsenTerug() : base("Ga 3 plaatsen terug") { }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            Veld veld = speler.Bord.GeefVeld(speler.HuidigePositie, -3);
            Gebeurtenis gebeurtenis = speler.Verplaats(veld);
            if (gebeurtenis.IsVerplicht())
            {
                GebeurtenisResult result = gebeurtenis.VoerUit(speler);
                if (!result.IsUitgevoerd)
                {
                    speler.UitTeVoerenGebeurtenissen.Add(gebeurtenis);
                }
                return result;
            }
            return GebeurtenisResult.Uitgevoerd(speler.Name, "belandt op", speler.HuidigePositie);
        }

        public override bool IsVerplicht()
        {
            return true;
        }
    }
}
