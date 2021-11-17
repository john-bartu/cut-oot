using System;
using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using TO_Lab_4.Graphic;
using TO_Lab_4.Unit;

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
                _simulation.Simulate();
                for (int i = 0; i < 15; i++)
                    if (_simulation.CurrentId() < _simulation.MaxId())
                        _simulation.Next();
            }

            if (input.IsKeyDown(Key.Left))
            {
                _simulation.Simulate();
                for (int i = 0; i < 15; i++)
                    _simulation.Previous();
            }
            else
            {
                _simulation.Next();
            }


            if (input.IsKeyDown(Key.Up))
            {
                Population.Bound += 2f;
            }

            if (input.IsKeyDown(Key.Down))
            {
                Population.Bound -= 2f;
            }

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


        Draw2D white = new(Color.White);
        Draw2D red = new(Color.Red);
        Draw2D green = new(new(0, 255, 0, 255));
        Draw2D blue = new(Color.Blue);
        Draw2D yellow = new(Color.Yellow);

        private Draw3D test = new(Color.Black);
        private Simulation _simulation = new();


        void RenderScene(FrameEventArgs e)
        {
            // blue.draw_circle(Vector2.Zero, 1f, true);
            // blue.draw_circle(Vector2.One * 2, 1f, true);
            blue.draw_square(Vector2.Zero, new Vector2(Population.Bound, Population.Bound));

            foreach (var person in _simulation.Current())
            {
                switch (person.State)
                {
                    case ImmuneState:
                        // test.cube(new Vector3(person.position.X, person.position.Y, 0), 1, 1, 1);
                        white.draw_circle(person.position, 0.5f, true);
                        break;
                    case VulnerableState:
                        green.draw_circle(person.position, 0.5f, true);
                        break;

                    case SymptomaticState:
                        red.draw_circle(person.position, 2f);
                        red.draw_circle(person.position, 0.5f, true);
                        break;

                    case AsymptomaticState:
                        red.draw_circle(person.position, 2f);
                        yellow.draw_circle(person.position, 0.5f, true);
                        break;
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}