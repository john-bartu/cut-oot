using System;

namespace TO_Lab_2
{
    class Polar2DInheritance : Vector2D
    {
        double getAngle()
        {
            return Math.Atan(Y / X);
        }

        public Polar2DInheritance(double y, double x) : base(y, x)
        {
        }
    }
}