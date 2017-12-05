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

        Player player;

        float radius = 8;

        public EnemyHandler(ContentManager content, SimplePath simplePath,
            List<Shots> shotsList, Player player)
        {
            spriteSheet = content.Load<Texture2D>("slimeSheet");

            position = simplePath.GetPos(0);

            enemyList = new List<Enemy>();

            this.shotsList = shotsList;

            this.simplePath = simplePath;

            this.player = player;

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
                    player.Level = 1;
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
                    if (Vector2.Distance(enemy.Position, shot.shotsPos) < (radius + 30))
                    {
                        if (shot is FireShot)
                        {
                            enemy.Health = 15;
                            //15 DoT;
                            enemy.Color = Color.Red;
                        }
                        else if (shot is IceShot)
                        {
                            enemy.Health = 15;
                            enemy.Speed = 1;
                            enemy.Color = Color.Blue;
                        }
                        else
                        {
                            enemy.Health = 20;
                        }
                    }
                }

                enemy.Update(gameTime);

                if (enemy.Status == 2)
                {
                    enemyList.Remove(enemy);
                    enemyKills--;
                    player.Balance = 5;
                    break;
                }

                if (1600 < enemy.Position.X)
                {
                    enemyList.Remove(enemy);
                    enemyKills--;
                    player.Health = 1;
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