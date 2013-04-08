using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.domein.gebeurtenis
{
    class KoopStraat : AbstractGebeurtenis
    {
        private Straat TeKopenStraat { get; set; }

        public KoopStraat(Straat straat)
        {
            TeKopenStraat = straat;
        }

        public override bool VoerUit(Speler koper)
        {
            if (koper.Betaal(TeKopenStraat.Aankoopprijs, new Speler("Bank")))
            {
                koper.Add(TeKopenStraat);
                TeKopenStraat.Eigenaar = koper;
                return true;
            }
            return false;
        }

        public override bool IsVerplicht()
        {
            return false;
        }

        public override string Gebeurtenisnaam()
        {
            return Gebeurtenisnamen.KOOP_STRAAT;
        }

        public override string ToString()
        {
            return "... koopt " + TeKopenStraat.Naam;
        }

    }
}
