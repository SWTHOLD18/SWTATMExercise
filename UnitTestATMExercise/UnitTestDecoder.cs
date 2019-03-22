using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using ATMExercise;
using TransponderReceiver;
using Decoder = ATMExercise.Decoder;


namespace UnitTestATMExercise
{
    class UnitTestDecoder
    {
        private ITransponderReceiver _fakeTransponderReceiver;
        private Decoder uut;
        private Stubspace air;
        private MockPrint print;
        private MockCalculator calc;
        private MockSeperation sep;

        [SetUp]
        public void setup()
        {
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            air = new Stubspace(0);
            print = new MockPrint();
            calc = new MockCalculator();
            sep = new MockSeperation();
            uut=new Decoder(_fakeTransponderReceiver, calc, print, air, sep);
        }

        [Test]
        public void testfirstplanetag()
        {
            List<string> testData = new List<string>();
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla119;50000;55000;900;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            string tester = uut.airplaneList[0].Tag;
            Assert.AreEqual("pla245", tester);
        }

        [Test]
        public void testfirstplanealti()
        {
            List<string> testData = new List<string>();
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla119;50000;55000;900;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            int tester = uut.airplaneList[0].Altitude;
            Assert.AreEqual(500, tester);
        }

        [Test]
        public void testfirstplaneX()
        {
            List<string> testData = new List<string>();
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla119;50000;55000;900;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            int tester = uut.airplaneList[0].X_coordinate;
            Assert.AreEqual(50000, tester);
        }

        [Test]
        public void testfirstplaneY()
        {
            List<string> testData = new List<string>();
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla119;50000;55000;900;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            int tester = uut.airplaneList[0].Y_coordinate;
            Assert.AreEqual(50000, tester);
        }

        [Test]
        public void testfirstplanetime()
        {
            List<string> testData = new List<string>();
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla119;50000;55000;900;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            string format = "yyyyMMddHHmmssfff";
            DateTime time = DateTime.ParseExact("20190320123500000", format, CultureInfo.InvariantCulture);

            DateTime tester = uut.airplaneList[0].Timestamp;
            Assert.AreEqual(time, tester);
        }

        [Test]
        public void testfirsttagaftermultipleevents()
        {
            List<string> testData = new List<string>();
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla119;50000;55000;900;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            testData.Clear();
            testData.Add("pla119;50300;55200;800;20190320123500100");
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            string tester = uut.airplaneList[0].Tag;
            Assert.AreEqual("pla119", tester);
        }

        [Test]
        public void testPrintCalledamountoftimesequaltoplanes()
        {
            List<string> testData = new List<string>();
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla119;50000;55000;900;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.AreEqual(3, print.numCalls);
        }

        [Test]
        public void testcalcnewposcalledoncewithoneevent()
        {
            List<string> testData = new List<string>();
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla119;50000;55000;900;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.AreEqual(1, calc.newposCalls);
        }

        [Test]
        public void testcalcnewposcalledtwicewithtwoevents()
        {
            List<string> testData = new List<string>();
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla119;50000;55000;900;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            testData.Clear();
            testData.Add("pla119;50300;55200;800;20190320123500100");
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            string tester = uut.airplaneList[0].Tag;
            Assert.AreEqual(2, calc.newposCalls);
        }

        [Test]
        public void testsepcalledoncewithoneevent()
        {
            List<string> testData = new List<string>();
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla119;50000;55000;900;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.AreEqual(1, sep.numCalls);
        }

        [Test]
        public void testsepcalledtwicewithtwoevents()
        {
            List<string> testData = new List<string>();
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla119;50000;55000;900;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            testData.Clear();
            testData.Add("pla119;50300;55200;800;20190320123500100");
            testData.Add("pla245;50000;50000;500;20190320123500000");
            testData.Add("pla893;10000;70000;1400;20190320123500000");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            string tester = uut.airplaneList[0].Tag;
            Assert.AreEqual(2, sep.numCalls);
        }
    }
}
