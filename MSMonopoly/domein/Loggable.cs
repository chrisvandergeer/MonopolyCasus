﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein.gebeurtenis;

namespace MSMonopoly.domein
{
    public class Loggable
    {
		public Worp Worp { get; private set; }
		public Speler Speler { get; private set; }
		public Gebeurtenis Gebeurtenis { get; private set; }

		public Loggable(Worp worp, Speler speler, Gebeurtenis gebeurtenis) 
        {
            Worp = worp;
            Speler = speler;
            Gebeurtenis = gebeurtenis;
		}
    }
}
