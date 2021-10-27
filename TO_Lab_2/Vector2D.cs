using System;

namespace TO_Lab_2
{
    class Vector2D : IVector
    {
        private double X { get; }
        private double Y { get; }

        public Vector2D(double y, double x)
        {
            this.Y = y;
            this.X = x;
        }

        public double abs()
        {
            throw new NotImplementedException();
        }

        public double cdot(IVector param)
        {
            throw new NotImplementedException();
        }

        public double[] getComponents()
        {
            throw new NotImplementedException();
        }
    }
}