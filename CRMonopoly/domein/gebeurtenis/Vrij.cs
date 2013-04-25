using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class Vrij : AbstractGebeurtenis
    {

        public Vrij() : base(Gebeurtenisnamen.VRIJ) { }

        public override bool VoerUit(Speler speler)
        {
            return true;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string ToString()
        {
            return Gebeurtenisnaam;
        }
    }
}
