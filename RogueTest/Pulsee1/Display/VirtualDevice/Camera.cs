using OpenTK;

namespace Pulsee1.Devices.Display.VirtualDevice
{
    class Camera
    {
        public Vector2 position = Vector2.Zero;
        public float movementSpeed = 0.2f;
        public float mouseSensivity = 0.01f; //not used by the game

        public Camera() { return; }

    }
}
