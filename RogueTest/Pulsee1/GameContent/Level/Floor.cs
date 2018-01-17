using System;
using System.Linq;
using OpenTK;
using Pulsee1.Utilities.Mathp;
using System.Collections.Generic;

namespace Pulsee1.GameContent.Level
{
    class Floor
    {
        public Dictionary<Vector2, char> rooms = new Dictionary<Vector2, char>();

        public Floor() { return; }

        public Floor(Dictionary<Vector2, char> rooms_ = null)
        {
            if (rooms_ != null)
                rooms = rooms_;
            else
                rooms = new Dictionary<Vector2, char>();
            return;
        }

        public void PrintConsoleFloor()
        {
            return;
        }

        private enum FloorTypes
        {
            Regular
        }

    }
}
