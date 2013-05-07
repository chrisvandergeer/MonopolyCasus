using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis.kans
{
    public class VerlaatDeGevangenis : AbstractGebeurtenis
    {
        private Boolean KaartLigtOpStapel { get; set; }
        private List<Gebeurtenis> Kaartstapel { get; set; }

        public VerlaatDeGevangenis(List<Gebeurtenis> kaartstapel)
            : base("Verlaat de gevangenis zonder te betalen")
        {
            Kaartstapel = kaartstapel;
            KaartLigtOpStapel = true;
        }

        /// <summary>
        /// Een Verlaat de gevangenis kaart kan 2 statussen hebben. Beide statussen hebben een andere gebeurtenis.
        /// 1. De kaart komt van de Kans of Algemeen Fonds stapel en wordt het bezit van de speler
        /// 2. De kaart wordt gespeeld door de eigenaar en wordt teruggelegd op de stapel.
        /// </summary>
        /// <param name="speler">De speler die de eigenaar wordt of die de kaart speelt</param>
        /// <returns>
        /// true als de gebeurtenis uitgevoerd is. 
        /// De enige reden dat het uitvoeren mislukt is wanneer de speler niet in de gevangenis zit.
        /// </returns>
    
        public override GebeurtenisResult VoerUit(Speler speler)
        {
            GebeurtenisResult result = null;
            if (KaartLigtOpStapel)
            {
                speler.OntvangVerlaatDeGevangenisKaart(this);
                KaartLigtOpStapel = false;
                result = GebeurtenisResult.Uitgevoerd(speler, "ontvang een", Gebeurtenisnaam, "kaart");
            }
            else
            {
                if (!speler.InGevangenis)
                    return GebeurtenisResult.NietUitgevoerd(Gebeurtenisnaam, "kon niet worden uitgevoerd, want", speler, "zit niet in de gevangenis");
                speler.InGevangenis = false;
                speler.LeverInVerlaatDeGevangenisKaart(this);
                Kaartstapel.Add(this);
                KaartLigtOpStapel = true;
                result = GebeurtenisResult.Uitgevoerd(speler, "speelt", Gebeurtenisnaam, "en is weer vrij");
            }
            return result;
        }

        /// <summary>
        /// Wanneer de kaart van de stapel komt moet deze verplicht (automatisch) aan de speler worden toegekend.
        /// Eenmaal in bezit van de speler is de Gebeurtenis niet meer verplicht.
        /// </summary>
        /// <returns></returns>
        public override bool IsVerplicht()
        {
            return KaartLigtOpStapel;
        }
    }
}
