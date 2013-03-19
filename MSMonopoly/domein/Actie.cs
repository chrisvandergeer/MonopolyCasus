using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    public interface Actie
    {
        bool IsVerplicht();
        bool IsBevestigd();
        void VoerUit();
    }
}
