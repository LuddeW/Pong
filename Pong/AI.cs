using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class AI
    {
        public enum Status { MoveUp, MoveDown, Idle }
        public Status status = Status.Idle;
        public Rectangle top;
        public Rectangle middle;
        public Rectangle bottom;
        int playerIndex;
        Vector2 pos;
        Ball ball;

        public AI(Rectangle top, Rectangle middle, Rectangle bottom, Vector2 pos, int playerIndex, Ball ball)
        {
            this.bottom = bottom;
            this.top = top;
            this.middle = middle;
            this.pos = pos;
            this.playerIndex = playerIndex;
            this.ball = ball;
        }

        public void Update()
        {
            Move();
            switch (status)
            {
                case Status.Idle:
                    {
                        if (ball.hitBox.X < 400 && middle.Y < ball.hitBox.Y)
                        {
                            status = Status.MoveDown;
                        }
                        else if(ball.hitBox.X < 400 && middle.Y > ball.hitBox.Y)
                        {
                            status = Status.MoveUp;
                        }
                    }
                    break;
                case Status.MoveUp:
                    {
                        if (ball.hitBox.X < 400 && middle.Y < ball.hitBox.Y)
                        {
                            status = Status.MoveDown;
                        }
                        else if (ball.hitBox.X > 400)
                        {
                            status = Status.Idle;
                        }
                    }
                    break;
                case Status.MoveDown:
                    {
                        if (ball.hitBox.X < 400 && middle.Y > ball.hitBox.Y)
                        {
                            status = Status.MoveUp;
                        }
                        else if (ball.hitBox.X > 400)
                        {
                            status = Status.Idle;
                        }
                    }
                    break;
            }

        }

        public void Move()
        {
            if (playerIndex == 2 && status == AI.Status.MoveUp && pos.Y > 40)
            {
                pos.Y -= 10;
                top.Y -= 10;
                middle.Y -= 10;
                bottom.Y -= 10;
            }
            if (playerIndex == 2 && status == AI.Status.MoveDown && pos.Y < 560)
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
