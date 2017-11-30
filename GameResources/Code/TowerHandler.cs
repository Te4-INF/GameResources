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

            //foreach (Enemy e in enemyList)
            //{

            //    e.Update(gameTime);

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

           //foreach(Enemy e in enemyList)
           // {

           //     e.Draw(sb);

           // }

        }

        public virtual bool PixelPerfectTowerCollision(RenderTarget2D renderTarget, Tower mouseTower)
        {

            
                Console.WriteLine("PRE-COLLISION");


                Color[] dataA = new Color[mouseTower.GetBoundingBox().Width * mouseTower.GetBoundingBox().Height];
                mouseTower.GetTexture().GetData<Color>(0, mouseTower.GetBoundingBox(), dataA, 0, mouseTower.GetBoundingBox().Width * mouseTower.GetBoundingBox().Height);

                Color[] dataB = new Color[graphics.PreferredBackBufferWidth * graphics.PreferredBackBufferHeight];
                renderTarget.GetData<Color>(0, mouseTower.GetBoundingBox(), dataB, 0, mouseTower.GetBoundingBox().Width * mouseTower.GetBoundingBox().Height);

                //int top = Math.Max(mouseTower.GetBoundingBox().Top, other.GetBoundingBox().Top);
                //int bottom = Math.Min(mouseTower.GetBoundingBox().Bottom, other.GetBoundingBox().Bottom);
                //int left = Math.Max(mouseTower.GetBoundingBox().Left, other.GetBoundingBox().Left);
                //int right = Math.Min(mouseTower.GetBoundingBox().Right, other.GetBoundingBox().Right);

                for (int i = 0; i < dataA.Length; i++)
                {

                    for (int j = 0; j < dataB.Length; j++)
                    {

                        Color colorA = dataA[i];

                        Color colorB = dataB[j];

                        if (colorA.A != 0 && colorB.A != 0)
                        {

                            Console.WriteLine("COLLISION" + i);
                            return true;

                        }
                    }
                }

                return false;

        }

    }
}
