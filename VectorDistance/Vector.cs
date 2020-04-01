using System;
using System.Collections.Generic;
using System.Text;

namespace VectorDistance
{
    public class Vector
    {
        private double x;
        private double y;
        private double z;

        public Vector(double X, double Y)
        {
            this.x = X;
            this.y = Y;
            this.z = 0;
        }
        public Vector(double X, double Y, double Z)
        {
            this.x = X;
            this.y = Y;
            this.y = Z;
        }

        public double X 
        { 
            get
            {
                return x;
            }
            set
            {
                x = X;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = Y;
            }
        }
        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = Z;
            }
        }
    }
}
