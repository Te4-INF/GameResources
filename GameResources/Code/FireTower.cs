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

        List<Shots> shotsList;

        public FireTower(Texture2D tex, Vector2 pos, List<Shots> shotsList) : base(tex, pos)
        {
            radius = 200;
            price = 150;
            this.shotsList = shotsList;

        }

        public override void Update(GameTime gameTime, List<Enemy> enemyList, ProjectileHandler projectileHandler)
        {
            shotTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Enemy e in enemyList)
            {

                float dist = Vector2.Distance(pos, e.GetPos());

                if (dist < radius && shotTimer <= 0) //om den är innanför radien så ska ett skott skutas                                                 fel!!!!!!!!!!!!!!!!!!!!!
                {
                    shotTimer = 2f;
                    projectileHandler.FireShoot(pos, e);

                }
            }

        }

        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(tex, pos, Color.IndianRed);

        }
    }
}
