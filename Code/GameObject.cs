using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF
{
    abstract class GameObject
    {

        protected Vector2 pos;
        protected Texture2D tex;
        protected Rectangle boundingBox;

        public GameObject(Texture2D tex, Vector2 pos)
        {

            this.pos = pos;
            this.tex = tex;
            boundingBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);

        }

        public abstract void Draw(SpriteBatch sb);

        public virtual Rectangle GetBoundingBox()
        {

            return boundingBox;

        }

        public virtual Texture2D GetTexture()
        {

            return tex;

        }

        public virtual Vector2 GetPos()
        {

            return pos;

        }

    }
}
