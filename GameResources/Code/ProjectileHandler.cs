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
        Texture2D StoneShotTex;

        Shots shots;

        //Shots[] shots = new Shots[3];

        List<Shots> ShotsList = new List<Shots>();

        public ProjectileHandler(ContentManager content)
        {
            fireShotTex = content.Load<Texture2D>("FireShot");
            iceShotTex = content.Load<Texture2D>("IceShot");
            StoneShotTex = content.Load<Texture2D>("StoneShot");

            //shots[0] = new FireShot(fireShotTex, new Vector2(100, 100)/*ska vara tornets position här iställett för den befintliga positionen*/);

            //shots[1] = new IceShot(iceShotTex, new Vector2(100, 100)/*ska vara tornets position här iställett för den befintliga positionen*/);

            //shots[2] = new StoneShot(StoneShotTex, new Vector2(100, 100)/*ska vara tornets position här iställett för den befintliga positionen*/);

        }



        public void Update(GameTime gameTime)
        {

            foreach(Shots s in ShotsList)
            {

                s.Update(gameTime);

            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            shots.Draw(spriteBatch);
        }

        public void ArrowShoot(Vector2 towerPos, Enemy e)
        {

            ShotsList.Add(new StoneShot(StoneShotTex, towerPos));

        }

        public void FireShoot(Vector2 towerPos, Enemy e)
        {

            ShotsList.Add(new FireShot(fireShotTex, towerPos));

        }

        public void IceShoot(Vector2 towerPos, Enemy e)
        {

            ShotsList.Add(new IceShot(iceShotTex, towerPos));

        }

    }
}
