using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using Microsoft.Practices.Unity;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein
{
    public abstract class Veld
    {
        protected List<HuurChangeListener> myHuurChangeListeners = new List<HuurChangeListener>();
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

        public void addHuurChangeListener(HuurChangeListener changeListener)
        {
            myHuurChangeListeners.Add(changeListener);
        }
    }
}
