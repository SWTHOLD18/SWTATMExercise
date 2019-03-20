using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMExercise;

namespace UnitTestATMExercise
{
    class Stubspace : IAirspace
    {
        private int numtrue;

        public Stubspace(int numtrue)
        {
            this.numtrue = numtrue;
        }

        public bool WithInAirspace(Airplane airplane)
        {
            if (numtrue > 0)
            {
                numtrue -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
