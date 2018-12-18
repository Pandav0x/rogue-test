using System;
using Pulsee1.Game.GameStates.BaseState;
using Pulsee1.Utils.Display;

namespace Pulsee1.Game.GameStates.States
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
