using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein;

namespace MSMonopoly.builders
{
    public class StadBuilder
    {
        public Stad BuildAmsterdam()
        {
            Stad amsterdam = new Stad("Amsterdam");
            amsterdam.Add(new Straat("Kalverstraat", 400, 50));
            amsterdam.Add(new Straat("Leidsestraat", 350, 35));
            return amsterdam;
        }

        public Stad BuildArnhem()
        {
            Stad arnhem = new Stad("Arnhem");
            arnhem.Add(new Straat("Steenstraat", 100, 6));
            arnhem.Add(new Straat("Velperplein", 120, 8));
            arnhem.Add(new Straat("Ketelstraat", 100, 6));
            return arnhem;
        }

        public Stad BuildDenHaag()
        {
            Stad denHaag = new Stad("Den Haag");
            denHaag.Add(new Straat("Spui", 260, 22));
            denHaag.Add(new Straat("Lange Poten", 280, 22));  
            return denHaag;
        }
    }
}