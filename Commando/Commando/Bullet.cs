using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Commando
{
    public class Bullet
    {
        public Texture2D texture;

        public Vector2 position;
        public Vector2 velocity;
        public Vector2 origin;
        public float rotation;

        public Rectangle bulletRectangle;

        public bool isVisible;

        public Bullet(Texture2D newTexture)
        {
            texture = newTexture;

            isVisible = true;
        }

        public void Update()
        {
            bulletRectangle.X = (int)position.X;
            bulletRectangle.Y = (int)position.Y;
        }

        public void Draw(SpriteBatch SB)
        {
            bulletRectangle = new Rectangle((int)position.X, (int)position.Y, texture.Bounds.Width, texture.Bounds.Height);

            SB.Begin();

            SB.Draw(texture, position, null, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 1);

            SB.End();
        }
    }
}
