using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace BulletHell
{
    public class Enemy : Sprite
    {
        public float RotationSpeed { get; set; }
        public float Rotation { get; set; }
        public float FireRate { get; set; }
        public Texture2D BulletTexture { get; private set; }
        public List<Bullet> Bullets = new List<Bullet>();
        private float Counter;


        public Enemy(Vector2 vector2,Texture2D texture2D,Texture2D bulletTexture, SpriteBatch spriteBatch, float rotationSpeed, float fireRate) : base(vector2, texture2D, spriteBatch)
        {
            RotationSpeed = rotationSpeed;
            Rotation = 0;
            FireRate = fireRate;
            BulletTexture = bulletTexture;
        }

        public override void Draw()
        {
            SpriteBatch.Draw(Texture2D, Vector2, null, null, new Vector2(Texture2D.Width / 2, Texture2D.Height / 2), (float)Rotation, null, Color.DarkGray, SpriteEffects.None, 0);
            foreach (Bullet BT in Bullets)
                BT.Draw();
        }

        public void Update(GameTime gameTime)
        {
            Rotation += RotationSpeed;
            foreach (Bullet BT in Bullets)
                BT.Update();
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i].DeletionTimer <= 0)
                    Bullets.RemoveAt(i);
            }

            Shoot();
        }

        public void Shoot()
        {

            if(Counter > FireRate)
            {
                Bullets.Add(new Bullet(Vector2, BulletTexture, SpriteBatch, Rotation, 500));
                Counter = 0;
            }

            Counter++;
            foreach (Bullet BT in Bullets)
                BT.Vector2 += new Vector2((float)Math.Cos(BT.Rotation), (float)Math.Sin(BT.Rotation));

        }
    }
}
