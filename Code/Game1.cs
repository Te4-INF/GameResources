using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefenceINF.GameResources.Code;

namespace TowerDefenceINF
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

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
