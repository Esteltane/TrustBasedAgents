using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonersDilemma
{
    class GRIM_Prisoner:PrisonerAgent
    {
        private bool trigger = false;

        protected override string ChooseAction(int lastOutcome, out bool cost)
        {
            cost = false;
            if(trigger == false)
            {
                if (lastOutcome == 0 || lastOutcome == 1)
                {
                    cost = true;
                    trigger = true;
                    return "Defect";
                }

                if (lastOutcome == 3 || lastOutcome == 5)
                {
                    cost = true;
                    return "Cooperate";
                }
            }
            else
            {
                cost = false;
                return "Defect";
            }
            return "";
        }

    }
}
