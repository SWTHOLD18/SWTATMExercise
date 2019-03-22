using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMExercise;

namespace UnitTestATMExercise
{
    public class MockSeperation : ISeperation
    {
        public int numCalls = 0;

        public void updateCondition(List<Airplane> airplaneList)
        {
            numCalls += 1;
        }
    }
}
