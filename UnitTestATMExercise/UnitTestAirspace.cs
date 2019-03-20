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
    public class UnitTestAirspace
    {
        //X, Y and Alitude within Airspace expected true
        [TestCase("ACR101", 12000, 15000, 1500, "20151006213456456", true)]

        //Y and Alitude within airspace, X out of Airspace expected false
        [TestCase("ACR102", 90001, 25000, 2500, "20151006213456023", false)]

        //X and Y are within Airspace, Alitude out of Airspace expected false
        [TestCase("ACR103", 25000, 50001, 25000, "20151006213456087", false)]

        //X and Y are within Airspace, Alitude out of Airspace expected false
        [TestCase("ACR104", 25000, 50001, 400, "20151006213456010", false)]

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
