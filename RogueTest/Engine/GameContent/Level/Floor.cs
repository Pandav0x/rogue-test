using System;
using System.Linq;
using OpenTK;
using RogueTest.Engine.Utilities.Mathp;
using System.Collections.Generic;

namespace RogueTest.Engine.GameContent.Level
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
