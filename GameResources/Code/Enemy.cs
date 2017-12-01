using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spline;

namespace TowerDefenceINF
{
    abstract class Enemy : Animated
    {
        protected byte health, status;

        protected float texturePosition;

        protected SimplePath simplePath;

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
            texturePosition++;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, simplePath.GetPos(texturePosition), sourceRectangle,
                Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
        }

    }
}