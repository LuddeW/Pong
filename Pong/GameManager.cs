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
        Texture2D ball;
        Player player;
        public GameManager()
        {
            player = new Player();
        }

        public void Load(ContentManager Content)
        {
            field = Content.Load<Texture2D>("Gamefield");
            bar = Content.Load<Texture2D>("Player");
            ball = Content.Load<Texture2D>("Ball");
        }

        public void Update()
        {
            player.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(field, new Vector2(0, 0), Color.White);
            player.Draw(sb, bar);
            sb.Draw(ball, new Vector2(700, 400), Color.White);
        }
    }   
}
