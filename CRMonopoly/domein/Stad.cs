﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.domein
{
    public class Stad
    {
        public String Naam { get; private set; }
        public int Huisprijs { get; private set; }
        public List<Straat> Straten { get; private set; }


        public Stad(string naam, int huisprijs)
        {
            Naam = naam;
            Huisprijs = huisprijs;
            Straten = new List<Straat>();
        }

        public void Add(Straat straat)
        {
            Straten.Add(straat);
            straat.Stad = this;
        }
    }
}
