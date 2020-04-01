using System;
using System.Collections.Generic;
using System.Text;

namespace VectorDistance
{
    class VectorSet3D
    {
        public Vector[] Vectors { get; }
        public Dictionary<int, Vector> ClosestPairs { get; set; }
        public VectorSet3D()
        {
            Vectors = new Vector[1000];
            for (int i = 0; i < 1000; i++)
            {
                Random random = new Random();
                double x = random.Next(1000);
                double y = random.Next(1000);
                double z = random.Next(1000);
                Vectors[i] = new Vector(x, y,z);
            }
            GetClosest3DVectors();
        }
        public VectorSet3D(int NumVectors)
        {
            Vectors = new Vector[NumVectors];
            for (int i = 0; i < NumVectors; i++)
            {
                Random random = new Random();
                double x = random.Next(1000);
                double y = random.Next(1000);
                double z = random.Next(1000);
                Vectors[i] = new Vector(x, y, z);
            }
            GetClosest3DVectors();
        }
        public Dictionary<int, Vector> GetClosest3DVectors()
        {
            Dictionary<int, Vector> result = new Dictionary<int, Vector>();
            double t = 0;
            for (int i = 0; i < Vectors.Length; i++)
            {
                for (int k = i + 1; k < Vectors.Length; k++)
                {
                    double v = CalcDistance(Vectors[i], Vectors[k]);
                    if (i == 0 || v < t)
                    {
                        result.Clear();
                        result.Add(i,Vectors[i]);
                        result.Add(k, Vectors[k]);
                        t = v;
                    }
                }
            }
            return ClosestPairs = result;
        }
        public double CalcDistance(Vector a, Vector b)
        {
            double x = a.X - b.X;
            double y = a.Y - b.Y;
            double z = a.Z - b.Z;
            return Math.Sqrt(Math.Abs(Math.Pow(x, 2)) + Math.Abs(Math.Pow(y, 2)) + Math.Abs(Math.Pow(z, 2)));
        }
        public void ReadClosestPairs()
        {
            Console.WriteLine($"The 3D vectors: \n");
            foreach (KeyValuePair<int, Vector> p in ClosestPairs)
            {
                Console.WriteLine($"{p.Value.X},{p.Value.Y},{p.Value.Z} at index {p.Key} \n");
            }
            Console.WriteLine($"Were the closest vectors.");
        }
        
    }
}
