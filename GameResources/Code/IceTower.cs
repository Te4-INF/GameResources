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
        float shotTimer;

        public IceTower(Texture2D tex, Vector2 pos) : base(tex, pos)
        {

            price = 200;

        }

        public override void Update(GameTime gameTime, List<Enemy> enemyList, ProjectileHandler projectileHandler)
        {
            shotTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds; 

            foreach (Enemy e in enemyList)
            {
                float dist = Vector2.Distance(pos, e.GetPos());
                if (dist < radius && shotTimer <= 0)
                {
                    shotTimer = 2f;

                    projectileHandler.IceShoot(pos, e);

                }

                else if(dist > radius && shotTimer <= 0)
                {


                    

                }

                   //Console.WriteLine("ENEMY NOT DETECTED");


            }

        }

        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(tex, pos, Color.CornflowerBlue);

        }
    }
}
