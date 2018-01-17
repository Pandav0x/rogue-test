using System.Collections.Generic;
using Pulsee1.GameContent.Level;
using Pulsee1.Utilities.Mathp;
using Pulsee1.Utilities.Display;
using System.Linq;
using OpenTK;
using System;

namespace Pulsee1.LevelGenerators.Generators
{
    class FloorGenerator
    {
        private Vector2 _floorSize = new Vector2(20, 20);
        private Dictionary<Vector2, char> _rooms = new Dictionary<Vector2, char>();
        private List<Vector2> _takenPos = new List<Vector2>();

        private int _roomNumber = 100;
        private float _seed;

        public FloorGenerator()
        {
            Console.WriteLine("Warining : if used, this instance will throw an error (FloorGenerator)");
            return;
        }

        public FloorGenerator(Vector2 size_, float seed_ = 0.6f, int roomNumber_ = 100)
        {
            xConsole.WriteLine("Generating Floor");
            xConsole.WriteLine("Initializing", ConsoleColor.Yellow);
            this._floorSize = new Vector2(20, 20);
            this._seed = seed_;
            this._roomNumber = roomNumber_;
            return;
        }

        public Floor GenerateFloor()
        {
            BFSFilling();
            Console.WriteLine("Number of rooms : " + _takenPos.Count);
            return new Floor(_rooms);
        }

        private void BFSFilling()
        {
            Queue<Vector2> stroller = new Queue<Vector2>();
            Vector2 startPos = new Vector2(((int)Math.Floor(_floorSize.X / 2.0)), ((int)Math.Floor(_floorSize.Y / 2.0)));
            _takenPos.Add(startPos);
            _rooms.Add(startPos, (char)RoomCharacter.start);

            while (_takenPos.Count <= _roomNumber)
            {
                stroller.Clear();
                stroller.Enqueue(startPos);
                for (int index = 0; index < (_floorSize.X * _floorSize.Y); index++)
                {
                    List<Vector2> gypsy = GitGudDirections(stroller.ElementAt<Vector2>(index));
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < gypsy.Count; j++)
                        {
                            if (!(stroller.Contains(gypsy[j])))
                            {
                                stroller.Enqueue(gypsy[j]);
                                RoomInstaller(index, gypsy[j]);
                            }
                            if (_takenPos.Count >= _roomNumber)
                                return;
                        }//end checking direction
                    }//end browsing directions
                }//end browsing map
            }//end while
        }

        private List<Vector2> GitGudDirections(Vector2 currentPos_)
        {
            List<Vector2> gud = new List<Vector2>();
            if (currentPos_.X - 1 >= 0)
                gud.Add(new Vector2(currentPos_.X - 1, currentPos_.Y));
            if (currentPos_.Y - 1 >= 0)
                gud.Add(new Vector2(currentPos_.X, currentPos_.Y - 1));
            if (currentPos_.X + 1 <= _floorSize.X - 1)
                gud.Add(new Vector2(currentPos_.X + 1, currentPos_.Y));
            if (currentPos_.Y + 1 <= _floorSize.Y - 1)
                gud.Add(new Vector2(currentPos_.X, currentPos_.Y + 1));
            return gud;
        }

        private bool HasNeighbor(List<Vector2> takenPos, Vector2 pos)
        {
            List<Vector2> udlr = GitGudDirections(pos);
            foreach (Vector2 coordinate in udlr)
                if (takenPos.Contains(coordinate))
                    return true;
            return false;
        }

        private void RoomInstaller(int index, Vector2 currElem)
        {
            if (index <= 4 || HasNeighbor(_takenPos, currElem) && (xRandom.GetRandomNumber() / 100 <= _seed))
            {
                _takenPos.Add(currElem);
                _rooms.Add(currElem, (_takenPos.Count == _roomNumber - 1) ? (char)RoomCharacter.finish : (char)RoomCharacter.regular);
            }
        }
    }

    public enum RoomCharacter
    {
        start = 'S',
        finish = 'F',
        regular = 'X'
    };
}
