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

        private Simulation _simulation;

        public SingleWindow(Simulation simulation) : base(1280, 720, GraphicsMode.Default, "Visualization",
            GameWindowFlags.Default,
            DisplayDevice.Default, 4, 2, GraphicsContextFlags.ForwardCompatible)
        {
            VSync = VSyncMode.On;
            _timer.Start();

            _simulation = simulation;

            _camera.SetupSize(_simulation.GetBound());
            _context1 = new GraphicsContext(GraphicsMode.Default, WindowInfo);
            _context2 = new GraphicsContext(GraphicsMode.Default, WindowInfo);
            MakeCurrent();
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            _camera.cameraDelta.Z -= e.Delta * 2;
            base.OnMouseWheel(e);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                _simulation.PlayPause();
            }

            base.OnKeyDown(e);
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
                for (int i = 0; i < 10; i++)
                    if (_simulation.CurrentId() < _simulation.MaxId())
                        _simulation.Next();
            }

            if (input.IsKeyDown(Key.R))
            {
                for (int i = 0; i < 20; i++)
                {
                    _simulation.Simulate();
                }
            }

            if (input.IsKeyDown(Key.Left))
            {
                for (int i = 0; i < 10; i++)
                    _simulation.Previous();
            }
            else
            {
                _simulation.Next();
            }


            if (input.IsKeyDown(Key.W))
            {
                _camera.cameraDelta.Y += 1;
            }

            if (input.IsKeyDown(Key.S))
            {
                _camera.cameraDelta.Y -= 1;
            }

            if (input.IsKeyDown(Key.Q))
            {
                _camera.cameraDelta.Z += 1;
            }

            if (input.IsKeyDown(Key.E))
            {
                _camera.cameraDelta.Z -= 1;
            }


            if (input.IsKeyDown(Key.A))
            {
                _camera.cameraDelta.X -= 1;
            }

            if (input.IsKeyDown(Key.D))
            {
                _camera.cameraDelta.X += 1;
            }
            
            _simulation.Simulate();
            Console.WriteLine($"Frame: {_simulation.CurrentId()} / {_simulation.MaxId()}");
            
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // 3D
            _camera.Perspective(Width, Height);

            RenderScene(e);
            // UI
            _camera.Orthographic(Width, Height, _simulation.GetBound());

            SwapBuffers();
        }


        Draw2D white = new(Color.White);
        Draw2D red = new(Color.Red);
        Draw2D green = new(new(0, 255, 0, 255));
        Draw2D blue = new(Color.Blue);
        Draw2D yellow = new(Color.Yellow);


        void DrawPerson(Person person)
        {
            switch (person.State)
            {
                case ImmuneState:
                    white.draw_circle(person.Position, 0.25f, true);
                    break;
                case HealthySoVulnerableState:
                    green.draw_circle(person.Position, 0.25f, true);
                    break;

                case SymptomaticState:
                    red.draw_circle(person.Position, 2f);
                    red.draw_circle(person.Position, 0.25f, true);
                    break;

                case AsymptomaticState:
                    red.draw_circle(person.Position, 2f);
                    yellow.draw_circle(person.Position, 0.25f, true);
                    break;
            }
        }

        void RenderScene(FrameEventArgs e)
        {
            blue.draw_square(Vector2.Zero, new Vector2(_simulation.GetBound(), _simulation.GetBound()));

            foreach (var person in _simulation.Current())
            {
                DrawPerson(person);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}