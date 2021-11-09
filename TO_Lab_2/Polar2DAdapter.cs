using System;

namespace TO_Lab_2
{
    class Polar2DAdapter : IPolar2D, IVector
    {
        private Vector2D _srcVector;

        public Polar2DAdapter(Vector2D srcVector)
        {
            _srcVector = srcVector;
        }

        public double getAngle()
        {
            return Math.Atan(_srcVector.Y / _srcVector.X);
        }

        public double abs()
        {
            return _srcVector.abs();
        }

        public double cdot(IVector param)
        {
            return _srcVector.cdot(param);
        }

        public double[] getComponents()
        {
            return _srcVector.getComponents();
        }
        
        public override string ToString()
        {
            return $"Polar2DAdapter({_srcVector.X:0.00000},{_srcVector.Y:0.00000})";
        }
    }
}