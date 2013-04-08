using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.domein.gebeurtenis.kans
{
    public class BetaalSchoolgeld : Gebeurtenis
    {

        public BetaalSchoolgeld()
        {            
        }

        public bool VoerUit(Speler speler)
        {
            return speler.Betaal(150, new Speler("bank"));
        }

        public bool IsVerplicht()
        {
            return true;
        }

        public string Gebeurtenisnaam()
        {
            return "Betaal schoolgeld ƒ 150";
        }
    }
}
