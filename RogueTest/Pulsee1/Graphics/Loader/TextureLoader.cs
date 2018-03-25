using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using Pulsee1.Graphics.Textures;
using System.IO;
using Pulsee1.Utils.Display;

namespace Pulsee1.Graphics.Loader
{
    class TextureLoader
    {
        public TextureLoader()
        { return; }

        public Texture2D LoadTexture(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found: " + path);

            Bitmap bitmap = new Bitmap(path, false);
            var bitmapRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            xConsole.WriteLine("Texture: " + path + " loading...", MessageType.Info);

            int id = GL.GenTexture(); //Tells GL to create a spot for a texture
            //set the tex created as the current texture
            GL.BindTexture(TextureTarget.Texture2D, id);

            //lock the image in read only (to access it)
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //Tells GL how to render the texture (TextureMinFilter.Linear = smooth and TextureMinFilter.Nearest = aliased)
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            //tells GL to create a tex from his side using bmpData
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

            //now that the transfer is over, releasing of the image
            bitmap.UnlockBits(bmpData);

            xConsole.WriteLine("Texture: " + path + " loaded", MessageType.Info);

            return new Texture2D(id, bitmap.Width, bitmap.Height, 0.5f);
        }
    }
}
