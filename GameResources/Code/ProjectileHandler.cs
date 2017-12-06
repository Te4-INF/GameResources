using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TowerDefenceINF.GameResources.Code
{
    class ProjectileHandler
    {
        Texture2D fireShotTex;
        Texture2D iceShotTex;
        Texture2D stoneShotTex;

        

        List<Shots> shotsList = new List<Shots>();

        public ProjectileHandler(ContentManager content)
        {
            fireShotTex = content.Load<Texture2D>("FireShot");
            iceShotTex = content.Load<Texture2D>("IceShot");
            stoneShotTex = content.Load<Texture2D>("StoneShot");

        }

        public void ArrowShoot(Vector2 towerPos, Enemy e)
        {

            shotsList.Add(new StoneShot(stoneShotTex, towerPos, e));

        }

        public void FireShoot(Vector2 towerPos, Enemy e)
        {

            shotsList.Add(new FireShot(fireShotTex, towerPos, e));

        }

        public void IceShoot(Vector2 towerPos, Enemy e)
        {

            shotsList.Add(new IceShot(iceShotTex, towerPos, e));

        }

        public void Update(GameTime gameTime)
        {

            foreach (Shots s in shotsList)
            {

                s.Update(gameTime);

            }

        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Shots s in shotsList)
            {
                s.Draw(sb);
            }
        }

        public List<Shots> ShotsList
        {
            get
            {
                return shotsList;
            }
        }

    }
}
