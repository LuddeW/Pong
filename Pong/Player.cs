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
        Rectangle pos = new Rectangle(1340, 300, 40, 200);
        public Player()
        {

        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                pos.Y -= 10;
            }
        }

        public void Draw(SpriteBatch sb, Texture2D texture)
        {
            sb.Draw(texture, pos, Color.White);
        }
    }
}
