using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.domein.gebeurtenis.kans
{
    public class BetaalGeld : AbstractGebeurtenis
    {
        private int Bedrag { get; set; }

        public BetaalGeld(int bedrag, string gebeurtenisnaam) : base(gebeurtenisnaam)
        {
            Bedrag = bedrag;
        }
        
        public override bool VoerUit(Speler speler)
        {
            return speler.Betaal(Bedrag, Speler.BANK);
        }

        public override bool IsVerplicht()
        {
            return true;
        }

    }
}
