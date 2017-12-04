using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spline;

namespace TowerDefenceINF.GameResources.Code
{
    class EnemyHandler
    {
        byte i;

        float spawnTimer, spawnInterval = 900, spawnAmount,
            enemies, enemyKills;

        Texture2D spriteSheet;

        Vector2 position;

        List<Enemy> enemyList;
        Enemy tempEnemy;

        List<Shots> shotsList;

        SimplePath simplePath;

        int dummyHealth, dummyBalance, dummyWave;

        float radius = 8;

        public EnemyHandler(ContentManager content, SimplePath simplePath,
            List<Shots> shotsList)
        {
            spriteSheet = content.Load<Texture2D>("slimeSheet");

            position = simplePath.GetPos(0);

            enemyList = new List<Enemy>();

            shotsList = new List<Shots>();

            this.simplePath = simplePath;

            spawnAmount = 5;
            enemyKills = spawnAmount;
        }

        public void Update(GameTime gameTime)
        {
            spawnTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (spawnTimer <= 0)
            {
                if (enemies < spawnAmount)
                {
                    tempEnemy = new BlueSlime(spriteSheet, position, simplePath);
                    enemyList.Add(tempEnemy);

                    enemies++;
                }

                if (enemyKills == 0)
                {
                    enemies -= spawnAmount;
                    dummyWave++;
                }

                if (enemies == 0)
                {
                    spawnAmount += 5;
                    enemyKills = spawnAmount;
                }

                spawnTimer = spawnInterval;
            }

            foreach (Enemy enemy in enemyList)
            {
                foreach (Shots shot in shotsList)
                {
                //    if (shot is FireShot)
                //    {
                //        if ()
                //    }
                //    if (Vector2.Distance(enemy.Position, shot.Position) < (radius + shot.Radius))
                //    {
                //        if (shot is FireShot)
                //        {

                //        }
                //        else if (shot is IceShot)
                //        {

                //        }
                //        else
                //        {

                //        }
                //    }
                }

                enemy.Update(gameTime);

                if (enemy.Status == 2 || 1600 < enemy.Position.X)
                {
                    enemyList.Remove(enemy);
                    enemyKills--;
                    dummyBalance++;
                    break;
                }

                if (1600 < enemy.Position.X)
                {
                    enemyList.Remove(enemy);
                    enemyKills--;
                    dummyHealth--;
                    break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}