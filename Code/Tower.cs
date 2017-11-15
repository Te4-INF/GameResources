using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF
{
    abstract class Tower: GameObject
    {

        public Tower(Texture2D tex, Vector2 pos): base(tex, pos)
        {



        }

        public abstract override void Draw(SpriteBatch sb);
    }
}
