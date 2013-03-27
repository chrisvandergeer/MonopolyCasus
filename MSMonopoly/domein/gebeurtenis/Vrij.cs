using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.gebeurtenis
{
    class Vrij : Gebeurtenis
    {
        public void VoerGebeurtenisUit()
        {
            // Vrij
        }

        public bool isVerplicht()
        {
            return true;
        }
    }
}
