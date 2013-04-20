using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.builders
{
    class DenHaagBuilder
    {
        public static readonly string DEN_HAAG          = "DenHaag";

        public static readonly string SPUI              = "Spui";
        public static readonly string LANGE_POTEN       = "Lange Poten";
        public static readonly string PLEIN             = "Plein";

        private static volatile DenHaagBuilder _instance;
        private static object _syncRoot = new Object();
        private Stad _denHaag = null;

        private DenHaagBuilder()
        {
        }


        public Stad DenHaag
        {
            get {
                if (_denHaag == null) {
                    buildStad();
                }
                return _denHaag;
            }
            private set {}
        }

        private void buildStad()
        {
            _denHaag = new Stad(DEN_HAAG, 150);
            _denHaag.Add(new Straat(SPUI, 260, new Huur(22, 110, 330, 800, 975, 1150)));
            _denHaag.Add(new Straat(PLEIN, 260, new Huur(22, 110, 330, 800, 975, 1150)));
            _denHaag.Add(new Straat(LANGE_POTEN, 280, new Huur(24, 120, 360, 850, 1025, 1200)));
        }

        public static DenHaagBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new DenHaagBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }
    }
}
