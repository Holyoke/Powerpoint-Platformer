using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Chute2
{
    class Slide
    {
        Texture2D backgroundImage;
        Rectangle bgrect;
        //Point currentFrame;
        protected Vector2 speed;
        protected Vector2 position;

        //constructors

        public Slide(Texture2D backgroundImage, Rectangle bgrect, Vector2 speed, Vector2 position)
        {
            this.backgroundImage = backgroundImage;
            this.bgrect = bgrect;
            this.speed = speed;
            this.position = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(backgroundImage,
                bgrect, null, Color.White, 0,
                new Vector2(0, 0), SpriteEffects.None, 1);

        }




    }
}
