using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenceINF;

namespace TowerDefenceINF
{
    class BackBufferHandler
    {
        RenderTarget2D backgroundLayer;

        List<Tower> towerList;

        public BackBufferHandler(List<Tower> towerList, GraphicsDevice graphicsDevice)
        {

            this.towerList = towerList;
            backgroundLayer = new RenderTarget2D(graphicsDevice, 1600, 900);

        }

        private void DrawRenderTargetLayer(GraphicsDevice device)

        {

            // skapa ny spriteBatch

            SpriteBatch sb = new SpriteBatch(device);

            // sätt till annat renderTarget device.SetRenderTarget(backgroundLayer); device.Clear(Color.Transparent); sb.Begin();

            foreach (Tower t in towerList)

            {

                t.Draw(sb);

            }
            sb.End();

            // Sätt tillbaka graphicsDevice till ordinarie fönster device.SetRenderTarget(null);

        }

    }
}
