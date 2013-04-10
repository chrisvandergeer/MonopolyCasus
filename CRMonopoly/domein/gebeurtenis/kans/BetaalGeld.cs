using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.domein.gebeurtenis.kans
{
    public class BetaalGeld : Gebeurtenis
    {
        private int Bedrag { get; set; }
        private string Naam { get; set; }

        public BetaalGeld(int bedrag, string gebeurtenisnaam)
        {
            Bedrag = bedrag;
            Naam = gebeurtenisnaam;
        }

        public bool VoerUit(Speler speler)
        {
            return speler.Betaal(Bedrag, Speler.BANK);
        }

        public bool IsVerplicht()
        {
            return true;
        }

        public string Gebeurtenisnaam()
        {
            return Naam;
        }
    }
}
