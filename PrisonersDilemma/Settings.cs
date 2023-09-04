using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonersDilemma
{
    class Settings
    {
        /*
         T > R > P > S
         social welfare 2R > T + S
         */
        public static int T = 5; //temptation for defecting
        public static int S = 0; //suckers pay off, cooperation exploited
        public static int R = 3; //mutual cooperation
        public static int P = 1; //punishment for mutual defection.

        public static int Trust = 3; // trust based threshold

        public static int Start = 3;

        public static int NoRounds = 10;


        public static double payment = 1.0;
        public static int EndGen = 500;
    }
}
