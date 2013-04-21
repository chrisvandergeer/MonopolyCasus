﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein
{
    public class BelastingVelden
    {
        public BelastingVelden()
        {
            AlleBelastingVelden = new List<BelastingVeld>();
        }
        public List<BelastingVeld> AlleBelastingVelden
        {
            get;
            private set;
        }

        public void Add(BelastingVeld belastingVeld)
        {
            AlleBelastingVelden.Add(belastingVeld);
        }

        public BelastingVeld getBelastingveldByName(string belastingnaam)
        {
            foreach (BelastingVeld belastingVeld in AlleBelastingVelden)
            {
                if (belastingVeld.Naam.Equals(belastingnaam)) return belastingVeld;
            }
            return null;
        }

    }
}
