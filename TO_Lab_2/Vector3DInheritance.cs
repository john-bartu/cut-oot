using System;

namespace TO_Lab_2
{
    class Vector3DInheritance : Vector2D
    {
        private double Z { get; }

        public Vector3DInheritance(double x, double y, double z) : base(x, y)
        {
            Z = z;
        }

        public new double abs()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public new double cdot(IVector param)
        {
            var paramComp = param.getComponents();
            var vecX = paramComp[0];
            var vecY = paramComp[1];
            var vecZ = paramComp.Length > 2 ? paramComp[2] : 0;
            return X * vecX + Y * vecY + Z * vecZ;
        }

        public new double[] getComponents()
        {
            return new[] { X, Y, Z };
        }

        public Vector3DInheritance cross(IVector param)
        {
            var paramComponents = param.getComponents();
            var paramVecX = paramComponents[0];
            var paramVecY = paramComponents[1];
            var paramVecZ = paramComponents.Length > 2 ? paramComponents[2] : 0;

            var newX = Y * paramVecZ - Z * paramVecY;
            var newY = Z * paramVecX - X * paramVecZ;
            var newZ = X * paramVecY - Y * paramVecX;
            return new Vector3DInheritance(newX, newY, newZ);
        }

        public override string ToString()
        {
            return $"Vector3DInheritance({X:0.00000},{Y:0.00000},{Z:0.00000})";
        }
    }
}