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

        protected Enemy enemy;

        public Shots(Texture2D texture, Vector2 pos, Enemy enemy)
        {
            this.texture = texture;
            this.pos = pos;
            boundingBox = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);

        }

        public virtual void Update(GameTime gameTime)
        {
            dirr = -towerPos;
            dirr.Normalize();
            dirr = enemy.GetPos() - towerPos;
            pos += dirr * 2;

        }

        public Vector2 ShotsPos
        {
            get
            {
                return pos;
            }

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, pos, Color.White);
           
        }

    }
}
