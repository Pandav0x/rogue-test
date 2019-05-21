using Pulsee1.KernelContent.Startup;
using Pulsee1.Game.GameStates;
using Pulsee1.Utils.Display;
using Pulsee1.Devices.Display;
using Pulsee1.Display.Graphics;
using Pulsee1.Graphics;
using Pulsee1.Game;

namespace Pulsee1
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

            PulseGL.GLSetContext(this);

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
