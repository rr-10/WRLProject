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
    class Enemy
    {
        public Vector2 pos; // current position
        private Vector2 startPos; // starting position
        private bool movingLeft;
        private bool movingRight;
        public Texture2D tex; // texture of enemy
        public Rectangle enemyRect; // enemy rectangle
        public Rectangle attackRect; // attacking rectangle

        KeyboardState newState, oldState;
        float timeHeldDown;

        int width;
        int height;
        int rows;
        int columns;
        int currentFrame;
        int totalFrames;
        bool spriteFlipped;

        public Enemy(Vector2 p, Texture2D t, int r, int c)
        {

            pos = p;
            tex = t;
            rows = r;
            columns = c;
            currentFrame = 0;

            movingLeft = true;
            movingRight = false;

            totalFrames = rows * columns;
            width = tex.Width / columns;
            height = tex.Height / rows;

            enemyRect = new Rectangle(
                (int)pos.X, 
                (int)pos.Y, 
                width, 
                height);

            movingLeft = true;
            movingRight = false;

            /*attackRect = new Rectangle(
                (int)enemyRect.X - 50,
                (int)enemyRect.Y - 50,
                tex.Width + 100,
                tex.Height + 100);*/

            attackRect = new Rectangle(
                (int)attackRect.X - 50,
                (int)attackRect.Y - 50,
                width + 100,
                height + 100);

            startPos = pos;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();            
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

            if (movingLeft)
            {
                pos.X -= 10;
                spriteFlipped = true;
                if (pos.X <= startPos.X - 200)
                {
                    movingLeft = false;
                    movingRight = true;                    
                }
            }

            if (movingRight)
            {
                pos.X += 10;
                spriteFlipped = false;
                if (pos.X >= startPos.X)
                {
                    movingLeft = true;
                    movingRight = false;                   
                }
            }

            oldState = newState;   

            enemyRect.X = (int)pos.X;
            enemyRect.Y = (int)pos.Y;
            attackRect.X = (int)pos.X - 50;
            attackRect.Y = (int)pos.Y - 50;
        }

        public void Draw(SpriteBatch sb)
        {
            //sb.Begin();

            int currRow = (int)((float)currentFrame / (float)columns);
            int currCol = currentFrame % columns;

            Rectangle srcRect = new Rectangle(width * currCol, height * currRow, width, height);

            if (spriteFlipped)
                sb.Draw(tex, enemyRect, srcRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            else
                sb.Draw(tex, enemyRect, srcRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0);

            //sb.End();
        }    

    }
}
