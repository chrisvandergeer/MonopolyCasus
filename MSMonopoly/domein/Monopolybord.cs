using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.builders;
using MSMonopoly.domein.velden;
using MSMonopoly.domein.gebeurtenis;

namespace MSMonopoly.domein
{
    public class Monopolybord
    {
        private List<Veld> Velden;

        public Monopolybord()
        {
            Velden = new List<Veld>();
            Vrij vrij = new Vrij();
            StadBuilder builder = new StadBuilder();
            Velden.Add(new Start());
            Velden.AddRange(builder.BuildAmsterdam().Straten);
            Velden.Add(new VrijParkeren());
            Velden.AddRange(builder.BuildArnhem().Straten);
            Velden.Add(new GevangenisOpBezoek());
            Velden.AddRange(builder.BuildDenHaag().Straten);
        }

        internal Veld StartVeld()
        {
            return Velden[0];
        }

        internal Veld GeefVeld(Veld veld, Worp worp)
        {
            int pos = Velden.IndexOf(veld);
            int nieuwePos = pos + worp.Totaal();
            if (nieuwePos >= Velden.Count)
            {
                nieuwePos = nieuwePos - Velden.Count;
            }
            return Velden[nieuwePos];
        }
    }
}
