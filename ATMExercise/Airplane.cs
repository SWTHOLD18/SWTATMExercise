using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMExercise
{
    public class Airplane
    {
        public Airplane(
            String _tag,
            int _X_coordinate,
            int _Y_coordinate,
            /*
            int _Pre_x_coordinate,
            int _Pre_y_coordinate,
            */
            int _Altitude,
            DateTime _Timestamp)
        {
            Tag = _tag;
            X_coordinate = _X_coordinate;
            Y_coordinate = _Y_coordinate;
            /*
            Pre_x_coordinate = _Pre_x_coordinate;
            Pre_y_coordinate = _Pre_y_coordinate;
            */
            Altitude = _Altitude;
            Timestamp = _Timestamp;
        }

        public string Tag { get; set; } 

        public int X_coordinate { get; set; }

        public int Y_coordinate { get; set; }


        /*
        public int X_coordinate  
        {
            get 
            {
                return X_coordinate;
            }

            set 
            {
                Pre_x_coordinate = X_coordinate;
                this.X_coordinate = value;
            }
        }

        public int Y_coordinate 
        {
            get
            {
                return Y_coordinate;
            }

            set 
            {
                Pre_y_coordinate = Y_coordinate;
                this.Y_coordinate = value;
            }
        }
        
        public int Pre_x_coordinate { get; set; }

        public int Pre_y_coordinate { get; set; }

        */

        public int Altitude { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
