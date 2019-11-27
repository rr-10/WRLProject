using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace WRLProject
{
    class Boss
    {
        public Vector2 currentPos; // current position
        //private bool movingLeft;
        //private bool movingRight;
        //private bool isJumping;
        public Texture2D bossTex; // texture of enemy
        public Rectangle rectangle; // player rectangle
        public Rectangle bossRect; // boss rectangle
        public Rectangle fightRect; // attacking rectangle
        //public Rectangle shootingRect;

        KeyboardState newState, oldState;        
        float timeHeldDown;
        Vector2 pos;

        int width;
        int height;
        int rows;
        int columns;
        int currentFrame;
        int totalFrames;
        bool spriteFlipped;

        public Boss(Vector2 p, Texture2D t, int r, int c)
        {
            currentPos = p; // pos
            bossTex = t; // tex
            rows = r;
            columns = c;
            currentFrame = 0;

            totalFrames = rows * columns;
            width = bossTex.Width / columns;
            height = bossTex.Height / rows;

            bossRect = new Rectangle(
                (int)currentPos.X, // pos.X
                (int)currentPos.Y, // pos.Y
                width, // width
                height); // height

            fightRect = new Rectangle((int)fightRect.X - 50, (int)fightRect.Y - 50, bossTex.Width + 100, bossTex.Height + 100);

            /*shootingRect = new Rectangle(
                (int)fightRect.X - 250,
                (int)fightRect.Y - 250,
                bossTex.Width + 500,
                bossTex.Height + 500);*/
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            spriteFlipped = true;
            timeHeldDown += (float)gameTime.ElapsedGameTime.Milliseconds;

            if (timeHeldDown > 100f)
            {
                currentFrame++;
                timeHeldDown = 0;


                if (currentFrame == totalFrames)
                    currentFrame = 1;

                pos.X -= 10;

            }
            else
            {
                currentFrame = 0;
            }

            oldState = newState;

            bossRect.X = (int)currentPos.X;
            bossRect.Y = (int)currentPos.Y;
            fightRect.X = (int)currentPos.X - 50;
            fightRect.Y = (int)currentPos.Y - 50;
            //shootingRect.X = (int)currentPos.X - 250;
            //shootingRect.Y = (int)currentPos.Y - 250;
        }

        public void Draw(SpriteBatch sb)
        {
            //sb.Begin();
            int currRow = (int)((float)currentFrame / (float)columns);
            int currCol = currentFrame % columns;

            Rectangle srcRect = new Rectangle(width * currCol, height * currRow, width, height);

            if (spriteFlipped)
                sb.Draw(bossTex, bossRect, srcRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0);

            //sb.End();
        }

        public bool CollideWithPlayer(Rectangle plyrRect)
        {
            if (rectangle.Intersects(plyrRect))
            {
                return true;
            }
            else
                return false;
        }

    }
}
