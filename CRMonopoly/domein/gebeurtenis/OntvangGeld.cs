using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class OntvangGeld : AbstractGebeurtenis
    {
        private int Bedrag { get; set; }

        public OntvangGeld(int bedrag, string gebeurtenisnaam) : base(gebeurtenisnaam, GebeurtenisType.OntvangGeld)
        {
            Bedrag = bedrag;
        }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            speler.Ontvang(Bedrag);
            return GebeurtenisResult.Uitgevoerd(speler.Name, "ontvangt", Bedrag);
        }

        public override bool IsVerplicht()
        {
            return true;
        }

    }
}
