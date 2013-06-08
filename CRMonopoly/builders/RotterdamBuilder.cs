using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.builders
{
    class RotterdamBuilder
    {
        public static readonly string ROTTERDAM         = "Rotterdam";

        public static readonly string HOFPLEIN          = "Hofplein";
        public static readonly string BLAAK             = "Blaak";
        public static readonly string COOLSINGEL        = "Coolsingel";

        [ThreadStatic]
        private static volatile RotterdamBuilder _instance;
        private static object _syncRoot = new Object();
        private Stad _rotterdam = null;

        private RotterdamBuilder() { }

        public Stad Rotterdam
        {
            get {
                if (_rotterdam == null)
                {
                    buildStad();
                }
                return _rotterdam;
            }
            private set {}
        }

        private void buildStad()
        {
            _rotterdam = new Stad(ROTTERDAM, 200);
            _rotterdam.Add(new Straat(HOFPLEIN, 300, new Huur(26, 130, 390, 900, 1100, 1275)));
            _rotterdam.Add(new Straat(BLAAK, 300, new Huur(26, 130, 390, 900, 1100, 1275)));
            _rotterdam.Add(new Straat(COOLSINGEL, 320, new Huur(28, 150, 450, 1000, 1200, 1400)));
        }

        public static RotterdamBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new RotterdamBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }
    }
}
