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

        }

        public abstract void Draw(SpriteBatch sb);

    }
}
