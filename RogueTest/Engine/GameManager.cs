using RogueTest.Engine.GameStates;
using RogueTest.Engine.Utilities.Display;
using RogueTest.Engine.Display;
using RogueTest.Engine.Controls.Events;
using RogueTest.Engine.Generators;

namespace RogueTest.Engine
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
