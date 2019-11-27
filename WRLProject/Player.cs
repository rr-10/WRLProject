using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace WRLProject
{
    class Player
    {
        // Variables for the player
        public Texture2D texIdleRun;
        public Texture2D texMelee;
        public Vector2 position;
        public Rectangle boundsRect;
        private Vector2 velocity;
        public Rectangle rectangle; // player rectangle
        public Rectangle shootAtMeRect; // the rectangle which the boss can then shoot at the player
        public bool isDead; // bool whether player is dead
        private Game1 game; // calling in Game1 variables

        KeyboardState newState, oldState;        
        float timeHeldDown;

        // Animation variables
        int width;
        int height;
        int rows;
        int columns;
        int currentFrame;
        int totalFrames;
        int totalFramesRowOne;
        int totalFramesRowTwo;
        int totalFramesRowThree;
        bool spriteFlipped;

        public Rectangle upCol;
        public Rectangle downCol;
        public Rectangle leftCol;
        public Rectangle rightCol;

        // List of booleans
        public bool canMoveUp = true;
        public bool canMoveDown = true;
        public bool canMoveLeft = true;
        public bool canMoveRight = true;
        public bool isAttacking = false;
        private bool isAtkWKnife = false;
        public bool isShooting = false;
        public bool hasKnife = false;
        private bool hasJumped = false;
        public bool paused = false;
        //private bool hasStopped = true;

        public int plyrHP;

        //using oop behaviour and methods to control Position
        public Vector2 Position
        {
            get { return position; }
        }

        //setting up constructor for CLass Player
        public Player(Vector2 p, Texture2D tI, int rI, int cI, Game1 g, bool dead/*ContentManager content*/)
        {
            //Load(content);

            position = p;
            texIdleRun = tI;
            rows = rI;
            columns = cI;
            game = g;
            isDead = dead;

            currentFrame = 0;
            totalFramesRowOne = (rows + 1) * columns;
            totalFramesRowTwo = (rows + 2) * columns;
            totalFramesRowThree = columns;
            totalFrames = rows * columns;

            width = texIdleRun.Width / columns;
            height = texIdleRun.Height / rows;
            
            rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            shootAtMeRect = new Rectangle(((int)rectangle.X - 500), ((int)rectangle.Y - 500), width + 1000, height + 1000);
            //boundsRect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            upCol = new Rectangle((int)position.X, (int)position.Y - 2, boundsRect.Width, 2);
            downCol = new Rectangle((int)position.X, (int)position.Y + boundsRect.Height, boundsRect.Width, 2);
            leftCol = new Rectangle((int)position.X - 2, (int)position.Y, 2, boundsRect.Height);
            rightCol = new Rectangle((int)position.X + boundsRect.Width, (int)position.Y, 2, boundsRect.Height);
        }

        /*public void Load(ContentManager Content)
        {
            //texture = Content.Load<Texture2D>("Player");
            texIdleRun = Content.Load<Texture2D>("TestSpriteSheetRun");
        }
        */
        public void Update(GameTime gameTime/*, SoundEffect effect*/)
        {
            //Console.WriteLine(isAttacking);
            newState = Keyboard.GetState();
            position += velocity;
            Input(gameTime);

            if (velocity.Y < 10)
                velocity.Y += 0.4f;

            //Melee Attack Code
            if (newState.IsKeyDown(Keys.L))
            {
                isAttacking = true;
                //hasStopped = false;
                if (!hasKnife)
                {
                    currentFrame = 8;
                }
                else
                {
                    currentFrame = 24;
                }
            }

            if (isAttacking)
            {
                if (gameTime.ElapsedGameTime.Milliseconds < 100)
                {
                    currentFrame++;
                }

                if (!hasKnife)
                {
                    if (currentFrame == 15)
                    {
                        isAttacking = false;
                        currentFrame = 3;
                    }
                }

                else
                {
                    if (currentFrame == 31)
                    {
                        isAttacking = false;
                        currentFrame = 3;
                    }
                }
            }

            //Projectile Attack Code
            if (newState.IsKeyDown(Keys.Space))
            {
                isShooting = true;
                currentFrame = 16;
                //hasStopped = false;
            }

            if (isShooting)
            {
                if (gameTime.ElapsedGameTime.Milliseconds < 100)
                {
                    currentFrame++;
                }

                if (currentFrame == 23)
                {
                    isShooting = false;
                    currentFrame = 3;
                }
            }

            /*if(newState.IsKeyDown(Keys.B) && oldState.IsKeyUp(Keys.B))
            {
                attacked = false;
            }*/

            //Walking/Running Animation Code

            if (newState.IsKeyDown(Keys.A) && !isAttacking && !isShooting && !isAtkWKnife)
            {
                spriteFlipped = true;
                //hasStopped = false;
                isAttacking = false;

                timeHeldDown += (float)gameTime.ElapsedGameTime.Milliseconds;

                if(timeHeldDown > 100f)
                {
                    currentFrame++;
                    timeHeldDown = 0;
                }

                if (currentFrame == 8)
                    currentFrame = 1;

                /*else
                    currentFrame = 0;*/

                position.X -= 10;
            }

            else if (newState.IsKeyDown(Keys.D) && !isAttacking && !isShooting && !isAtkWKnife)
            {
                spriteFlipped = false;
                //hasStopped = false;
                isAttacking = false;

                timeHeldDown += (float)gameTime.ElapsedGameTime.Milliseconds;

                if(timeHeldDown > 100f)
                {
                    currentFrame++;
                    timeHeldDown = 0;
                }

                if (currentFrame == 8)
                    currentFrame = 1;

                /*else
                    currentFrame = 0;*/

                position.X += 10;
            } 
            
            /*else
            {
                currentFrame = 3;
                
            }*/

            
            /*else if (!isAttacking)
            {
                currentFrame = 3;                
            }
            
            else if (!isShooting)
            {
                currentFrame = 3;
            }*/
            

            oldState = newState;

            rectangle.X = (int)position.X;
            rectangle.Y = (int)position.Y;
            shootAtMeRect.X = (int)position.X - 500;
            shootAtMeRect.Y = (int)position.Y - 500;
            //boundsRect.X = (int)position.X;
            //boundsRect.Y = (int)position.Y;
            upCol.X = boundsRect.Left;
            upCol.Y = boundsRect.Top - upCol.Height;
            downCol.X = boundsRect.Left;
            downCol.Y = boundsRect.Bottom;
            leftCol.X = boundsRect.Left - leftCol.Width;
            leftCol.Y = boundsRect.Top;
            rightCol.X = boundsRect.Right;
            rightCol.Y = boundsRect.Top;
        }

        private void Input(GameTime gameTime/*, SoundEffect effect*/)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                game.CurDir = Game1.Directions.Right;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                game.CurDir = Game1.Directions.Left;
            }

            //This is used to control computer CPU lag. 
            else if (paused == true)
            {
                velocity.X = 0f;
            }

            else velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.W) && hasJumped == false)
            {
                position.Y -= 3f;
                velocity.Y = -12f;
                hasJumped = true;
                //effect.Play();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && hasJumped == false && paused == true)
            {
                position.Y -= 0f;
                velocity.Y = 0f;
                hasJumped = true;
            }
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset, int tileID, Game1 game)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;

                switch(tileID)
                {
                    case 3:
                        position.Y -= 3f;
                        velocity.Y = -24f;
                        break;

                    case 4:
                        /*game.gameState = Game1.GameState.GameOver;
                        break;*/
                        game.plyrHP -= 100;
                        //game.plyrLife -= 1;

                        if (game.plyrHP < 0)
                        {
                            game.isDead = true;
                            game.plyrLife -= 1;

                            if (game.plyrLife < 0)
                            {
                                game.gameState = Game1.GameState.GameOver;
                                break;
                            }
                        }
                        break;


                        /*game.isDead = true;
                        if (game.plyrLife < 0)
                        {
                            game.gameState = Game1.GameState.GameOver;
                        }
                        break;*/

                    case 5:
                        game.gameState = Game1.GameState.FinishLv1;
                        break;

                    case 6:
                        game.plyrHP -= 10;

                        if (game.plyrHP <= 0)
                        {
                            game.isDead = true;
                            game.plyrLife -= 1;

                            if (game.plyrLife < 0)
                            {
                                game.gameState = Game1.GameState.GameOver;
                                break;
                            }
                        }
                        break;
                }
            }

            //********************************************************************8888

            if (rectangle.TouchLeftOf(newRectangle))
            {
                position.X = newRectangle.X - rectangle.Width - 2;
            }

            if (rectangle.TouchRightOf(newRectangle))
            {
                position.X = newRectangle.X + newRectangle.Width + 2;
            }

            if (rectangle.TouchBottomOf(newRectangle))

                velocity.Y = 1f;

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.X < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.Y = yOffset - rectangle.Height;

            // controls the movement from the side screen
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int currRow = (int)((float)currentFrame / (float)columns);
            int currCol = currentFrame % columns;

            Rectangle srcRect = new Rectangle(width * currCol, height * currRow, width, height);

            if (!spriteFlipped)
                spriteBatch.Draw(texIdleRun, rectangle, srcRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0);
            else
                spriteBatch.Draw(texIdleRun, rectangle, srcRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            
            //spriteBatch.Draw(texture, rectangle, Color.White);

        }
    }
}
