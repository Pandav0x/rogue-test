using Pulsee1.GameStates.BaseState;

namespace Pulsee1.GameStates.States
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
