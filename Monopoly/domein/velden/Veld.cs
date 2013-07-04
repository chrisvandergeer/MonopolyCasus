using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.velden
{
    public abstract class Veld : IVeld, IHuurObservable
    {
        public string Naam { get; private set; }

        public Veld(string naam)
        {
            Naam = naam;
        }

        public abstract IGebeurtenis BepaalGebeurtenis();
        public abstract void addObserver(IHuurObserver observer);

        public override bool Equals(object obj)
        {
            if (obj is IVeld)
            {
                IVeld veld = (IVeld)obj;
                return Naam == null ? veld.Naam == null : Naam.Equals(veld.Naam);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Naam == null ? 0 : Naam.GetHashCode();
        }

        public override string ToString()
        {
            return Naam == null ? "[null]" : Naam;
        }



        string IVeld.Naam
        {
//            get { throw new NotImplementedException(); }
            get { return Naam; }
        }

    }
}
