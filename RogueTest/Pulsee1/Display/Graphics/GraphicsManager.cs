﻿using Pulsee1.Display.Graphics.GLOverlay;
using Pulsee1.Display.Graphics.Loader;
using Pulsee1.Display.Graphics.Textures;
using Pulsee1.Utilities.Display;
using System.Collections.Generic;

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
            xConsole.WriteLine("OpenGL - " + PulseGL.GetGLVersion());
            return;
        }

        public Texture2D LoadTexture(string path_)
        {
            return this._texLoader.LoadTexture(path_);
        }
    }
}
