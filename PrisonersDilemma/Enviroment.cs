using System;
using System.Collections.Generic;
using System.Text;
using ActressMas;

namespace PrisonersDilemma
{
    class Enviroment
    {
        public static IPDEnvironment env = new IPDEnvironment(noTurns: 200);
        public class IPDEnvironment : EnvironmentMas
        {
            private int _noTurns;

            public IPDEnvironment(int noTurns)
                : base(noTurns: noTurns * 2 + 2, randomOrder: false, parallel: false)
            {
                _noTurns = noTurns * 2;
            }

            public override void TurnFinished(int turn)
            {
                if (turn < _noTurns && turn % 2 == 0)
                    Console.WriteLine($"Round {turn / 2 + 1}");

                if (turn == _noTurns - 1)
                {

                    foreach (var a in FilteredAgents("Prisoner"))
                        Send(new Message("env", a, "end"));
                }
            }
        }
    }
}
