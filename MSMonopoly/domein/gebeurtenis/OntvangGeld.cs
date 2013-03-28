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

        public bool voerUit()
        {
            Geldontvanger.Ontvang(Bedrag);
            return true;
        }

        public bool isVerplicht()
        {
            return true;
        }
    }
}
