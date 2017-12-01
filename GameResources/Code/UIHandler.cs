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
  public class UIHandler
    {
        SpriteFont UIfont;

        public void loadFont(ContentManager content)
        {
            UIfont = content.Load<SpriteFont>("UI_font");
        }

        public void Drawstring(SpriteBatch sb, int value, Vector2 stringPos) //e.g value is life (10) and stringPos would be (100,100)
        {
            sb.DrawString(UIfont, value.ToString(), stringPos, Color.White);
        }
    }
}
