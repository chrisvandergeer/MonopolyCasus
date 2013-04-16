using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.builders;

namespace CRMonopoly.builders
{
    public class StadBuilder
    {
        private static StadBuilder _instance = null;

        public static readonly string NAAM_STAD_ONS_DORP    = "Ons Dorp";
        public static readonly string NAAM_STAD_AMSTERDAM   = "Amsterdam";
        public static readonly string NAAM_STAD_ARNHEM      = "Arnhem";
        public static readonly string NAAM_STAD_DEN_HAAG    = "Den Haag";
        public static readonly string NAAM_STAD_HAARLEM     = "Haarlem";
        public static readonly string NAAM_STAD_UTRECHT     = "Utrecht";
        public static readonly string NAAM_STAD_GRONINGEN   = "Groningen";
        public static readonly string NAAM_STAD_ROTTERDAM   = "Rotterdam";

        public static readonly string NAAM_STRAAT_ONS_DORP_DORPSSTRAAT      = "Dorpsstraat";
        public static readonly string NAAM_STRAAT_ONS_DORP_BRINK            = "Brink";

        public static readonly string NAAM_STRAAT_AMSTERDAM_LEIDSESTRAAT    = "Leidsestraat";
        public static readonly string NAAM_STRAAT_AMSTERDAM_KALVERSTRAAT    = "Kalverstraat";

        public static readonly string NAAM_STRAAT_ARNHEM_STEENSTRAAT        = "Steenstraat";
        public static readonly string NAAM_STRAAT_ARNHEM_VELPERPLEIN        = "Velperplein";
        public static readonly string NAAM_STRAAT_ARNHEM_KETELSTRAAT        = "Ketelstraat";

        public static readonly string NAAM_STRAAT_DEN_HAAG_SPUI             = "Spui";
        public static readonly string NAAM_STRAAT_DEN_HAAG_LANGE_POTEN      = "Lange Poten";
        public static readonly string NAAM_STRAAT_DEN_HAAG_PLEIN            = "Plein";

        public static readonly string NAAM_STRAAT_HAARLEM_HOUTSTRAAT        = "Houtstraat";
        public static readonly string NAAM_STRAAT_HAARLEM_BARTELJORISSTRAAT = "Barteljorisstraat";
        public static readonly string NAAM_STRAAT_HAARLEM_ZIJLWEG           = "Zijlweg";

        public static readonly string NAAM_STRAAT_UTRECHT_NEUDE             = "Neude";
        public static readonly string NAAM_STRAAT_UTRECHT_BILTSTRAAT        = "Biltstraat";
        public static readonly string NAAM_STRAAT_UTRECHT_VREEBURG          = "Vreeburg";

        public static readonly string NAAM_STRAAT_GRONINGEN_ALGEMENE_KERKHOF = "A-Kerkhof";
        public static readonly string NAAM_STRAAT_GRONINGEN_GROTE_MARKT     = "Grote Markt";
        public static readonly string NAAM_STRAAT_GRONINGEN_HEERESTRAAT     = "Heerestraat";

        public static readonly string NAAM_STRAAT_ROTTERDAM_HOFPLEIN        = "Hofplein";
        public static readonly string NAAM_STRAAT_ROTTERDAM_BLAAK           = "Blaak";
        public static readonly string NAAM_STRAAT_ROTTERDAM_COOLSINGEL      = "Coolsingel";

        
        private Stad amsterdam = null;
        private Stad arnhem = null;
        private Stad denHaag = null;
        private Stad onsDorp = null;
        private Stad haarlem = null;
        private Stad utrecht = null;
        private Stad groningen = null;
        private Stad rotterdam = null;

        private StadBuilder()
        {
            // Hier misschien alle steden alvast bouwen? We hebben ze toch nodig.
            // Opmerking Chris: Ik zou ik de builders geen straten en steden vasthouden (state). 
            // Je hebt ze in principe maar 1 keer nodig om je bord op te bouwen en daarna niet meer.
        }


        public static StadBuilder Instance {
            get
            {
                if ( _instance == null ) {
                    _instance = new StadBuilder();
                }
                return _instance;
            }
        }

        public Stad BuildAmsterdam()
        {
            if (amsterdam == null)
            {
                amsterdam = new Stad(NAAM_STAD_AMSTERDAM, 200);
                amsterdam.Add(new Straat(NAAM_STRAAT_AMSTERDAM_LEIDSESTRAAT, 350, new Huur(35, 175, 500, 1100, 1300, 1500)));
                amsterdam.Add(new Straat(NAAM_STRAAT_AMSTERDAM_KALVERSTRAAT, 400, new Huur(50, 200, 600, 1400, 1700, 2000)));
            }
            return amsterdam;
        }

