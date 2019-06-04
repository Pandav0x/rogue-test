using System;
using System.Collections.Generic;
using System.Reflection;
using Pulsee.Game.GameObjects;
using Pulsee.Utilities.Display;

namespace Pulsee.Game
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
                if(gameObject.IsSubclassOf(typeof(Pulsee.Game.GameObjects.GameObject)))
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
