using System;

namespace TO_Lab_2
{
    class Program
    {
        static void Main()
        {
            var vector2D1 = new Vector2D(1.0 / 2.0, Math.Sqrt(3.0) / 2.0);
            var polar2D1 = new Polar2DAdapter(vector2D1);
            var vector2D2 = new Vector2D(Math.Sqrt(3.0), 1.0);
            var polar2D2 = new Polar2DAdapter(vector2D2);
            var polar2D3 = new Polar2DInheritance(2.0 * Math.Sqrt(2.0), 2.0 * Math.Sqrt(2.0));

            Console.WriteLine($"v1 = {polar2D1}, {polar2D1.Cartesian()}");
            Console.WriteLine($"v2 = {polar2D2}, {polar2D2.Cartesian()}");
            Console.WriteLine($"v3 = {polar2D3}, {polar2D3.Cartesian()}");

            Console.WriteLine("-");

            Console.WriteLine($"v1 * v2 = {polar2D1.cdot(polar2D2):0.00000}");
            Console.WriteLine($"v2 * v1 = {polar2D2.cdot(polar2D1):0.00000}");
            Console.WriteLine($"v1 * v3 = {polar2D1.cdot(polar2D3):0.00000}");
            Console.WriteLine($"v3 * v1 = {polar2D3.cdot(polar2D1):0.00000}");
            Console.WriteLine($"v2 * v3 = {polar2D2.cdot(polar2D3):0.00000}");
            Console.WriteLine($"v3 * v2 = {polar2D3.cdot(polar2D2):0.00000}");

            Console.WriteLine("-");

            var vector3D4 = new Vector3DDecorator(new Vector2D(1.0, 2.0), 3.0);
            var vector3D5 = new Vector3DInheritance(1, 1.0 / 2.0, 1.0 / 3.0);

            Console.WriteLine($"v4 = {vector3D4}");
            Console.WriteLine($"v5 = {vector3D5}");

            Console.WriteLine("-");

            Console.WriteLine($"v4 * v5 = {vector3D4.cdot(vector3D5):0.00000}");
            Console.WriteLine($"v4 x v5 = {vector3D4.cross(vector3D5)}");
            Console.WriteLine($"v5 * v1 = {vector3D5.cdot(polar2D1):0.00000}");
            Console.WriteLine($"v5 x v1 = {vector3D5.cross(polar2D1)}");
        }
    }
}