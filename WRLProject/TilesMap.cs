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
    class TileMap
    {
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();

        // this section is used to capture the tiles, used to hold colliable tiles
        //with the character

        public List<CollisionTiles> CollisionTiles
        {
            get { return collisionTiles; } // collisionable tiles 
        }

        private int width, height;

        //width value will be used to hold - how many tiles across the
        //X values so if each tile is 64pixels and screen needs 100 
        //width will 64 * 100 = 640
        // Width will be used to take into consideration of the camera

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public TileMap() { }// leaving constructor blank 

        public void Generate(int[,] map, int size) // two Dimenional Array array being passed
        {
            for (int x = 0; x < map.GetLength(1); x++)
                for (int y = 0; y < map.GetLength(0); y++)//cyclying through x, then y
                {
                    int numbers = map[y, x];

                    if (numbers > 0)
                        collisionTiles.Add(new CollisionTiles(numbers, new Rectangle(x * size, y * size, size, size))); //Size (width) Size (Height)
                                                                                                                        //if 0 then draw blank

                    width = (x + 1) * size; // this is used to control camera
                    height = (y + 1) * size;

                }

            // The loops cycles through X and Y and maps tiles

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in collisionTiles)
                tile.Draw(spriteBatch);
        }
    }
}