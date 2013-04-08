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
        private Speler _speler;

        public BoeteVoorTeSnelRijden()
        {
        }

        public bool VoerUit(Speler speler)
        {
            return _speler.Betaal(15, new Speler("bank"));
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
