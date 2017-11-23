using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF
{
    class StoneShot: Shots
    {

        public StoneShot(Texture2D texture, Vector2 pos) : base(texture, pos)
        {

        }

        public override void Update()
        {


        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, pos, Color.Gray);

        }
    }
}
