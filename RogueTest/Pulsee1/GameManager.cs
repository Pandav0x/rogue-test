using Pulsee1.GameStates;
using Pulsee1.Utilities.Display;
using Pulsee1.Display;
using Pulsee1.Controls.Events;
using Pulsee1.Generators;

namespace Pulsee1
{
    class GameManager
    {
        public GameStatesManager gsm;
        public DisplayManager dm;
        public EventManager em;
        public GeneratorsManager gm;

        public GameManager()
        {
            xConsole.WriteLine("Initializing all the management bullshittery...");

            this.dm = new DisplayManager(this);
            this.gsm = new GameStatesManager(this);
            this.em = new EventManager(this);
            this.gm = new GeneratorsManager();

            return;
        }

        public void Run()
        {
            this.gsm.StartFirstState();

            this.dm.StartWindow();

            return;
        }  
    }
}
