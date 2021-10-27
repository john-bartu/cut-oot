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
            throw new NotImplementedException();
        }

        public new IVector cdot(IVector param)
        {
            throw new NotImplementedException();
        }

        public new double[] getComponents()
        {
            throw new NotImplementedException();
        }
    }
}