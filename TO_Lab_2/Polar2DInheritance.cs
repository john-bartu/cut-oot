using System;

namespace TO_Lab_2
{
    class Polar2DInheritance : Vector2D
    {
        public double getAngle()
        {
            return Math.Atan(Y / X);
        }

        public Polar2DInheritance(double y, double x) : base(y, x)
        {
        }
        
        public override string ToString()
        {
            return $"Polar2DInheritance({X:0.00000},{Y:0.00000})";
        }
    }
}