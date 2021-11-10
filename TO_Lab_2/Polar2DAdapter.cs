using System;

namespace TO_Lab_2
{
    class Polar2DAdapter : IPolar2D, IVector
    {
        private readonly Vector2D _srcVector;

        public Polar2DAdapter(Vector2D srcVector)
        {
            _srcVector = srcVector;
        }

        public double getAngle()
        {
            return Math.Atan(_srcVector.Y / _srcVector.X);
        }

 
        public override string ToString()
        {
            return $"Polar2DAdap({_srcVector.X:0.00000},{_srcVector.Y:0.00000})";
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

        public string Cartesian()
        {
            var r = abs();
            var angle = getAngle() * 180 / Math.PI;
            return $"f[{r:0.00}, {angle:0.00}°]";
        }
        
    }
}