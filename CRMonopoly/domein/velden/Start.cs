﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    class Start : Veld
    {
        public static string VELD_NAAM = "Start";
        public static string START_GEBEURTENIS_NAAM = "Op Start ontvangt u euro 400,--";

        public Start() : base(VELD_NAAM) { }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return new OntvangGeld(400, START_GEBEURTENIS_NAAM);
        }
    }
}
