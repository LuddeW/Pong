using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class Player
    {
        public Rectangle top;
        public Rectangle middle;
        public Rectangle bottom;
        Vector2 pos;
        public Player(Rectangle top, Rectangle middle, Rectangle bottom, Vector2 pos)
        {
            this.bottom = bottom;
            this.top = top;
            this.middle = middle;
            this.pos = pos;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && pos.Y > 40)
            {
                pos.Y -= 10;
                top.Y -= 10;
                middle.Y -= 10;
                bottom.Y -= 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && pos.Y < 560)
            {
                pos.Y += 10;
                top.Y += 10;
                middle.Y += 10;
                bottom.Y += 10;
            }
        }

        public void Draw(SpriteBatch sb, Texture2D texture)
        {
            sb.Draw(texture, pos, Color.White);
            sb.Draw(texture, bottom, Color.Red);
            sb.Draw(texture, middle, Color.Blue);
            sb.Draw(texture, top, Color.Green);
        }
    }
}
