using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class OntvangGeld : AbstractGebeurtenis
    {
        private Speler Geldontvanger { get; set; }
        private int Bedrag { get; set; }

        public OntvangGeld(Speler speler, int bedrag)
        {
            Geldontvanger = speler;
            Bedrag = bedrag;
        }

        public override bool VoerUit()
        {
            Geldontvanger.Ontvang(Bedrag);
            return true;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string Gebeurtenisnaam()
        {
            return Gebeurtenisnamen.ONTVANG_GELD;
        }
    }
}
