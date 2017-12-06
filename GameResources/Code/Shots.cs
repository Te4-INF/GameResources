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

        protected Vector2 pos, dirr;

        protected Rectangle boundingBox;

        protected Enemy enemy;

        public Shots(Texture2D texture, Vector2 pos, Enemy enemy)
        {
            this.texture = texture;
            this.pos = pos;
            boundingBox = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
            this.enemy = enemy;
        }

        public virtual void Update(GameTime gameTime)
        {
            dirr = enemy.GetPos() - pos;
            dirr.Normalize();
            pos += dirr * 4f;

        }

        public Vector2 ShotsPos
        {
            get
            {
                return pos;
            }

        }

        public virtual void Draw(SpriteBatch sb)
        {

            sb.Draw(texture, pos, Color.White);
           
        }

    }
}
