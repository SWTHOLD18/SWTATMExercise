using System;

namespace ATMExercise
{
    public class Print : IPrint
    {
        public void PrintAirplaneWithSpeedAndDirection(Airplane airplane, ICalculator calculator, IAirspace Airspace)
        {
            if(Airspace.WithInAirspace(airplane))
            {
                System.Console.WriteLine("Airplane: Tag: {0} // X-coordinate: {1} // Y-coordinate: {2} // Altitude: {3} // Timestamp: {4} // Speed: {5} // Direction: {6}", 
                airplane.Tag, airplane.X_coordinate, airplane.Y_coordinate, airplane.Altitude, airplane.Timestamp, calculator.CalculateSpeed(airplane),calculator.GetDirection(airplane));
            }
        }

        public void PrintAirplane(Airplane airplane)
        {
            System.Console.WriteLine("Airplane: Tag: {0} // X-coordinate: {1} // Y-coordinate: {2} // Altitude: {3} // Timestamp: {4}", 
                airplane.Tag, airplane.X_coordinate, airplane.Y_coordinate, airplane.Altitude, airplane.Timestamp);
        }

        public void PrintPoint(IPoint point)
        {
            System.Console.WriteLine("Point is: x={0}, y={1}, z={2}", point.x, point.y, point.z);
        }

        public void PrintWithinAirspace(Airplane airplane, IAirspace airspace)
        {
            if(airspace.WithInAirspace(airplane))
            {
                System.Console.WriteLine("Airplane: {0} is 'IN' within airspace!", airplane.Tag);
            } else {
                System.Console.WriteLine("Airplane: {0} is 'NOT' within airspace!", airplane.Tag);
            }
        }

        public void PrintAirplaneDirection(Airplane airplane, ICalculator calculator, IAirspace airspace)
        {
            if(airspace.WithInAirspace(airplane))
            {
                System.Console.WriteLine("Airplane: {0} is flying in direction: {1} degress (clockwise from North=0)", airplane.Tag, calculator.GetDirection(airplane));
            }
        }
    } 
}