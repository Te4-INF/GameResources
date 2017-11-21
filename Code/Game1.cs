using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefenceINF.GameResources.Code;
using System.Collections.Generic;

namespace TowerDefenceINF.GameResources.Code
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        MapHandler mapHandler;
        //TowerHandler towerHandler;
        //BackBufferHandler bufferHandler;
        //ProjectileHandler projectileHandler;
        //UIHandler uIHandler;
        //EnemyHandler enemyHandler;

        int width = 1600;
        int hight = 900;
        SpriteFont UIfont;
        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        void Draw(SpriteBatch sb)
        {
            //empty
        }

        void Drawstring(SpriteBatch sb, int value, Vector2 stringPos) //e.g value is life (10) and stringPos would be (100,100)
        {
            sb.DrawString(UIfont, value.ToString(), stringPos, Color.White);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferHeight = hight;
            graphics.PreferredBackBufferWidth = width;
            graphics.ApplyChanges();
            mapHandler = new MapHandler(graphics.GraphicsDevice);
            //towerHandler = new TowerHandler(Content);
            //backBufferHandler = new BackBufferHandler(Content);
            //projectileHandler = new ProjectileHandler(Content);
            //enemyHandler = new EnemyHandler(Content);
            
            UIfont = Content.Load<SpriteFont>("UI_font");

            int life = 10, cash = 25, wave = 1;
            player = new Player(life, cash, wave);
        }
        
        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);
            spriteBatch.Begin();

            mapHandler.Draw(spriteBatch);
            
            Drawstring(spriteBatch, player.getLife(), new Vector2(100, 100));
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
