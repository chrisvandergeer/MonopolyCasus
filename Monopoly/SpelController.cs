using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Monopoly.domein.gebeurtenissen;
using Microsoft.Practices.Unity;
using Monopoly.AI;

namespace Monopoly
{
    public class SpelController
    {
        [Dependency]
        public Monopolyspel Spel { get; set; }

        public Monopolyspel MaakSpel()
        {
            return Spel;
        }

        public void VoegSpelerToe(string spelersnaam, TypesAI aiType)
        {
            Spel.VoegSpelerToe(spelersnaam, aiType);
        }

        public Speler StartSpel()
        {
            Spel.Start();
            return Spel.HuidigeSpeler;
        }

        public Gebeurtenislijst SpeelGebeurtenis(string gebeurtenisnaam)
        {
            Speler speler = Spel.HuidigeSpeler;
            speler.SpeelGebeurtenis(gebeurtenisnaam);
            return speler.BeurtGebeurtenissen;
        }

        public Speler EindeBeurt()
        {
            return Spel.WisselBeurt();
        }
    }
}
