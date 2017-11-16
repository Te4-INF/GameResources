using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private Tower mouseTower;

        public TowerHandler(ContentManager content)
        {

            towerList = new List<Tower>();
            towerTextures = new Texture2D[3];
            towerChoice = 0;
            towerTextures[0] = content.Load<Texture2D>("tower");
            


        }

        public void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {

                towerChoice = 1;

            }

            else if(Keyboard.GetState().IsKeyDown(Keys.D2))
            {

                towerChoice = 2;

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.D3))
            {

                towerChoice = 3;

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.D4))
            {

                towerChoice = 4;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {

                towerList.RemoveRange(0, towerList.Count);

            }

            if (towerChoice == 1)
            {

                mouseTower = new ArcherTower(towerTextures[0], new Vector2(Mouse.GetState().X, Mouse.GetState().Y));

            }

            else if(towerChoice == 2)
            {

                mouseTower = new FireTower(towerTextures[0], new Vector2(Mouse.GetState().X, Mouse.GetState().Y));

            }

            else if(towerChoice == 3)
            {

                mouseTower = new IceTower(towerTextures[0], new Vector2(Mouse.GetState().X, Mouse.GetState().Y));

            }


            

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {

                towerList.Add(mouseTower);

            }

            //foreach (Tower t in towerList)
            //{

            //    t.Update(gameTime);

            //}

        }

        public void Draw(SpriteBatch sb)
        {

            if(towerChoice == 1 || towerChoice == 2 || towerChoice == 3)
            {

                mouseTower.Draw(sb);

            }

           foreach(Tower t in towerList)
            {

                t.Draw(sb);

            }

        }

    }
}
