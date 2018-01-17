using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Pulsee1.GameContent.Level
{
    class Tile
    {
        public string path;
        public char tileChar;
        private TileType _type;
        private FacingPosition _facingPos;

        private Vector2 _tileSize = new Vector2(30, 30); //size of the tiles in px
        private string _assetsPath = @"C:\Users\Panda\Desktop\rogueAssets\textures\";
        
        private Dictionary<TileType, string> _tilesFiles = new Dictionary<TileType, string>
        {
            { TileType.wall, "wall" },
            { TileType.floor, "floor" },
            { TileType.door, "door" },
            { TileType.ladder, "ladder" }
        };

        private string _fileExt = ".png";

        public Tile()
        {
            return;
        }

        public void GenerateTile(TileType type_ = TileType.wall, FacingPosition facingPos_ = FacingPosition.Down)
        {
            this._type = type_;
            this.tileChar = this._type.ToString().ToCharArray()[0];
            this._facingPos = FacingPosition.Down;
            this.path = this._assetsPath + _tilesFiles[this._type] + "_" + this._facingPos.ToString().ToLower() + this._fileExt;
            //Console.WriteLine(this.path);
            return;
        }

        public enum TileType
        {
            wall,
            floor,
            door,
            ladder
        }

        public enum FacingPosition
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
