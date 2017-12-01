﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceINF.GameResources.Code
{
    class BlueSlime : Enemy
    {
        Rectangle[] moveRectangles;

        public BlueSlime(Texture2D tex, Vector2 pos)
            : base(tex, pos)
        {
            health = 1;

            destinationRectangle = new Rectangle(50, 100, 36, 36);
            sourceRectangle = new Rectangle(10, 81, 12, 15);

            frameInterval = 100;

            moveRectangles = new Rectangle[10];

            moveRectangles[0] = new Rectangle(10, 86, 12, 10);
            moveRectangles[1] = new Rectangle(42, 86, 12, 10);
            moveRectangles[2] = new Rectangle(74, 84, 12, 10);
            moveRectangles[3] = new Rectangle(106, 82, 12, 10);
            moveRectangles[4] = new Rectangle(139, 81, 10, 11);
            moveRectangles[5] = new Rectangle(170, 83, 12, 10);
            moveRectangles[6] = new Rectangle(202, 84, 12, 11);
            moveRectangles[7] = new Rectangle(234, 88, 12, 8);
            moveRectangles[8] = new Rectangle(265, 89, 14, 7);
            moveRectangles[9] = new Rectangle(298, 87, 12, 9);
        }

        public override void Update(GameTime gameTime)
        {
            frameTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (frameTimer <= 0)
            {
                if (frame < 9)
                {
                    frame++;
                    if (1 < frame && frame < 4)
                    {
                        destinationRectangle.Y -= 2;
                    }
                    else if (frame == 6 || frame == 8)
                    {
                        destinationRectangle.Y++;
                    }
                    else if (frame == 4)
                    {
                        destinationRectangle.Y--;
                    }
                    else if (frame == 5)
                    {
                        destinationRectangle.Y += 2;
                    }
                    else if (frame == 7)
                    {
                        destinationRectangle.Y += 4;
                    }
                }
                else
                {
                    frame = 0;
                    destinationRectangle.Y -= 3;
                }
                sourceRectangle = moveRectangles[frame];
                destinationRectangle.Width = moveRectangles[frame].Width * 2;
                destinationRectangle.Height = moveRectangles[frame].Height * 2;
                frameTimer = frameInterval;
            }
        }
    }
}