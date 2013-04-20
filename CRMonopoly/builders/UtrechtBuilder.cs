using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.builders
{
    class UtrechtBuilder
    {
        public static readonly string UTRECHT           = "Utrecht";

        public static readonly string NEUDE             = "Neude";
        public static readonly string BILTSTRAAT        = "Biltstraat";
        public static readonly string VREEBURG          = "Vreeburg";

        private static volatile UtrechtBuilder _instance;
        private static object _syncRoot = new Object();
        private Stad _utrecht = null;

        private UtrechtBuilder()
        {
        }


        public Stad Utrecht
        {
            get {
                if (_utrecht == null)
                {
                    buildStad();
                }
                return _utrecht;
            }
            private set {}
        }

        private void buildStad()
        {
            _utrecht = new Stad(UTRECHT, 100);
            _utrecht.Add(new Straat(NEUDE, 180, new Huur(14, 70, 200, 550, 750, 950)));
            _utrecht.Add(new Straat(BILTSTRAAT, 180, new Huur(14, 70, 200, 550, 750, 950)));
            _utrecht.Add(new Straat(VREEBURG, 200, new Huur(16, 80, 220, 600, 800, 1000)));
        }

        public static UtrechtBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new UtrechtBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }
    }
}
