using OpenTK;

namespace Pulsee1.Game.GameContent.Level
{
    class Room
    {
        private Tile[][] _tiles;
        private Vector2 _gridPos;
        private int _roomType;
        private bool doorT, doorb, doorL, doorR;

        public Room() { return; }

        public Room(Vector2 gridPos_, int roomType_)
        {
            this._gridPos = gridPos_;
            this._roomType = roomType_;
            return;
        }
    }
}
