using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.akties
{
    public class Hypotheek : IHuurObservable
    {
        private IHypotheekveld HypotheekObject { get; set; }
        public bool IsOnderHypotheek { get; private set; }
        private List<IHuurObserver> myObservers = new List<IHuurObserver>();

        public Hypotheek(IHypotheekveld eigendom)
        {
            HypotheekObject = eigendom;
        }
        
        public bool NeemHypotheek()
        {
            Speler eigenaar = HypotheekObject.Eigenaar;
            if (IsOnderHypotheek)
                return false;
            eigenaar.Bezittingen.OntvangGeld(HypotheekObject.Koopprijs / 2);
            IsOnderHypotheek = true;
            signalHuurUpdate();
            return true;
        }

        public int HypotheekAflosbedrag()
        {
            Speler eigenaar = HypotheekObject.Eigenaar;
            int hypotheekBedrag = HypotheekObject.Koopprijs / 2;
            return hypotheekBedrag + (int)(hypotheekBedrag * 0.1);
        }

        public bool LosHypotheekAf()
        {
            if (IsOnderHypotheek)
            {
                Speler eigenaar = HypotheekObject.Eigenaar;
                int aflosBedrag = HypotheekAflosbedrag();
                if (eigenaar.Bezittingen.Betaal(aflosBedrag))
                {
                    IsOnderHypotheek = false;
                    signalHuurUpdate();
                    return true;
                }
            }
            return false;
        }
        public void addObserver(IHuurObserver observer)
        {
            myObservers.Add(observer);
        }
        private void signalHuurUpdate()
        {
            myObservers.ForEach(o => o.huurUpdate(null));
        }
    }
}
