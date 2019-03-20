using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMExercise;

namespace UnitTestATMExercise
{
    public class MockPrint : IPrint
    {
        public int numCalls = 0;

        public void PrintAirplaneWithSpeedAndDirection(Airplane airplane, ICalculator calculator, IAirspace Airspace)
        {
            numCalls += 1;
        }
    }
}
