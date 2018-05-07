using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BulletHell
{
    public class Player : Sprite
    {
        public int HP { get; set; }
        public Vector2 Velocity { get; private set; }
        public Rectangle Rectangle { get; private set; }
        public List<PlayerBullet> Bullets = new List<PlayerBullet>();
        public int FireRate { get; private set; }
        public Texture2D BulletTexture { get; private set; }
        private float Rotation;
        private int FireCounter;


        public Player(Vector2 vector2, Texture2D texture2D, SpriteBatch spriteBatch, Texture2D bulletTexture) : base(vector2, texture2D, spriteBatch)
        {
            HP = 5;
            Rotation = -MathHelper.PiOver2;
            FireRate = 15;
            BulletTexture = bulletTexture;
        }

        public void Update(GameTime gameTime)
        {
            if (HP <= 0)
                HP = 5;
            //Player Rectangle.
            Rectangle = new Rectangle((int)Vector2.X, (int)Vector2.Y, Texture2D.Width, Texture2D.Height);

            Fire();
            Movement();
            RotationUpdate();
        }

        public void RotationUpdate()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                Rotation -= 0.05f;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                Rotation += 0.05f;
        }

        public override void Draw()
        {
            SpriteBatch.Draw(Texture2D, Vector2, null, null, new Vector2(Texture2D.Width / 2, Texture2D.Height / 2), (float)Rotation, null, Color.DarkGray, SpriteEffects.None, 0);
            foreach (PlayerBullet PB in Bullets)
                SpriteBatch.Draw(PB.Texture2D, PB.Vector2, Color.DarkBlue);
        }

        private void Fire()
        {
            foreach (PlayerBullet PB in Bullets)
                PB.Vector2 += new Vector2((float)Math.Cos(PB.Rotation), (float)Math.Sin(PB.Rotation)) * 2.5f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && FireCounter >= FireRate)
            {
                Bullets.Add(new PlayerBullet(Vector2 - new Vector2(BulletTexture.Width / 2, BulletTexture.Height / 2), BulletTexture, SpriteBatch, Rotation, 1500));
                FireCounter = 0;
            }
            FireCounter++;
        }

        private void Movement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                Velocity += new Vector2(-0.025f, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                Velocity += new Vector2(0.025f, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                Velocity += new Vector2(0, 0.025f);
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                Velocity += new Vector2(0, -0.025f);

            Vector2 += Velocity;
        }
    }
}
