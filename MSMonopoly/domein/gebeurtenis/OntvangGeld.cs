using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.gebeurtenis
{
    class OntvangGeld : Gebeurtenis
    {
        private Speler Geldontvanger { get; set; }
        private int Bedrag { get; set; }

        public OntvangGeld(Speler speler, int bedrag)
        {
            Geldontvanger = speler;
            Bedrag = bedrag;
        }

        public void VoerGebeurtenisUit()
        {
            Geldontvanger.Ontvang(Bedrag);
        }

        public bool isVerplicht()
        {
            return true;
        }
    }
}
