using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenceINF;

namespace TowerDefenceINF.GameResources.Code
{
    class BackBufferHandler
    {
        RenderTarget2D backgroundLayer;

        Texture2D mapTexture;

        public BackBufferHandler(GraphicsDevice graphicsDevice, ContentManager content)
        {
            mapTexture = content.Load<Texture2D>("meh");
            backgroundLayer = new RenderTarget2D(graphicsDevice, 1600, 900);
        }

        public void Update(GraphicsDevice device, List<Tower> towerList)
        {
            SpriteBatch sb = new SpriteBatch(device);
            
            // sätt till annat renderTarget

            device.SetRenderTarget(backgroundLayer);
            device.Clear(Color.Transparent);
            sb.Begin();



            foreach (Tower t in towerList)
            {
                t.Draw(sb);
                
            }

            sb.Draw(mapTexture, new Vector2(0, 0), Color.White);

            sb.End();

            // Sätt tillbaka graphicsDevice till ordinarie fönster 
            device.SetRenderTarget(null);
        }

        public RenderTarget2D GetBackgroundLayer()
        {
            return backgroundLayer;
        }
    }
}
