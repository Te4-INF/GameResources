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
        protected int map;
        private bool mapIsLoaded;
        private int totalNumberMaps;
        public MapHandler(GraphicsDevice graphics)
        {
            totalNumberMaps = 1;
            map = 1;
            LoadMap(graphics);
        }
        public void Update(GameTime gameTime)
        {
           
        }
        public void LoadMap(GraphicsDevice graphics)
        {
            mapIsLoaded = false;
            currentMapSpline = new Spline(graphics);
            if (map > 0 && map <= totalNumberMaps)
            {
                ReadMap(@"Map" + map.ToString() + ".txt");
                mapIsLoaded = true;
            }
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
            if (mapIsLoaded)
                currentMapSpline.Draw(spriteBatch);
        }
    }
}
