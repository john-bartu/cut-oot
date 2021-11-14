using System;
using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using TO_Lab_4.Graphic;

namespace TO_Lab_4
{
    class SingleWindow : GameWindow
    {
        private readonly Stopwatch _timer = new();
        private readonly Camera _camera = new();

        private GraphicsContext _context1;
        private GraphicsContext _context2;

        public SingleWindow() : base(1280, 720, GraphicsMode.Default, "Visualization",
            GameWindowFlags.Default,
            DisplayDevice.Default, 4, 2, GraphicsContextFlags.ForwardCompatible)
        {
            VSync = VSyncMode.On;
            _timer.Start();


            _context1 = new GraphicsContext(GraphicsMode.Default, WindowInfo);
            _context2 = new GraphicsContext(GraphicsMode.Default, WindowInfo);
            this.MakeCurrent();
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.2f, 0.3f, 1f);

            Console.WriteLine(GL.GetString(StringName.Version));
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Console.WriteLine($"Step {_simulation.CurrentId()} of {_simulation.MaxId()}");

            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            if (input.IsKeyDown(Key.Right))
            {
                _simulation.Next();
            }

            if (input.IsKeyDown(Key.Left))
            {
                _simulation.Previous();
            }


            _simulation.Next();
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // 3D
            _camera.Perspective(Width, Height);

            RenderScene(e);
            // UI
            _camera.Orthographic(Width, Height);

            SwapBuffers();
        }

        Draw2D green = new Draw2D();
        Draw2D red = new Draw2D();
        Draw2D blue = new Draw2D();
        private Simulation _simulation = new();
        

        void RenderScene(FrameEventArgs e)
        {
            red.SetColor(255, 0, 0);
            blue.SetColor(0, 255, 255);
            
            blue.draw_circle(Vector2.Zero,1f,true);
            blue.draw_circle(Vector2.One*2,1f,true);
            
            blue.draw_square(Vector2.Zero, new Vector2(Population.Bound, Population.Bound));
            foreach (var person in _simulation.Current())
            {
                if (person.IllTime > 0)
                {
                    red.draw_circle(person.position, 2f);
                    red.draw_circle(person.position, 0.5f, true);
                }
                else
                {
                    green.draw_circle(person.position, 0.5f, true);
                }


                if (person.IllTime == 0)
                {
                    person.MakeImmune();
                    // Console.WriteLine(person.IllTime);
                }
            }

            // _simulation.Next();
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}