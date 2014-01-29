using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace Chute2
{
    class Player3Manager//pg 119, creating the player
    {
        public Sprite playerSprite;
        private float playerSpeed = 110.0f; //moves at 160 pixels per second 

        Vector2 screenBounds;
        ContentManager content;

        SlideManager slideManager;
        bool canJump = true;
        bool onGround;
        bool canplay; 

        //animation?
        private SpriteEffects flip = SpriteEffects.None;
        Texture2D walkingAnimationsheet;
        Texture2D idleSheet;

        Texture2D texture;
        int frameCount;

        public Player3Manager(
            ContentManager content,
            Texture2D texture,
            SlideManager slideManager,
            Rectangle initialFrame,
            int frameCount,
            Vector2 screenBounds)
        {
            playerSprite = new Sprite(
                new Vector2((screenBounds.X - 64)/3, 0),
                texture,
                initialFrame,
                Vector2.Zero);

            this.screenBounds = screenBounds;

            this.slideManager = slideManager;

            this.content = content;

            this.texture = texture;

            this.frameCount = frameCount;

            for (int x = 1; x < frameCount; x++)
            {
                playerSprite.AddFrame(
                    new Rectangle(
                        initialFrame.X + (initialFrame.Width * x),
                        initialFrame.Y,
                        initialFrame.Width,
                        initialFrame.Height));
            }


            //Player 1 sprites
            walkingAnimationsheet = content.Load<Texture2D>(@"Textures\Koopa2Walk");

            idleSheet = content.Load<Texture2D>(@"Textures\Koopa2Idle");


        }// end pg 120 coding

        //load player sprite media



        private void HandleInput(KeyboardState keyState, GamePadState gamePadState) //pg 121, handlekeyboardinput helper method
        {
            /*
            walkingAnimationsheet = content.Load<Texture2D>(@"Textures\MarioWalking");

            marioLooking = content.Load<Texture2D>(@"Textures\MarioLookingUp");

            jumpingSheet = content.Load<Texture2D>(@"Textures\MarioJump");

            idleSheet = content.Load<Texture2D>(@"Textures\MarioIdle");
            */

            float pan = 2 * (playerSprite.Location.X / screenBounds.X) - 1;

            if (keyState.IsKeyUp(Keys.Space) && gamePadState.Buttons.A == ButtonState.Released)
                canJump = true;


            if (onGround == true)
                playerSprite.ChangeTexture(idleSheet);


            if (((keyState.IsKeyDown(Keys.Space)) || gamePadState.Buttons.A == ButtonState.Pressed)
                && canJump == true)
            {
                AudioManager.Play3JumpEffect(pan);
                playerSprite.Velocity += new Vector2(0, -24);

                playerSprite.ChangeTexture(walkingAnimationsheet);

                canJump = false;
                onGround = false;
            }

            if (keyState.IsKeyDown(Keys.Left) || gamePadState.ThumbSticks.Left.X < 0)
            {
                playerSprite.Velocity += new Vector2(-2, 0);
                flip = SpriteEffects.FlipHorizontally;
                playerSprite.ChangeTexture(walkingAnimationsheet);
            }

            if (keyState.IsKeyDown(Keys.Right) || gamePadState.ThumbSticks.Left.X > 0)
            {
                playerSprite.Velocity += new Vector2(2, 0);
                flip = SpriteEffects.None;
                playerSprite.ChangeTexture(walkingAnimationsheet);
            }

            if (gamePadState.Buttons.B == ButtonState.Pressed)
            {
                if (canplay == true)
                {
                    canplay = false;
                    AudioManager.Snare();
                }
            }

            else if (gamePadState.Buttons.B == ButtonState.Released)
                canplay = true; 


        }


        private void imposeMovementLimits()//pg 123, updating and darwing the player's ship
        {
            Vector2 location = playerSprite.Location;

            //if player reaches bottom of the screen, stays on the "ground"
            if (location.Y >= (screenBounds.Y - playerSprite.Source.Height - 58))
            {
                location.Y = screenBounds.Y - playerSprite.Source.Height - 58;
                onGround = true;
                canJump = true;
            }

            else
                canJump = false;


            //lock player from going above the screen
            if (location.Y <= (0 - playerSprite.Source.Height / 2))
            {
                location.Y = -playerSprite.Source.Height / 2;
            }

            if (location.X > (screenBounds.X))
            {
                location.X = 0;
            }

            if (location.X < (0 - playerSprite.Source.Width))
            {
                location.X = screenBounds.X - playerSprite.Source.Width;
            }



            playerSprite.Location = location;
        }

        public void Update(GameTime gameTime)
        {

            //gravity 
            playerSprite.Velocity = new Vector2(0, 3);

            HandleInput(Keyboard.GetState(), GamePad.GetState(PlayerIndex.Three));

            playerSprite.Velocity.Normalize();
            playerSprite.Velocity *= playerSpeed;



            playerSprite.Update(gameTime);
            imposeMovementLimits();




        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerSprite.Draw(spriteBatch, flip);
        }





    }
}
