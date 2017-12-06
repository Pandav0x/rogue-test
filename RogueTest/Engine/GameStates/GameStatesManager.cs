using RogueTest.Engine.GameStates.BaseState;
using RogueTest.Engine.Utilities.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueTest.Engine.GameStates
{
    class GameStatesManager
    {
        private string firstStateToLoad = "mainMenu";

        private Dictionary<string, IStateEnum> gameStates = new Dictionary<string, IStateEnum>();

        public GameStatesManager(GameManager context)
        {
            xConsole.WriteLine("Those Fucking Game States Loading...", ConsoleColor.Green);
            this.gameStates.Add("mainMenu", new GameStates.States.MainMenuState(context));
            this.gameStates.Add("lose", new GameStates.States.LoseState(context));
            this.gameStates.Add("win", new GameStates.States.WinState(context));
            this.gameStates.Add("level", new GameStates.States.LevelState(context));
        }

        public void startFirstState()
        {
            xConsole.WriteLine("Launching first state : FUCK YOU ->" + this.firstStateToLoad, ConsoleColor.DarkMagenta);
            this.gameStates[firstStateToLoad].Start();
        }
    }
}
