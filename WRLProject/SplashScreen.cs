using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace WRLProject
{
    class SplashScreen
    {
        // Variables for Splash Screen
        Vector2 splashPos;
        Texture2D splashTex;
        Rectangle splashRect;

        // Splash Screen constructor
        public SplashScreen (Vector2 pos, Texture2D tex, Rectangle rect)
        {
            splashPos = pos;
            splashTex = tex;
            splashRect = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }

        public void Update(GameTime gameTime)
        {
            splashRect.X = (int)splashPos.X;
            splashRect.Y = (int)splashPos.Y;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(splashTex, splashRect, Color.White);
        }
    }
}
