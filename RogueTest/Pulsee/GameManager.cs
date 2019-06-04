using Pulsee.KernelContent.Startup;
using Pulsee.Game.GameStates;
using Pulsee.Utilities.Display;
using Pulsee.Devices.Display;
using Pulsee.Display.Graphics;
using Pulsee.Graphics;
using Pulsee.Game;

namespace Pulsee
{
    class GameManager
    {
        public GameStatesManager gasm;
        public DisplayManager dim;
        public GraphicsManager grm;
        public GameObjectManager gom;

        public GameManager()
        {
            xConsole.WriteLine("Loading game manager...");

            this.dim = new DisplayManager(this);
            this.grm = new GraphicsManager(this);
            this.gasm = new GameStatesManager(this);
            gom = new GameObjectManager();

            PulseeGL.GLSetContext(this);

            return;
        }

        public void Run()
        {
            Opening.PrintLogoOnScreen(this);

            this.gasm.StartFirstState();

            this.dim.StartWindow();

            return;
        }  
    }
}
