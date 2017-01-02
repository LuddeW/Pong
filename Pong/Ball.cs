﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class Ball
    {
        public Rectangle hitBox = new Rectangle(700, 400, 20, 20);
        Vector2 speed = new Vector2(0, 5);

        public Ball()
        {

        }

        public void Update()
        {
            hitBox.X += (int)speed.X;
            hitBox.Y += (int)speed.Y;
        }

        public void Intersects()
        {
            speed.X *= -1;
            speed.Y *= -1;
        }

        public void Draw(SpriteBatch sb, Texture2D texture)
        {
            sb.Draw(texture, hitBox, Color.White);
        }
    }
}