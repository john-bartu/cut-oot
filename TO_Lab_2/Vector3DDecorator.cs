using System;

namespace TO_Lab_2
{
    class Vector3DDecorator : IVector
    {
        private IVector srcVector;
        private double z;

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