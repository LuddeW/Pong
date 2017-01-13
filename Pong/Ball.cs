using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class Ball
    {
        public Rectangle hitBox;
        public Vector2 speed = new Vector2(5, 0);
        Vector2 startPos;
        

        public Ball(Vector2 startPos)
        {
            this.startPos = startPos;
             hitBox = new Rectangle((int)startPos.X, (int)startPos.Y, 20, 20);
        }

        public void Update()
        {
            hitBox.X += (int)speed.X;
            hitBox.Y += (int)speed.Y;
        }

        public void IntersectsTop()
        {
            speed.X *= -1;
            speed.Y = -2;
        }

        public void IntersectsBottom()
        {
            speed.X *= -1;
            speed.Y = 2;
        }

        public void IntersectsMiddle()
        {
            if (speed.X > 0)
            {
                speed.X += 1;
            }
            else
            {
                speed.X -= 1;
            }
            speed.X *= -1;
            Console.WriteLine(speed);
        }

        public void IntersectsWall()
        {
            speed.Y *= -1;
        }

        public void Draw(SpriteBatch sb, Texture2D texture)
        {
            sb.Draw(texture, hitBox, Color.White);
        }
    }
}
