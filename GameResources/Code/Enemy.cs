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

        protected int radius;

        protected Vector2  center;

        public Enemy(Texture2D tex, Vector2 pos)
            : base(tex, pos)
        {
            direction = new Vector2(1, 0);
            speed = new Vector2(5, 0);

            color = Color.White;

            center = new Vector2(pos.X + 7, pos.Y + 5.5f);
        }

        public int Radius
        {
            get
            {
                return radius;
            }
        }

        public Vector2 Center
        {
            get
            {
                return center;
            }
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
            center = new Vector2(pos.X + 7, pos.Y + 5.5f);

            frameTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (status == 0)
            {
                if (0 < frameTimer)
                {
                    if (color == Color.Blue)        //om fienden är blå så är hastigheten lägre
                    {
                        Speed = 1;
                    }
                    else if (color == Color.Red)    //är den röd så tar den -5 per frame
                    {
                        health -= 5;
                    }

                }
                else                            //om den har vanlig färg så är hastigheten 2
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