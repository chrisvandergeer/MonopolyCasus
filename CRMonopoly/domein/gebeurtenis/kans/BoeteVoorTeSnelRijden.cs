using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.domein.gebeurtenis.kans
{
    class BoeteVoorTeSnelRijden : AbstractGebeurtenis
    {
        public BoeteVoorTeSnelRijden() : base("Boete voor te snel rijden ƒ 15,00") { }

        public override bool VoerUit(Speler speler)
        {
            return speler.Betaal(15, Speler.BANK);
        }

        public override bool IsVerplicht()
        {
            return true;
        }
    }
}
