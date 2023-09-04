using System;
using System.Collections.Generic;
using System.Text;
using ActressMas;

namespace PrisonersDilemma
{
    class TBS_Prisoner:PrisonerAgent
    {
        private int count = 0;
        protected override string ChooseAction(int lastOutcome, out bool _cost)
        {

            
            _cost = false;
            Random _rnd = new Random();
            Random _rndC = new Random();
            
            if (count < Settings.Trust)
            {
                if (lastOutcome == 0 || lastOutcome == 1)
                {
                    _cost = true;
                    count = 0;
                    Console.WriteLine("Trust Lost");
                    return "Defect";
                }// initially, lastOutcome = 0 => cooperate first time

                if (lastOutcome == 3 || lastOutcome == 5)
                {
                    _cost = true;
                    count++;
                    return "Cooperate";
                }
            }
            else
            {
                Console.WriteLine("Trust Gained");
                if (_rnd.NextDouble() > 0.1)
                {
                        _cost = false;
                        return "Cooperate";
                    
                }
                else
                {
                    if (lastOutcome == 0 || lastOutcome == 1)
                    {
                        _cost = true;
                        count = 0;
                        Console.WriteLine("Trust Lost");
                        return "Defect";
                    }// initially, lastOutcome = 0 => cooperate first time

                    if (lastOutcome == 3 || lastOutcome == 5)
                    {
                        _cost = true;
                        return "Cooperate";
                    }
                }
            }
            return "";
        }
    }
}
