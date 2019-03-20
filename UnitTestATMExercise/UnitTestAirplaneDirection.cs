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
    public class UnitTestAirplaneDirection
    {
        //Test plane going from X=40000 Y=40000 to X=40000 Y=60000 expected direction = 0 degrees/North
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001",
            "ACR101", 40000, 60000, 8000, "20151006213457001", 0)]

        //Test plane going from X=40000 Y=40000 to X=40000 Y=20000 expected direction = 90 degrees/East
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001",
            "ACR101", 60000, 40000, 8000, "20151006213457001", 90)]

        //Test plane going from X=40000 Y=40000 to X=40000 Y=20000 expected direction = 180 degrees/South
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001",
            "ACR101", 40000, 20000, 8000, "20151006213457001", 180)]

        //Test plane going from X=40000 Y=40000 to X=40000 Y=20000 expected direction = 270 degrees/West
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001",
            "ACR101", 20000, 40000, 8000, "20151006213457001", 270)]

        public void AirplaneDirection(string plane1Tag, int plane1X, int plane1Y, int plane1Alitude,
            string plane1Timestamp,
            string plane2Tag, int plane2X, int plane2Y, int plane2Alitude, string plane2Timestamp, double expected)
        {
            string format = "yyyyMMddHHmmssfff";
            DateTime plane1Time = DateTime.ParseExact(plane1Timestamp, format, CultureInfo.InvariantCulture);
            DateTime plane2Time = DateTime.ParseExact(plane2Timestamp, format, CultureInfo.InvariantCulture);

            var airplanePing1 = new Airplane(plane1Tag, plane1X, plane1Y, plane1Alitude, plane1Time);
            var airplanePing2 = new Airplane(plane2Tag, plane2X, plane2Y, plane2Alitude, plane2Time);

            //Create list of Airplanes
            List<Airplane> airplanesList = new List<Airplane>();

            airplanesList.Add(airplanePing1);

            //Unit under test/uut
            ICalculator calculator = new Calculator();

            calculator.NewPositions(airplanesList);
            var actual = calculator.GetDirection(airplanePing2);

            Assert.AreEqual(actual, expected);
        }
    }
}
