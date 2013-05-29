using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class GaTerugNaar : AbstractGebeurtenis
    {
        private Veld _bestemmingsveld;

        public GaTerugNaar(Veld veld) : base("ga terug naar " + veld.Naam) 
        {
            _bestemmingsveld = veld;
        }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            GebeurtenisResult result = GebeurtenisResult.Uitgevoerd(Gebeurtenisnaam);
            speler.HuidigePositie = _bestemmingsveld;
            Gebeurtenis gebeurtenis = _bestemmingsveld.bepaalGebeurtenis(speler);
            if (gebeurtenis.IsVerplicht())
            {
                result.Append(gebeurtenis.VoerUit(speler));
            }
            return result;
        }

        public override bool IsVerplicht()
        {
            return true;
        }
    }
}
