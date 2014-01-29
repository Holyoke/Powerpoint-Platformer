using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Chute2
{
    class SlideManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        //List<Slide> slideList = new List<Slide>();
        Slide[] slideList = new Slide[61];
        int i = 0;

        Slide currentslide;


        public SlideManager(Game game)
            : base(game)
        {

        }


        protected override void LoadContent()
        {
            //slide objects here
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            for (int j = 1; j <= 61; j++)
            {
                slideList[j-1] = new Slide(
                    Game.Content.Load<Texture2D>(@"Slides/Slide" + j.ToString()),
                    new Rectangle(0, 0, Game.Window.ClientBounds.Width,Game.Window.ClientBounds.Height),
                    Vector2.Zero, Vector2.Zero);
            }

            /*
            slideList[0] = new Slide(
                 Game.Content.Load<Texture2D>(@"Slides/Slide1"),
                 new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height),
                 Vector2.Zero, Vector2.Zero);


            slideList[1] = new Slide(
                Game.Content.Load<Texture2D>(@"Slides/Slide2"),
                new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height),
                Vector2.Zero, Vector2.Zero);

            slideList[2] = new Slide(
                Game.Content.Load<Texture2D>(@"Slides/Slide3"),
                new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height),
                Vector2.Zero, Vector2.Zero);

            slideList[3] = new Slide(
                Game.Content.Load<Texture2D>(@"Slides/Slide4"),
                new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height),
                Vector2.Zero, Vector2.Zero);
            */
             


            //Block



            base.LoadContent();
        }


        public override void Initialize()
        {


            base.Initialize();
        }

        public int Index
        {
            get { return i; }
        }


        public void IncreaseSlide()
        {
            if (i == 60)
                i = 60;
            else
                i++;
        }

        public void DecreaseSlide()
        {
            if (i == 0)
                i = 0;
            else
                i--;
        }

        //block logic
        public override void Update(GameTime gameTime)
        {

            currentslide = slideList[i];

            //Slide Change Code
            /*if (Keyboard.GetState().IsKeyDown(Keys.Right) && canchangeSlide == true)
            {
                IncreaseSlide();
                canchangeSlide = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Left))
                canchangeSlide = true;

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && canchangeSlide == true)
            {
                DecreaseSlide();
                canchangeSlide = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right))
                canchangeSlide = true;
            */ 

            //if (playerManager.playerSprite.Location.X >= Game.Window.ClientBounds.Width)


            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            currentslide.Draw(spriteBatch);

        }
    }
}
