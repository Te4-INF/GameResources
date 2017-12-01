using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceINF.GameResources.Code
{
    abstract class Animated : GameObject
    {
        protected byte frame;
        protected float frameTimer, frameInterval;

        protected Vector2 position, direction, speed;

        public Animated(Texture2D tex, Vector2 pos)
            : base(tex, pos)
        {
        }

        public abstract void Update(GameTime gameTime);
    }
}