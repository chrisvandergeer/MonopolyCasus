using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    class KoopStation : AbstractGebeurtenis
    {
        private Station TeKopenVeld { get; set; }

        public KoopStation(Station veld)
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

        public override string Gebeurtenisnaam()
        {
            return Gebeurtenisnamen.KOOP_STATION;
        }

        public override string ToString()
        {
            return "... koopt " + TeKopenVeld.Naam;
        }

    }
}
