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
        Ball ball;
        Rectangle playBox = new Rectangle(0, 60, 1400, 680);
        Vector2 ballStartPos = new Vector2(700, 400);
        SpriteFont font;
        int player1Score = 0;
        int player2Score = 0;
        int soundCorrector = 1;
        int startDirection;
        enum GameState { Play, Score, Menu}
        GameState currentGameState = GameState.Play;
        public GameManager()
        {
            player = new Player(new Rectangle(1340, 300, 40, 66), new Rectangle(1340, 366, 40, 66), new Rectangle(1340, 432, 40, 67), new Vector2(1340, 300), 1);
            player2 = new Player(new Rectangle(60, 300, 40, 66), new Rectangle(60, 366, 40, 66), new Rectangle(60, 432, 40, 67), new Vector2(60, 300), 2);
            ball = new Ball(ballStartPos);
            clock = new Clock();
        }

        public void Load(ContentManager Content)
        {
            field = Content.Load<Texture2D>("Gamefield");
            bar = Content.Load<Texture2D>("Player");
            balltex = Content.Load<Texture2D>("Ball");
            font = Content.Load<SpriteFont>(@"Font");
            song = Content.Load<Song>(@"spel 1");
            blip = Content.Load<SoundEffect>(@"blip");
            blop = Content.Load<SoundEffect>(@"blop");
            soundManager = new SoundManager(song, blip, blop);
            soundManager.PlaySong();
        }

        public void Update()
        {
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
                        player2.Update();
                        ball.Update();
                        HandleContact();
                    }
                    break;
                case GameState.Score:
                    {
                        clock.AddTime(0.3f);
                        player.Update();
                        player2.Update();
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

                    }
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(field, new Vector2(0, 0), Color.White);
            PrintString(sb);
            player.Draw(sb, bar);
            player2.Draw(sb, bar);
            ball.Draw(sb, balltex);

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
            if (ball.hitBox.Intersects(player.middle) || ball.hitBox.Intersects(player2.middle))
            {
                ball.IntersectsMiddle();
                HandleSounds();
            }
            else if (ball.hitBox.Intersects(player.top) || ball.hitBox.Intersects(player2.top))
            {
                ball.IntersectsTop();
                HandleSounds();

            }
            else if (ball.hitBox.Intersects(player.bottom) || ball.hitBox.Intersects(player2.bottom))
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
    }   
}
