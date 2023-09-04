using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonersDilemma
{
    class ALLDPrisoner: PrisonerAgent
    {
        protected override string ChooseAction(int lastOutcome, out bool cost)
        {
            
            cost = false;
            return "Defect";
        }
    }
}
