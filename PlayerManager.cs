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
    class PlayerManager//pg 119, creating the player
    {
        public Sprite playerSprite;
        private float playerSpeed = 160.0f; //moves at 160 pixels per second
        float pan; 

        Vector2 screenBounds;
        ContentManager content; 

        SlideManager slideManager;
        bool canJump = true;
        bool onGround;

        //animation?
        private SpriteEffects flip = SpriteEffects.None;
        Texture2D walkingAnimationsheet;
        Texture2D jumpingSheet;
        Texture2D idleSheet;
        Texture2D marioLooking;

        //2p sprites

        Texture2D texture;
        int frameCount;

        //block data
        Sprite block;
        Sprite block2;

        Sprite block3, block4;

        Rectangle blockBox ;
        Rectangle blockBox2;
        Rectangle blockBox3;
        Rectangle blockBox4;


        public PlayerManager(
            ContentManager content,
            Texture2D texture,
            SlideManager slideManager,
            Rectangle initialFrame,
            int frameCount,
            Vector2 screenBounds)
        {
            playerSprite = new Sprite(
                new Vector2((screenBounds.X - 64)/2, -768*3),
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
            
            block = new Sprite(new Vector2(0, screenBounds.Y - 250),
                content.Load<Texture2D>(@"Textures\Block"),
                new Rectangle(0, 0, 32, 64), Vector2.Zero);

            block2 = new Sprite(new Vector2(screenBounds.X - 32, screenBounds.Y - 250),
                content.Load<Texture2D>(@"Textures\Block"),
                new Rectangle(0, 0, 32, 64), Vector2.Zero);

            block3 = new Sprite(new Vector2(449 , screenBounds.Y - 250),
                content.Load<Texture2D>(@"Textures\Block"),
                new Rectangle(0, 0, 32, 64), Vector2.Zero);

            block4 = new Sprite(new Vector2(558, screenBounds.Y - 250),
                content.Load<Texture2D>(@"Textures\Block"),
                new Rectangle(0, 0, 32, 64), Vector2.Zero);

            //Player 1 sprites
            walkingAnimationsheet = content.Load<Texture2D>(@"Textures\MarioWalking");
            marioLooking = content.Load<Texture2D>(@"Textures\MarioLookingUp");
            jumpingSheet = content.Load<Texture2D>(@"Textures\MarioJump");
            idleSheet = content.Load<Texture2D>(@"Textures\MarioIdle");

            blockBox = block.BoundingBoxRect;
            blockBox2 = block2.BoundingBoxRect;
            blockBox3 = block3.BoundingBoxRect;
            blockBox4 = block4.BoundingBoxRect;



        }// end pg 120 coding

        //load player sprite media


        public void LoadContent()
        {
            //animated textures;

                        
        }

        private void HandleInput(KeyboardState keyState, GamePadState gamePadState) //pg 121, handlekeyboardinput helper method
        {
            /*
            walkingAnimationsheet = content.Load<Texture2D>(@"Textures\MarioWalking");

            marioLooking = content.Load<Texture2D>(@"Textures\MarioLookingUp");

            jumpingSheet = content.Load<Texture2D>(@"Textures\MarioJump");

            idleSheet = content.Load<Texture2D>(@"Textures\MarioIdle");
            */
            pan = 2 * (playerSprite.Location.X / screenBounds.X) - 1; 
            
            if (keyState.IsKeyUp(Keys.Space) && gamePadState.Buttons.A == ButtonState.Released)
                canJump = true;


            if ( onGround == true )
                playerSprite.ChangeTexture(idleSheet);


            if ( ((keyState.IsKeyDown(Keys.Space)) || gamePadState.Buttons.A == ButtonState.Pressed )
                && canJump == true)
            {
                AudioManager.PlayJumpEffect(pan);
                playerSprite.Velocity += new Vector2(0, -36 );

                playerSprite.ChangeTexture(jumpingSheet);

                canJump = false;
                onGround = false;
            }

            if (keyState.IsKeyDown(Keys.Left) || gamePadState.ThumbSticks.Left.X < 0)
            {
                playerSprite.Velocity += new Vector2(-2, 0);
                flip = SpriteEffects.FlipHorizontally;
                playerSprite.ChangeTexture(walkingAnimationsheet);
            }

            if (keyState.IsKeyDown(Keys.Right) || gamePadState.ThumbSticks.Left.X >0)
            {
                playerSprite.Velocity += new Vector2(2, 0);
                flip = SpriteEffects.None;
                playerSprite.ChangeTexture(walkingAnimationsheet);
            }


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


            if (location.X > (screenBounds.X))
            {
                location.X = 0;
                slideManager.IncreaseSlide();
                AudioManager.PlayRightWhoosh();
            }

            if (location.X < (0 - playerSprite.Source.Width))
            {
                location.X = screenBounds.X - playerSprite.Source.Width;
                slideManager.DecreaseSlide();
                AudioManager.PlayLeftWhoosh();
            }



            playerSprite.Location = location; 
        }

        public void Update(GameTime gameTime)
        {





            //gravity 
            playerSprite.Velocity = new Vector2(0, 3);

            HandleInput(Keyboard.GetState(), GamePad.GetState(PlayerIndex.One));

            if (playerSprite.IsBoxColliding(blockBox))
            {
                playerSprite.Location = new Vector2(playerSprite.Location.X, blockBox.Bottom);
                slideManager.DecreaseSlide();
                AudioManager.PlayCoin(-1.0f);
            }

            if (playerSprite.IsBoxColliding(blockBox2))
            {
                playerSprite.Location = new Vector2(playerSprite.Location.X, blockBox.Bottom);
                slideManager.IncreaseSlide();
                AudioManager.PlayCoin(1.0f);
            }

            if (playerSprite.IsBoxColliding(blockBox3) && slideManager.Index == 13)
            {
                playerSprite.Location = new Vector2(playerSprite.Location.X, blockBox.Bottom);
                AudioManager.PlayHyoshigi();
            }

            if (playerSprite.IsBoxColliding(blockBox4) && slideManager.Index == 13)
            {
                playerSprite.Location = new Vector2(playerSprite.Location.X, blockBox.Bottom);
                AudioManager.PlayOtsuzumi();
            }

            playerSprite.Velocity.Normalize();
            playerSprite.Velocity *= playerSpeed;



            playerSprite.Update(gameTime);
            imposeMovementLimits();




        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerSprite.Draw(spriteBatch, flip);
            block.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
            block2.Draw(spriteBatch, SpriteEffects.None);
            if (slideManager.Index == 13)
            {
                block3.Draw(spriteBatch, SpriteEffects.None);
                block4.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
            }
        }





    }
}
