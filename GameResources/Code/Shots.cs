using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceINF
{
    class Shots
    {
        protected Texture2D texture;
        protected Vector2 pos;
        protected Rectangle boundingBox;


        public Shots(Texture2D texture, Vector2 pos)
        {
            this.texture = texture;
            this.pos = pos;
            this.boundingBox = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);


        }

        public virtual void Update()
        {



        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {


        }

    }
}
