using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.domein.velden
{
    public interface VerkoopbaarVeld 
    {
        int GeefTeBetalenHuur(Speler bezoeker);

        int GeefAankoopprijs();

        Speler Eigenaar { get; set; }

        string Naam { get; set; }

        //Speler GeefEigenaar();

        bool heeftEigenaar();
    }
}
