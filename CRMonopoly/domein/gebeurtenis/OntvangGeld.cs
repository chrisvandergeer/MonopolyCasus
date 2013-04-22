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
            : this(bedrag, Gebeurtenisnamen.ONTVANG_GELD)
        { }

        public OntvangGeld(int bedrag, string gebeurtenisnaam) : base(gebeurtenisnaam)
        {
            Bedrag = bedrag;
        }

        public override bool VoerUit(Speler speler)
        {
            Logger.log(Gebeurtenisnaam);
            speler.Ontvang(Bedrag);
            return true;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

    }
}
