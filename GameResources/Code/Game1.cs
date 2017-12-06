using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefenceINF.GameResources.Code;
using System.Collections.Generic;
using Spline;

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

        BackBufferHandler backBufferHandler;
        ProjectileHandler projectileHandler;
        UIHandler uIHandler;
        EnemyHandler enemyHandler;
        Player player;

        int width = 1600;
        int hight = 900;
        SpriteFont font;
        SimplePath map;
        bool mouseVisibility;

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
            Content.RootDirectory = "Content";
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
            mouseVisibility = true;

            mapHandler = new MapHandler(graphics.GraphicsDevice, Content);
            
            IsMouseVisible = true;
            backBufferHandler = new BackBufferHandler(GraphicsDevice, Content);

            uIHandler = new UIHandler(Content);
            player = uIHandler.Player;

            projectileHandler = new ProjectileHandler(Content);
            enemyHandler = new EnemyHandler(Content, mapHandler.GetSimplePath(), projectileHandler.ShotsList, uIHandler.Player);
            towerHandler = new TowerHandler(Content, graphics, enemyHandler.enemyList, uIHandler.Player, projectileHandler.ShotsList);
        }
        
        
        protected override void Update(GameTime gameTime)
        {
            IsMouseVisible = mouseVisibility;
            KeyMouseReader.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (currentState == GameState.Meny)
            {
                MenyKes();
            }
            else if(currentState == GameState.Play)
            {

                mapHandler.Update(gameTime);
                
                towerHandler.Update(gameTime, ref mouseVisibility, backBufferHandler.GetBackgroundLayer(), projectileHandler);
                backBufferHandler.Update(GraphicsDevice, towerHandler.GetTowerList());

                enemyHandler.Update(gameTime);
                projectileHandler.Update(gameTime);
                //uIHandler.Update(gameTime);
                if (player.Health == 0)
                {
                    currentState = GameState.Gameover;
                }
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
                spriteBatch.DrawString(font, "TD", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 2 - 50), Color.Black);
                spriteBatch.DrawString(font, "Start Press Enter", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 2 - 5), Color.Black);
            }
            else if(currentState == GameState.Play)
            {
                GraphicsDevice.Clear(Color.Blue);
                mapHandler.Draw(spriteBatch);
                towerHandler.Draw(spriteBatch);
                enemyHandler.Draw(spriteBatch);
                projectileHandler.Draw(spriteBatch);
                uIHandler.Draw(spriteBatch);
            }
            else if(currentState == GameState.Gameover)
            {
                GraphicsDevice.Clear(Color.Green);
                spriteBatch.DrawString(font, "Level: "+ player.Level.ToString(), new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 2 - 25), Color.Black);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
