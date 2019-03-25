using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMExercise
{
    public class Seperation : ISeperation
    {
       
        //public Airplane Airplane { get; set; }
        //public void newTrack(Airplane airplane)
        //{
        //    Airplane = airplane;
        //}

        public List<string> ConditionDetected(List<Airplane> airplaneList)
        {
            List<string> con = new List<string>();
            for(int i=0; i < airplaneList.Count - 1; i++)
            {
                for(int j = i + 1; j < airplaneList.Count; j++)
                {
                    
                    if(airplaneList[i].X_coordinate - airplaneList[j].X_coordinate < 5000 && airplaneList[i].X_coordinate - airplaneList[j].X_coordinate > -5000 && airplaneList[i].Y_coordinate - airplaneList[j].Y_coordinate < 5000 && airplaneList[i].Y_coordinate - airplaneList[j].Y_coordinate > -5000 && airplaneList[i].Altitude - airplaneList[j].Altitude < 300 && airplaneList[i].Altitude - airplaneList[j].Altitude > -300)
                    {
                        string timestr = airplaneList[i].Timestamp.ToString();
                        string str = "SEPERATION WARNING " + airplaneList[i].Tag + ' ' + airplaneList[j].Tag + ' ' + timestr;
                        con.Add(str);

                    }
                }
            }
            return con;
        }

        public void updateCondition(List<Airplane> airplaneList)
        {
            List<string> log = new List<string>();
            log.AddRange(ConditionDetected(airplaneList));

            StreamWriter file = new StreamWriter(@"ATMlog.txt", true);
            foreach (string condition in log)
            {
                file.WriteLine(condition);
                System.Console.WriteLine(condition);
            }

            file.Close();
        }
    }
}
