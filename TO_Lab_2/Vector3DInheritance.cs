using System;

namespace TO_Lab_2
{
    class Vector3DInheritance : Vector2D
    {
        private double z;

        public Vector3DInheritance(double y, double x, double z) : base(y, x)
        {
            this.z = z;
        }


        public new double abs()
        {
            return Math.Sqrt(X * X + Y * Y + z * z);
        }

        public new IVector cdot(IVector param)
        {
            throw new NotImplementedException();
        }

        public new double[] getComponents()
        {
            return new[] {X, Y, z};
        }
    }
}