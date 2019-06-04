using Pulsee.Graphics;
using Pulsee.Graphics.Textures;
using Pulsee.Graphics.Loader;
using Pulsee.Utilities.Display;
using System.Collections.Generic;

namespace Pulsee.Display.Graphics
{
    class GraphicsManager
    {
        private GameManager _parent;
        private TextureLoader _texLoader;

        public List<Texture2D> textures;

        public GraphicsManager(GameManager parent_)
        {
            this._parent = parent_;
            this._texLoader = new TextureLoader();
            xConsole.WriteLine("OpenGL - " + PulseeGL.GetGLVersion());
            return;
        }

        public Texture2D LoadTexture(string path_)
        {
            return this._texLoader.LoadTexture(path_);
        }
    }
}
