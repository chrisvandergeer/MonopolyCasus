using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;
using Monopoly.builders;
using Monopoly.domein.labels;

namespace Monopoly.domein
{
    public class Spelbord : IHuurObserver
    {
        public List<Veld> Velden { get; private set; }
        public int maxHuur = -1;

        public Spelbord()
        {
            Velden = new List<Veld>();
            Gebeurtenisveldbuilder gebeurtenisveldBuilder = new Gebeurtenisveldbuilder(this);
            Straatbuilder straatbuilder = new Straatbuilder().Build();
            StationEnNutsBuilder stationbuilder = new StationEnNutsBuilder();
            Velden.Add(gebeurtenisveldBuilder.BuildStart());
            Velden.Add(straatbuilder.Naam(Veldnamen.DORPSSTRAAT));
            Velden.Add(gebeurtenisveldBuilder.BuildAlgemeenFonds());
            Velden.Add(straatbuilder.Naam(Veldnamen.BRINK));
            Velden.Add(gebeurtenisveldBuilder.BuildInkomstenBelasting());
            Velden.Add(stationbuilder.buildStationZuid());
            Velden.Add(straatbuilder.Naam(Veldnamen.STEENSTRAAT));
            Velden.Add(gebeurtenisveldBuilder.BuildKans());             // Kans
            Velden.Add(straatbuilder.Naam(Veldnamen.KETELSTRAAT));
            Velden.Add(straatbuilder.Naam(Veldnamen.VELPERPLEIN));
            //Velden.Add(gebeurtenisveldBuilder.BuildGevangenis());// Gevangenis
            Velden.Add(new Gevangenis());
            Velden.Add(straatbuilder.Naam(Veldnamen.BARTELJORISSTRAAT));
            Velden.Add(stationbuilder.buildNutsElektriciteit());
            Velden.Add(straatbuilder.Naam(Veldnamen.ZIJLWEG));
            Velden.Add(straatbuilder.Naam(Veldnamen.HOUTSTRAAT));
            Velden.Add(stationbuilder.buildStationWest());
            Velden.Add(straatbuilder.Naam(Veldnamen.NEUDE));
            Velden.Add(gebeurtenisveldBuilder.BuildAlgemeenFonds());
            Velden.Add(straatbuilder.Naam(Veldnamen.BILTSTRAAT));
            Velden.Add(straatbuilder.Naam(Veldnamen.VREEBURG));
            Velden.Add(gebeurtenisveldBuilder.BuildVrijParkeren());     // Vrij parkeren
            Velden.Add(straatbuilder.Naam(Veldnamen.AKERKHOF));
            Velden.Add(gebeurtenisveldBuilder.BuildKans());             // Kans
            Velden.Add(straatbuilder.Naam(Veldnamen.GROTE_MARKT));
            Velden.Add(straatbuilder.Naam(Veldnamen.HEERESTRAAT));
            Velden.Add(stationbuilder.buildStationNoord());
            Velden.Add(straatbuilder.Naam(Veldnamen.SPUI));
            Velden.Add(straatbuilder.Naam(Veldnamen.PLEIN));
            Velden.Add(stationbuilder.buildNutsWaterleiding());
            Velden.Add(straatbuilder.Naam(Veldnamen.LANGE_POTEN));
            Velden.Add(gebeurtenisveldBuilder.BuildGaNaarGevangenis()); // Naar de gevangenis
            Velden.Add(straatbuilder.Naam(Veldnamen.HOFPLEIN));
            Velden.Add(straatbuilder.Naam(Veldnamen.BLAAK));
            Velden.Add(gebeurtenisveldBuilder.BuildAlgemeenFonds());
            Velden.Add(straatbuilder.Naam(Veldnamen.COOLSINGEL));
            Velden.Add(stationbuilder.buildStationOost());
            Velden.Add(gebeurtenisveldBuilder.BuildKans());             // Kans
            Velden.Add(straatbuilder.Naam(Veldnamen.LEIDSCHESTRAAT));
            Velden.Add(gebeurtenisveldBuilder.BuildInkomstenBelasting());
            Velden.Add(straatbuilder.Naam(Veldnamen.KALVERSTRAAT));
            addHuurObserver2AllFields();
        }

        /// <summary>
        /// Plaatst een nieuwe speler op bij aanvang van het spel.
        /// </summary>
        /// <param name="nieuweSpeler"></param>
        public void Plaats(Speler nieuweSpeler)
        {
            nieuweSpeler.Positie = Velden[0];
        }

        public Veld GeefVeld(string veldnaam)
        {
            return Velden.FindLast(item => item.Naam.Equals(veldnaam));
        }

        /// <summary>
        /// Geeft het nieuwe veld ten opzichte van de huidige positie en de worp. 
        /// </summary>
        /// <param name="Positie"></param>
        /// <param name="worp"></param>
        /// <returns></returns>
        public Veld GeefVeld(Veld huidigePositie, Worp worp)
        {
            return GeefVeld(huidigePositie, worp.Totaal());
            //int pos = Velden.IndexOf(huidigePositie);
            //int nieuwePos = pos + worp.Totaal();
            //if (nieuwePos >= Velden.Count)
            //{
            //    nieuwePos = nieuwePos - Velden.Count;
            //}
            //return Velden[nieuwePos];
        }

        public Veld GeefVeld(Veld huidigePositie, int aantalPosities)
        {
            int pos = Velden.IndexOf(huidigePositie);
            int nieuwePos = pos + aantalPosities;
            if (nieuwePos >= Velden.Count)
            {
                nieuwePos = nieuwePos - Velden.Count;
            }
            else if (nieuwePos < 0)
            {
                nieuwePos = Velden.Count + nieuwePos;
            }
            return Velden[nieuwePos];
        }

        public int GeefVeldIndex(Veld veld)
        {
            for (int teller = 0; teller < Velden.Count; teller++)
            {
                if (Velden[teller] == veld) return teller;
            }
            return -1;
        }

        public void huurUpdate(Veld veld)
        {
            if ( veld is IHypotheekveld ) {
                if (maxHuur < ((IHypotheekveld)veld).BepaalHuurprijs())
                {
                    maxHuur = ((IHypotheekveld)veld).BepaalHuurprijs();
                }
                //else
                //{
                //    Velden.ForEach(s => maxHuur = Math.Max(maxHuur, (s is IHypotheekveld && ((IHypotheekveld)s).Eigenaar != null) ? ((IHypotheekveld)s).BepaalHuurprijs(): 0));
                //}
            }
        }
        private void addHuurObserver2AllFields()
        {
            Velden.ForEach(s => s.addObserver(this));
        }
        public int geefMaximumHuur()
        {
            return maxHuur;
        }


        internal Gevangenis Gevangenis()
        {
            return (Gevangenis)GeefVeld(Veldnamen.GEVANGENIS);
        }
    }
}
