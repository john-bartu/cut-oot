using System;

namespace TO_Lab_2
{
    class Vector2D : IVector
    {
        public double X { get; }
        public double Y { get; }

        public Vector2D(double y, double x)
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
            throw new NotImplementedException();
        }

        public double[] getComponents()
        {
            return new[] {X,Y};
        }
    }
}