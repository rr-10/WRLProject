using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WRLProject
{
    class AmmoPowerup
    {
        Texture2D ammoTex;  //declares the texture ID
        public Rectangle ammoRect;  //declares the Rectangle 
        public Vector2 spawnPosition; // Position to Spawn the object 

        public AmmoPowerup(Texture2D tex, Vector2 pos)    // assigns the class values 
        {
            ammoTex = tex;
            spawnPosition = pos;
        }

        public void Update(GameTime gt, Game1 game1)
        {
            ammoRect = new Rectangle(
                (int)spawnPosition.X,
                (int)spawnPosition.Y,
                ammoTex.Width,
                ammoTex.Height);
            //defines the rectangle specification 
            //spawnPosition.Y += 2;

            /*if (rect.Intersects(player.rectangle))
            {
                game1.plyrLife++;
                spawnPosition.Y = -1000;
            }*/
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(ammoTex, ammoRect, Color.White);
        }
    }
}
