using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spline;

namespace TowerDefenceINF.GameResources.Code
{
    abstract class Enemy : Animated
    {
        protected int health, status;

        protected float texturePosition;

        protected SimplePath simplePath;

        protected Rectangle destinationRectangle, sourceRectangle;

        protected Color color;

        public Enemy(Texture2D tex, Vector2 pos)
            : base(tex, pos)
        {
            direction = new Vector2(1, 0);
            speed = new Vector2(5, 0);

            color = Color.White;
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
                return pos;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }
        }

        public float Speed
        {
            set
            {
                texturePosition -= value;
            }
        }

        public Color Color
        {
            set
            {
                color = value;
            }
        }

        public float FrameTimer
        {
            set
            {
                frameTimer = value;
            }
        }

        public override void Update(GameTime gameTime)
        {
            frameTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (status == 0)
            {
                if (0 < frameTimer)
                {
                    if (color == Color.Blue)
                    {
                        Speed = 1;
                    }
                    else if (color == Color.Red)
                    {
                        health -= 5;
                    }
                    //else
                    //{
                    //    color = Color.White;
                    //    Speed = 2;
                    //}
                }
                else
                {
                    color = Color.White;
                    Speed = 2;
                }
                pos = simplePath.GetPos(texturePosition);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (status != 2)
            {
                spriteBatch.Draw(tex, pos, sourceRectangle,
                color, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
            }
        }
    }
}