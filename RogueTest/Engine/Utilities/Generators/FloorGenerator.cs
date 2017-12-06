using System.Collections.Generic;
using RogueTest.Engine.GameContent.Level;
using RogueTest.Engine.Utilities.Mathp;
using RogueTest.Engine.Utilities.IO;
using OpenTK;
using System;
using RogueTest.Engine.Utilities.Display;

namespace RogueTest.Engine.Utilities.Generators
{
    class FloorGenerator
    {
        private Vector2 _floorSize = new Vector2(10,10);
        private Room[,] _rooms; //a
        private List<Vector2> _takenPositions = new List<Vector2>();
        private int _gridSizeX, _gridSizeY, _roomNumber = 20;

        public FloorGenerator() { return; }

        public static Floor GenerateFloor(string seed_ = null)
        {
            //https://www.youtube.com/watch?v=nADIYwgKHv4
            return new Floor();
        }

        private void Start()
        {
            if (this._roomNumber >= (this._floorSize.X * 2) * (this._floorSize.Y * 2))
                this._roomNumber = (int)Math.Round((double)((this._floorSize.X * 2) * (this._floorSize.Y * 2)));
            this._gridSizeX = (int)Math.Round((double)((this._floorSize.X * 2)));
            this._gridSizeY = (int)Math.Round((double)((this._floorSize.Y * 2)));
            CreateRooms();
            return;
        }

        private void CreateRooms()
        {
            this._rooms = new Room[this._gridSizeX * 2, this._gridSizeY * 2];
            this._rooms[_gridSizeX, _gridSizeY] = new Room(Vector2.Zero, 1);
            this._takenPositions.Insert(0, Vector2.Zero);
            Vector2 checkPos = Vector2.Zero;

            float randomCompare = 0.2f, randomCompareStart = 0.2f, randomCompareEnd = 0.01f;

            for (int i = 0; i < this._roomNumber - 1; i++)
            {
                float randomPerc = ((float)i) / (((float)this._roomNumber - 1));
                randomCompare = Lerp.LerpThatAss(randomCompareStart, randomCompareEnd, randomPerc);
                checkPos = NewPosistion();

                if (NeighborsNum(checkPos, _takenPositions) > 1 && xRandom.GetRandomNumber() > randomCompare)
                {
                    int ite = 0;
                    do
                    {
                        checkPos = SelectiveNewPosition();
                        ite++;
                    } while (NeighborsNum(checkPos, _takenPositions) > 1 && ite < 100);
                    if (ite >= 50)
                        xConsole.WriteLine("Error with the room numbers", ConsoleColor.Red);
                }
            }

            return;
        }

        private Vector2 NewPosistion()
        {
            return new Vector2();
        }

        private int NeighborsNum(Vector2 position, List<Vector2> map)
        {
            return 0;
        }

        private Vector2 SelectiveNewPosition()
        {
            return new Vector2();
        }
    }
}
