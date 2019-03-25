using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMExercise
{
    public class Print : IPrint
    {
        public void PrintAirplaneWithSpeedAndDirection(Airplane airplane, ICalculator calculator, IAirspace Airspace)
        {
            if(Airspace.WithInAirspace(airplane))
            {
                System.Console.WriteLine("Airplane: Tag: {0}\t\t// X-coordinate: {1} m\t// Y-coordinate: {2} m\t// Altitude: {3} m\t// Timestamp: {4}\t// Speed: {5} m/s\t\t// Direction: {6}", 
                airplane.Tag, airplane.X_coordinate, airplane.Y_coordinate, airplane.Altitude, airplane.Timestamp, calculator.CalculateSpeed(airplane),calculator.GetDirection(airplane));
            }
        }

        //public void PrintAirplane(Airplane airplane)
        //{
        //    System.Console.WriteLine("Airplane: Tag: {0} // X-coordinate: {1} // Y-coordinate: {2} // Altitude: {3} // Timestamp: {4}", 
        //        airplane.Tag, airplane.X_coordinate, airplane.Y_coordinate, airplane.Altitude, airplane.Timestamp);
        //}

        //public void PrintPoint(IPoint point)
        //{
        //    System.Console.WriteLine("Point is: x={0}, y={1}, z={2}", point.x, point.y, point.z);
        //}

        //public void PrintWithinAirspace(Airplane airplane, IAirspace airspace)
        //{
        //    if(airspace.WithInAirspace(airplane))
        //    {
        //        System.Console.WriteLine("Airplane: {0} is 'IN' within airspace!", airplane.Tag);
        //    } else {
        //        System.Console.WriteLine("Airplane: {0} is 'NOT' within airspace!", airplane.Tag);
        //    }
        //}

        //public void PrintAirplaneDirection(Airplane airplane, ICalculator calculator, IAirspace airspace)
        //{
        //    if(airspace.WithInAirspace(airplane))
        //    {
        //        System.Console.WriteLine("Airplane: {0} is flying in direction: {1} degress (clockwise from North=0)", airplane.Tag, calculator.GetDirection(airplane));
        //    }
        //}

        //public void PrintAirplaneWithSeperation(Airplane airplane, IAirspace airspace, Seperation seperation, List<Airplane> airplaneList)
        //{
        //    if (airspace.WithInAirspace(airplane))
        //    {
        //        var print = new List<string>();
        //        print.AddRange(seperation.ConditionDetected(airplaneList));
        //        print.ForEach(Console.WriteLine);
        //        //System.Console.WriteLine("{0}", seperation.ConditionDetected(airplaneList));
        //        seperation.updateCondition(airplaneList);
        //    }
        //}
    } 
}