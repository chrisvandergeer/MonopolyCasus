using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace CRMonopoly.domein
{ 
    public class Huur
    {
        private List<int> _huurprijzen;
        private int _huurprijsHotel;

        public Huur(int huurOnbebouwd, int huurMet1Huis, int huurMet2Huizen, int huurMet3Huizen, int huurMet4Huizen, int huurMetHotel)
        {
            _huurprijzen = new List<int>();
            _huurprijzen.Add(huurOnbebouwd);
            _huurprijzen.Add(huurMet1Huis);
            _huurprijzen.Add(huurMet2Huizen);
            _huurprijzen.Add(huurMet3Huizen);
            _huurprijzen.Add(huurMet4Huizen);
            _huurprijsHotel = huurMetHotel;
        }

        public int GeefTeBetalenHuur(Straat straat)
        {
            if (straat.HeeftHotel())
            {
                return _huurprijsHotel;
            }
            return _huurprijzen[straat.GeefAantalHuizen()];
        }
    }
}
