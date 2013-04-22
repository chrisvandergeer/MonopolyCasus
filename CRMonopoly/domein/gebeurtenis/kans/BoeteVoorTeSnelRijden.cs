using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.domein.gebeurtenis.kans
{
    class BoeteVoorTeSnelRijden : Gebeurtenis
    {
        public BoeteVoorTeSnelRijden() 
        {
        }

        public bool VoerUit(Speler speler)
        {
            return speler.Betaal(15, Speler.BANK);
        }

        public bool IsVerplicht()
        {
            return true;
        }

        public string Gebeurtenisnaam()
        {
            return "Boete voor te snel rijden ƒ 15,00";
        }
    }
}
