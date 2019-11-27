using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace WRLProject
{
    class Bullet
    {
        Vector2 pos;
        Texture2D tex;
        public Rectangle rect;
        Player player;
        float xDirection = 0f;
        float yDirection = 0f;
        bool leftRight;
        Game1 game;

        public Bullet(Vector2 p, Texture2D t, Game1.Directions initialDirection)
        {
            pos = p;
            tex = t;

            switch (initialDirection)
            {
                case Game1.Directions.Left:
                    xDirection = -20;
                    break;
                case Game1.Directions.Right:
                    xDirection = 20;
                    break;
            }

            rect = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }

        public void Update()
        {
            if (xDirection != 0)
                pos.X += xDirection;
            else if (yDirection != 0)
                pos.Y += yDirection;

            rect.X = (int)pos.X;
            rect.Y = (int)pos.Y;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rect, Color.White);
        }


    }
}
