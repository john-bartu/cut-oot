using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TO_Lab_4.Graphic
{
    public class Draw3D : Draw
    {
        public Draw3D()
        {
        }

        public Draw3D(Color color) : base(color)
        {
        }

        
        public void cube(Vector3 position, float width, float height, float depth)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Color.R, Color.G, Color.B, Color.A);
            GL.Vertex3(width + position.X, -height + position.Y, -depth + position.Z);
            GL.Vertex3(-width + position.X, -height + position.Y, -depth + position.Z);
            GL.Vertex3(-width + position.X, height + position.Y, -depth + position.Z);
            GL.Vertex3(width + position.X, height + position.Y, -depth + position.Z);

            GL.Vertex3(width + position.X, -height + position.Y, depth + position.Z);
            GL.Vertex3(width + position.X, height + position.Y, depth + position.Z);
            GL.Vertex3(-width + position.X, height + position.Y, depth + position.Z);
            GL.Vertex3(-width + position.X, -height + position.Y, depth + position.Z);

            GL.Vertex3(width + position.X, -height + position.Y, -depth + position.Z);
            GL.Vertex3(width + position.X, height + position.Y, -depth + position.Z);
            GL.Vertex3(width + position.X, height + position.Y, depth + position.Z);
            GL.Vertex3(width + position.X, -height + position.Y, depth + position.Z);

            GL.Vertex3(-width + position.X, -height + position.Y, depth + position.Z);
            GL.Vertex3(-width + position.X, height + position.Y, depth + position.Z);
            GL.Vertex3(-width + position.X, height + position.Y, -depth + position.Z);
            GL.Vertex3(-width + position.X, -height + position.Y, -depth + position.Z);

            GL.Vertex3(width + position.X, height + position.Y, depth + position.Z);
            GL.Vertex3(width + position.X, height + position.Y, -depth + position.Z);
            
            GL.Vertex3(-width + position.X, height + position.Y, -depth + position.Z);
            GL.Vertex3(-width + position.X, height + position.Y, depth + position.Z);

            GL.Vertex3(width + position.X, -height + position.Y, -depth + position.Z);
            GL.Vertex3(width + position.X, -height + position.Y, depth + position.Z);
            GL.Vertex3(-width + position.X, -height + position.Y, depth + position.Z);
            GL.Vertex3(-width + position.X, -height + position.Y, -depth + position.Z);
            GL.End();
        }
    }
}