using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.domein.gebeurtenis.kans
{
    class GaNaarGebeurtenis : AbstractGebeurtenis
    {
        private String Bestemming { get; set; }

        public GaNaarGebeurtenis(String bestemmingVeldnaam, string gebeurtenisnaam) : base(gebeurtenisnaam, GebeurtenisType.Verplaats)
        {
            Bestemming = bestemmingVeldnaam;
        }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            string startGeldMeldingTekst = null;
            Veld huidigePositie = speler.HuidigePositie;
            if (KomtLangsStart(speler))
            {
                startGeldMeldingTekst = new OntvangGeld(200, 
                    String.Format("Speler '{0}' komt langs start en ontvangt ƒ 200,--", speler.Name)
                    ).VoerUit(speler).Melding;
            }
            Gebeurtenis gebeurtenis = speler.Verplaats(speler.Bord.GeefVeld(Bestemming));
            GebeurtenisResult result = gebeurtenis.VoerUit(speler);
            if (startGeldMeldingTekst != null)
                result.Append(startGeldMeldingTekst);
            return result;
        }

        private bool KomtLangsStart(Speler speler)
        {
            Veld huidigePositie = speler.HuidigePositie;
            Monopolybord bord = huidigePositie.Bord;
            return bord.GeefPositie(huidigePositie) > bord.GeefPositie(speler.Bord.GeefVeld(Bestemming));
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string ToString()
        {
            return String.Format("GaNaarGebeurtenis: ga naar {0}, Naam: {1}", Bestemming, Gebeurtenisnaam);
        }
    }
}
