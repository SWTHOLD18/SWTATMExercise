using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMExercise;

namespace UnitTestATMExercise
{
    [TestFixture]
    class CalculatorTests
    {
        private Airplane _airplane1;
        private Airplane _airplane2;
        private Airplane _airplane3;
        private Airplane _airplane4;

        private List<Airplane> _airplaneList;

        private ICalculator _calculator;

        /*
        [SetUp]
        public void Setup()
        {
            string timeStamp1 = "20151006213456001";
            string timeStamp2 = "20151006213457001";
            _airplane1 = new Airplane("ACR101", 40000, 40000, 8000, "20151006213456001");
        }
        */

        // Der skal laves således at den ikke kan tage negativ tid eller hvis tiden er 0

        // Plane moved 100 m east in 1000 milliseconds, 40000 to 40100, expected 100 meter/second
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR101", 40100, 40000, 8000, "20151006213457001", 100)]
        // Plane moved 100 m west in 1000 milliseconds (backwards), 40000 to 39900, expected 100 meter/second
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR101", 39900, 40000, 8000, "20151006213457001", 100)]

        // Plane not moved ***      Time need to be checked if the plane hasn't moved           *******
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR101", 40000, 40000, 8000, "20151006213457001", 100)]

        // Plane moved 300 m on x-axis and 400 m in y-akis, distance moved = 500 m in one second, 40000 to 40300 and 40000 to 40400, expected 500 meter/second
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR101", 40300, 40400, 8000, "20151006213457001", 100)]
        // Plane moved 300 m on x-axis and 400 m in y-akis (backwards), distance moved is 500 m in one second, 40300 to 40000 and 40400 to 40000, expected 500 meter/second
        [TestCase("ACR101", 40300, 40400, 8000, "20151006213456001", "ACR101", 40000, 40000, 8000, "20151006213457001", 100)]
        public void CalculateSpeed_AirplaneFoundInList_ReturnsSpeed(string plane1Tag, int plane1X, int plane1Y,
            int plane1Altitude, string plane1Timestamp,
            string plane2Tag, int plane2X, int plane2Y, int plane2Altitude, string plane2Timestamp, double result)
        {
            string format = "yyyyMMddHHmmssfff";
            DateTime plane1Time = DateTime.ParseExact(plane1Timestamp, format, CultureInfo.InvariantCulture);
            DateTime plane2Time = DateTime.ParseExact(plane2Timestamp, format, CultureInfo.InvariantCulture);

            var airplane1 = new Airplane(plane1Tag, plane1X, plane1Y, plane1Altitude, plane1Time);
            var airplane2 = new Airplane(plane2Tag, plane2X, plane2Y, plane2Altitude, plane2Time);

            List<Airplane> airplaneList = new List<Airplane>();

            airplaneList.Add(airplane1);

            //Unit under test/uut
            Calculator calculator = new Calculator();

            calculator.NewPositions(airplaneList);

            var actual = calculator.CalculateSpeed(airplane2);

            Assert.AreEqual(actual, result);
        }


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

            public void AirplaneDirection(string plane1Tag, int plane1X, int plane1Y, int plane1Alitude, string plane1Timestamp,
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
