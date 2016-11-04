using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveThing
{
    public class Character
    {
        private object sprite;
        private int height;
        private int width;

        public Character() : this(null, 0, 0) { }


        public Character(object sprite, int height, int width)
        {
            this.sprite = sprite;
            this.height = height;
            this.width = width;
        }

        public void MoveUp()
        {
            // move up
        }

        public void MoveDown()
        {
            // move down
        }

        public void MoveRight()
        {
            //move right
        }

        public void MoveLeft()
        {
            //move left
        }

        public void Draw()
        {
            // draw character
        }


    }
}
