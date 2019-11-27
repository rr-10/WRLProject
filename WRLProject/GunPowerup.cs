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
    class GunPowerup
    {
        Texture2D gunTex;  //declares the texture ID
        public Rectangle gunRect;  //declares the Rectangle 
        public Vector2 spawnPosition; // Position to Spawn the object 

        public GunPowerup(Texture2D tex, Vector2 pos)    // assigns the class values 
        {
            gunTex = tex;
            spawnPosition = pos;
        }

        public void Update(GameTime gt, Game1 game1)
        {
            gunRect = new Rectangle(
                (int)spawnPosition.X,
                (int)spawnPosition.Y,
                gunTex.Width,
                gunTex.Height);
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

            sb.Draw(gunTex, gunRect, Color.White);

        }

    }
}
