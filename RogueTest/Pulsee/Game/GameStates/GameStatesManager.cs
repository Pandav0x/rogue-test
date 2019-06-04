using Pulsee.Game.GameStates.BaseState;
using Pulsee.Utilities.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsee.Game.GameStates
{
    class GameStatesManager
    {
        private string firstStateToLoad = "mainMenu";

        private Dictionary<string, IStateEnum> gameStates = new Dictionary<string, IStateEnum>();

        public GameStatesManager(GameManager context)
        {
            xConsole.WriteLine("Game States Loading...");
            this.gameStates.Add("mainMenu", new GameStates.States.MainMenuState(context));
            this.gameStates.Add("lose", new GameStates.States.LoseState(context));
            this.gameStates.Add("win", new GameStates.States.WinState(context));
            this.gameStates.Add("level", new GameStates.States.LevelState(context));
        }

        public void StartFirstState()
        {
            xConsole.WriteLine("Launching first state -> " + this.firstStateToLoad);
            this.gameStates[firstStateToLoad].Start();
        }
    }
}
