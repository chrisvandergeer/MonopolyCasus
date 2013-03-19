using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.acties
{
    class GeenActie : Actie
    {
        public bool IsVerplicht()
        {
            return false;
        }

        public bool IsBevestigd()
        {
            return true;
        }

        public void VoerUit()
        {
            // niks
        }
    }
}
