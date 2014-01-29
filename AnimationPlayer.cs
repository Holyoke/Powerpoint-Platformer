#region File Description
//Animation Player
#endregion


using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chute2
{
    /// <summary>
    /// this controls the playback of animation, not the player
    /// </summary>
    struct AnimationPlayer
    {
        //Get the animation which will play

        public Animation Animation
        {
            get { return animation; }
        }

        Animation animation;

        //get the index of current animation frame
        public int FrameIndex
        {
            get { return frameIndex; }
        }
        int frameIndex;

        //the amount of time in seconds the frame will display
        private float time;

        //get texture origin at the bottom center of each frame
        public Vector2 Origin
        {
            get { return new Vector2(Animation.FrameWidth / 2.0f, Animation.FrameHeight / 2.0f); }
        }

        //begins or continues playback of an animation
        public void PlayAnimation(Animation animation)
        {
            //if animation is already running, don't restart
            if (Animation == animation)
                return;

            //Start the new animation
            this.animation = animation;
            this.frameIndex = 0;
            this.time = 0.0f;
        }

        //advances the time position and darws the current frame
        //of the animation
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects)
        {
            if (Animation == null)
                throw new NotSupportedException("No animation dumbass");

            //Process passing time
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (time > Animation.FrameTime)
            {
                time -= Animation.FrameTime;

                //advance the frame index; looping/clamping as needed.
                if (Animation.IsLooping)
                {
                    frameIndex = (frameIndex + 1) % Animation.FrameCount;
                }
                else
                {
                    frameIndex = Math.Min(frameIndex + 1, Animation.FrameCount - 1);
                }
            }

            //calculate the source rectangle of the current frame
            Rectangle source = new Rectangle(FrameIndex * Animation.Texture.Height, 0, Animation.Texture.Height, Animation.Texture.Height);

            //Draw the current frame
            spriteBatch.Draw(Animation.Texture, position, source, Color.Black, 0.0f, Origin, 1.0f, spriteEffects, 0.0f);
        }
    }
}





