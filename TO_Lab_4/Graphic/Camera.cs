using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TO_Lab_4.Graphic
{
    class Camera
    {
        private Matrix4 projectionMatrix;
        private Matrix4 modelViewMatrix;
        private Vector3 cameraPosition = new Vector3(Population.Bound / 2, Population.Bound / 2, Population.Bound);
        private Vector3 cameraTarget = new Vector3(Population.Bound / 2, Population.Bound / 2, 0);
        private Vector3 cameraUp = Vector3.UnitX;


        public void Perspective(double Width, double Height)
        {
            SetPerspectiveProjection(Width, Height, 55); // 45 is in degrees
            SetLookAtCamera(cameraPosition, cameraTarget, cameraUp);
        }


        public void Orthographic(double width, double height)
        {
            SetOrthographicProjection(width, height);
        }

        private void SetPerspectiveProjection(double width, double height, double FOV)
        {
            projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                (float)(Math.PI * (FOV / 180)),
                (float)(width / height),
                0.2f,
                Population.Bound * 2
            );
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projectionMatrix); // this replaces the old matrix, no need for GL.LoadIdentity()
        }

        private void SetOrthographicProjection(double width, double height)
        {
            projectionMatrix = Matrix4.Identity;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity(); // reset matrix

            var aspect = width / height;


            var size = Population.Bound/2+5;
            if (aspect < 1)
                GL.Ortho(-size, size, -size * (1 / aspect), size * (1 / aspect), 1000f, -1000f);
            else
                GL.Ortho(-size * aspect, size * aspect, -size, size, 1000f, -1000f);
        }

        private void SetLookAtCamera(Vector3 position, Vector3 target, Vector3 up)
        {
            modelViewMatrix = Matrix4.LookAt(position, target, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelViewMatrix);
        }
    }
}