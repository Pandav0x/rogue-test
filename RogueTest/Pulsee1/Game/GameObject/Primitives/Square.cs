using System;
using Pulsee1.Utils.Display;

namespace Pulsee1.Game.GameObject.Primitives
{
    class Square : GameObject
    {
        public Square() : base()
        {
            //nothing
        }

        public override void RenderUpdate ()
        {
            xConsole.WriteLine("ouioui");
        }

        public override void Update ()
        {
            throw new NotImplementedException();
        }
    }
}
