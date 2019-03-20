using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using ATMExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestATMExercise
{
    [TestFixture]
    public class AirplaneUnitTest
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

            var actual = calculator.GetDirection(airplanePing2);

            Assert.AreEqual(actual, expected);
        }
    }

    [TestFixture]
    public class AirspaceUnitTest
    {
        //X, Y and Alitude within Airspace expected true
        [TestCase("ACR101", 12000, 15000, 1500, "20151006213456456", true)]

        //Y and Alitude within airspace, X out of Airspace expected false
        [TestCase("ACR102", 80001, 25000, 2500, "20151006213456023", false)]

        //X and Y are within Airspace, Alitude out of Airspace expected false
        [TestCase("ACR103", 25000, 80001, 25000, "20151006213456087", false)]

        //X and Y are within Airspace, Alitude out of Airspace expected false
        [TestCase("ACR104", 25000, 80001, 400, "20151006213456010", false)]

        //X, Y and Alitude out of Airspace expected false
        [TestCase("ACR105", -1, -1, -1, "20151006213456435", false)]

        public void AirplaneWithinAirspace(string tag, int x, int y, int alitude, string timestamp, bool expected)
        {
            string format = "yyyyMMddHHmmssfff";
            DateTime time = DateTime.ParseExact(timestamp, format, CultureInfo.InvariantCulture);

            var airplane = new Airplane(tag, x, y, alitude, time);

            //Unit under test/uut
            Airspace airspace = new Airspace();

            var actual = airspace.WithInAirspace(airplane);

            Assert.AreEqual(actual, expected);
        }
    }
}
