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
        public Rectangle top = new Rectangle(1340, 300, 40, 66);
        public Rectangle middle = new Rectangle(1340, 366, 40, 66);
        public Rectangle bottom = new Rectangle(1340, 432, 40, 67);
        public Vector2 pos = new Vector2(1340, 300);
        public Player()
        {

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
        }
    }
}
