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
        Player player2;
        Ball ball;
        Rectangle playBox = new Rectangle(0, 60, 1400, 680);
        public GameManager()
        {
            player = new Player(new Rectangle(1340, 300, 40, 66), new Rectangle(1340, 366, 40, 66), new Rectangle(1340, 432, 40, 67), new Vector2(1340, 300), 1);
            player2 = new Player(new Rectangle(60, 300, 40, 66), new Rectangle(60, 366, 40, 66), new Rectangle(60, 432, 40, 67), new Vector2(60, 300), 2);
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
            player2.Update();
            ball.Update();
            if (ball.hitBox.Intersects(player.middle) || ball.hitBox.Intersects(player2.middle))
            {
                ball.IntersectsMiddle();
            }
            if (ball.hitBox.Intersects(player.top) || ball.hitBox.Intersects(player2.top))
            {
                ball.IntersectsTop();
            }
            if (ball.hitBox.Intersects(player.bottom) || ball.hitBox.Intersects(player2.bottom))
            {
                ball.IntersectsBottom();
            }
            if (!ball.hitBox.Intersects(playBox))
            {
                ball.IntersectsWall();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(field, new Vector2(0, 0), Color.White);
            player.Draw(sb, bar);
            player2.Draw(sb, bar);
            ball.Draw(sb, balltex);
        }
    }   
}
