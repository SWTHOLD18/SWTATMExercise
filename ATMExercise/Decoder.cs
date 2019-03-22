using System;
using System.Collections.Generic;
using System.Globalization;
using TransponderReceiver;

namespace ATMExercise
{
    public class Decoder
    {
        private ITransponderReceiver receiver;

        //List of Airplanes
        public List<Airplane> airplaneList = new List<Airplane>();
        public ICalculator calc = new Calculator();
        public IPrint printer = new Print();
        public IAirspace space = new Airspace();
        public ISeperation seperation = new Seperation();

        public Decoder(ITransponderReceiver receiver)
        {
            this.receiver = receiver;
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        //fake inject constructer
        public Decoder(ITransponderReceiver receiver, ICalculator calc, IPrint printer, IAirspace space, ISeperation seperation)
        {
            this.receiver = receiver;
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
            this.calc = calc;
            this.printer = printer;
            this.space = space;
            this.seperation = seperation;
        }


        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            airplaneList.Clear();
            foreach (var data in e.TransponderData)
            {
                string[] plane = data.Split(';');
                string tag = plane[0];
                int xCord = Int32.Parse(plane[1]);
                int yCord = Int32.Parse(plane[2]);
                int alti = Int32.Parse(plane[3]);
                string format = "yyyyMMddHHmmssfff";
                DateTime time = DateTime.ParseExact(plane[4], format, CultureInfo.InvariantCulture);

                //Create new plane from decoder.
                Airplane airplane = new Airplane(tag, xCord, yCord, alti, time);

                //Add current Airplane to list of Airplanes.
                airplaneList.Add(airplane);

                printer.PrintAirplaneWithSpeedAndDirection(airplane, calc, space);
            }
            calc.NewPositions(airplaneList);
            seperation.updateCondition(airplaneList);
        }
    }
}
