using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.velden;

namespace CRMonopoly.builders
{
    class BelastingVeldenBuilder
    {
        public static readonly String INKOMSTENBELASTING = "Inkomstenbelasting";
        public static readonly String EXTRAINKOMSTENBELASTING = "Extra Inkomstenbelasting";

        private static volatile BelastingVeldenBuilder _instance;
        private static object _syncRoot = new Object();
        private BelastingVelden _belastingVelden = null;

        private BelastingVeldenBuilder()
        {
        }

        public BelastingVelden BelastingVelden
        {
            get
            {
                if (_belastingVelden == null)
                {
                    buildBelastingVelden();
                }
                return _belastingVelden;
            }
            private set { }
        }
        private void buildBelastingVelden()
        {
            _belastingVelden = new BelastingVelden();
            _belastingVelden.Add(new BelastingVeld(INKOMSTENBELASTING, 150));
            _belastingVelden.Add(new BelastingVeld(EXTRAINKOMSTENBELASTING, 200));
        }

        public static BelastingVeldenBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new BelastingVeldenBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }
    }
}
