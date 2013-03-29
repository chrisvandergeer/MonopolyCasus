using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.gebeurtenis
{
    class Vrij : Gebeurtenis
    {
        public bool voerUit()
        {
            return true;
        }

        public bool isVerplicht()
        {
            return true;
        }
    }
}
