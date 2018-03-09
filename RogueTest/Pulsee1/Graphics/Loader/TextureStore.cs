using Pulsee1.Graphics.Textures;
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
            return;
        }

        public void LoadTex(string path)
        {
            texLoaded.Add(texLoader.LoadTexture(path));
            return;
        }

        //load all the textures in content file using TextureLoader
        //by scaning the content of the res/textures folder (fi)
    }
}
