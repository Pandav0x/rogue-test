using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsee1.Game.GameContent.Characters;
using OpenTK;

namespace Pulsee1.Game.GameContent.Characters.Player
{
    class Player : Character
    {
        public Player()
        {
            this.floor = 0;
            this.room = new Vector2(8,8);

            return;
        }
    }
}
