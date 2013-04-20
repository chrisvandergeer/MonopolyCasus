using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.builders
{
    class HaarlemBuilder
    {
        public static readonly string HAARLEM           = "Haarlem";

        public static readonly string HOUTSTRAAT        = "Houtstraat";
        public static readonly string BARTELJORISSTRAAT = "Barteljorisstraat";
        public static readonly string ZIJLWEG           = "Zijlweg";

        private static volatile HaarlemBuilder _instance;
        private static object _syncRoot = new Object();
        private Stad _haarlem = null;

        private HaarlemBuilder()
        {
        }


        public Stad Haarlem
        {
            get {
                if (_haarlem == null) {
                    buildStad();
                }
                return _haarlem;
            }
            private set {}
        }

        private void buildStad()
        {
            _haarlem = new Stad(HAARLEM, 100);
            _haarlem.Add(new Straat(BARTELJORISSTRAAT, 140, new Huur(10, 50, 150, 450, 625, 750)));
            _haarlem.Add(new Straat(ZIJLWEG, 140, new Huur(10, 50, 150, 450, 625, 750)));
            _haarlem.Add(new Straat(HOUTSTRAAT, 160, new Huur(12, 60, 180, 500, 700, 900)));
        }

        public static HaarlemBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new HaarlemBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }
    }
}
