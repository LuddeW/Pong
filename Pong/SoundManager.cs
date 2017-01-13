using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class SoundManager
    {
        Song song;
        SoundEffect blip;
        SoundEffect blop;
        public SoundManager(Song song, SoundEffect blip, SoundEffect blop)
        {
            this.song = song;
            this.blip = blip;
            this.blop = blop;
        }

        public void PlaySong()
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.3f;
        }

        public void PlayBlip()
        {
            blip.Play();
        }

        public void PlayBlop()
        {
            blop.Play();
        }
    }
}
