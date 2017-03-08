using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ballthrow
{
    class Ball
    {
        public Vector2 start_position;
        public Vector2 current_position;
        public Vector2 start_velocity;
        public Vector2 current_velocityTestChange;
        public Rectangle hitBox;
        Vector2 acceleration;
        public float delta_time;
        float scale;
        float radie = 1.5f;
        Texture2D texture;
        public float x, y;
        Vector2 origin;
        private GameWindow window;
        float wallElast = 0.9f, floorElast = 0.9f;

        public Ball(Texture2D texture, float x, float y, Vector2 velocity, GameWindow gameWindow)
        {
            //100 pixlar per meter
            this.texture = texture;
            this.x = (int) x;
            this.y = (int) y;
            start_position = new Vector2(x, y);
            start_velocity = new Vector2(velocity.X, velocity.Y);
            acceleration = new Vector2(0, -9.8f);
            scale = 2 * radie / (texture.Width / Constants.scale.X);
            origin = new Vector2(texture.Width / 2.0f, texture.Height / 2.0f);
            window = gameWindow;
        }

        public void Update(GameTime gameTime)
        {
            delta_time = (float) gameTime.ElapsedGameTime.TotalSeconds;
            hitBox = new Rectangle((int) (current_position.X * 50) - (int) origin.X, (int) (current_position.Y * 50) - (int) origin.Y,
                texture.Width, texture.Height);

            current_velocity = start_velocity + acceleration * delta_time;
            current_position = start_position + ((start_velocity + current_velocity)) / 2 * delta_time;

            start_position = current_position;
            start_velocity = current_velocity;

            if (hitBox.Right > window.ClientBounds.Width)
            {
                current_position.X = (window.ClientBounds.Width - origin.X) / Constants.scale.X;
                start_position = current_position;
                start_velocity.X = -current_velocity.X * wallElast;
                start_velocity.Y = current_velocity.Y * wallElast;
                //totalTime = 0;
            }
            if (hitBox.Left < 0)
            {
                current_position.X = (0 + origin.X) / Constants.scale.X;
                start_position = current_position;
                start_velocity.X = -current_velocity.X * wallElast;
                start_velocity.Y = current_velocity.Y * wallElast;
                //totalTime = 0;
            }

            if (hitBox.Bottom > window.ClientBounds.Height)
            {
                current_position.Y = (window.ClientBounds.Height - origin.Y) / Math.Abs(Constants.scale.Y);
                start_position = current_position;
                start_velocity.Y = -current_velocity.Y * floorElast;
                start_velocity.X = current_velocity.X * floorElast;
                //totalTime = 0;
            }

            if (hitBox.Top < 0)
            {
                current_position.Y = (0 + origin.Y) / Math.Abs(Constants.scale.Y);
                start_position = current_position;
                start_velocity.Y = -current_velocity.Y * floorElast;
                start_velocity.X = current_velocity.X * floorElast;
                //totalTime = 0;
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, PosToPixel(current_position), null, Color.White, 0f, origin, 1f,
                SpriteEffects.None, 0);
        }

        static public Vector2 PosToPixel(Vector2 vec)
        {
            return Constants.PosToPixel(vec);
        }
    }
}