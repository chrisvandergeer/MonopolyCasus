using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.builders
{
    class GroningenBuilder
    {
        public static readonly string GRONINGEN         = "Groningen";

        public static readonly string ALGEMENE_KERKHOF  = "A-Kerkhof";
        public static readonly string GROTE_MARKT       = "Grote Markt";
        public static readonly string HEERESTRAAT       = "Heerestraat";

        private static volatile GroningenBuilder _instance;
        private static object _syncRoot = new Object();
        private Stad _groningen = null;

        private GroningenBuilder()
        {
        }


        public Stad Groningen
        {
            get {
                if (_groningen == null)
                {
                    buildStad();
                }
                return _groningen;
            }
            private set {}
        }

        private void buildStad()
        {
            _groningen = new Stad(GRONINGEN, 150);
            _groningen.Add(new Straat(ALGEMENE_KERKHOF, 220, new Huur(18, 90, 250, 700, 875, 1050)));
            _groningen.Add(new Straat(GROTE_MARKT, 220, new Huur(18, 90, 250, 700, 875, 1050)));
            _groningen.Add(new Straat(HEERESTRAAT, 240, new Huur(20, 100, 300, 750, 925, 1100)));
        }

        public static GroningenBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new GroningenBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }
    }
}
