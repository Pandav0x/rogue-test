using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsee1;

namespace Pulsee1.GameStates.BaseState
{

    class State : IStateEnum
    {
        private GameManager _parent;

        public GameManager _Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public State(GameManager parent_)
        {
            this._parent = parent_;
            return;
        }

        public virtual void Start(params dynamic[] args)
        {
            Initialize();
            Content();
            Stop();
            return;
        }

        protected virtual void Initialize(params dynamic[] args) { return; }
        protected virtual void Content(params dynamic[] args) { return; }
        protected virtual void Stop(params dynamic[] args) { return; }
    }

    interface IStateEnum
    {
        void Start(params dynamic[] args);
    }
}
