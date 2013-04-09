using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.domein.velden
{
    interface VerkoopbaarVeld 
    {
        int GeefTeBetalenHuur();

        int GeefAankoopprijs();

        Speler GeefEigenaar();
    }
}
