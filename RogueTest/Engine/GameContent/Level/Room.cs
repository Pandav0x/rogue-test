using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using RogueTest.Engine.Utilities.Mathp;
using RogueTest.Engine.Utilities.Generators;

namespace RogueTest.Engine.GameContent.Level
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
