using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF.GameResources.Code
{
    class ArcherTower : Tower
    {

        float shotTimer;

        public ArcherTower(Texture2D tex, Vector2 pos) :base(tex, pos)
        {

            price = 100;

        }

        public override void Update(GameTime gameTime, List<Enemy> enemyList, ProjectileHandler projectileHandler)
        {

            shotTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Enemy e in enemyList)
            {

                if (Vector2.Distance(pos, e.GetPos()) < radius && shotTimer <= 0)
                {
                    shotTimer = 2f;
                    projectileHandler.ArrowShoot(pos, e);

                }

                else
                    Console.WriteLine("ENEMY NOT DETECTED");

            };

        }

        public override void Draw(SpriteBatch sb)
        {

            base.Draw(sb);

        }
    }
}