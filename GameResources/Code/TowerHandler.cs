using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF.GameResources.Code
{
    class TowerHandler: MasterHandler
    {

        private List<Tower> towerList;
        private int towerChoice;
        private Texture2D[] towerTextures;
        private Tower mouseTower;
        private GraphicsDeviceManager graphics;

        Enemy testEnemy;
        List<Enemy> enemyList;

        public TowerHandler(ContentManager content, GraphicsDeviceManager graphics)
        {

            towerList = new List<Tower>();
            towerTextures = new Texture2D[3];
            towerChoice = 4;
            towerTextures[0] = content.Load<Texture2D>("tower");
            this.graphics = graphics;

            enemyList = new List<Enemy>();
            //testEnemy = new Enemy(towerTextures[0], new Vector2(100, 100));
            //enemyList.Add(testEnemy);

        }

        public void Update(GameTime gameTime, ref bool test, RenderTarget2D renderTarget)
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

            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {

                towerList.RemoveRange(0, towerList.Count);

            }

            if (towerChoice == 1)
            {

                mouseTower = new ArcherTower(towerTextures[0], new Vector2(Mouse.GetState().X - (towerTextures[0].Width / 2), Mouse.GetState().Y - (towerTextures[0].Height / 2)));

                test = false;

            }

            else if(towerChoice == 2)
            {

                mouseTower = new FireTower(towerTextures[0], new Vector2(Mouse.GetState().X - (towerTextures[0].Width / 2), Mouse.GetState().Y - (towerTextures[0].Height / 2)));
                
                test = false;

            }

            else if(towerChoice == 3)
            {

                mouseTower = new IceTower(towerTextures[0], new Vector2(Mouse.GetState().X - (towerTextures[0].Width / 2), Mouse.GetState().Y - (towerTextures[0].Height / 2)));

                test = false;

            }

            else if(towerChoice == 4)
            {

                test = true;

            }

            

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && towerChoice != 4)
            {

                bool testBool = PixelPerfectTowerCollision(renderTarget, mouseTower);

                if (!testBool)
                {

                    towerList.Add(mouseTower);
                    towerChoice = 4;

                }
                

            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
                towerChoice = 4;

            foreach (Tower t in towerList)
            {

                t.Update(gameTime, enemyList);

            }

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

           //foreach(Enemy e in enemyList)
           // {

           //     e.Draw(sb);

           // }

        }

        public virtual bool PixelPerfectTowerCollision(RenderTarget2D renderTarget, Tower mouseTower)
        {

                Color[] dataA = new Color[mouseTower.GetBoundingBox().Width * mouseTower.GetBoundingBox().Height];
                mouseTower.GetTexture().GetData<Color>(dataA);

                Color[] dataB = new Color[mouseTower.GetBoundingBox().Width * mouseTower.GetBoundingBox().Height];
                renderTarget.GetData<Color>(0, mouseTower.GetBoundingBox(), dataB, 0, mouseTower.GetBoundingBox().Width * mouseTower.GetBoundingBox().Height);
            

                for (int i = 0; i < dataA.Length; i++)
                {

                    Color colorA = dataA[i];
                    Color colorB = dataB[i];

                    if (colorA.A >= 200 && colorB.A >= 200)
                    {

                        Console.WriteLine("COLLISION" + i);
                        return true;

                    }
                
                }

            return false;

        }

        public List<Tower> GetTowerList()
        {

            return towerList;

        }

        public bool MouseInWindow()
        {

            bool tempBool = true;

            if(mouseTower.GetPos().X < 0 && mouseTower.GetPos().X > (graphics.PreferredBackBufferWidth - mouseTower.GetTexture().Width))
            {



            }

            return tempBool;

        }

    }
}
