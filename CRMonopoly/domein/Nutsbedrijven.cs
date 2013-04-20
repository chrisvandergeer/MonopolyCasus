﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein
{
    public class Nutsbedrijven
    {
        public Nutsbedrijven()
        {
            AlleNutsBedrijven = new List<Nutsbedrijf>();
        }
        public List<Nutsbedrijf> AlleNutsBedrijven
        {
            get;
            private set;
        }

        public void Add(Nutsbedrijf nutsbedrijf)
        {
            AlleNutsBedrijven.Add(nutsbedrijf);
        }

        public Nutsbedrijf getBedrijfByName(string bedrijfsnaam)
        {
            foreach (Nutsbedrijf bedrijf in AlleNutsBedrijven)
            {
                if (bedrijf.Naam.Equals(bedrijfsnaam)) return bedrijf;
            }
            return null;
        }

    }
}
