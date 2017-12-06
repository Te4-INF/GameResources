using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF.GameResources.Code
{
     class Player
    {
        int health, balance, level;

        SpriteFont UIFont;

        public Player(SpriteFont UIFont)
        {
            this.UIFont = UIFont;

            health = 50;
            balance = 200;
            level = 1;
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health -= value;
            }
        }

        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance += value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level += value;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(UIFont, "Health: " + health.ToString() + "hp", new Vector2(20, 860), Color.White);
            spriteBatch.DrawString(UIFont, "Level: " + level.ToString(), new Vector2(500, 860), Color.White);
            spriteBatch.DrawString(UIFont, "Balance: $" + balance.ToString(), new Vector2(1000, 860), Color.White);
        }
    }
}
