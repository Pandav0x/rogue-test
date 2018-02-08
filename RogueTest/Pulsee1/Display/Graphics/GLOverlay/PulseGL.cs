using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Pulsee1.Display.Graphics.GLOverlay
{
    static class PulseGL
    {
        private static GameManager _parent;

        public static void GLSetContext(GameManager parent_)
        {
            return;
        }

        public static void GLInit()
        {
            GL.Viewport(new Rectangle(0, 0, _parent.dim.window.Width, _parent.dim.window.Height));

            GL.Enable(EnableCap.Blend | EnableCap.DepthTest | EnableCap.Texture2D);

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadIdentity();

            GL.Ortho(0.0, _parent.dim.window.Width, _parent.dim.window.Height, 0.0, 0.0, 100.0);

            GL.MatrixMode(MatrixMode.Modelview);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            GL.ClearDepth(0.0f);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            /*
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.DepthFunc(DepthFunction.Lequal);
            */
            return;
        }

        public static string GetGLVersion()
        {
            return GL.GetString(StringName.Version);
        }

        public static void ClearBuffers()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}
