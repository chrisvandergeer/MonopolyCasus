using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein
{
    class Kaart
    {
        public string Naam { get; private set; }
        public Gebeurtenis Actie { get; private set; }
        public bool KaartNaarSpeler { get; private set; }

        public Kaart(string naam, Gebeurtenis gebeurtenis, bool verplaatsKaartNaarSpeler)
        {
            Naam = naam;
            Actie = gebeurtenis;
            KaartNaarSpeler = verplaatsKaartNaarSpeler;
        }
    }
}
