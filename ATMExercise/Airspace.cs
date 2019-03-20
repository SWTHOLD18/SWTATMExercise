using System;

namespace ATMExercise
{
    public class Airspace : IAirspace
    {
        //Limit for start of Airspace with minium Height.
        IPoint pointMin = new Point(10000, 10000, 500);

        //Limit for end of Airspace with maxium Height.
        IPoint pointMax = new Point(90000, 90000, 20000);

        //Create Point for Airplane.
        public IPoint CreatePointForAirplane(Airplane airplane)
        {
            IPoint pointAirplane = new Point(
                airplane.X_coordinate,
                airplane.Y_coordinate,
                airplane.Altitude);

            return pointAirplane;
        }

        //Is Point within Airspace, return true if yes else false.
        public bool WithInAirspace(Airplane airplane)
        {
            var point = CreatePointForAirplane(airplane);

            if (point.x >= pointMin.x & point.x <= pointMax.x & 
                point.y >= pointMin.y & point.y <= pointMax.y & 
                point.z >= pointMin.z & point.z <= pointMax.z )
            {
                return true;

            } else {

                return false;
            }
        }
    } 
}