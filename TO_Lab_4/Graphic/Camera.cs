using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TO_Lab_4.Graphic
{
    class Camera
    {
        private Matrix4 projectionMatrix;
        private Matrix4 modelViewMatrix;

        private Vector3 cameraPosition = new Vector3(0, 0, 0);
        private Vector3 cameraTarget = new Vector3(0, 0, 0);
        private Vector3 cameraUp = Vector3.UnitY;

        public Vector3 cameraDelta;


        public void Perspective(double Width, double Height)
        {
            SetPerspectiveProjection(Width, Height, 55); // 45 is in degrees
            SetLookAtCamera(
                cameraPosition + cameraDelta,
                cameraTarget + cameraDelta,
                cameraUp);
        }

        public void SetupSize(float size)
        {
            cameraPosition = new Vector3(size / 2f, size / 2f, size);
            cameraTarget = new Vector3(size / 2f, size / 2f, 0);
        }


        public void Orthographic(double width, double height, double size)
        {
            SetOrthographicProjection(width, height, size);
        }

        private void SetPerspectiveProjection(double width, double height, double FOV)
        {
            projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                (float)(Math.PI * (FOV / 180)),
                (float)(width / height),
                0.2f,
                cameraPosition.Y * 8
            );
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projectionMatrix); // this replaces the old matrix, no need for GL.LoadIdentity()
        }

        private void SetOrthographicProjection(double width, double height, double size)
        {
            projectionMatrix = Matrix4.Identity;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity(); // reset matrix

            var aspect = width / height;


            var halfSize = size / 2 + 5;
            if (aspect < 1)
                GL.Ortho(-halfSize, halfSize, -halfSize * (1 / aspect), halfSize * (1 / aspect), 1000f, -1000f);
            else
                GL.Ortho(-halfSize * aspect, halfSize * aspect, -halfSize, halfSize, 1000f, -1000f);
        }

        private void SetLookAtCamera(Vector3 position, Vector3 target, Vector3 up)
        {
            // var time = Stopwatch.ElapsedMilliseconds;
            //
            // var test = (time * 0.1);
            // Console.WriteLine(test);
            //
            // var angle = 2.0 * Math.PI * test / 360;
            //
            // var x = 25 * Math.Cos(angle);
            // var y = 25 * Math.Sin(angle);
            //
            //
            // position.X = (float)Population.Bound / 2;
            // position.Y = (float)x;
            // position.Z = (float)Population.Bound;


            modelViewMatrix = Matrix4.LookAt(position, target, up);


            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelViewMatrix);
        }
    }
}