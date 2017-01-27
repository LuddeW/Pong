using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class GameManager
    {
        Game1 game;
        SoundManager soundManager;
        Song song;
        SoundEffect blip;
        SoundEffect blop;
        Clock clock;
        Texture2D field;
        Texture2D bar;
        Texture2D balltex;
        Player player;
        Player player2;
        AI ai;
        Ball ball;
        Rectangle playBox = new Rectangle(0, 60, 1400, 680);
        Vector2 ballStartPos = new Vector2(700, 400);
        SpriteFont font;
        SpriteFont menuFont;
        KeyboardState prevKeyboardState;
        Menu menu;
        int player1Score = 0;
        int player2Score = 0;
        int soundCorrector = 1;
        int startDirection;
        enum GameState { Play, Score, Menu}
        GameState currentGameState = GameState.Menu;
        public GameManager(Game1 game)
        {
            this.game = game;           
            ball = new Ball(ballStartPos);
            player = new Player(new Rectangle(1340, 300, 40, 66), new Rectangle(1340, 366, 40, 66), new Rectangle(1340, 432, 40, 67), new Vector2(1340, 300), 1, ball);
            //player2 = new Player(new Rectangle(60, 300, 40, 66), new Rectangle(60, 366, 40, 66), new Rectangle(60, 432, 40, 67), new Vector2(60, 300), 2, ball);
            ai = new AI(new Rectangle(60, 300, 40, 66), new Rectangle(60, 366, 40, 66), new Rectangle(60, 432, 40, 67), new Vector2(60, 300), 2, ball);
            clock = new Clock();
        }

        public void Load(ContentManager Content)
        {
            field = Content.Load<Texture2D>("Gamefield");
            bar = Content.Load<Texture2D>("Player");
            balltex = Content.Load<Texture2D>("Ball");
            font = Content.Load<SpriteFont>(@"Font");
            menuFont = Content.Load<SpriteFont>(@"menuFont");
            menu = new Menu(menuFont, balltex, game);
            song = Content.Load<Song>(@"spel 1");
            blip = Content.Load<SoundEffect>(@"blip");
            blop = Content.Load<SoundEffect>(@"blop");
            soundManager = new SoundManager(song, blip, blop);
            soundManager.PlaySong();
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            switch(currentGameState)
            {
                case GameState.Play:
                    {
                        if (ball.hitBox.X > 1400 || ball.hitBox.X < 0)
                        {
                            if (ball.hitBox.X >= 1400)
                            {
                                player2Score += 1;
                                startDirection = 1;
                            }
                            else
                            {
                                player1Score += 1;
                                startDirection = 2;
                            }
                            currentGameState = GameState.Score;
                        }
                        player.Update();
                        ai.Update();
                        //player2.Update();
                        ball.Update();
                        HandleContact();
                    }
                    break;
                case GameState.Score:
                    {
                        clock.AddTime(0.3f);
                        player.Update();
                        ai.Update();
                        //player2.Update();
                        ball.hitBox.X = (int)ballStartPos.X;
                        ball.hitBox.Y = (int)ballStartPos.Y;
                        if (clock.Timer() > 20.0f)
                        {
                            if (startDirection == 1)
                            {
                                ball.speed.X = 5;
                            }
                            else
                            {
                                ball.speed.X = -5;
                            }
                            clock.ResetTime();                          
                            currentGameState = GameState.Play;
                        }
                    }
                    break;
                case GameState.Menu:
                    {
                        menu.Update(keyboardState, prevKeyboardState);
                    }
                    break;
            }
            prevKeyboardState = keyboardState;
        }

        public void Draw(SpriteBatch sb)
        {
            switch (currentGameState)
            {
                case GameState.Play:
                    sb.Draw(field, new Vector2(0, 0), Color.White);
                    PrintString(sb);
                    player.Draw(sb, bar);
                    ai.Draw(sb, bar);
                    //player2.Draw(sb, bar);
                    ball.Draw(sb, balltex);
                    break;

                case GameState.Score:
                    sb.Draw(field, new Vector2(0, 0), Color.White);
                    PrintString(sb);
                    player.Draw(sb, bar);
                    ai.Draw(sb, bar);
                    //player2.Draw(sb, bar);
                    ball.Draw(sb, balltex);
                    break;

                case GameState.Menu:
                    sb.Draw(field, new Vector2(0, 0), Color.White);
                    player.Draw(sb, bar);
                    //player2.Draw(sb, bar);
                    menu.Draw(sb);
                    break;
            }

        }

        private void PrintString(SpriteBatch sb)
        {
            string p1 ="" + player1Score;
            string p2 = "" + player2Score;

            Vector2 p1Len = font.MeasureString(p1);
            Vector2 p2Len = font.MeasureString(p2);

            sb.DrawString(font, p1, new Vector2(1400 / 4 * 3 - p1Len.X / 2, 800 / 2 - p1Len.Y / 2), Color.Gray);
            sb.DrawString(font, p2, new Vector2(1400 / 4 - p2Len.X / 2, 800 / 2 - p2Len.Y / 2), Color.Gray);
        }

        private void HandleContact()
        {
            if (ball.hitBox.Intersects(player.middle) || /*ball.hitBox.Intersects(player2.middle) ||*/ ball.hitBox.Intersects(ai.middle))
            {
                ball.IntersectsMiddle();
                HandleSounds();
            }
            else if (ball.hitBox.Intersects(player.top) || /*ball.hitBox.Intersects(player2.top) ||*/ ball.hitBox.Intersects(ai.top))
            {
                ball.IntersectsTop();
                HandleSounds();

            }
            else if (ball.hitBox.Intersects(player.bottom) || /*ball.hitBox.Intersects(player2.bottom) ||*/ ball.hitBox.Intersects(ai.bottom))
            {
                ball.IntersectsBottom();
                HandleSounds();
            }
            if (!ball.hitBox.Intersects(playBox))
            {
                ball.IntersectsWall();
                HandleSounds();
            }
        }

        private void HandleSounds()
        {
            if (soundCorrector == 2)
            {
                soundManager.PlayBlip();
                soundCorrector = 1;
            }
            else
            {
                soundManager.PlayBlop();
                soundCorrector = 2;
            }
        }

        public void SetScreen()
        {
            currentGameState = GameState.Play;
        }
    }   
}
