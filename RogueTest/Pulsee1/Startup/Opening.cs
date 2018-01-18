using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using Pulsee1.Utilities.Display;
using Pulsee1.Graphics.Textures;
using Pulsee1.Graphics.Loader;

namespace Pulsee1.Startup
{
    static class Opening
    {
        private static GameManager _parent = null;
        private static  string _logoPath = @"Pulsee1\Pictures\Logos\poweredBy.png";

        public static void PrintLogoOnScreen(GameManager parent_)
        {
            if (_parent == null) //just in case y'know
                _parent = parent_;

            //Texture2D tex = _parent.grm.LoadTexture(_logoPath);

            /*GL.BindTexture(TextureTarget.Texture2D, tex.ID);

            GL.Begin(PrimitiveType.Triangles);

            //first triangle of the pic rendered
            GL.TexCoord2(0, 0); GL.Vertex2(0, 1);
            GL.TexCoord2(1, 1); GL.Vertex2(1, 0);
            GL.TexCoord2(0, 1); GL.Vertex2(0, 0);

            //second triangle of the pic rendered
            GL.TexCoord2(0, 0); GL.Vertex2(0, 1);
            GL.TexCoord2(1, 1); GL.Vertex2(1, 1);
            GL.TexCoord2(0, 1); GL.Vertex2(1, 0);

            GL.End();*/

            return;
        }
    }
}
