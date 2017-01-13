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
        Song zombie;
        public SoundManager(Song zombie)
        {
            this.zombie = zombie;
        }

        public void PlaySong()
        {
            MediaPlayer.Play(zombie);
            MediaPlayer.IsRepeating = true;
        }


    }
}
