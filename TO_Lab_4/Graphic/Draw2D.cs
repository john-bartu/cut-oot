using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TO_Lab_4.Graphic
{
    public class Draw2D : Draw
    {
        public Draw2D()
        {
        }

        public Draw2D(Color color) : base(color)
        {
        }


        public void draw_circle(Vector2 vector, float r, bool fill = false)
        {
            draw_circle(vector, r, 180, fill);
        }

        public void draw_circle(Vector2 vector, float r, int quality, bool fill = false)
        {
            GL.Begin(fill ? PrimitiveType.Polygon : PrimitiveType.LineLoop);

            GL.Color4(Color.R, Color.G, Color.B, Color.A);

            for (var i = 0; i < quality; i++)
            {
                var angle = 2.0 * Math.PI * i / quality;
                var x = r * Math.Cos(angle);
                var y = r * Math.Sin(angle);
                GL.Vertex2(vector.X + x, vector.Y + y);
            }

            GL.End();
        }


        public void draw_square(Vector2 bound1, Vector2 bound2, bool fill = false)
        {
            GL.Begin(fill ? PrimitiveType.Polygon : PrimitiveType.LineLoop);

            GL.Color4(Color.R, Color.G, Color.B, Color.A);

            GL.Vertex2(-bound1.X, -bound1.Y);
            GL.Vertex2(-bound1.X, bound2.Y);
            GL.Vertex2(bound2.X, bound2.Y);
            GL.Vertex2(bound2.X, -bound1.Y);

            GL.End();
        }
    }
}