using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis.creator
{
    public class GebeurtenissenCreator
    {
        private static GebeurtenissenCreator _instance;
        private static object _syncRoot = new Object();
        private List<GebeurtenisCreator> _gebeurtenissenCreatorList;

        private GebeurtenissenCreator()
        {
            _gebeurtenissenCreatorList = new List<GebeurtenisCreator>();
            _gebeurtenissenCreatorList.Add(new GooiDobbelstenenGebeurtenisCreator());
            _gebeurtenissenCreatorList.Add(new SpeelVerlaatDeGevangenisGebeurtenisCreator());
        }

        public static GebeurtenissenCreator Instance()
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    if (_instance == null) {
                        GebeurtenissenCreator creator = new GebeurtenissenCreator();
                        _instance = creator;
                    }
                }
            }
            return _instance;
        }

        public Gebeurtenissen createGebeurtenissen(Speler speler)
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            foreach (GebeurtenisCreator creator in _gebeurtenissenCreatorList)
            {
                if (creator.IsGebeurtenisVoorSpeler(speler))
                    gebeurtenissen.Add(creator.MaakGebeurtenis(speler));
            }
            return gebeurtenissen;
        }
    }
}
