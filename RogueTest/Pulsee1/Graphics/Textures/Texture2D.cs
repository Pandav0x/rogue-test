namespace Pulsee1.Graphics.Textures
{
    class Texture2D
    {
        private int _id;
        private int _width, _height;

        public int ID { get { return _id; }  }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }

        public Texture2D(int id_, int width_, int height_)
        {
            this._id = id_;
            this._width = width_;
            this._height = height_;
        }

        public Texture2D() { return; }
    }
}
