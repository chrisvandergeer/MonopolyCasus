using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    public interface Gebeurtenis
    {
        /// <summary>
        /// Voer de gebeurtenis uit
        /// </summary>
        /// <param name="speler">De speler waarvoor de gebeurtenis van toepassing is</param>
        /// <returns>true indien succesvol uitgevoerd. Indien de gebeurtenis niet kan worden
        /// uitgevoerd, bijvoorbeeld omdat de speler niet genoeg geld heeft om de gebeurtenis terug te geven, wordt false 
        /// teruggegeven.</returns>
        GebeurtenisResult VoerUit(Speler speler);

        /// <summary>
        /// Geeft aan of een gebeurtenis afgerond moet worden voordat de speler zijn beurt kan beeindigen. 
        /// voorbeelden van een verplichte gebeurtenissen: betaal huur, betaal belasting, ontvang geld  
        /// voorbeeld van een niet-verplichte gebeurtenis: koop een straat
        /// </summary>
        /// <returns></returns>
        bool IsVerplicht();

        string Gebeurtenisnaam { get; }
        GebeurtenisType Gebeurtenistype { get; }

        bool IsUitvoerbaar(Speler speler);
    }
}
