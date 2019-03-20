using System;

namespace ATMExercise
{
    //Simple class for Points
    public class Point : IPoint
    {
        private int _x;
        private int _y;
        private int _z;

        public Point(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public int x
        {
            get { return _x; }
            set { _x = value; }
        }

        public int y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int z
        {
            get { return _z; }
            set { _z = value; }
        }
    }
}

