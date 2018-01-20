using OpenTK.Graphics.OpenGL;

namespace Pulsee1.GLOverlay.Display.Graphics
{
    class PulseGL
    {
        public PulseGL() { return; }

        public void GLInit()
        {
            GL.Enable(EnableCap.Blend | EnableCap.DepthTest | EnableCap.Texture2D);

            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.DepthFunc(DepthFunction.Lequal);

            return;
        }

        public string GetGLVersion()
        {
            return GL.GetString(StringName.Version);
        }

        public void ClearBuffers()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}
