using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefenceINF.GameResources.Code;
using System.Collections.Generic;

namespace TowerDefenceINF.GameResources.Code
{
    public class KeyMouseReader
    {
        public static KeyboardState keyState, oldKeyState = Keyboard.GetState();
        public static MouseState mouseState, oldMouseState = Mouse.GetState();

        public static bool KeyPressed(Keys key)
        {
            return keyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key);
        }
        public static bool LeftClick()
        {
            return mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released;
        }
        public static bool RightClick()
        {
            return mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released;
        }

        public static Point MousePos()
        {

            return new Point(mouseState.X, mouseState.Y);

        }

        //Should be called at beginning of Update in Game
        public static void Update()
        {
            oldKeyState = keyState;
            keyState = Keyboard.GetState();
            oldMouseState = mouseState;
            mouseState = Mouse.GetState();

        }
    }
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        MapHandler mapHandler;
        TowerHandler towerHandler;
        //BackBufferHandler bufferHandler;
        //ProjectileHandler projectileHandler;
        //UIHandler uIHandler;
        //EnemyHandler enemyHandler;
        int width = 1600;
        int hight = 900;
        Player player;
        SpriteFont font;
        enum GameState
        {
            Meny,
            Play,
            Gameover
        }
        GameState currentState = GameState.Meny;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "GameResources/Content";
        }
        
        protected override void Initialize()
        {
            base.Initialize();
        }


        private void MenyKes()// vad man ska trycka för de olika banerna
        {
            if (KeyMouseReader.KeyPressed(Keys.Enter))
            {
                currentState = GameState.Play;
            }
            
        }
        
        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>("Font");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferHeight = hight;
            graphics.PreferredBackBufferWidth = width;
            graphics.ApplyChanges();
            mapHandler = new MapHandler(graphics.GraphicsDevice);
            towerHandler = new TowerHandler(Content);
            IsMouseVisible = true;
            //backBufferHandler = new BackBufferHandler(Content);
            //projectileHandler = new ProjectileHandler(Content);
            //enemyHandler = new EnemyHandler(Content);
            
            int life = 10, cash = 25, wave = 1;
            player = new Player(life, cash, wave);
        }
        
        bool test = true;
        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (currentState == GameState.Meny)
            {
                MenyKes();
            }
            else if(currentState == GameState.Play)
            {
                //mapHandler.Update(gameTime);
                //bufferHandler.Update(gameTime);
                towerHandler.Update(gameTime, ref test);
                //enemyHandler.Update(gameTime);
                //projectileHandler.Update(gameTime);
                //uIHandler.Update(gameTime);
            }
            else if(currentState == GameState.Gameover)
            {
                MenyKes();
            }
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (currentState == GameState.Meny)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.DrawString(font, "TD", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 2 - 25), Color.Black);
                spriteBatch.DrawString(font, "Start Press Escape", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 2 - 5), Color.Black);
            }
            else if(currentState == GameState.Play)
            {
                GraphicsDevice.Clear(Color.Blue);
                mapHandler.Draw(spriteBatch);
                towerHandler.Draw(spriteBatch);
                //enemyHandler.Draw(spriteBatch);
                //projectileHandler.Draw(spriteBatch);
                //uIHandler.Draw(spriteBatch);
            }
            else if(currentState == GameState.Gameover)
            {
                GraphicsDevice.Clear(Color.Green);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
