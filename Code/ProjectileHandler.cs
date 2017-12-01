﻿using System;
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

        Shots shotsUpdate;

        Shots[] shots = new Shots[3];

        List<Shots> ShotsList = new List<Shots>();

        public ProjectileHandler(ContentManager content)
        {
            fireShotTex = content.Load<Texture2D>("FireShot");
            iceShotTex = content.Load<Texture2D>("IceShot");
            StoneShotTex = content.Load<Texture2D>("StoneShot");

            shots[0] = new FireShot(fireShotTex, new Vector2(100, 100)/*ska vara tornets position här iställett för den befintliga positionen*/);

            shots[1] = new IceShot(iceShotTex, new Vector2(100, 100)/*ska vara tornets position här iställett för den befintliga positionen*/);

            shots[2] = new StoneShot(StoneShotTex, new Vector2(100, 100)/*ska vara tornets position här iställett för den befintliga positionen*/);

        }



        public void Update(GameTime gameTime, ref Enemy e)
        {

            foreach(Shots s in ShotsList)
            {

                s.Update(gameTime, e);

            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //if (/*om tornet är ett eldtorn och tornets område kommer emot ett monster så ska skottet ritas ut*/)
            //{
            //    shots[0].Draw(spriteBatch);
            //}

            //if (/*om tornet är ett istorn och tornets område kommer emot ett monster så ska skottet ritas ut*/)
            //{
            //    shots[1].Draw(spriteBatch);
            //}

            //if (/*om tornet är ett stentorn och tornets område kommer emot ett monster så ska skottet ritas ut*/)
            //{
            //    shots[2].Draw(spriteBatch);
            //}
        }

        public void ArrowShoot(Vector2 towerPos, ref Enemy e)
        {

            ShotsList.Add(new StoneShot(StoneShotTex, towerPos));

        }

        public void FireShoot(Vector2 towerPos)
        {

            ShotsList.Add(new FireShot(fireShotTex, towerPos));

        }

        public void IceShoot(Vector2 towerPos)
        {

            ShotsList.Add(new IceShot(iceShotTex, towerPos));

        }

    }
}
