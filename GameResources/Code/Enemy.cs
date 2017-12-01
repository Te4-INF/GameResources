using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TowerDefenceINF.GameResources.Code
{
    abstract class Enemy : Animated
    {
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
            pos += direction * speed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.White);
        }

    }
}