using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class OntvangGeld : AbstractGebeurtenis
    {
        private int Bedrag { get; set; }

        public OntvangGeld(int bedrag)
        {
            Bedrag = bedrag;
        }

        public override bool VoerUit(Speler speler)
        {
            speler.Ontvang(Bedrag);
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
