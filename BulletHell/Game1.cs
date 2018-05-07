using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace BulletHell
{
    public class Main : Game
    {
        Random random = new Random();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D EnemyCubeTexture;
        Texture2D BulletTexture;
        Texture2D RectangleDebugTexture;

        public static Player player;

        List<Enemy> EnemyCubes = new List<Enemy>();

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.IsFullScreen = true;

            //Load textures.
            EnemyCubeTexture = Content.Load<Texture2D>("Block");
            BulletTexture = Content.Load<Texture2D>("WhiteBall");
            RectangleDebugTexture = Content.Load<Texture2D>("1x1Px");

            player = new Player(Vector2.One * 80, EnemyCubeTexture, spriteBatch, BulletTexture);

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            if (EnemyCubes.Count < 5)
                EnemyCubes.Add(new Enemy(new Vector2(random.Next(1,800), random.Next(1,400)), EnemyCubeTexture, BulletTexture, spriteBatch, 0.02f, 15));

            foreach (Enemy EN in EnemyCubes)
                EN.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();


            foreach (Enemy EN in EnemyCubes)
                EN.Draw();

            player.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
