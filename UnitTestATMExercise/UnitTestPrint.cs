using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using NUnit.Framework;
using ATMExercise;

namespace UnitTestATMExercise
{
    [TestFixture]
    public class UnitTestPrint
    {
        //Airplane within Airspace
        [TestCase("ACR101", 12000, 15000, 1500, "20151006213456456", 1, 1)]

        //Airplane not within Airspace
        [TestCase("ACR102", 90500, 15000, 1500, "20151006213456456", 0, 0)]
        public void TestGetDirectionCalled(string tag, int x, int y, int altitude, string timestamp, int numtrue, int expected)
        {
            string format = "yyyyMMddHHmmssfff";
            DateTime time = DateTime.ParseExact(timestamp, format, CultureInfo.InvariantCulture);

            var airplane = new Airplane(tag, x, y, altitude, time);

            Print print = new Print();

            Stubspace stubspace = new Stubspace(numtrue);

            MockCalculator mockCalculator = new MockCalculator();

            //Unit under test/uut
            print.PrintAirplaneWithSpeedAndDirection(airplane, mockCalculator, stubspace);

            var actual = mockCalculator.getdirCalls;

            Assert.AreEqual(actual, expected);
        }

        //Airplane within Airspace
        [TestCase("ACR101", 12000, 15000, 1500, "20151006213456456", 1, 1)]

        //Airplane not within Airspace
        [TestCase("ACR102", 90500, 15000, 1500, "20151006213456456", 0, 0)]
        public void TestCalucalteSpeedCalled(string tag, int x, int y, int altitude, string timestamp, int numtrue, int expected)
        {
            string format = "yyyyMMddHHmmssfff";
            DateTime time = DateTime.ParseExact(timestamp, format, CultureInfo.InvariantCulture);

            var airplane = new Airplane(tag, x, y, altitude, time);

            Print print = new Print();

            Stubspace stubspace = new Stubspace(numtrue);

            MockCalculator mockCalculator = new MockCalculator();

            //Unit under test/uut
            print.PrintAirplaneWithSpeedAndDirection(airplane, mockCalculator, stubspace);

            var actual = mockCalculator.calcspdCalls;

            Assert.AreEqual(actual, expected);
        }
    }

}