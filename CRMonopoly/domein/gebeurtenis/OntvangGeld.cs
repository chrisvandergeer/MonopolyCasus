using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class OntvangGeld : AbstractGebeurtenis
    {
        private int Bedrag { get; set; }

        public OntvangGeld(int bedrag, string gebeurtenisnaam) : base(gebeurtenisnaam)
        {
            Bedrag = bedrag;
        }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            speler.Ontvang(Bedrag);
            return GebeurtenisResult.Uitgevoerd(Gebeurtenisnaam);
        }

        public override bool IsVerplicht()
        {
            return true;
        }

    }
}
