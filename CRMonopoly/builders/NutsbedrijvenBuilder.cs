using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.velden;

namespace CRMonopoly.builders
{
    class NutsbedrijvenBuilder
    {
        public static readonly String ELEKTRICITEITSBEDRIJF = "Elektriciteitsbedrijf";
        public static readonly String WATERLEIDING          = "Waterleiding";

        [ThreadStatic]
        private static volatile NutsbedrijvenBuilder _instance;
        private static object _syncRoot = new Object();

        private Nutsbedrijven _nutsbedrijven = null;

        private NutsbedrijvenBuilder()
        {
        }

        public Nutsbedrijven NutsBedrijven
        {
            get
            {
                if (_nutsbedrijven == null)
                {
                    buildNutsbedrijven();
                }
                return _nutsbedrijven;
            }
            private set { }
        }
        private void buildNutsbedrijven()
        {
            _nutsbedrijven = new Nutsbedrijven();
            _nutsbedrijven.Add(new Nutsbedrijf(ELEKTRICITEITSBEDRIJF));
            _nutsbedrijven.Add(new Nutsbedrijf(WATERLEIDING));
        }

        public static NutsbedrijvenBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new NutsbedrijvenBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }
    }
}
