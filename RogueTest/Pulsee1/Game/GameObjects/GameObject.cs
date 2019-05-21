using System.Collections.Generic;

namespace Pulsee1.Game.GameObjects
{ 
    abstract class GameObject
    {
        public GameObject(){}

        public abstract void Update();

        public abstract void RenderUpdate();

    }
}
