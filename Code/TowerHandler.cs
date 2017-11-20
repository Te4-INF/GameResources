using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenceINF.GameResources.Code;

namespace TowerDefenceINF
{
    class TowerHandler: MasterHandler
    {

        private List<Tower> towerList;
        private int towerChoice;
        private Texture2D[] towerTextures;

        public TowerHandler(ContentManager content)
        {

            towerList = new List<Tower>();
            towerTextures = new Texture2D[3];


        }

        public void Update(GameTime gameTime)
        {



        }

    }
}
