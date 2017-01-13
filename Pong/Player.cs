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
        int playerIndex;
        Vector2 pos;
        public Player(Rectangle top, Rectangle middle, Rectangle bottom, Vector2 pos, int playerIndex)
        {
            this.bottom = bottom;
            this.top = top;
            this.middle = middle;
            this.pos = pos;
            this.playerIndex = playerIndex;
        }

        public void Update()
        {
            if (playerIndex == 1 && Keyboard.GetState().IsKeyDown(Keys.Up) && pos.Y > 40)
            {
                pos.Y -= 10;
                top.Y -= 10;
                middle.Y -= 10;
                bottom.Y -= 10;
            }
            if (playerIndex == 1 && Keyboard.GetState().IsKeyDown(Keys.Down) && pos.Y < 560)
            {
                pos.Y += 10;
                top.Y += 10;
                middle.Y += 10;
                bottom.Y += 10;
            }
            if (playerIndex == 2 && Keyboard.GetState().IsKeyDown(Keys.W) && pos.Y > 40)
            {
                pos.Y -= 10;
                top.Y -= 10;
                middle.Y -= 10;
                bottom.Y -= 10;
            }
            if (playerIndex == 2 && Keyboard.GetState().IsKeyDown(Keys.S) && pos.Y < 560)
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
        }
    }
}
