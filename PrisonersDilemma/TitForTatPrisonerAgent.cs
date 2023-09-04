using System;
using System.Collections.Generic;
using System.Text;
using ActressMas;

namespace PrisonersDilemma
{
    public class TitForTatPrisonerAgent: PrisonerAgent
    {
        protected override string ChooseAction(int lastOutcome, out bool _cost)
        {
            _cost = true;
            if (lastOutcome == 0 || lastOutcome == 1)
                return "Defect"; // initially, lastOutcome = 0 => cooperate first time

            if (lastOutcome == 3 || lastOutcome == 5)
                return "Cooperate";

           

            return "";
        }
    }
}
