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
    class Tile
    {
        protected Texture2D texture;
        private Rectangle rectangle;
        protected int tileID;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        public int TileID { get { return tileID; } }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }  //call tiles outside game world

        }//means it can call the contents manager.

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    // Next class will inheritent from the class tile and to do this, it will
    // need a constructor and methods, behaviours and definitions

    class CollisionTiles : Tile    //Class Collision Tiles Inheritents from Class Tile
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("Tile" + i);
            this.Rectangle = newRectangle;
            this.tileID = i;
        }
        // this constructure takes in two values 1 & 0 within two images, to allow
        // for simple display.
    }
}
