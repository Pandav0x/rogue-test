using System;
using System.Linq;
using OpenTK;
using RogueTest.Engine.Utilities.Mathp;

namespace RogueTest.Engine.GameContent.Level
{
    class Floor
    {
        public char floorChar;
        private Room[][] _rooms;
        private Vector2 _floorSize;
        private FloorTypes _floorType;
        
        public Floor(Vector2 floorSize_ = new Vector2())
        {
            /*this._floorSize = (!floorSize_.Equals(null)) ? xRandom.getRandomSize(3, 5) : floorSize_; //floor min-max size : 5-20
            this._rooms = Enumerable.Range(0, (int)_floorSize.X).Select(i => Enumerable.Range(0, (int)_floorSize.Y).Select(j => new Room()).ToArray()).ToArray();

            this._floorType = (floorTypes)xRandom.random.Next(0, 0);
            this.floorChar = this._floorType.ToString().ToCharArray()[0];*/

            return;
        }

        public void PrintConsoleFloor()
        {
            string ret = "Floor - (" + this._floorSize.X.ToString() + "x" + this._floorSize.Y.ToString() + ")";
            for (int i = 0; i < this._floorSize.X; i++)
            {
                for (int j = 0; j < this._floorSize.Y; j++)
                {
                    //this._rooms[i][j].printConsoleRoom();
                }
            }
            Console.Write(ret);
            return;
        }

        private enum FloorTypes
        {
            Regular
        }

    }
}
