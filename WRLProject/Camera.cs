using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;


namespace WRLProject
{
    class Camera
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
            //calling internal class
            //Get Matrix object Transform Private
        }
        private Vector2 centre;
        private Viewport viewport;

        public Camera(Viewport newViewport)
        {
            viewport = newViewport;
            //Calling viewport within Camera Class and assigning
            //New Object 
        }

        public void Update(Vector2 position, int xOffset, int yOffset)
        {
            if (position.X < viewport.Width / 2)
                centre.X = viewport.Width / 2;
            //================================================
            // this is used to stop camera from moving far left
            // of the map
            //================================================
            else if (position.X > xOffset - (viewport.Width / 2))
                centre.X = xOffset - (viewport.Width / 2);
            //================================================
            // this is used to stop camera from moving far right
            // of the map
            //================================================

            else centre.X = position.X;
            //================================================
            //This will allow the camera to follow the character
            // within the gaming world.. 
            //================================================

            //================================================
            ///=========  Adjusting variables for Y axis 
            //==========  Height Also. Dont Forget not Width
            //================================================

            if (position.Y < viewport.Height / 2)
                centre.Y = viewport.Height / 2;
            //================================================
            // this is used to stop camera from moving far top
            // of the map
            //================================================

            else if (position.Y > yOffset - (viewport.Height / 2))
                centre.Y = yOffset - (viewport.Height / 2);
            //================================================
            // this is used to stop camera from moving far bottom
            // of the map
            //================================================
            else centre.Y = position.Y;
            //================================================
            //This will allow the camera to follow the character
            // within the gaming world.. 
            //================================================

            //==== Setting Private Object of Matrix with the Creation of Translation
            transform = Matrix.CreateTranslation(new Vector3(
                -centre.X + (viewport.Width / 2),
                -centre.Y + (viewport.Height / 2), 0));
        }
    }
}
