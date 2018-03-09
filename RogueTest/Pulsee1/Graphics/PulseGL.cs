using OpenTK.Graphics.OpenGL;
using Pulsee1.Graphics.Textures;
using Pulsee1.Graphics.Loader;
using System.Collections.Generic;
using System.Drawing;
using Pulsee1.Utils.Display;
using System.Threading;

namespace Pulsee1.Graphics
{
    static class PulseGL
    {
        private static TextureStore _texStore = new TextureStore();
        private static bool _isInitialized = false;
        private static bool _isTexLoaded = false;
        private static Devices.Display.Window.Context _context;

        #region TODEL
        public static void LoadTemp(string path)
        {
            _texStore.LoadTex(path);
        }
        #endregion

        public static void GLSetContext(GameManager parent_)
        {
            _context = parent_.dim.window;
            xConsole.WriteLine("GL Context given: " + _context.WindowInfo);
            return;
        }

        /// <summary>
        /// Initialisation of OpenGL
        /// </summary>
        private static void GLInit()
        {
            if (_isInitialized) return;

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.ClearDepth(1.0);
            GL.DepthFunc(DepthFunction.Less);
            GL.Enable(EnableCap.DepthTest);
            GL.ShadeModel(ShadingModel.Smooth);

            GL.MatrixMode(MatrixMode.Modelview);

            return;
        }

        /// <summary>
        /// Load and bind all textures from the texture store to OpenGL
        /// </summary>
        public static void GLLoadTex()
        {
            if (_isTexLoaded) return;

            //TODO: DELETE ALL THE BINDED TEXTURES

            for(int i = 0; i < _texStore.texLoaded.Count; i++)
                GL.DeleteTexture(i);

            foreach (Texture2D t in _texStore.texLoaded)
                GL.BindTexture(TextureTarget.Texture2D, t.ID);
            _isTexLoaded = true;

            return;
        }

        public static void ResetGLInit()
        {
            _isInitialized = false;
            return;
        }

        public static void ResetTexLoaded()
        {
            _isTexLoaded = false;
            return;
        }

        /// <summary>
        /// Stretch the viewport to fit the sreen
        /// </summary>
        public static void GLOnResize()
        {
            GL.Viewport(0, 0, _context.Width, _context.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GLDrawScene();
            return;
        }

        public static void GLDrawScene()
        {
            GLInit();
            GLLoadTex();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();

            GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0, 0); GL.Vertex2(-1, 1);  //ul
                GL.TexCoord2(1, 0); GL.Vertex2(1, 1);   //ur
                GL.TexCoord2(1, 1); GL.Vertex2(1, -1);  //br
                GL.TexCoord2(0, 1); GL.Vertex2(-1, -1); //bl

            GL.End();
                
            return;
        }

        public static string GetGLVersion()
        {
            return GL.GetString(StringName.Version) + " (" + GL.GetString(StringName.Renderer)+ ")";
        }

        public static void ClearBuffers()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}
