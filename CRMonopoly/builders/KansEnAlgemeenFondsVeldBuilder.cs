using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;
using CRMonopoly.domein.velden;

namespace CRMonopoly.builders
{
    class KansEnAlgemeenFondsVeldBuilder// : KaartenBuilder
    {
        public static readonly string ALGEMEEN_FONDS_NAAM = "Algemeen Fonds";
        public static readonly string KANS_NAAM = "Kans";

        [ThreadStatic]
        private static volatile KansEnAlgemeenFondsVeldBuilder _instance;
        private static object _syncRoot = new Object();

        private Monopolybord Bord { get; set; }

        private KansEnAlgemeenFondsVeldBuilder()
        {
        }

        public static KansEnAlgemeenFondsVeldBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new KansEnAlgemeenFondsVeldBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }

        public Veld getAlgemeenFondsVeld(Monopolybord bord)
        {
            if (Bord == null)
            {
                Bord = bord;
            }
            KansEnAlgemeenfondsVeld veld = new KansEnAlgemeenfondsVeld(ALGEMEEN_FONDS_NAAM);
            veld.Builder = AlgemeenFondsKaartenBuilder.Instance;
            AlgemeenFondsKaartenBuilder.Instance.Bord = bord;
            return veld;
        }

        public Veld getKansVeld(Monopolybord bord)
        {
            if (Bord == null)
            {
                Bord = bord;
            }
            KansEnAlgemeenfondsVeld veld = new KansEnAlgemeenfondsVeld(KANS_NAAM);
            veld.Builder = KansKaartenBuilder.Instance;
            KansKaartenBuilder.Instance.Bord = bord;
            return veld;
        }

    }
}
