using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace WRLProject
{
    static class RectangleHelper
    {
        //four methods are ready 

        //used by the player when rectangle touches top of the block it will stop it from 
        // from going through it. 
        // This will allow for if you change size of the images also

        const int penetrationMargin = 10;

        // this checks if the player touches the top of the tile
        public static bool TouchTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - penetrationMargin &&   //used to calculate if chara
                    r1.Bottom <= r2.Top + 1 &&  //through top of the block from high volcity movement
                    r1.Right >= (r2.Left + 5) &&
                    r1.Left <= (r2.Right - 5));

            /*return (r1.Bottom >= r2.Top - 1 &&   //used to calculate if chara
                    r1.Bottom <= r2.Top + (r2.Height / 2) &&  //through top of the block from high volcity movement
                    r1.Right >= r2.Left + r2.Width / 5 && 
                    r1.Left <= r2.Right - r2.Width / 5);*/

        }

        // this checks if the player touches the bottom of the tile
        public static bool TouchBottomOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Top <= r2.Bottom + (r2.Height / 5) &&   //used to calculate if chara
                               r1.Top >= r2.Bottom - 1 &&
                               r1.Right >= r2.Left + (r2.Width / 5) &&
                               r1.Left <= r2.Right - (r2.Width / 2));
        }

        // this checks if the player touches the left of the tile
        public static bool TouchLeftOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right <= r2.Right &&   //used to calculate if chara
                              r1.Right >= r2.Left - 5 &&
                              r1.Top <= r2.Bottom - (r2.Width / 4) &&
                              r1.Bottom >= r2.Top + (r2.Width / 4));
        }

        // this checks if the player touches the right of the tile
        public static bool TouchRightOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Left &&   //used to calculate if chara
                              r1.Left <= r2.Right + 5 &&
                              r1.Top <= r2.Bottom - (r2.Width / 4) &&
                              r1.Bottom >= r2.Top + (r2.Width / 4));
        }


    }
}
