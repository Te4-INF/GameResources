using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spline;
using TowerDefenceINF.GameResources.Code;
using System.IO;
using Microsoft.Xna.Framework;

namespace TowerDefenceINF.GameResources.Code
{
    class MapHandler
    {
        Spline currentMapSpline;
        public MapHandler(GraphicsDevice graphics)
        {
            currentMapSpline = new Spline(graphics);
            ReadMap(@"Bana1.txt");
        }
        private void ReadMap(string mapName)
        {
            StreamReader sr = new StreamReader(mapName);
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] temp = line.Split(',');
                int x = int.Parse(temp[0]);
                int y = int.Parse(temp[1]);
                currentMapSpline.AddPoint(x, y);
            }
            sr.Close();
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            currentMapSpline.Draw(spriteBatch);
        }
    }
}
