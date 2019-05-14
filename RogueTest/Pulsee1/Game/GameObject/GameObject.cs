using System.Collections.Generic;

namespace Pulsee1.Game.GameObject
{ 
    abstract class GameObject
    {
        private static List<GameObject> gameObjects;

        public GameObject()
        {
            gameObjects.Add(this);
        }

        public abstract void Update();

        public abstract void RenderUpdate();

    }
}
