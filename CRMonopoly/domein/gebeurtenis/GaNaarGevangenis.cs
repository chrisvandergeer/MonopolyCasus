using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class GaNaarGevangenis : AbstractGebeurtenis
    {
        public Speler Speler { get; set; }

        public GaNaarGevangenis() : base(Gebeurtenisnamen.NAAR_GEVANGENIS) { }

        public override bool VoerUit(Speler speler)
        {
            speler.Bord.DeGevangenis.NieuweGevangene(speler);
            SpelinfoLogger.Log(speler, "is naar de gevangenis gestuurd");
            return true;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string ToString()
        {
            return string.Format("Speler {0} gaat direct naar de gevangenis.", Speler.Name);
        }
    }
}
