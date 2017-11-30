using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spline;

namespace TowerDefenceINF
{
    class EnemyHandler
    {
        byte i;

        float spawnTimer, spawnInterval = 900;

        Texture2D spriteSheet;

        Vector2 position;

        List<Enemy> enemyList;
        Enemy tempEnemy;

        public EnemyHandler(ContentManager content, SimplePath simplePath)
        {
            spriteSheet = content.Load<Texture2D>("slimeSheet");

            position = Vector2.Zero;

            enemyList = new List<Enemy>();
        }

        public void Update(GameTime gameTime)
        {
            spawnTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (spawnTimer <= 0)
            {
                tempEnemy = new BlueSlime(spriteSheet, position);
                enemyList.Add(tempEnemy);

                spawnTimer = spawnInterval;
            }

            foreach (Enemy enemy in enemyList)
            {
                enemy.Update(gameTime);
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