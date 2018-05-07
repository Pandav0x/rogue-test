﻿using Pulsee1.Utils.IO;
using Pulsee1.Graphics.Textures;
using Pulsee1.Utils.Display;
using System.Collections.Generic;

namespace Pulsee1.Graphics.Loader
{
    class TextureStore
    {
        public TextureLoader texLoader;
        public List<Texture2D> texLoaded;

        public TextureStore()
        {
            this.texLoader = new TextureLoader();
            this.texLoaded = new List<Texture2D>();
            xConsole.Write(AppData.AssetsLocation());
            return;
        }

        public void LoadSingleTex(string path)
        {
            texLoaded.Add(texLoader.LoadTexture(path));
            return;
        }

        public void LoadAllTex()
        {
            foreach (string file in DirManagement.GetAllFiles(AppData.AssetsLocation()))
                texLoaded.Add(texLoader.LoadTexture(AppData.AssetsLocation() + file));

            return;
        }

        //load all the textures in content file using TextureLoader
        //by scaning the content of the res/textures folder (fi)
    }
}
