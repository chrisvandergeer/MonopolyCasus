using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.builders
{
    class AmsterdamBuilder
    {
        public static readonly string AMSTERDAM         = "Amsterdam";

        public static readonly string LEIDSESTRAAT      = "Leidsestraat";
        public static readonly string KALVERSTRAAT      = "Kalverstraat";

        private static volatile AmsterdamBuilder _instance;
        private static object _syncRoot = new Object();
        private Stad _amsterdam = null;

        private AmsterdamBuilder()
        {
        }


        public Stad Amsterdam
        {
            get {
                if (_amsterdam == null)
                {
                    buildStad();
                }
                return _amsterdam;
            }
            private set {}
        }

        private void buildStad()
        {
            _amsterdam = new Stad(AMSTERDAM, 200);
            _amsterdam.Add(new Straat(LEIDSESTRAAT, 350, new Huur(35, 175, 500, 1100, 1300, 1500)));
            _amsterdam.Add(new Straat(KALVERSTRAAT, 400, new Huur(50, 200, 600, 1400, 1700, 2000)));
        }

        public static AmsterdamBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new AmsterdamBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }
    }
}
