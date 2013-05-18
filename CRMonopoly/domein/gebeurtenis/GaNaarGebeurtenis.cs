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
                startGeldMeldingTekst = new OntvangGeld(200, "Langs Start ontvangt u ƒ 200,--").VoerUit(speler).Melding;
            }
            Gebeurtenis gebeurtenis = speler.Verplaats(speler.Bord.GeefVeld(Bestemming));
            // TODO: Checken of dit wel direct uitgevoerd moet worden. Wanneer de speler nu op een niet verkocht veld komt koopt ie die direct.
            // Volgens mij zou dit in de AI bepaald moeten worden. DUs waarschijnlijk alleen verplichtte gebeurtenissen laten direct uitvoeren.
            // Overleggen
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
    }
}
