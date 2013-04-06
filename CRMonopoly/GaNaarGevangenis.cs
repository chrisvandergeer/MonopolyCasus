using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class GaNaarGevangenis : AbstractGebeurtenis
    {
        public Speler Speler { get; set; }

        public override bool VoerUit()
        {
            Speler.Verplaats(Speler.Bord.getGevangenisVeld());
            return true;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string Gebeurtenisnaam()
        {
            return Gebeurtenisnamen.NAAR_GEVANGENIS;
        }

        public override string ToString()
        {
            return string.Format("Speler {0} gaat direct naar de gevangenis.", Speler.Name);
        }
    }
}
