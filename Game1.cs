using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
// needed for user input
using Microsoft.Xna.Framework.Input;
// needed for loading the sprite images
using System.Collections.Generic;
using System.Diagnostics; 





namespace NanoscopicKnight
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
       
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public int health = 100; 
        Player p1;
        ScrollingBackground b1;
        Crosshair c1;
        List<basicAntibodyFire> basicAntibodies;
        List<Influenza> influenzas;

        FastAntibody fA1;
        HealthBar hB1;

        //Timer idea from https://gamedev.stackexchange.com/questions/32203/interval-timing-in-xna
        float timerInfluenza = 1;
        const float TIMER = 1;
        float timerInfluenzaSpawn = 1;
        const float TIMERSPAWN = 1;
        float timerBAF = .75f;
        const float TIMERBAF = .75f;
        float timerGame=0;
        const float TIMERGAME=120; 


        bool game=true; 


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            
                p1 = new Player();
                b1 = new ScrollingBackground();
                c1 = new Crosshair();

                basicAntibodies = new List<basicAntibodyFire>();
                influenzas = new List<Influenza>();
                fA1 = new FastAntibody(b1);
                hB1 = new HealthBar();
            
            


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



            // TODO: use this.Content to load your game content here
           
                b1.LoadContent(Content);
                p1.LoadContent(Content);
                c1.LoadContent(Content);
                basicAntibodyFire.LoadContent(Content);
                Influenza.LoadContent(Content);

                FastAntibody.LoadContent(Content);
                hB1.LoadContent(Content);
            
            

            


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        MouseState oldState;
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            float timeElapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timerGame += timeElapsed;
            if (timerGame< TIMERGAME & health>0)
            {
                game = true; 
            }
            else
            {
                game = false; 
            }
            
            
            if (game)
            {
                //spawn enemies
                Random random = new Random();
                float elapsedSpawn = (float)gameTime.ElapsedGameTime.TotalSeconds;
                timerInfluenzaSpawn -= elapsedSpawn;
                if (timerInfluenzaSpawn < 0)
                {
                    influenzas.Add(new Influenza(random.Next(0, 1280), random.Next(0, 360)));
                    timerInfluenzaSpawn = TIMERSPAWN;
                }

                p1.Move();
                c1.Update();
                //make sure health can only be between 0 and 100
                health = MathHelper.Clamp(health, 0, 100);


                KeyboardState keys = Keyboard.GetState();
                if (keys.IsKeyDown(Keys.Up) == true)
                {
                    health += 1;
                }



                //If the Down Arrowis pressed, decrease the Health bar
                /* if (keys.IsKeyDown(Keys.Down) == true)
                 {
                     health -= 1;
                 }*/

                MouseState mouseState = Mouse.GetState();
                float elapsedFire = (float)gameTime.ElapsedGameTime.TotalSeconds;
                timerBAF -= elapsedFire;
                if (mouseState.LeftButton == ButtonState.Released & oldState.LeftButton == ButtonState.Pressed)
                {
                    if (timerBAF < 0)
                    {
                        basicAntibodies.Add(new basicAntibodyFire(c1.position, p1.position, p1.playerXRadius, p1.playerYRadius));
                        timerBAF = TIMERBAF;
                    }

                }
                oldState = mouseState;
                foreach (basicAntibodyFire bAF in basicAntibodies)
                {
                    bAF.Move();
                }
                foreach (Influenza i in influenzas.ToArray())
                {

                    Vector2 v1 = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);
                    if (Vector2.Distance(p1.position + v1, i.position) >= 10)
                    {
                        i.Move(p1.position);
                        if (Vector2.Distance(i.newPosition, 2 * v1) >= 1280)
                        {
                            i.Move2(p1.position);
                        }
                        //timer


                    }
                    else
                    {
                        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                        timerInfluenza -= elapsed;
                        if (timerInfluenza < 0)
                        {

                            health -= 1;
                            timerInfluenza = TIMER;
                        }
                    }
                }
                foreach (Influenza i in influenzas.ToArray())
                {
                    foreach (basicAntibodyFire bAF in basicAntibodies.ToArray())
                    {

                        Vector2 bAFPosition = new Vector2(bAF.position.X + GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, bAF.position.Y + GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);
                        if (Vector2.Distance(i.position, bAFPosition) < 50)
                        {
                            influenzas.Remove(i);
                            basicAntibodies.Remove(bAF);
                        }
                    }
                }

            }
            base.Update(gameTime);
        }
            
 

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (game)
            {
                b1.Draw(spriteBatch, p1.position);
                p1.Draw(spriteBatch, b1.position);
                c1.Draw(spriteBatch);
                foreach (basicAntibodyFire bAF in basicAntibodies)
                {
                    bAF.Draw(spriteBatch, p1.position);
                }

                fA1.Draw(spriteBatch, p1.position);
                foreach (Influenza i in influenzas)
                {
                    i.Draw(spriteBatch, p1.position);
                }
                hB1.Draw(spriteBatch, health);
                base.Draw(gameTime);
            }
        }
            
    }
}
