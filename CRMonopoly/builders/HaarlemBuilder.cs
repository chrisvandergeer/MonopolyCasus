using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;

namespace MSMonopoly.builders
{
    class HaarlemBuilder
    {
        public static readonly string HAARLEM           = "Haarlem";
        public static readonly string HOUTSTRAAT        = "Houtstraat";
        public static readonly string BARTELJORISSTRAAT = "Barteljorisstraat";
        public static readonly string ZIJLWEG           = "Zijlweg";

        public Stad buildStad()
        {
            Stad stad = new Stad(HAARLEM, 100);
            stad.Add(new Straat(BARTELJORISSTRAAT, 140, new Huur(10, 50, 150, 450, 625, 750)));
            stad.Add(new Straat(ZIJLWEG, 140, new Huur(10, 50, 150, 450, 625, 750)));
            stad.Add(new Straat(HOUTSTRAAT, 160, new Huur(12, 60, 180, 500, 700, 900)));
            return stad;
        }

        public static Straat createBarteljorisstraat()
        {
            return new HaarlemBuilder().buildStad().getStraatByName(BARTELJORISSTRAAT);
        }

    }
}
