using System;
using Pulsee.Game.GameStates.BaseState;
using Pulsee.Utilities.Display;

namespace Pulsee.Game.GameStates.States
{
    class MainMenuState : State
    {
        public MainMenuState(GameManager parent_) : base(parent_) { }

        protected override void Content(params dynamic[] args)
        {
            xConsole.WriteLine("Main menu started !");
            //base._Parent.gameStates["level"].Start();
            return;
        }
    }
}
