using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF
{
    abstract class Tower: GameObject
    {
        
        protected int price, radius;

        public Tower(Texture2D tex, Vector2 pos): base(tex, pos)
        {

            radius = 420;

        }

        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(tex, pos, Color.White);

        }

        public virtual void Update(GameTime gameTime, List<Enemy> enemyList)
        {

            

        }

        public virtual bool IsColliding(Rectangle other)
        {

            return boundingBox.Intersects(other);

        }


        
        
    }
}
