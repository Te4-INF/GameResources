using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TowerDefenceINF.GameResources.Code
{
    abstract class Enemy : Animated
    {
        protected byte health, status;

        protected Rectangle destinationRectangle, sourceRectangle;

        public Enemy(Texture2D tex, Vector2 pos)
            : base(tex, pos)
        {
            direction = new Vector2(1, 0);
            speed = new Vector2(5, 0);
        }

        public Vector2 Position
        {
            get
            {
                return pos;
            }
        }

        public override void Update(GameTime gameTime)
        {
            destinationRectangle.X += (int)(direction.X * speed.X);
            destinationRectangle.Y += (int)(direction.Y * speed.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, destinationRectangle, sourceRectangle,
                Color.White);
        }

    }
}