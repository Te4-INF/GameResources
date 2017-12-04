using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceINF.GameResources.Code
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

        public virtual void Update(GameTime gameTime)
        {
            dirr = -towerPos;
            dirr.Normalize();
            //dirr = e.GetPos() - towerPos;
            pos += dirr * 2;

        }

        public Vector2 shotsPos
        {
            get
            {
                return pos;
            }

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

          //if()
          //  {
          //      spriteBatch.Draw(texture, pos, Color.Red);
          //  }

          //if()
          //  {
          //      spriteBatch.Draw(texture, pos, Color.Blue);
          //  }

          //if()
          //  {
          //      spriteBatch.Draw(texture, pos, Color.Gray);
          //  }
           
        }

    }
}
