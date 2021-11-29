using System;

namespace TO_Lab_5.Vector
{
    public class Vector2 : IVector
    {
        public double X { get; }
        public double Y { get; }

        public Vector2(double x, double y)
        {
            Y = y;
            X = x;
        }

        public double abs()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public double cdot(IVector param)
        {
            var paramVec = param.getComponents();
            return X * paramVec[0] + Y * paramVec[1];
        }

        public double[] getComponents()
        {
            return new[] { X, Y };
        }

        public override string ToString()
        {
            return $"Vector2({X:0.00000},{Y:0.00000})";
        }
    }
}