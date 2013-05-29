using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class GaNaarGevangenis : AbstractGebeurtenis
    {
        public GaNaarGevangenis() : base(Gebeurtenisnamen.NAAR_GEVANGENIS, GebeurtenisType.Verplaats) { }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            speler.Bord.DeGevangenis.NieuweGevangene(speler);
            return GebeurtenisResult.Uitgevoerd(speler, "is naar de gevangenis gestuurd");
        }

        public override bool IsVerplicht()
        {
            return true;
        }
    }
}
