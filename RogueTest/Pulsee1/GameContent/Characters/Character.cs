using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Pulsee1.GameContent.Level;

namespace Pulsee1.GameContent.Characters
{
    class Character
    {
        /// <summary>
        /// Life of the character
        /// </summary>
        private int _life;
        /// <summary>
        /// Position of the character in the room
        /// </summary>
        private Vector2d _pos = new Vector2d();
        /// <summary>
        /// Facing position of the character
        /// </summary>
        private Tile.FacingPosition _facingPosition;
        /// <summary>
        /// Current state of the character
        /// </summary>
        private CharacterState _characterState;
        /// <summary>
        /// Name of the character (en_XXXX = baddy, pl_XXXX = player)
        /// </summary>
        private string _name;

        public int floor;
        public Vector2 room;

        /// <summary>
        /// Default constructor, set the base position of the character
        /// </summary>
        public Character()
        {
            this._pos.X = 0;
            this._pos.Y = 0;
            return;
        }

        /// <summary>
        /// Create an empty character
        /// </summary>
        /// <returns></returns>
        public Character Create() { return new Character(); }

        /// <summary>
        /// Check the life of the current character
        /// </summary>
        /// <returns>True if the character is still alive, False if not</returns>
        public bool IsAlive()
        {
            return (this._life <= 0);
        }

        /// <summary>
        /// Change the position of the character in the room
        /// </summary>
        /// <param name="vector_">Changing position vector(2d)</param>
        public void Move(Vector2d vector_)
        {
            this._pos += vector_;
            return;
        }

        /// <summary>
        /// States that the characters can be in
        /// </summary>
        public enum CharacterState
        {
            Idle,
            Walk,
            Attack,
            DmgTaken
        }
                
    }
}
