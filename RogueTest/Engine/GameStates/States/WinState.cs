using RogueTest.Engine.GameStates.BaseState;

namespace RogueTest.Engine.GameStates.States
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
