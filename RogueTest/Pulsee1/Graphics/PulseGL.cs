using OpenTK.Graphics.OpenGL;
using Pulsee1.Graphics.Textures;
using Pulsee1.Graphics.Loader;
using System;
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

        /// <summary>
        /// Get the context from the game manager
        /// </summary>
        /// <param name="parent_"></param>
        public static void GLSetContext(GameManager parent_)
        {
            _context = parent_.dim.window;
            xConsole.WriteLine("GL Context given: " + _context.WindowInfo);
            return;
        }

        /// <summary>
        /// Load a single image
        /// </summary>
        /// <param name="path"></param>
        public static void LoadSingle(string path)
        {
            xConsole.WriteLine("LoadSingle method", ConsoleColor.Red);
            _texStore.LoadSingleTex(path);
            ResetTexLoaded(true); //cancel texture loading
        }

        /// <summary>
        /// Initialisation of OpenGL
        /// </summary>
        private static void GLInit()
        {
            if (_isInitialized) return;

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(AlphaFunction.Greater, 0.01f);
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
            if(_isTexLoaded) return;

            //TODO: DELETE ALL THE BINDED TEXTURES

            for (int i = 0; i < _texStore.texLoaded.Count; i++)
            {
                GL.DeleteTexture(_texStore.texLoaded[i].ID);
                xConsole.WriteLine("Tex Deleted: id-" + _texStore.texLoaded[i].ID.ToString(), ConsoleColor.Magenta);
            }

            foreach (Texture2D t in _texStore.texLoaded)
            {
                GL.BindTexture(TextureTarget.Texture2D, t.ID);
                GL.Color4(1, 1, 1, t.Alpha);
            }

            _isTexLoaded = true;

            return;
        }

        /// <summary>
        /// Reset the initialization of OpenGL
        /// </summary>
        public static void ResetGLInit()
        {
            _isInitialized = false;
            return;
        }

        /// <summary>
        /// Reset the textures loaded
        /// </summary>
        public static void ResetTexLoaded(bool areTexLoaded_ = false)
        {
            _isTexLoaded = areTexLoaded_;
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

        /// <summary>
        /// Display the current scene (currently a single picture)
        /// </summary>
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

        /// <summary>
        /// Clear the OpenGL buffers
        /// </summary>
        public static void ClearBuffers()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        /// <summary>
        /// Return the OpenGL version as string
        /// </summary>
        /// <returns></returns>
        public static string GetGLVersion()
        {
            return GL.GetString(StringName.Version) + " (" + GL.GetString(StringName.Renderer)+ ")";
        }

        /// <summary>
        /// Return the graphic card (detected by OpenGL) manufacturer
        /// </summary>
        /// <returns></returns>
        public static string GetGLHardwareManufacturer()
        {
            return GL.GetString(StringName.Vendor);
        }
    }
}
