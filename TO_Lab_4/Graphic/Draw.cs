using OpenTK;

namespace TO_Lab_4.Graphic
{
    public class Draw
    {
        protected Color Color;

        public Draw()
        {
            Color = Color.White;
        }

        public Draw(Color color)
        {
            Color = color;
        }

        public void SetColor(byte r, byte g, byte b, byte alpha = 255)
        {
            Color.R = r;
            Color.G = g;
            Color.B = b;
            Color.A = alpha;
        }

        public void SetColor(Color color)
        {
            Color.R = color.R;
            Color.G = color.G;
            Color.B = color.B;
            Color.A = color.A;
        }
    }
}