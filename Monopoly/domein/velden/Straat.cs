using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein.akties;

namespace Monopoly.domein.velden
{
    public class Straat : Veld, IHypotheekveld, IHuurObserver
    {
        private Straathuur Huurbedragen { get; set;         }
        public Stad Stad                { get; private set; }
        public Speler Eigenaar
        {
            get
            {
                return Eigenaar;
            }
            private set
            {
                signalHuurUpdate();
                Eigenaar = value;
            }
        }
        public int Koopprijs            { get; private set; }
        public int PrijsVoorEenHuis     { get; private set; }
        public int AantalHuizen         { get; private set; }
        public Hypotheek Hypotheek      { get; private set; }
        private List<IHuurObserver> myObservers = new List<IHuurObserver>();
         
        public Straat(string straatnaam, int prijs, Straathuur huur)
            : base(straatnaam) 
        {
            Koopprijs = prijs;
            Huurbedragen = huur;
            PrijsVoorEenHuis = prijs;
            Hypotheek = new Hypotheek(this);
            Hypotheek.addObserver(this);
        }

        internal void SetStad(Stad stad) 
        {
            Stad = stad;
        }

        public override IGebeurtenis BepaalGebeurtenis()
        {
            if (Eigenaar == null)
                return new KoopStraat(this);
            if (Eigenaar.IsHuidigespeler())
                return new Vrij(this + " is van " + Eigenaar);
            return new BetaalHuur(this);
        }


        /// <summary>
        /// Verkoop een straat aan een speler
        /// </summary>
        /// <param name="koper"></param>
        /// <returns>true indien speler voldoende geld had en de koop gelukt is</returns>
        public bool Verkoop(Speler koper)
        {
            Speler begunstigde = Eigenaar == null ? Monopolyspel.BANK : Eigenaar;
            if (koper.Bezittingen.Betaal(Koopprijs, begunstigde))
            {
                Eigenaar = koper;
                koper.Bezittingen.Hypotheekvelden.Add(this);
                begunstigde.Bezittingen.Hypotheekvelden.Remove(this);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Een Straat kan bebouwd worden indien aan de volgende voorwaarden wordt voldaan:
        /// - De straat heeft een eigenaar
        /// - De eigenaar heeft alle straten van de stad in bezit
        /// - De straat bevat minder dan 4 huizen
        /// - De eigenaar heeft voldoende kasgeld om een huis te betalen
        /// </summary>
        /// <returns></returns>
        public bool KanBebouwdWordenMetHuis()
        {
            if (Eigenaar == null)
                return false;
            return Stad.BezitStad(Eigenaar)
                && AantalHuizen < 4
                && !Hypotheek.IsOnderHypotheek;
        }

        public int BepaalHuurprijs()
        {
            return Huurbedragen.BepaalHuurprijs(this);
        }
        
        public bool Bebouw()
        {
            if (Eigenaar.Bezittingen.Betaal(PrijsVoorEenHuis))
            {
                AantalHuizen++;
                signalHuurUpdate();
                return true;
            }
            return false;
        }

         public void VerkoopHuis()
        {
            if (AantalHuizen < 0)
                throw new ApplicationException("Er kan geen huis verkocht worden op een straat waar geen huizen staan");
            Eigenaar.Bezittingen.OntvangGeld(PrijsVoorEenHuis / 2);
            AantalHuizen--;
            signalHuurUpdate();
        }
         public override void addObserver(IHuurObserver observer)
         {
             myObservers.Add(observer);
         }
         private void signalHuurUpdate()
         {
             myObservers.ForEach(o => o.huurUpdate(this));
         }
         public void huurUpdate(Veld veld)
         {
             signalHuurUpdate();
         }
    }
}
