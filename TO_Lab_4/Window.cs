using System;
using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace TO_Lab_4
{
    class Window : GameWindow
    {
        private readonly Stopwatch _timer = new();
        private readonly Camera _camera = new();

        public Window() : base(1280, 720, GraphicsMode.Default, "Visualization")
        {
            VSync = VSyncMode.On;
            _timer.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.2f, 0.3f, 1f);

            Console.WriteLine(GL.GetString(StringName.Version));
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // 3D
            _camera.Perspective(Width, Height);


            // UI
            _camera.Orthographic(Width, Height);
            RenderScene(e);

            SwapBuffers();
        }

        Draw2D green = new Draw2D();
        Draw2D red = new Draw2D();
        private double x = 0f;
        private Population _population = new(4000, 0, 20);

        void RenderScene(FrameEventArgs e)
        {
            red.SetColor(255, 0, 0);

            // red.draw_circle(new Vector2(0, 0) - new Vector2(250, 250), 1f);
            // red.draw_circle(new Vector2(Population.Bound, Population.Bound)- new Vector2(250, 250), 1f);


            foreach (var person in _population.People)
            {
                if (person.IllTime > 0)
                    red.draw_circle(person.position - new Vector2(250, 250), 1f, true);
                else
                    green.draw_circle(person.position - new Vector2(250, 250), 1f, true);

                person.IllTime -= 1;
            }

            _population.Step();
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}