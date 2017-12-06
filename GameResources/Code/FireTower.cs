using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceINF.GameResources.Code
{
    class FireTower : Tower
    {

        float shotTimer;

        public FireTower(Texture2D tex, Vector2 pos) : base(tex, pos)
        {

            price = 150;
            

        }

        public override void Update(GameTime gameTime, List<Enemy> enemyList, ProjectileHandler projectileHandler)
        {
            shotTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Enemy e in enemyList)
            {

                if (Vector2.Distance(pos, e.GetPos()) < radius && shotTimer <= 0)
                {
                    shotTimer = 2f;
                    projectileHandler.FireShoot(pos, e);

                }

                else
                    Console.WriteLine("ENEMY NOT DETECTED");

            }

        }

        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(tex, pos, Color.IndianRed);

        }
    }
}
