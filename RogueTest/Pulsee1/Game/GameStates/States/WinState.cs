using Pulsee1.Game.GameStates.BaseState;

namespace Pulsee1.Game.GameStates.States
{
    class WinState : State
    {
        private GameManager _parent;

        public WinState(GameManager parent_) : base(parent_) { }

        protected override void Content(params dynamic[] args)
        {
            return;
        }
    }
}
