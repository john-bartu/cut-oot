using System;

namespace TO_Lab_2
{
    class Vector3DDecorator : IVector
    {
        private Vector2D srcVector;
        private double z;

        public double abs()
        {
            return Math.Sqrt(srcVector.X * srcVector.X + srcVector.Y * srcVector.Y + z * z);
        }

        public double cdot(IVector param)
        {
            throw new NotImplementedException();
        }

        public double[] getComponents()
        {
            return new[] {srcVector.X, srcVector.Y, z};
        }

        Vector3DDecorator cross(IVector param)
        {
            throw new NotImplementedException();
        }

        IVector getSrcV()
        {
            return srcVector;
        }
    }
}