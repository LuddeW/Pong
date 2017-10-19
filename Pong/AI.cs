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
        Rectangle middleBox;
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
            UpdateMiddleBox();
            switch (status)
            {
                case Status.Idle:
                    {
                        if (middleBox.Intersects(ball.hitBox))
                        {
                            break;
                        }
                        else if (ball.hitBox.X < 500 && middle.Y <= ball.hitBox.Y && ball.speed.X <= 0)
                        {
                            status = Status.MoveDown;
                        }
                        else if(ball.hitBox.X < 500 && middle.Y >= ball.hitBox.Y && ball.speed.X <= 0)
                        {
                            status = Status.MoveUp;
                        }
                    }
                    break;
                case Status.MoveUp:
                    {                  
                        if (ball.hitBox.X > 500 || middleBox.Intersects(ball.hitBox))
                        {
                            status = Status.Idle;
                            break;
                        }
                        else if (ball.hitBox.X < 500 && middle.Y  + 132 < ball.hitBox.Y && ball.speed.X <= 0)
                        {
                            status = Status.MoveDown;
                        }                       
                    }
                    break;
                case Status.MoveDown:
                    {
                        if (ball.hitBox.X > 500 || middleBox.Intersects(ball.hitBox))
                        {
                            status = Status.Idle;
                            break;
                        }
                        else if (ball.hitBox.X < 500 && middle.Y > ball.hitBox.Y && ball.speed.X <= 0)
                        {
                            status = Status.MoveUp;
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

        public void UpdateMiddleBox()
        {
            middleBox = middle;
            middleBox.Width = 500;
            middleBox.Height = 66 * 3;
            middleBox.Y = middle.Y - 66;
        }

        public void Draw(SpriteBatch sb, Texture2D texture)
        {
            sb.Draw(texture, pos, Color.White);
        }

    }
}
