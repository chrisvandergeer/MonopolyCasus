using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class Vrij : AbstractGebeurtenis
    {
        public override bool VoerUit()
        {
            return true;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string Gebeurtenisnaam()
        {
            return Gebeurtenisnamen.VRIJ;
        }

        public override string ToString()
        {
            return Gebeurtenisnaam();
        }
    }
}
