using System;
namespace Monopoly.AI
{
    interface IAIDecider
    {
        void AddDecision(string gebeurtenisnaam, IDecision decision);
        string Decide(Monopoly.domein.Monopolyspel spel);
    }
}
