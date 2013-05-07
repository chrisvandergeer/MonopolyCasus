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

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            GebeurtenisResult result = null;
            if (DeGevangenis.IsGevangene(speler))
            {
                int aantalBeurtenWacht = DeGevangenis.WachtBeurt(speler);
                if (aantalBeurtenWacht == 3)
                {
                    DeGevangenis.LaatVrij(speler);
                    result = GebeurtenisResult.Uitgevoerd(speler, "is vrij na 3 beurten in de gevangenis");
                }
                else
                {
                    result = GebeurtenisResult.Uitgevoerd(speler, " zit voor de ", aantalBeurtenWacht, "e beurt in de wacht");
                }
            }
            else
            {
                result = GebeurtenisResult.Uitgevoerd(speler, "is slechts op bezoek bij de gevangenis");
            }
            return result;
        }

        public override bool IsVerplicht()
        {
            return true;
        }
    }
}
