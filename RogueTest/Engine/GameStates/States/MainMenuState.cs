using System;
using RogueTest.Engine.GameStates.BaseState;
using RogueTest.Engine.Utilities.Display;

namespace RogueTest.Engine.GameStates.States
{
    class MainMenuState : State
    {
        public MainMenuState(GameManager parent_) : base(parent_) { }

        protected override void Content(params dynamic[] args)
        {
            xConsole.WriteLine("Main menu started !", ConsoleColor.Yellow);
            //base._Parent.gameStates["level"].Start();
            return;
        }
    }
}
