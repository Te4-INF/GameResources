using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenceINF.GameResources.Code;
using Spline;
using Microsoft.Xna.Framework.Graphics;
namespace TowerDefenceINF.GameResources.Code
{
    class Spline
    {
        protected SimplePath simplePath;
        
        public Spline(GraphicsDevice graphicsDevice)
        {
            simplePath = new SimplePath(graphicsDevice);
            simplePath.Clean();
        }

        public void AddPoint(int x, int y) // lägger till punkterna i splinen 
        {
            simplePath.AddPoint(new Vector2(x, y));
        }

        public void Draw(SpriteBatch spriteBatch) //Ritar utt splinen
        {
            simplePath.Draw(spriteBatch);
        }

        public SimplePath GetSimplePath()
        {

            return simplePath;

        }
    }
}
