using Pulsee1.Display.Graphics.Loader;
using Pulsee1.Display.Graphics.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsee1.Display.Graphics
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
            return;
        }

        public Texture2D LoadTexture(string path_)
        {
            return this._texLoader.LoadTexture(path_);
        }
    }
}
