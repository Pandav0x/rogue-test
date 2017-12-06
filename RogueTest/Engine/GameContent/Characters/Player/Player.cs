using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueTest.Engine.GameContent.Characters;
using OpenTK;

namespace RogueTest.Engine.GameContent.Characters.Player
{
    class Player : Character
    {
        Player()
        {
            this.floor = 0;
            this.room = new Vector2(8,8);

            return;
        }
    }
}
