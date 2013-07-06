//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Monopoly.domein.velden;

//namespace Monopoly.domein.gebeurtenissen
//{
//    public class GevangenisGebeurtenis : Gebeurtenis
//    {
//        public GevangenisGebeurtenis()
//            : base(Gebeurtenisnamen.IN_DE_GEVANGENIS)
//        {
//            SpelerStatus = GevangenisStatus.Bezoek;
//        }
//        public GevangenisGebeurtenis(GevangenisStatus spelerStatus)
//            : base(Gebeurtenisnamen.IN_DE_GEVANGENIS)
//        {
//            SpelerStatus = spelerStatus;
//        }

//        public GevangenisStatus SpelerStatus { get; set; }

//        public override bool IsVerplicht()
//        {
//            return true;
//        }

//        public override bool IsUitvoerbaar(Speler speler)
//        {
//            return SpelerStatus == GevangenisStatus.Bezoek;
//        }

//        public override void Voeruit(Speler speler)
//        {
//            if (!speler.BeurtGebeurtenissen.BevatGebeurtenis(Gebeurtenisnamen.IN_DE_GEVANGENIS))
//            {   // Alleen de gevangenis gebeurtenis toevoegen met status "Op bezoek" als de speler niet al 
//                // zo'n gebeurtenis heeft.
//                speler.BeurtGebeurtenissen.VoegGebeurtenisToe(this);
//            }
//        }
//    }
//}
