using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Chute2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        Texture2D player, player2, player3, player4; 

        
        PlayerManager playerManager;
        Player2Manager player2Manager;
        Player3Manager player3Manager;
        Player4Manager player4Manager; 

        SlideManager slideManager;

        Video video;
        VideoPlayer Vplayer;
        Song daisybell;
        Song currenttrack, rkryu;
        Song fin, ryu, asteroidmusic,drums,phaser,synths,theremin,gameover,dead; 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.IsFullScreen = true; 

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            slideManager = new SlideManager(this);
            Components.Add(slideManager);

            daisybell = Content.Load<Song>(@"Audio/DaisyBell");
            ryu = Content.Load<Song>(@"Audio/Ryu");
            rkryu = Content.Load<Song>(@"Audio/RKRyu");
            asteroidmusic = Content.Load<Song>(@"Audio\AsteroidMusic");
            drums = Content.Load<Song>(@"Audio\AsteroidMusicDrums");
            phaser = Content.Load<Song>(@"Audio\AsteroidMusicPhaser");
            synths = Content.Load<Song>(@"Audio\AsteroidMusicSynths");
            theremin = Content.Load<Song>(@"Audio\AsteroidMusicTheremin");
            gameover = Content.Load<Song>(@"Audio\Dead");
            dead = Content.Load<Song>(@"Audio\Dead");
            fin = Content.Load<Song>(@"Audio\DaisyBellFin");

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f; 

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player = Content.Load<Texture2D>(@"Textures\MarioFall");
            player2 = Content.Load<Texture2D>(@"Textures\KoopaWalk");
            player3 = Content.Load<Texture2D>(@"Textures\Koopa2Walk");
            player4 = Content.Load<Texture2D>(@"Textures\GoombaWalk");


            playerManager = new PlayerManager(Content, player, slideManager, 
                new Rectangle(0, 0, 64, 64),
                2,
                new Vector2(
                    this.Window.ClientBounds.Width,
                    this.Window.ClientBounds.Height));

            player2Manager = new Player2Manager(Content, player2, slideManager,
                new Rectangle(0, 0, 64, 64),
                2,
                new Vector2(
                    this.Window.ClientBounds.Width,
                    this.Window.ClientBounds.Height));

            player3Manager = new Player3Manager(Content, player3, slideManager,
                new Rectangle(0, 0, 64, 64),
                2,
                new Vector2(
                    this.Window.ClientBounds.Width,
                    this.Window.ClientBounds.Height));

            player4Manager = new Player4Manager(Content, player4, slideManager,
                new Rectangle(0, 0, 64, 64),
                2,
                new Vector2(
                    this.Window.ClientBounds.Width,
                    this.Window.ClientBounds.Height)); 

            AudioManager.Initialize(Content);

            video = Content.Load<Video>(@"Slides\Video");
            Vplayer = new VideoPlayer(); 

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        /// 

        public void MediaUpdate(int Index)
        {
            switch (Index)
            {
                case 0:
                    if (MediaPlayer.State != MediaState.Playing)
                    {
                        currenttrack = daisybell;
                        if (playerManager.playerSprite.Location.Y ==
                            (this.Window.ClientBounds.Height - playerManager.playerSprite.Source.Height - 58))
                        {
                            MediaPlayer.Play(currenttrack);
                        }
                    }
                    break;
                
                case 3:
                    MediaPlayer.Stop();
                    Vplayer.Stop();
                    break;
                case 4:
                    Vplayer.Play(video);
                    MediaPlayer.Pause();
                    break;
                case 5:
                    Vplayer.Stop();
                    if (MediaPlayer.State != MediaState.Playing)
                    {
                        MediaPlayer.Volume = 0.3f;
                        MediaPlayer.Play(Content.Load<Song>(@"Audio\RKRyu"));
                    }
                    break;

                case 8:
                    if (currenttrack != ryu)
                    {
                        currenttrack = ryu;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;

                case 13:
                    MediaPlayer.Pause();
                    break; 
                case 14:
                    if (currenttrack != rkryu)
                    {
                        currenttrack = rkryu;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 21:
                    if (currenttrack != asteroidmusic)
                    {
                        currenttrack = asteroidmusic;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 22:
                    if (currenttrack != daisybell)
                    {
                        currenttrack = daisybell;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 43:
                    if (currenttrack != synths)
                    {
                        currenttrack = synths;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 45:
                    if (currenttrack != drums)
                    {
                        currenttrack = drums;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 46:
                    if (currenttrack != phaser)
                    {
                        currenttrack = phaser;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 47:
                    if (currenttrack != theremin)
                    {
                        currenttrack = theremin;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 48:
                    if (currenttrack != synths)
                    {
                        currenttrack = synths;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 53:
                    if (currenttrack != dead)
                    {
                        currenttrack = dead;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 54:
                    if (currenttrack != gameover)
                    {
                        currenttrack = gameover;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 55:
                    if (currenttrack != synths)
                    {
                        currenttrack = synths;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 56:
                    if (currenttrack != daisybell)
                    {
                        currenttrack = daisybell;
                        MediaPlayer.Play(currenttrack);
                    }
                    break;
                case 60:
                    if (currenttrack != fin)
                    {
                        currenttrack = fin;
                        MediaPlayer.Play(currenttrack);
                        MediaPlayer.IsRepeating = false; 
                    }
                    break;

            }

              
            
            
           

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            MediaUpdate(slideManager.Index);

            playerManager.Update(gameTime);
            player2Manager.Update(gameTime);
            player3Manager.Update(gameTime);
            player4Manager.Update(gameTime);








            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            Texture2D videoTexture = null;
            if (Vplayer.State != MediaState.Stopped)
                videoTexture = Vplayer.GetTexture();



            spriteBatch.Begin();

            slideManager.Draw(spriteBatch);

            player2Manager.Draw(spriteBatch);
            player3Manager.Draw(spriteBatch);
            player4Manager.Draw(spriteBatch);
            playerManager.Draw(spriteBatch);

            // TODO: Add your drawing code here

            if (videoTexture != null && slideManager.Index == 4)
            {
                spriteBatch.Draw(videoTexture, new Rectangle(195, 100, 650, 488), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
