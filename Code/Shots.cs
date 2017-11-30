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

        protected Vector2 pos, dirr, towerPos;

        protected Rectangle boundingBox;

        public Shots(Texture2D texture, Vector2 pos)
        {
            this.texture = texture;
            this.pos = pos;
            boundingBox = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);

        }

        public virtual void Update(GameTime gameTime, Enemy e)
        {            
            dirr = e.GetPos() - towerPos;
            pos += dirr * 2;

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {



        }

    }
}
