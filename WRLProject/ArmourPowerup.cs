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
    class ArmourPowerup
    {
        Texture2D armourTex;  //declares the texture ID
        public Rectangle armourRect;  //declares the Rectangle 
        public Vector2 spawnPosition; // Position to Spawn the object 

        public ArmourPowerup(Texture2D tex, Vector2 pos)    // assigns the class values 
        {
            armourTex = tex;
            spawnPosition = pos;
        }

        public void Update(GameTime gt, Game1 game1)
        {
            armourRect = new Rectangle(
                (int)spawnPosition.X,
                (int)spawnPosition.Y,
                armourTex.Width,
                armourTex.Height);
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
            sb.Draw(armourTex, armourRect, Color.White);
        }
    }
}
