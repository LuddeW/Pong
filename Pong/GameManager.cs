using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class GameManager
    {
        Texture2D field;
        Texture2D bar;
        Texture2D balltex;
        Player player;
        Ball ball;
        Rectangle playBox = new Rectangle(0, 60, 1400, 680);
        public GameManager()
        {
            player = new Player();
            ball = new Ball();
        }

        public void Load(ContentManager Content)
        {
            field = Content.Load<Texture2D>("Gamefield");
            bar = Content.Load<Texture2D>("Player");
            balltex = Content.Load<Texture2D>("Ball");
        }

        public void Update()
        {
            player.Update();
            ball.Update();
            if (ball.hitBox.Intersects(player.pos) || !ball.hitBox.Intersects(playBox))
            {
                ball.Intersects();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(field, new Vector2(0, 0), Color.White);
            player.Draw(sb, bar);
            ball.Draw(sb, balltex);
        }
    }   
}
