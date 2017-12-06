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

        List<Shots> shotsList;

        public IceTower(Texture2D tex, Vector2 pos, List<Shots> shotsList) : base(tex, pos)
        {

            price = 200;
            this.shotsList = shotsList;

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

                    foreach(IceShot ice in shotsList)
                    {
                        shotsList.Remove(ice);
                        break;
                    }
                    

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
