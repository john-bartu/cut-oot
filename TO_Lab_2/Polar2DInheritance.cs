using System;

namespace TO_Lab_2
{
    class Polar2DInheritance : Vector2D
    {
        private double getAngle()
        {
            return Math.Atan(Y / X);
        }

        public Polar2DInheritance(double y, double x) : base(y, x)
        {
        }
        
        public override string ToString()
        {
            return $"Polar2DInh({X:0.00000},{Y:0.00000})";
        }

        public string Cartesian()
        {
            var r = abs();
            var angle = getAngle() * 180 / Math.PI;
            return $"f[{r:0.00}, {angle:0.00}°]";
        }
    }
}