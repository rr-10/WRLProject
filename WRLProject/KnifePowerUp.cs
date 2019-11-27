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
    class KnifePowerup
    {
        Texture2D knifeTex;  //declares the texture ID
        public Rectangle knifeRect;  //declares the Rectangle 
        public Vector2 spawnPosition; // Position to Spawn the object 

        public KnifePowerup(Texture2D tex, Vector2 pos)    // assigns the class values 
        {
            knifeTex = tex;
            spawnPosition = pos;
        }

        public void Update(GameTime gt, Game1 game1)
        {
            knifeRect = new Rectangle(
                (int)spawnPosition.X,
                (int)spawnPosition.Y,
                knifeTex.Width,
                knifeTex.Height);
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

            sb.Draw(knifeTex, knifeRect, Color.White);

        }
    }
}
