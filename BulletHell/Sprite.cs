using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell
{
    public class Sprite
    {
        public Vector2 Vector2 { get; set; }
        public Texture2D Texture2D { get; set; }
        public SpriteBatch SpriteBatch { get; set; }

        public Sprite(Vector2 vector2, Texture2D texture2D, SpriteBatch spriteBatch)
        {
            Vector2 = vector2;
            Texture2D = texture2D;
            SpriteBatch = spriteBatch;
        }

        public virtual void Draw()
        {
            SpriteBatch.Draw(Texture2D, Vector2, Color.OrangeRed);
        }
    }
}
