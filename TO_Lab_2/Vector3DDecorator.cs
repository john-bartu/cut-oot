using System;

namespace TO_Lab_2
{
    class Vector3DDecorator : IVector
    {
        public Vector3DDecorator(Vector2D srcVector, double z)
        {
            this.srcVector = srcVector;
            Z = z;
        }

        private Vector2D srcVector { get; }
        private double Z { get; }

        public double abs()
        {
            return Math.Sqrt(srcVector.X * srcVector.X + srcVector.Y * srcVector.Y + Z * Z);
        }

        public double cdot(IVector param)
        {
            var selfComp = srcVector.getComponents();
            var paramComp = param.getComponents();
            var vecX = paramComp[0];
            var vecY = paramComp[1];
            var vecZ = paramComp.Length > 2 ? paramComp[2] : 0;
            return selfComp[0] * vecX + selfComp[1] * vecY + Z * vecZ;
        }

        public double[] getComponents()
        {
            return new[] { srcVector.X, srcVector.Y, Z };
        }

        public Vector3DDecorator cross(IVector param)
        {
            var srcComponents = srcVector.getComponents();
            var srcVecX = srcComponents[0];
            var srcVecY = srcComponents[1];

            var paramComponents = param.getComponents();
            var paramVecX = paramComponents[0];
            var paramVecY = paramComponents[1];
            var paramVecZ = paramComponents.Length > 2 ? paramComponents[2] : 0;

            var newX = srcVecY * paramVecZ - Z * paramVecY;
            var newY = Z * paramVecX - srcVecX * paramVecZ;
            var newZ = srcVecX * paramVecY - srcVecY * paramVecX;
            return new Vector3DDecorator(new Vector2D(newX, newY), newZ);
        }

        IVector getSrcV()
        {
            return srcVector;
        }

        public override string ToString()
        {
            var srcComp = srcVector.getComponents();
            return $"Vector3DDecorator({srcComp[0]:0.00000},{srcComp[1]:0.00000},{Z:0.00000})";
        }
    }
}