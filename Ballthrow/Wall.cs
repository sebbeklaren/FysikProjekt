using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ballthrow
{
    class Wall
    {
        public Vector2 position;
        public Rectangle wall_rect;
        Texture2D texture;
        public float e;
        public Vector2 norm;

        public Wall(Texture2D texture, Vector2 position, Rectangle wall_rect,Vector2 norm, float elasticity)
        {
            this.position = position;
            this.wall_rect = wall_rect;
            this.texture = texture;
            this.e = elasticity;
            this.norm = norm;    
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, wall_rect, Color.Black);
        }
    }
}
