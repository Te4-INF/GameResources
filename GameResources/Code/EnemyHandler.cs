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

        SimplePath simplePath;

        public EnemyHandler(ContentManager content, SimplePath simplePath)
        {
            spriteSheet = content.Load<Texture2D>("slimeSheet");

            position = simplePath.GetPos(0);

            enemyList = new List<Enemy>();

            this.simplePath = simplePath;
        }

        public void Update(GameTime gameTime)
        {
            spawnTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (spawnTimer <= 0)
            {
                tempEnemy = new BlueSlime(spriteSheet, position, simplePath);
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