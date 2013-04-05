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
            Stad amsterdam = new Stad("Amsterdam", 200);
            amsterdam.Add(new Straat("Kalverstraat", 400, new Huur(50, 200, 600, 1400, 1700, 2000)));
            amsterdam.Add(new Straat("Leidsestraat", 350, new Huur(35, 175, 500, 1100, 1300, 1500)));
            return amsterdam;
        }

        public Stad BuildArnhem()
        {
            Stad arnhem = new Stad("Arnhem", 50);
            arnhem.Add(new Straat("Steenstraat", 100, new Huur(6, 30, 90, 270, 400, 550)));
            arnhem.Add(new Straat("Velperplein", 120, new Huur(8, 40, 120, 360, 450, 600)));
            arnhem.Add(new Straat("Ketelstraat", 100, new Huur(6, 30, 90, 270, 400, 550)));
            return arnhem;
        }

        public Stad BuildDenHaag()
        {
            Stad denHaag = new Stad("Den Haag", 150);
            denHaag.Add(new Straat("Spui", 260, new Huur(22, 110, 330, 800, 975, 1150)));
            denHaag.Add(new Straat("Lange Poten", 280, new Huur(24, 120, 360, 850, 1025, 1200)));
            denHaag.Add(new Straat("Plein 's Gravenhage", 260, new Huur(22, 110, 330, 800, 975, 1150)));
            return denHaag;
        }

        public Stad BuildOnsDorp()
        {
            Stad onsDorp = new Stad("Ons Dorp", 50);
            onsDorp.Add(new Straat("Dorpsstraat", 60, new Huur(2, 10, 30, 90, 160, 250)));
            onsDorp.Add(new Straat("Brink", 60, new Huur(4, 20, 60, 180, 320, 450)));
            return onsDorp;
        }

        public Stad BuildHaarlem()
        {
            Stad haarlem = new Stad("Haarlem", 100);
            haarlem.Add(new Straat("Houtstraat", 160, new Huur(12, 60, 180, 500, 700, 900)));
            haarlem.Add(new Straat("Barteljorisstraat", 140, new Huur(10, 50, 150, 450, 625, 750)));
            haarlem.Add(new Straat("Zijlweg", 140, new Huur(10, 50, 150, 450, 625, 750)));
            return haarlem;
        }
        public Stad BuildUtrecht()
        {
            Stad utrecht = new Stad("Utrecht", 100);
            utrecht.Add(new Straat("Neude", 180, new Huur(14, 70, 200, 550, 750, 950)));
            utrecht.Add(new Straat("Biltstraat", 180, new Huur(14, 70, 200, 550, 750, 950)));
            utrecht.Add(new Straat("Vreeburg", 200, new Huur(16, 80, 220, 600, 800, 1000)));
            return utrecht;
        }
        public Stad BuildGroningen()
        {
            Stad groningen = new Stad("Groningen", 150);
            groningen.Add(new Straat("A-Kerkhof", 220, new Huur(18, 90, 250, 700, 875, 1050)));
            groningen.Add(new Straat("Grote Markt", 220, new Huur(18, 90, 250, 700, 875, 1050)));
            groningen.Add(new Straat("Heerestraat", 240, new Huur(20, 100, 300, 750, 925, 1100)));
            return groningen;
        }
        public Stad BuildRotterdam()
        {
            Stad rotterdam = new Stad("Rotterdam", 200);
            rotterdam.Add(new Straat("Hofplein", 300, new Huur(26, 130, 390, 900, 1100, 1275)));
            rotterdam.Add(new Straat("Blaak", 300, new Huur(26, 130, 390, 900, 1100, 1275)));
            rotterdam.Add(new Straat("Coolsingel", 320, new Huur(28, 150, 450, 1000, 1200, 1400)));
            return rotterdam;
        }
    }
}