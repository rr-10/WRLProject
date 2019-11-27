using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace WRLProject
{
    class HealthPowerup
    {
        Texture2D healthTex;  //declares the texture ID
        public Rectangle healthRect;  //declares the Rectangle 
        public Vector2 spawnPosition; // Position to Spawn the object 

        public HealthPowerup(Texture2D tex, Vector2 pos)    // assigns the class values 
        {
            healthTex = tex;
            spawnPosition = pos;
        }

        public void Update(GameTime gt, Game1 game1)
        {
            healthRect = new Rectangle(
                (int)spawnPosition.X,
                (int)spawnPosition.Y,
                healthTex.Width,
                healthTex.Height);
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
            sb.Draw(healthTex, healthRect, Color.White);
        }
    }
}
