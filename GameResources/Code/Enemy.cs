using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spline;

namespace TowerDefenceINF.GameResources.Code
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

        public byte Health
        {
            set
            {
                if (0 < health)
                {
                    health -= value;
                }
                else if (status != 1 && status != 2)
                {
                    status = 1;
                }
            }
        }

        public Vector2 Position
        {
            get
            {
                return simplePath.GetPos(texturePosition);
            }
        }

        public byte Status
        {
            get
            {
                return status;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (status == 0)
            {
                texturePosition++;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (status != 2)
            {
                spriteBatch.Draw(tex, simplePath.GetPos(texturePosition), sourceRectangle,
                Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
            }
        }
    }
}