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
using Microsoft.Xna.Framework.Content;

namespace TowerDefenceINF.GameResources.Code
{
    class MapHandler
    {
        Spline currentMapSpline;
        protected int map;
        private bool mapIsLoaded;
        private int totalNumberMaps;
        private Texture2D splineTextures;
        public MapHandler(GraphicsDevice graphics, ContentManager content)
        {
            totalNumberMaps = 1;
            map = 1;
            LoadMap(graphics);
            loadMap(content);
        }

        public void loadMap(ContentManager content)
        {
            splineTextures = content.Load<Texture2D>("meh");
        }
        public void LoadMap(GraphicsDevice graphics)
        {
            mapIsLoaded = false;
            currentMapSpline = new Spline(graphics);
            if (map > 0 && map <= totalNumberMaps) // välger vilken bana om man har fler
            {
                ReadMap(@"..\..\TowerDefence\GameResources\Maps\Map" + map.ToString() + ".txt");
                mapIsLoaded = true;
            }
             
        }
        private void ReadMap(string mapName)// läser in banan och delar in i filen x och y kordinater
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
            {
                spriteBatch.Draw(splineTextures, new Vector2(0, 0), Color.White);

            }
        }
        public SimplePath GetSimplePath()
        {

            return currentMapSpline.GetSimplePath();

        }
    }
}
