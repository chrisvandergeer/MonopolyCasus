﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Monopoly.domein.gebeurtenissen;
using Microsoft.Practices.Unity;

namespace Monopoly
{
    public class SpelController
    {
        [Dependency]
        public Monopolyspel Spel { get; set; }

        public Monopolyspel MaakSpel()
        {
            //Spel = new Monopolyspel();
            return Spel;
        }

        public void VoegSpelerToe(string spelersnaam)
        {
            Spel.VoegSpelerToe(spelersnaam);
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
