using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.gebeurtenis
{
    public interface Gebeurtenis
    {
        bool VoerUit();
        bool IsVerplicht();
        string Gebeurtenisnaam();
    }
}
