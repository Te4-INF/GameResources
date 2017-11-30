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

            price = 100;

        }

        public override void Update(GameTime gameTime, List<Enemy> enemyList)
        {

            foreach (Enemy e in enemyList)
            {

                if (Vector2.Distance(pos, e.Position) < radius)
                {

                    Console.WriteLine("ENEMY DETECTED");

                }

                else
                    Console.WriteLine("ENEMY NOT DETECTED");

            }

        }

        public override void Draw(SpriteBatch sb)
        {

            base.Draw(sb);

        }
    }
}