using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Chute2 
{
    public static class AudioManager
    {


        //player movement sounds
        private static SoundEffect JumpEffect1, JumpEffect2, JumpEffect3, JumpEffect4;

        private static SoundEffect leftWhoosh;
        private static SoundEffect rightWhoosh, kick, snare,egg;
        private static SoundEffect coin, hyoshigi, otsuzumi; 

        private static Random rand = new Random();

        public static void Initialize(ContentManager content)
        {
            try
            {
                /*playerShot = content.Load<SoundEffect>(@"Sounds\Shot1");

                rightsoundInstance = rightSound.CreateInstance();

                leftsoundInstance.Volume = 0.2f;
                rightsoundInstance.Volume = 0.2f;
                 */

                JumpEffect1 = content.Load<SoundEffect>(@"Audio\PlayerJump");
                JumpEffect2 = content.Load<SoundEffect>(@"Audio\Player2Jump");
                JumpEffect3 = content.Load<SoundEffect>(@"Audio\Player3Jump");
                JumpEffect4 = content.Load<SoundEffect>(@"Audio\Player4Jump");

                leftWhoosh = content.Load<SoundEffect>(@"Audio\LeftWhoosh");
                rightWhoosh = content.Load<SoundEffect>(@"Audio\RightWhoosh");
                coin = content.Load<SoundEffect>(@"Audio\coin");

                hyoshigi = content.Load<SoundEffect>(@"Audio\Hyoshigi");
                otsuzumi = content.Load<SoundEffect>(@"Audio\Otsuzumi");

                kick = content.Load<SoundEffect>(@"Audio\Kick");
                snare = content.Load<SoundEffect>(@"Audio\Snare");
                egg = content.Load<SoundEffect>(@"Audio\Egg"); 



            }
            catch
            {
                Debug.Write("SoundManager Initialization Failed");
            }

        }
         
        public static void PlayJumpEffect(float pan)
        {
            try
            {
                JumpEffect1.Play(0.5f, 0.0f , pan);
            }
            catch
            {
                Debug.Write("JumpEffect1 failed");
            }
        }

        public static void Play2JumpEffect(float pan)
        {
            try
            {
                JumpEffect2.Play(0.5f, 0.0f, pan);
            }
            catch
            {
                Debug.Write("JumpEffect1 failed");
            }
        }

        public static void Play3JumpEffect(float pan)
        {
            try
            {
                JumpEffect3.Play(0.5f, 0.0f, pan);
            }
            catch
            {
                Debug.Write("JumpEffect1 failed");
            }
        }

        public static void Play4JumpEffect(float pan)
        {
            try
            {
                JumpEffect4.Play(0.5f, 0.0f, pan);
            }
            catch
            {
                Debug.Write("JumpEffect1 failed");
            }
        }

        public static void PlayLeftWhoosh()
        {
            leftWhoosh.Play(0.5f, 0.0f, -1.0f);
        }

        public static void PlayRightWhoosh()
        {
            rightWhoosh.Play(0.5f, 0.0f, 1.0f);
        }

        public static void PlayCoin(float pan)
        {
            coin.Play(0.2f, 0.0f, pan);        
        }

        public static void PlayHyoshigi()
        {
            hyoshigi.Play();
        }

        public static void PlayOtsuzumi()
        {
            otsuzumi.Play();
        }

        public static void Kick()
        {
            kick.Play(0.5f, 0.0f, -0.75f);
        }

        public static void Snare()
        {
            snare.Play(0.5f, 0.0f, 0.75f);
        }

        public static void Egg()
        {
            egg.Play(0.5f, 0.0f, 0.0f);
        }

        /*public static void PlayLeftSound(float pan, bool canPlay)
        {
            leftsoundInstance.Pan = pan;

            if (canPlay == true)
                try
                {
                    leftsoundInstance.Play();
                }
                catch
                {
                    Debug.Write("PlayPlayerShot Failed");
                }

            else if (canPlay == false)

                leftsoundInstance.Stop();

        }
         */


        //pg 160, using the SoundManager class




    }
}
