using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.builders
{
    class KaartenBuilder
    {
        private static KaartenBuilder _instance = null;
        private List<Kaart> _kansKaarten = null;
        private List<Kaart> _algemeenFondsKaarten = null;

        public static KaartenBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KaartenBuilder();
                }
                return _instance;
            }
        }
 
        private KaartenBuilder()
        {
            initKansKaarten();
            initAlgemeneFondsKaarten();
        }

        private void initAlgemeneFondsKaarten()
        {
            // TODO: Further implement this method. The stack of card should have ?? cards
            _algemeenFondsKaarten = new List<Kaart>();
            _algemeenFondsKaarten.Add(new Kaart("naar gevangenis", new GaNaarGevangenis(), false));
        }

        private void initKansKaarten()
        {
            // TODO: Further implement this method. The stack of card should have ?? cards
            _kansKaarten = new List<Kaart>();
            _kansKaarten.Add(new Kaart("naar gevangenis", new GaNaarGevangenis(), false));
        }

        public List<Kaart> getKansKaarten()
        {
            return _kansKaarten;
        }
        public List<Kaart> getAlgemeenFondsKaarten()
        {
            return _algemeenFondsKaarten;
        }
    }
}
