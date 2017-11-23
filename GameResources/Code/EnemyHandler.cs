using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceINF
{
    class EnemyHandler
    {
        float frameTimer, frameInterval = 100;

        Texture2D spriteSheet;

        Vector2 position;

        List<Enemy> enemyList;
        Enemy tempEnemy;

        public EnemyHandler(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("slimeSheet");

            position = new Vector2(50, 50);

            enemyList = new List<Enemy>();
        }

        public void Update(GameTime gameTime)
        {
            frameTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (frameTimer <= 0)
            {
                tempEnemy = new BlueSlime(spriteSheet, position);
                enemyList.Add(tempEnemy);

                frameTimer = frameInterval;
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