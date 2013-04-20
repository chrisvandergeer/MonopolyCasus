using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein
{
    public abstract class Veld
    {
        public string Naam { get; set; }
        internal Monopolybord Bord { get; set; }

        public abstract Gebeurtenis bepaalGebeurtenis(Speler speler);

        public Veld(string naam)
        {
            Naam = naam;
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
