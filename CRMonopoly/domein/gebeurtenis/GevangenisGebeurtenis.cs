using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    public class GevangenisGebeurtenis : AbstractGebeurtenis
    {
        private Gevangenis DeGevangenis { get; set; }

        public GevangenisGebeurtenis(Gevangenis gevangenis) : base("De gevangenis")
        {
            DeGevangenis = gevangenis;
        }

        public override bool VoerUit(Speler speler)
        {
            if (DeGevangenis.IsGevangene(speler))
            {
                int aantalBeurtenWacht = DeGevangenis.WachtBeurt(speler);
                if (aantalBeurtenWacht == 3)
                {
                    DeGevangenis.LaatVrij(speler);
                    SpelinfoLogger.Log(speler, " is vrij na 3 beurten in de gevangenis");
                }
                else
                {
                    SpelinfoLogger.Log(speler, " zit voor de ", aantalBeurtenWacht, "e beurt in de wacht");
                }
            }
            else
            {
                SpelinfoLogger.Log(speler, " is slechts op bezoek bij de gevangenis");
            }
            return true;
        }

        public override bool IsVerplicht()
        {
            return true;
        }
    }
}