        public Stad BuildArnhem()
        {
            if (arnhem == null)
            {
                arnhem = new Stad(NAAM_STAD_ARNHEM, 50);
                arnhem.Add(new Straat(NAAM_STRAAT_ARNHEM_STEENSTRAAT, 100, new Huur(6, 30, 90, 270, 400, 550)));
                arnhem.Add(new Straat(NAAM_STRAAT_ARNHEM_KETELSTRAAT, 100, new Huur(6, 30, 90, 270, 400, 550)));
                arnhem.Add(new Straat(NAAM_STRAAT_ARNHEM_VELPERPLEIN, 120, new Huur(8, 40, 120, 360, 450, 600)));
            }
            return arnhem;
        }

        public Stad BuildDenHaag()
        {
            if (denHaag == null)
            {
                denHaag = new Stad(NAAM_STAD_DEN_HAAG, 150);
                denHaag.Add(new Straat(NAAM_STRAAT_DEN_HAAG_SPUI, 260, new Huur(22, 110, 330, 800, 975, 1150)));
                denHaag.Add(new Straat(NAAM_STRAAT_DEN_HAAG_PLEIN, 260, new Huur(22, 110, 330, 800, 975, 1150)));
                denHaag.Add(new Straat(NAAM_STRAAT_DEN_HAAG_LANGE_POTEN, 280, new Huur(24, 120, 360, 850, 1025, 1200)));
            }
            return denHaag;
        }

        public Stad BuildOnsDorp()
        {
            if (onsDorp == null)
            {
                onsDorp = new Stad(NAAM_STAD_ONS_DORP, 50);
                onsDorp.Add(new Straat(NAAM_STRAAT_ONS_DORP_DORPSSTRAAT, 60, new Huur(2, 10, 30, 90, 160, 250)));
                onsDorp.Add(new Straat(NAAM_STRAAT_ONS_DORP_BRINK, 60, new Huur(4, 20, 60, 180, 320, 450)));
            }
            return onsDorp;
        }

        public Stad BuildHaarlem()
        {
            if (haarlem == null)
            {
                haarlem = new HaarlemBuilder().buildStad();
            }
            return haarlem;
        }
        public Stad BuildUtrecht()
        {
            if (utrecht == null)
            {
                utrecht = new Stad(NAAM_STAD_UTRECHT, 100);
                utrecht.Add(new Straat(NAAM_STRAAT_UTRECHT_NEUDE, 180, new Huur(14, 70, 200, 550, 750, 950)));
                utrecht.Add(new Straat(NAAM_STRAAT_UTRECHT_BILTSTRAAT, 180, new Huur(14, 70, 200, 550, 750, 950)));
                utrecht.Add(new Straat(NAAM_STRAAT_UTRECHT_VREEBURG, 200, new Huur(16, 80, 220, 600, 800, 1000)));
            }
            return utrecht;
        }
        public Stad BuildGroningen()
        {
            if (groningen == null)
            {
                groningen = new Stad(NAAM_STAD_GRONINGEN, 150);
                groningen.Add(new Straat(NAAM_STRAAT_GRONINGEN_ALGEMENE_KERKHOF, 220, new Huur(18, 90, 250, 700, 875, 1050)));
                groningen.Add(new Straat(NAAM_STRAAT_GRONINGEN_GROTE_MARKT, 220, new Huur(18, 90, 250, 700, 875, 1050)));
                groningen.Add(new Straat(NAAM_STRAAT_GRONINGEN_HEERESTRAAT, 240, new Huur(20, 100, 300, 750, 925, 1100)));
            }
            return groningen;
        }
        public Stad BuildRotterdam()
        {
            if (rotterdam == null)
            {
                rotterdam = new Stad(NAAM_STAD_ROTTERDAM, 200);
                rotterdam.Add(new Straat(NAAM_STRAAT_ROTTERDAM_HOFPLEIN, 300, new Huur(26, 130, 390, 900, 1100, 1275)));
                rotterdam.Add(new Straat(NAAM_STRAAT_ROTTERDAM_BLAAK, 300, new Huur(26, 130, 390, 900, 1100, 1275)));
                rotterdam.Add(new Straat(NAAM_STRAAT_ROTTERDAM_COOLSINGEL, 320, new Huur(28, 150, 450, 1000, 1200, 1400)));
            }
            return rotterdam;
        }
    }
}