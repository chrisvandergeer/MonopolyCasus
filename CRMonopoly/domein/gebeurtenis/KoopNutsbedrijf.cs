using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    class KoopNutsbedrijf : AbstractGebeurtenis
    {
        private Nutsbedrijf TeKopenVeld { get; set; }

        public KoopNutsbedrijf(Nutsbedrijf veld) : base(Gebeurtenisnamen.KOOP_NUTSBEDRIJF)
        {
            TeKopenVeld = veld;
        }

        public override bool VoerUit(Speler koper)
        {
            if (koper.Betaal(TeKopenVeld.GeefAankoopprijs(), new Speler("Bank")))
            {
                koper.Add(TeKopenVeld);
                TeKopenVeld.Eigenaar = koper;
                Logger.log(koper, "koopt", TeKopenVeld);
                return true;
            }            
            return false;
        }

        public override bool IsVerplicht()
        {
            return false;
        }
        
        public override string ToString()
        {
            return "... koopt " + TeKopenVeld.Naam;
        }

    }
}
