using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.builders
{
    public class StadBuilder
    {
        public Stad BuildAmsterdam()
        {
            Stad amsterdam = new Stad("Amsterdam");
            amsterdam.Add(new Straat("Kalverstraat", 400, new Huur(50, 200, 600, 1400, 1700, 2000)));
            amsterdam.Add(new Straat("Leidsestraat", 350, new Huur(35, 175, 500, 1100, 1300, 1500)));
            return amsterdam;
        }

        public Stad BuildArnhem()
        {
            Stad arnhem = new Stad("Arnhem");
            arnhem.Add(new Straat("Steenstraat", 100, new Huur(6, 30, 90, 270, 400, 550)));
            arnhem.Add(new Straat("Velperplein", 120, new Huur(8, 40, 120, 360, 450, 600)));
            arnhem.Add(new Straat("Ketelstraat", 100, new Huur(6, 30, 90, 270, 400, 550)));
            return arnhem;
        }

        public Stad BuildDenHaag()
        {
            Stad denHaag = new Stad("Den Haag");
            denHaag.Add(new Straat("Spui", 260, new Huur(6, 22, 0, 0, 0, 0)));
            denHaag.Add(new Straat("Lange Poten", 280, new Huur(22, 0, 0, 0, 0, 0)));
            denHaag.Add(new Straat("Plein 's Gravenhage", 260, new Huur(22, 0, 0, 0, 0, 0)));
            return denHaag;
        }

        public Stad BuildOnsDorp()
        {
            Stad onsDorp = new Stad("Ons Dorp");
            onsDorp.Add(new Straat("Dorpsstraat", 60, new Huur(2, 0, 0, 0, 0, 0)));
            onsDorp.Add(new Straat("Brink", 60, new Huur(4, 0, 0, 0, 0, 0)));
            return onsDorp;
        }

        public Stad BuildHaarlem()
        {
            Stad haarlem = new Stad("Haarlem");
            haarlem.Add(new Straat("Houtstraat", 160, new Huur(12, 0, 0, 0, 0, 0)));
            haarlem.Add(new Straat("Barteljorisstraat", 140, new Huur(10, 0, 0, 0, 0, 0)));
            haarlem.Add(new Straat("Zijlweg", 140, new Huur(10, 0, 0, 0, 0, 0)));
            return haarlem;
        }
    }
}