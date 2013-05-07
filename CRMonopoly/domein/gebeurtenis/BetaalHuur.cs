using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    class BetaalHuur : AbstractGebeurtenis
    {
        private VerkoopbaarVeld VeldWaarvoorHuurWordtOntvangen { get; set; }

        public BetaalHuur(VerkoopbaarVeld veld) : base("Huur betalen")
        {
            VeldWaarvoorHuurWordtOntvangen = veld;
        }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            int huurbedrag = VeldWaarvoorHuurWordtOntvangen.GeefTeBetalenHuur();
            Speler eigenaar = VeldWaarvoorHuurWordtOntvangen.Eigenaar;
            if (speler.Betaal(huurbedrag, eigenaar))
            {
                return GebeurtenisResult.Uitgevoerd(speler, "betaald", huurbedrag, "huur aan", eigenaar);
            }
            return GebeurtenisResult.NietUitgevoerd(speler, "is nog", huurbedrag, "verschuldigd aan", eigenaar);
        }

        public override bool IsVerplicht()
        {
            return true;
        }
        
    }
}
