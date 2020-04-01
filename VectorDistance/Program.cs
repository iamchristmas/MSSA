using System;

namespace VectorDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            VectorSet2D vectorSet2D = new VectorSet2D();
            VectorSet3D vectorSet3D = new VectorSet3D();
            vectorSet2D.ReadClosestPairs();
            vectorSet3D.ReadClosestPairs();
        }
    }
}
