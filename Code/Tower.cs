using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF
{
    abstract class Tower: GameObject
    {

        protected Vector2 radius;

        public Tower(Texture2D tex, Vector2 pos): base(tex, pos)
        {
            
            radius = new Vector2(100, 100);

        }

        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(tex, pos, Color.White);

        }

        public abstract void Update(GameTime gameTime, List<Enemy> enemyList);

        public virtual bool IsColliding(Rectangle other)
        {

            return boundingBox.Intersects(other);

        }

        public virtual bool PixelPerfectTowerCollision(Tower other)
        {

            
                Console.WriteLine("PRE-COLLISION");


                Color[] dataA = new Color[boundingBox.Width * boundingBox.Height];
                tex.GetData<Color>(0, boundingBox, dataA, 0, boundingBox.Width * boundingBox.Height);

                Color[] dataB = new Color[other.GetBoundingBox().Width * other.GetBoundingBox().Height];
                other.GetTexture().GetData<Color>(0, other.GetBoundingBox(), dataB, 0, other.GetBoundingBox().Width * other.GetBoundingBox().Height);

                int top = Math.Max(GetBoundingBox().Top, other.GetBoundingBox().Top);
                int bottom = Math.Min(GetBoundingBox().Bottom, other.GetBoundingBox().Bottom);
                int left = Math.Max(GetBoundingBox().Left, other.GetBoundingBox().Left);
                int right = Math.Min(GetBoundingBox().Right, other.GetBoundingBox().Right);

                for (int y = top; y < bottom; y++)
                {

                    for (int x = left; x < right; x++)
                    {

                        Color colorA = dataA[(x - GetBoundingBox().Left) +
                        (y - GetBoundingBox().Top) * GetBoundingBox().Width];

                        Color colorB = dataB[(x - other.GetBoundingBox().Left) +
                        (y - other.GetBoundingBox().Top) *
                        other.GetBoundingBox().Width];

                        if (colorA.A != 0 && colorB.A != 0)
                        {
                            
                            Console.WriteLine("COLLISION" + y);
                            return true;

                        }
                    }
                }

                 return false;
            
        }
        
        
    }
}
