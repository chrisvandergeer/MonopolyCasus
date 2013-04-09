using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.velden
{
    interface VerkoopbaarVeld 
    {
        int GeefTeBetalenHuur();

        int Aankoopprijs { get; set; } 
    }
}
