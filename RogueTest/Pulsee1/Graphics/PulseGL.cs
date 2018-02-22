using OpenTK.Graphics.OpenGL;
using Pulsee1.Graphics.Textures;
using Pulsee1.Graphics.Loader;
using System.Collections.Generic;
using System.Drawing;
using Pulsee1.Utils.Display;

namespace Pulsee1.Graphics
{
    static class PulseGL
    {
        private static GameManager _parent;
        private static TextureStore _texStore = new TextureStore();
        private static bool _isInitialized = false;

        public static void LoadTemp(string path)
        {
            _texStore.LoadTex(path);
        }

        public static void GLSetContext(GameManager parent_)
        {
            _parent = parent_;
            return;
        }

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

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.MatrixMode(MatrixMode.Modelview);

            return;
        }

        public static void GLDrawScene()
        {
            GLInit();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();

            //*
            foreach (Texture2D t in _texStore.texLoaded)
                GL.BindTexture(TextureTarget.Texture2D, t.ID);//*/

            GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0, 0);GL.Vertex2(-1, 1);
                GL.TexCoord2(1, 0);GL.Vertex2(1, 1);
                GL.TexCoord2(1, 1);GL.Vertex2(1, -1);
                GL.TexCoord2(0, 1);GL.Vertex2(-1, -1);

            GL.End();

            return;
        }

        public static void GLDrawSplash(string splashPath)
        {
            GLInit();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();

            GL.BindTexture(TextureTarget.Texture2D, _texStore.texLoader.LoadTexture(splashPath).ID);

            GL.Begin(PrimitiveType.Quads);

            //GL.Color4(0, 0, 0, 0);
            
            GL.TexCoord2(0, 0); GL.Vertex2(-1, 1);
            GL.TexCoord2(1, 0); GL.Vertex2(1, 1);
            GL.TexCoord2(1, 1); GL.Vertex2(1, -1);
            GL.TexCoord2(0, 1); GL.Vertex2(-1, -1);

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
