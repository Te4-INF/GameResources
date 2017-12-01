using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceINF.GameResources.Code
{
    class IceTower : Tower
    {
        public IceTower(Texture2D tex, Vector2 pos) : base(tex, pos)
        {

            price = 200;

        }

        public override void Update(GameTime gameTime, List<Enemy> enemyList, ProjectileHandler projectileHandler)
        {

            foreach (Enemy e in enemyList)
            {

                if (Vector2.Distance(pos, e.GetPos()) < radius)
                {


                    projectileHandler.IceShoot(pos, e);

                }

                else
                    Console.WriteLine("ENEMY NOT DETECTED");

            }

        }

        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(tex, pos, Color.CornflowerBlue);

        }
    }
}
