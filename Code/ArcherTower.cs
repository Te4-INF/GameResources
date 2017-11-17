using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF
{
    class ArcherTower : Tower
    {

        public ArcherTower(Texture2D tex, Vector2 pos) :base(tex, pos)
        {

            

        }

        public override void Update(GameTime gameTime, List<Enemy> enemyList)
        {
                
            foreach(Enemy e in enemyList)
            {

                //om inom radie, skjut(väntar på kod från Carlo)

            }

        }
    }
}