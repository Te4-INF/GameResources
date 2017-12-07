using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spline;
using System;

namespace TowerDefenceINF.GameResources.Code
{
    class EnemyHandler
    {
        byte i;

        float spawnTimer, spawnInterval = 900, spawnAmount,
            enemies, enemyKills;

        Texture2D spriteSheet;

        Vector2 position;

        public List<Enemy> enemyList;
        Enemy tempEnemy;

        List<Shots> shotsList;

        SimplePath simplePath;

        Player player;

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
                if (enemies < spawnAmount)      //lägger till en fiende
                {
                    tempEnemy = new BlueSlime(spriteSheet, position, simplePath);
                    enemyList.Add(tempEnemy);

                    enemies++;
                }

                if (enemyKills == 0)        // lägger till en level när fienderna är dödade
                {
                    enemies -= spawnAmount;
                    player.Level = 1;
                }

                if (enemies == 0)           //lägger på 5 extra varje runda
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

                    float dist = Vector2.Distance(enemy.Center, shot.GetCenter());
                    float radius = shot.GetRadius() + enemy.Radius;
                    if (dist < radius)
                    {
                        Console.WriteLine("TEST");

                        if (shot is FireShot)               //ändrar färgen på fienden till röd ifall den blir träffad av rött skott, skadar över tid
                        {
                            enemy.Color = Color.Red;
                            enemy.FrameTimer = 3000;
                        }
                        if (shot is IceShot)                //ändrar färgen på fienden till blå ifall den blir träffad av blått skott, blå skott skadar 15
                        {
                            enemy.Health = 15;
                            enemy.Color = Color.Blue;
                            enemy.FrameTimer = 3000;
                        }
                        if (shot is StoneShot)              //grå skott skadar 20
                        {
                            enemy.Health = 20;
                        }
                        shotsList.Remove(shot);
                        break;
                    }
                }

                enemy.Update(gameTime);

                if (enemy.Status == 2)          //tar bort fienden ifall fienden är död och ger även 10 pengar
                {
                    enemyList.Remove(enemy);
                    enemyKills--;
                    player.Balance = 10;
                    break;
                }

                if (1600 < enemy.Position.X)        //om fienden når slutet av banan så förlorar man 1 liv
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