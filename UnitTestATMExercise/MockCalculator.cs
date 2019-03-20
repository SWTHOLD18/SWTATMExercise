using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMExercise;

namespace UnitTestATMExercise
{
    public class MockCalculator : ICalculator
    {
        public int newposCalls;
        public int getdirCalls;
        public int calcspdCalls;

        public MockCalculator()
        {
            newposCalls = 0;
            getdirCalls = 0;
            calcspdCalls = 0;
        }

        public void NewPositions(List<Airplane> newAirplaneList)
        {
            newposCalls += 1;
        }

        public double GetDirection(Airplane newAirplane)
        {
            getdirCalls += 1;
            return 0;
        }

        public double CalculateSpeed(Airplane newAirplane)
        {
            calcspdCalls += 1;
            return 0;
        }
    }
}
