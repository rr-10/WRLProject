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
    class Collider
    {
        Vector2 pos;
        Texture2D tex;
        public Rectangle rect;

        public Collider(Vector2 p, Texture2D t)
        {
            pos = p;
            tex = t;

            rect = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }

        public void Update()
        {
            rect.X = (int)pos.X;
            rect.Y = (int)pos.Y;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rect, Color.White);
        }
    }
}
