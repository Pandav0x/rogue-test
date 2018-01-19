using Pulsee1.Game.GameStates.BaseState;

namespace Pulsee1.Game.GameStates.States
{
    class LoseState : State
    {
        private GameManager _parent;

        public LoseState(GameManager parent_) : base(parent_){}

        protected override void Content(params dynamic[] args)
        {
            return;
        }
    }
}
