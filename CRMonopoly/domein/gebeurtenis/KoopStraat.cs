using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    class KoopStraat : AbstractGebeurtenis
    {
        private VerkoopbaarVeld TeKopenStraat { get; set; }  
      
        public KoopStraat(VerkoopbaarVeld straat) : base(Gebeurtenisnamen.KOOP_STRAAT)
        {
            TeKopenStraat = straat;
        }

        public override bool VoerUit(Speler koper)
        {
            if (koper.Betaal(TeKopenStraat.GeefAankoopprijs(), new Speler("Bank")))
            {
                koper.Add(TeKopenStraat);
                TeKopenStraat.Eigenaar = koper;
                Logger.log(koper, "koopt", TeKopenStraat);
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
            return "... koopt " + TeKopenStraat.Naam;
        }

    }
}
