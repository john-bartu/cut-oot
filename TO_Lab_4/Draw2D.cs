using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TO_Lab_4
{
    public class Draw2D : Draw
    {
        public void draw_circle(Vector2 vector2, float r, bool fill = false)
        {
            draw_circle(vector2.X, vector2.Y, r, 180, fill);
        }

        /**
         * Draws a Circle.
         * @param x The x coordinate of center of circle
         * @param y The y of center of circle
         * @param r Radius of circle
         */
        public void draw_circle(float x, float y, float r, bool fill = false)
        {
            draw_circle(x, y, r, 180, fill);
        }

        /**
     * Draws a Circle.
     * @param x The x coordinate of center of circle
     * @param y The y of center of circle
     * @param r Radius of circle
     * @param quality quality of circle (4-360)
     */
        public void draw_circle(float x, float y, float r, int quality, bool fill = false)
        {
            GL.Begin(fill ? PrimitiveType.Polygon : PrimitiveType.LineLoop);

            GL.Color4(_color.R, _color.G, _color.B, _color.A);

            for (int i = 0; i < quality; i++)
            {
                var angle = 2.0 * Math.PI * i / quality;
                var _x = r * Math.Cos(angle);
                var _y = r * Math.Sin(angle);
                GL.Vertex2(x + _x, y + _y);
            }

            GL.End();
        }
    }
}