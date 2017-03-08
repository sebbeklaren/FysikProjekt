using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;
using System;

namespace Ballthrow
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ball_text;
        //float x, y;
        //Vector2 velocity;
        
        Form1 form;
        Ball ball;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            form = new Form1(this);
            form.Show();

            base.Initialize();
        }
        
        public void SetStartX(float myX)
        {
            ball.start_position.X = myX;
        }
        public void SetStartY(float myY)
        {
            ball.start_position.Y = myY;
        }

        public void SetStartVelocity(float speed, float degrees)
        {
         double rad = degrees * Math.PI / 180;
         ball.start_velocity = new Vector2((float)(speed * Math.Cos(rad)), (float)(speed * Math.Sin(rad)));
        }


        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ball_text = Content.Load<Texture2D>(@"ball");


            ball = new Ball(ball_text, 1, 1, new Vector2(0, 0), Window);
           
           
        }


        protected override void UnloadContent()
        {
           
        }


        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();
 
            ball.Update(gameTime);
            //Console.WriteLine(ball.delta_time);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            ball.Draw(spriteBatch);
            

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
