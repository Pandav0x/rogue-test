using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace RogueTest.Engine.Display.Content
{
    class Camera
    {
        public Vector2 position = Vector2.Zero;
        public float movementSpeed = 0.2f;
        public float mouseSensivity = 0.01f; //not used by the game

        public Camera() { return; }

    }
}
