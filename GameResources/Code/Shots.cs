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

        protected Vector2 pos, dirr, center, targetPos;

        protected int radius;

        protected Rectangle boundingBox;

        public Enemy enemy;

        public Shots(Texture2D texture, Vector2 pos, Enemy enemy)
        {
            this.texture = texture;
            this.pos = pos;
            radius = texture.Width / 2;
            center = new Vector2(pos.X + (texture.Width / 2), pos.Y + (texture.Height / 2));
            boundingBox = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
            this.enemy = enemy;
        }

        public virtual void Update(GameTime gameTime)
        {
            center = new Vector2(pos.X + (texture.Width / 2), pos.Y + (texture.Height / 2));
            targetPos = new Vector2(enemy.Center.X - (texture.Width / 2), enemy.Center.Y - (texture.Height / 2));



            if (enemy.Status != 2)
            {
                dirr = targetPos - pos;        //vilken riktning
                dirr.Normalize();                   //
                pos += dirr * 4f;                   // hastighet på skotten
            } 
            else
            {
                enemy = null;
            }

        }

        public Vector2 ShotsPos
        {
            get
            {
                return pos;
            }

        }

        public Vector2 GetCenter()
        {
            return center;
        }

        public int GetRadius()
        {

            return radius;

        }

        public virtual void Draw(SpriteBatch sb)
        {
            if(enemy!= null && enemy.Status != 2)
                sb.Draw(texture, pos, Color.White);

            
        }
        
    }
}
