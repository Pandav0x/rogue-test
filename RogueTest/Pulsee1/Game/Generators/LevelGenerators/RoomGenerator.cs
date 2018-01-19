using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsee1.Game.GameContent.Level;

namespace Pulsee1.Game.LevelGenerators.Generators
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
