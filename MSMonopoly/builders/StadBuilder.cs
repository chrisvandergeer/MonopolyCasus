using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein;

namespace MSMonopoly.builders
{
    class StadBuilder
    {
        public Stad BuildAmsterdam()
        {
            Stad amsterdam = new Stad() { Naam = "Amsterdam" };
            amsterdam.Add(new Straat() { Straatnaam = "Kalverstraat", Aankoopprijs = 400, HuurOnbebouwd = 50  });
            amsterdam.Add(new Straat() { Straatnaam = "Leidsestraat", Aankoopprijs = 350, HuurOnbebouwd = 35  });
            return amsterdam;
        }

        public Stad BuildArnhem()
        {
            Stad arnhem = new Stad()    { Naam = "Arnhem" };
            arnhem.Add(new Straat()     { Straatnaam = "Steenstraat", Aankoopprijs = 100, HuurOnbebouwd = 6 });
            arnhem.Add(new Straat()     { Straatnaam = "Velperplein", Aankoopprijs = 120, HuurOnbebouwd = 8 });
            arnhem.Add(new Straat()     { Straatnaam = "Ketelstraat", Aankoopprijs = 100, HuurOnbebouwd = 6 });
            return arnhem;
        }

        public Stad BuildDenHaag()
        {
            Stad denHaag = new Stad()   { Naam = "Den Haag" };
            denHaag.Add(new Straat()    { Straatnaam = "Spui",        Aankoopprijs = 260, HuurOnbebouwd = 22 });
            denHaag.Add(new Straat()    { Straatnaam = "Lange Poten", Aankoopprijs = 280, HuurOnbebouwd = 22 });  
            return denHaag;
        }
    }
}
