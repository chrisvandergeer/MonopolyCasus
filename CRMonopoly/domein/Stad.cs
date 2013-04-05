﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.domein
{
    public class Stad
    {
        public String Naam { get; set; }
        public List<Straat> Straten { get; set; }

        public Stad(string naam)
        {
            Naam = naam;
            Straten = new List<Straat>();
        }

        public void Add(Straat straat)
        {
            Straten.Add(straat);
            straat.Stad = this;
        }
    }
}
