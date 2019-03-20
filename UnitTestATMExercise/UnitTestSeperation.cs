﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMExercise;
using NUnit.Framework;


namespace UnitTestATMExercise
{
    [TestFixture]
    class UnitTestSeperation
    {
        private Airplane _airplane1;
        private Airplane _airplane2;
      

        private List<Airplane> _airplaneList;


        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR102", 41000, 41000, 8000, "20151006213456001", true)]

        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR102", 41000, 41000, 8000, "20151006213456001", true)]

        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR102", 41000, 41000, 800, "20151006213456001", false)]

        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR102", 41000, 4100, 8000, "20151006213456001", false)]

        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR102", 4100, 41000, 8000, "20151006213456001", false)]

        public void seperationConditionTest(string tag, int x, int y, int altitude, string timestamp, string tag2, int x2, int y2, int altitude2, string timestamp2, bool expected)
        {
            string format = "yyyyMMddHHmmssfff";
            DateTime plane1Time = DateTime.ParseExact(timestamp, format, CultureInfo.InvariantCulture);
            DateTime plane2Time = DateTime.ParseExact(timestamp2, format, CultureInfo.InvariantCulture);

            var airplane1 = new Airplane(tag, x, y, altitude, plane1Time);
            var airplane2 = new Airplane(tag, x, y, altitude, plane2Time);

            List<Airplane> airplaneList = new List<Airplane>();

            airplaneList.Add(airplane1);
            airplaneList.Add(airplane2);

            Seperation septest = new Seperation();

            var actual = septest.ConditionDetected(airplaneList);

            Assert.AreEqual(actual, expected);

        }

    }
}
