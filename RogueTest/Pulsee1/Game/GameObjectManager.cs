using System;
using System.Collections.Generic;
using System.Reflection;
using Pulsee1.Game.GameObjects;
using Pulsee1.Utils.Display;

namespace Pulsee1.Game
{
    class GameObjectManager
    {
        public List<GameObject> gameObjects;


        public GameObjectManager()
        {
            gameObjects = new List<GameObject>();
            PopulateGameObjects();
            xConsole.WriteLine(gameObjects.Count.ToString() + " game objects loaded.", ConsoleColor.Green);
        }

        private void PopulateGameObjects()
        {
            foreach(Type gameObject in Assembly.GetExecutingAssembly().GetTypes())
            {
                if(gameObject.IsSubclassOf(typeof(Pulsee1.Game.GameObjects.GameObject)))
                {
                    gameObjects.Add((GameObject)Activator.CreateInstance(gameObject));
                }
            }
                
            return;
        }

        public void SpreadUpdate()
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Update();
            }
            return;
        }

        public void SreadRenderUpdate()
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.RenderUpdate();
            }
            return;
        }
    }
}
