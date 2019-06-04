using System;
using Pulsee.Utilities.Display;

namespace Pulsee.Game.GameObjects.Primitives
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
