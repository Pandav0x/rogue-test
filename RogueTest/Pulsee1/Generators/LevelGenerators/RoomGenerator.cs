using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsee1.GameContent.Level;

namespace Pulsee1.LevelGenerators.Generators
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
