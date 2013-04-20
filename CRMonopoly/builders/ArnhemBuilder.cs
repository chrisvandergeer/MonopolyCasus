using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.builders
{
    class ArnhemBuilder
    {
        public static readonly string ARNHEM            = "Arnhem";

        public static readonly string STEENSTRAAT       = "Steenstraat";
        public static readonly string VELPERPLEIN       = "Velperplein";
        public static readonly string KETELSTRAAT       = "Ketelstraat";

        private static volatile ArnhemBuilder _instance;
        private static object _syncRoot = new Object();
        private Stad _arnhem = null;

        private ArnhemBuilder()
        {
        }


        public Stad Arnhem
        {
            get {
                if (_arnhem == null)
                {
                    buildStad();
                }
                return _arnhem;
            }
            private set {}
        }

        private void buildStad()
        {
            _arnhem = new Stad(ARNHEM, 50);
            _arnhem.Add(new Straat(STEENSTRAAT, 100, new Huur(6, 30, 90, 270, 400, 550)));
            _arnhem.Add(new Straat(KETELSTRAAT, 100, new Huur(6, 30, 90, 270, 400, 550)));
            _arnhem.Add(new Straat(VELPERPLEIN, 120, new Huur(8, 40, 120, 360, 450, 600)));
        }

        public static ArnhemBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new ArnhemBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }
    }
}
