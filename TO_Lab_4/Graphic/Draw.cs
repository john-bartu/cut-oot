using OpenTK;

namespace TO_Lab_4.Graphic
{
    public class Draw
    {
        protected Color _color = new Color(0, 255, 0, 1);

        public void SetColor(byte r, byte g, byte b, byte alpha = 255)
        {
            _color.R = r;
            _color.G = g;
            _color.B = b;
            _color.A = alpha;

        }
    }
}