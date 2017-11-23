using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceINF
{
    class FireShot : Shots
    {

        public FireShot(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
            

        }

        public override void Update()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, pos, Color.Red);

        }

    }
}
