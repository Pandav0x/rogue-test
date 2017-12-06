using RogueTest.Engine.GameStates;
using RogueTest.Engine.Utilities.Display;
using RogueTest.Engine.Display;
using RogueTest.Engine.Controls.Events;

namespace RogueTest.Engine
{
    class GameManager
    {
        public GameStatesManager gsm;
        public DisplayManager dm;
        public EventManager em;

        public GameManager()
        {
            xConsole.WriteLine("Initializing all the management bullshittery...");

            this.dm = new DisplayManager(this);
            this.gsm = new GameStatesManager(this);
            this.em = new EventManager(this);

            return;
        }

        public void Run()
        {
            this.gsm.startFirstState();

            this.dm.startWindow();

            return;
        }  
    }
}
