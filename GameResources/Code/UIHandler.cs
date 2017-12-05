using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF.GameResources.Code
{
  class UIHandler
    {
        SpriteFont UIFont;

        Player player;

        public UIHandler(ContentManager content)
        {
            UIFont = content.Load<SpriteFont>("UIFont");

            player = new Player(UIFont);
        }

        public Player Player
        {
            get
            {
                return player;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}
