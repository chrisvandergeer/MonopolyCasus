using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    class KaartVeld : Veld
    {
        private List<Kaart> mynStapelKaarten = null;

        public KaartVeld(String naam, List<Kaart> stapelKaarten) : base(naam)
        {
            mynStapelKaarten = stapelKaarten;
        }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            // Haal de kaart van de stapel (positie 0) en plaats hem weer onderop (met lijst.Add) als
            // de kaart niet aan de speler gegeven moet worden (bijv. de ga-uit-de-gevangenis kaart)
            Kaart kaart = mynStapelKaarten[0];
            mynStapelKaarten.Remove(kaart);
            if (!kaart.KaartNaarSpeler)
            {
                mynStapelKaarten.Add(kaart);
            }
            return kaart.Actie;
        }

    }
}
