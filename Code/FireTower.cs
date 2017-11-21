using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceINF
{
    class FireTower : Tower
    {
        public FireTower(Texture2D tex, Vector2 pos) : base(tex, pos)
        {

            price = 150;

        }

        public override void Update(GameTime gameTime, List<Enemy> enemyList)
        {

            base.Update(gameTime, enemyList);

        }

        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(tex, pos, Color.IndianRed);

        }
    }
}
