using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class OntvangGeld : AbstractGebeurtenis
    {
        private int Bedrag { get; set; }
        private string _gebeurtenisnaam;

        public OntvangGeld(int bedrag)
            : this(bedrag, Gebeurtenisnamen.ONTVANG_GELD)
        { }

        public OntvangGeld(int bedrag, string gebeurtenisnaam)
        {
            Bedrag = bedrag;
            _gebeurtenisnaam = gebeurtenisnaam;
        }

        public override bool VoerUit(Speler speler)
        {
            Logger.log(Gebeurtenisnaam());
            speler.Ontvang(Bedrag);
            return true;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string Gebeurtenisnaam()
        {
            return _gebeurtenisnaam;
        }
    }
}
