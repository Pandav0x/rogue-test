using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueTest.Engine.GameContent.Level;

namespace RogueTest.Engine.Utilities.Generators
{
    class RoomGenerator
    {
        public RoomGenerator() { return; }

        public static Room GenerateRoom(string seed_ = null)
        {
            return new Room();
        }
    }
}
