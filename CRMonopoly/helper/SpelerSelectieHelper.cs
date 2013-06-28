using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;
using CRMonopoly.domein;

namespace CRMonopoly.helper
{
    class SpelerSelectieHelper
    {

        public static List<VerkoopbaarVeld> geefMogelijkeStraatWaaropGebouwdKanWorden(Speler speler)
        {
            List<VerkoopbaarVeld> mijnStratenWaaropGebouwdKanWorden = new List<VerkoopbaarVeld>();
            foreach (VerkoopbaarVeld veld in speler.getStraten())
            {
                if (veld is Straat)
                {
                    Straat straat = (Straat)veld;
                    if (straat.MagHuisKopen())
                    {
                        mijnStratenWaaropGebouwdKanWorden.Add(veld);
                    }
                }
            }
            return mijnStratenWaaropGebouwdKanWorden;
        }
        public static List<VerkoopbaarVeld> geefMogelijkeStraatAankopenVoorSpeler(Speler speler)
        {
            List<VerkoopbaarVeld> stratenVoorEenBod = new List<VerkoopbaarVeld>();
            foreach (Veld veld in speler.Bord.GeefAlleVelden())
            {
                if (veld is VerkoopbaarVeld)
                {
                    VerkoopbaarVeld verkoopbaarVeld = (VerkoopbaarVeld)veld;
                    if (verkoopbaarVeld.heeftEigenaar() && verkoopbaarVeld.Eigenaar != speler)
                    {
                        stratenVoorEenBod.Add(verkoopbaarVeld);
                    }
                }
            }
            return stratenVoorEenBod;
        }

        internal int geeftAlleStratenDieInBezitZijnVanSpeler(Speler speler)
        {
            int aantal = 0;
            if (verkoopbaarVeld is Nutsbedrijf)
            {
                aantal = geefAantalNutsbedrijvenInBezitVanSpeler(speler);
            }
            else if (verkoopbaarVeld is Station)
            {
                aantal = geefAantalStationsInBezitVanSpeler(speler);
            }
            else if (verkoopbaarVeld is Straat)
            {
                aantal = geefAantalStratenInDezelfdeStadInBezitVanSpeler(speler, (Straat)verkoopbaarVeld);
            }
            return aantal;
        }

        internal int geeftAantalStratenInDeStadVanDezeStraatDieInBezitZijnVanSpeler(VerkoopbaarVeld verkoopbaarVeld, Speler speler)
        {
            int aantal = 0;
            if (verkoopbaarVeld is Nutsbedrijf)
            {
                aantal = geefAantalNutsbedrijvenInBezitVanSpeler(speler);
            }
            else if (verkoopbaarVeld is Station)
            {
                aantal = geefAantalStationsInBezitVanSpeler(speler);
            }
            else if (verkoopbaarVeld is Straat)
            {
                aantal = geefAantalStratenInDezelfdeStadInBezitVanSpeler(speler, (Straat)verkoopbaarVeld);
            }
            return aantal;
        }

        private int geefAantalStratenInDezelfdeStadInBezitVanSpeler(Speler speler, Straat straat)
        {
            Stad stad = geeftStadVanDezeStraat(straat);
            int aantal = 0;
            // TODO: Implementeren met ?? macro
            foreach (Straat tempStraat in stad.Straten)
            {
                if (tempStraat.Eigenaar == speler)
                {
                    aantal++;
                }
            }
            return aantal;
        }

        private Stad geeftStadVanDezeStraat(Straat straat)
        {
            if (OnsDorpBuilder.Instance.OnsDorp.Contains(straat))
            {
                return OnsDorpBuilder.Instance.OnsDorp;
            }
            else if (ArnhemBuilder.Instance.Arnhem.Contains(straat))
            {
                return ArnhemBuilder.Instance.Arnhem;
            }
            else if (UtrechtBuilder.Instance.Utrecht.Contains(straat))
            {
                return UtrechtBuilder.Instance.Utrecht;
            }
            else if (HaarlemBuilder.Instance.Haarlem.Contains(straat))
            {
                return HaarlemBuilder.Instance.Haarlem;
            }
            else if (DenHaagBuilder.Instance.DenHaag.Contains(straat))
            {
                return DenHaagBuilder.Instance.DenHaag;
            }
            else if (GroningenBuilder.Instance.Groningen.Contains(straat))
            {
                return GroningenBuilder.Instance.Groningen;
            }
            else if (RotterdamBuilder.Instance.Rotterdam.Contains(straat))
            {
                return RotterdamBuilder.Instance.Rotterdam;
            }
            else if (AmsterdamBuilder.Instance.Amsterdam.Contains(straat))
            {
                return AmsterdamBuilder.Instance.Amsterdam;
            }
            return null;
        }

        private int geefAantalStationsInBezitVanSpeler(Speler speler)
        {
            int aantal = 0;
            // TODO: Implementeren met ?? macro
            foreach (Station station in Stationbuilder.Instance.Stations.Values)
            {
                if (station.Eigenaar == speler)
                {
                    aantal++;
                }
            }
            return aantal;
        }

        private static int geefAantalNutsbedrijvenInBezitVanSpeler(Speler speler)
        {
            int aantal = 0;
            // TODO: Implementeren met ?? macro
            foreach (Nutsbedrijf nutsbedrijf in NutsbedrijvenBuilder.Instance.NutsBedrijven.AlleNutsBedrijven)
            {
                if (nutsbedrijf.Eigenaar == speler)
                {
                    aantal++;
                }
            }
            return aantal;
        }

    }
}
