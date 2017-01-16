using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class Menu
    {
        Game1 game;
        SpriteFont menuFont;
        Texture2D ball;
        protected enum ButtonState { Start, Exit }
        ButtonState CurrentState = ButtonState.Start;
        Rectangle posRect;
        Rectangle srcRect;
        Vector2 startLen;
        Vector2 exitLen;
        string start = "START";
        string exit = "EXIT";

        public Menu(SpriteFont menuFont, Texture2D ball, Game1 game)
        {
            this.game = game;
            this.menuFont = menuFont;
            this.ball = ball;
            startLen = menuFont.MeasureString(start);
            exitLen = menuFont.MeasureString(exit);
        }

        public void Update(KeyboardState keyState, KeyboardState prevKeyState)
        {
            switch (CurrentState)
            {
                case ButtonState.Start:
                    posRect = new Rectangle(1400 / 2 + (int)startLen.X / 2 + 50, 260, 20, 20);
                    break;
                case ButtonState.Exit:
                    posRect = new Rectangle(1400 / 2 + (int)exitLen.X / 2 + 50, 460, 20, 20);
                    break;
            }
            HandleMenu(keyState, prevKeyState);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(menuFont, start, new Vector2(1400 / 2 - startLen.X / 2, 200), Color.Gray);
            sb.DrawString(menuFont, exit, new Vector2(1400 / 2 - exitLen.X / 2, 400), Color.Gray);
            sb.Draw(ball, posRect, Color.White);
        }

        protected void HandleMenu(KeyboardState keyState, KeyboardState prevKeyState)
        {
            if (CurrentState == ButtonState.Start)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    game.SetScreen();
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down) && prevKeyState.IsKeyUp(Keys.Down))
                {
                    CurrentState = ButtonState.Exit;
                }
                prevKeyState = keyState;
            }
            if (CurrentState == ButtonState.Exit)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    game.Exit();
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Up) && prevKeyState.IsKeyUp(Keys.Up))
                {
                    CurrentState = ButtonState.Start;
                }
                prevKeyState = keyState;
            }
        }

    }
}
