using System;
using System.Collections.Generic;
using System.Text;

namespace ATMExercise
{
    public class Calculator : ICalculator
    {

        public List<Airplane> OldaAirplaneList { get;  private set; }
        
        public Calculator()
        {
            OldaAirplaneList = new List<Airplane>();            
        }

        public void NewPositions(List<Airplane> newAirplaneList)
        {
            // Make room for new airplanes, overwrite
            OldaAirplaneList.Clear();
            foreach (var plane in newAirplaneList)
            {
                // Add planes in the oldList
                OldaAirplaneList.Add(plane);
            }
        }

        public double GetDirection(Airplane newAirplane)
        {
            Airplane oldAirplane = OldaAirplaneList.Find(a => a.Tag == newAirplane.Tag);

            // Check if airplane is in list
            if (!OldaAirplaneList.Contains(oldAirplane))
            {
                return 0;
            }

            var x = newAirplane.X_coordinate - oldAirplane.X_coordinate;
            var y = newAirplane.Y_coordinate - oldAirplane.Y_coordinate;

            double angle = Math.Atan2(y,x);
           
            // To make direction go clockwise we want the second quadrant to be negatve rather than positive
            // we subtract PI to counteract Atan2's automatic +pi if x<0 and y>=0 and than subtract PI to make
            // the degrees go negative clockwise
            if(x < 0 && y>=0)
            {
               angle -= 2*Math.PI; 
            }

            // Convert angle to degrees
            var degrees = angle * 180/Math.PI;

            // Subtract 90degrees to make north 0 and invert to make the clockwise negative into clockwise positive
            var result = (degrees - 90) * -1;

            // Return the current direction from the 2 inputs.
            return result;
        }        

        public double CalculateSpeed(Airplane newAirplane)
        {
            // Find oldAirplane with corresponding tag
            Airplane oldAirplane = OldaAirplaneList.Find(a => a.Tag == newAirplane.Tag);

            // Check if airplane is in list
            if (!OldaAirplaneList.Contains(oldAirplane))
            {
                return 0;
            }

            // Differences in x and y coordinates
            double x_coordinate_difference = 0;
            double y_coordinate_difference = 0;

            // Direction doesn't matter, but we need a positive value for the velocity
            if (newAirplane.X_coordinate > oldAirplane.X_coordinate)
            {
                x_coordinate_difference = newAirplane.X_coordinate - oldAirplane.X_coordinate;
            }
            else
            {
                x_coordinate_difference = oldAirplane.X_coordinate - newAirplane.X_coordinate;
            }

            if (newAirplane.Y_coordinate > oldAirplane.Y_coordinate)
            {
                y_coordinate_difference = newAirplane.Y_coordinate - oldAirplane.Y_coordinate;
            }
            else
            {
                y_coordinate_difference = oldAirplane.Y_coordinate - newAirplane.Y_coordinate;
            }

            // Timespan of the timestamps and then the time difference in double
            TimeSpan tDif = newAirplane.Timestamp - oldAirplane.Timestamp;
            var timeDifference = (double) tDif.TotalSeconds;

            // Using pythagorean theorem to calculate the distance between the planes
            double distance = Math.Sqrt(Math.Pow(x_coordinate_difference, 2) + Math.Pow(y_coordinate_difference, 2));

            return distance/timeDifference;
        }
    }
}
