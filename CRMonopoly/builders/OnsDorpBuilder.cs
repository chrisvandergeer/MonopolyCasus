using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.builders
{
    class OnsDorpBuilder
    {
        public static readonly string ONS_DORP          = "OnsDorp";

        public static readonly string DORPSSTRAAT       = "Dorpsstraat";
        public static readonly string BRINK             = "Brink";

        private static volatile OnsDorpBuilder _instance;
        private static object _syncRoot = new Object();
        private Stad _onsDorp = null;

        private OnsDorpBuilder()
        {
        }


        public Stad OnsDorp
        {
            get {
                if (_onsDorp == null) {
                    buildStad();
                }
                return _onsDorp;
            }
            private set {}
        }

        private void buildStad()
        {
            _onsDorp = new Stad(ONS_DORP, 50);
            _onsDorp.Add(new Straat(DORPSSTRAAT, 60, new Huur(2, 10, 30, 90, 160, 250)));
            _onsDorp.Add(new Straat(BRINK, 60, new Huur(4, 20, 60, 180, 320, 450)));
        }

        public static OnsDorpBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new OnsDorpBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }
    }
}
