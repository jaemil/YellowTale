using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace YellowTale
{
    class Movement
    {
        public Vector2 position = new Vector2(0, 0); //Spielerposition
        public int speed = 5; //Bewegungsgeschwindigkeit
        public int playerheight = 48; //Texturhöhe
        public int playerwidth = 32; //Texturbreite
        private int pixel;

        public void moving(Collision collisionproof)
        {
            KeyboardState keystate = Keyboard.GetState();

            pixel = 0;

            if (keystate.IsKeyDown(Keys.D) && keystate.IsKeyDown(Keys.A) != true)
            {
                if (keystate.IsKeyDown(Keys.W) && collisionproof.CollisionCheck(position, 't', playerheight, playerwidth) && keystate.IsKeyDown(Keys.S) != true)
                {
                    while (collisionproof.CollisionCheck(position, 'r', playerheight, playerwidth) && collisionproof.CollisionCheck(position, 't', playerheight, playerwidth) && pixel < speed)
                    {
                        if (collisionproof.CollisionCheck(position, 'r', playerheight, playerwidth))
                        {
                            position.X = Convert.ToInt32(position.X + 1);
                        }

                        if (collisionproof.CollisionCheck(position, 't', playerheight, playerwidth))
                        {
                            position.Y = Convert.ToInt32(position.Y - 1);
                        }

                        pixel++;
                    }
                }
                else if (keystate.IsKeyDown(Keys.S) && collisionproof.CollisionCheck(position, 'b', playerheight, playerwidth) && position.Y + playerheight < GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height && keystate.IsKeyDown(Keys.W) != true)
                {
                    while (collisionproof.CollisionCheck(position, 'r', playerheight, playerwidth) && collisionproof.CollisionCheck(position, 'b', playerheight, playerwidth) && position.Y + playerheight < GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height && pixel < speed)
                    {
                        if (collisionproof.CollisionCheck(position, 'r', playerheight, playerwidth))
                        {
                            position.X = Convert.ToInt32(position.X + 1);
                        }

                        if (collisionproof.CollisionCheck(position, 'b', playerheight, playerwidth))
                        {
                            position.Y = Convert.ToInt32(position.Y + 1);
                        }

                        pixel++;
                    }
                }
                else
                {
                    while (collisionproof.CollisionCheck(position, 'r', playerheight, playerwidth) && pixel < speed)
                    {
                        position.X = Convert.ToInt32(position.X + 1);
                        pixel++;
                    }
                }
            }

            if (keystate.IsKeyDown(Keys.A) && keystate.IsKeyDown(Keys.D) != true)
            {
                if (keystate.IsKeyDown(Keys.W) && collisionproof.CollisionCheck(position, 't', playerheight, playerwidth) && keystate.IsKeyDown(Keys.S) != true)
                {
                    while (collisionproof.CollisionCheck(position, 'l', playerheight, playerwidth) && collisionproof.CollisionCheck(position, 't', playerheight, playerwidth) && pixel < speed)
                    {
                        if (collisionproof.CollisionCheck(position, 'l', playerheight, playerwidth))
                        {
                            position.X = Convert.ToInt32(position.X - 1);
                        }

                        if (collisionproof.CollisionCheck(position, 't', playerheight, playerwidth))
                        {
                            position.Y = Convert.ToInt32(position.Y - 1);
                        }

                        pixel++;
                    }
                }
                else if (keystate.IsKeyDown(Keys.S) && collisionproof.CollisionCheck(position, 'b', playerheight, playerwidth) && position.Y + playerheight < GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height && keystate.IsKeyDown(Keys.W) != true)
                {
                    while (collisionproof.CollisionCheck(position, 'l', playerheight, playerwidth) && collisionproof.CollisionCheck(position, 'b', playerheight, playerwidth) && position.Y + playerheight < GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height && pixel < speed)
                    {
                        if (collisionproof.CollisionCheck(position, 'l', playerheight, playerwidth))
                        {
                            position.X = Convert.ToInt32(position.X - 1);
                        }

                        if (collisionproof.CollisionCheck(position, 'b', playerheight, playerwidth))
                        {
                            position.Y = Convert.ToInt32(position.Y + 1);
                        }

                        pixel++;
                    }
                }
                else
                {
                    while (collisionproof.CollisionCheck(position, 'l', playerheight, playerwidth) && pixel < speed)
                    {
                        position.X = Convert.ToInt32(position.X - 1);
                        pixel++;
                    }
                }
            }

            if (keystate.IsKeyDown(Keys.S) && keystate.IsKeyDown(Keys.W) != true)
            {
                if (keystate.IsKeyDown(Keys.A) && collisionproof.CollisionCheck(position, 'l', playerheight, playerwidth) && position.Y + playerheight < GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height && keystate.IsKeyDown(Keys.D) != true)
                {
                    while (collisionproof.CollisionCheck(position, 'l', playerheight, playerwidth) && collisionproof.CollisionCheck(position, 'b', playerheight, playerwidth) && pixel < speed)
                    {
                        if (collisionproof.CollisionCheck(position, 'l', playerheight, playerwidth))
                        {
                            position.X = Convert.ToInt32(position.X - 1);
                        }

                        if (collisionproof.CollisionCheck(position, 'b', playerheight, playerwidth))
                        {
                            position.Y = Convert.ToInt32(position.Y + 1);
                        }

                        pixel++;
                    }
                }
                else if (keystate.IsKeyDown(Keys.D) && collisionproof.CollisionCheck(position, 'r', playerheight, playerwidth) && position.Y + playerheight < GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height && keystate.IsKeyDown(Keys.A) != true)
                {
                    while (collisionproof.CollisionCheck(position, 'r', playerheight, playerwidth) && collisionproof.CollisionCheck(position, 'b', playerheight, playerwidth) && pixel < speed)
                    {
                        if (collisionproof.CollisionCheck(position, 'r', playerheight, playerwidth))
                        {
                            position.X = Convert.ToInt32(position.X + 1);
                        }

                        if (collisionproof.CollisionCheck(position, 'b', playerheight, playerwidth))
                        {
                            position.Y = Convert.ToInt32(position.Y + 1);
                        }
                        pixel++;
                    }
                }
                else
                {
                    while (collisionproof.CollisionCheck(position, 'b', playerheight, playerwidth) && pixel < speed)
                    {
                        position.Y = Convert.ToInt32(position.Y + 1);
                        pixel++;
                    }
                }
            }

            if (keystate.IsKeyDown(Keys.W) && keystate.IsKeyDown(Keys.S) != true)
            {
                if (keystate.IsKeyDown(Keys.A) && collisionproof.CollisionCheck(position, 'l', playerheight, playerwidth) && keystate.IsKeyDown(Keys.D) != true)
                {
                    while (collisionproof.CollisionCheck(position, 'l', playerheight, playerwidth) && collisionproof.CollisionCheck(position, 't', playerheight, playerwidth) && pixel < speed)
                    {
                        if (collisionproof.CollisionCheck(position, 'l', playerheight, playerwidth))
                        {
                            position.X = Convert.ToInt32(position.X - 1);
                        }

                        if (collisionproof.CollisionCheck(position, 't', playerheight, playerwidth))
                        {
                            position.Y = Convert.ToInt32(position.Y + 1);
                        }

                        pixel++;
                    }
                }
                else if (keystate.IsKeyDown(Keys.D) && collisionproof.CollisionCheck(position, 'r', playerheight, playerwidth) && keystate.IsKeyDown(Keys.A) != true)
                {
                    while (collisionproof.CollisionCheck(position, 'r', playerheight, playerwidth) && collisionproof.CollisionCheck(position, 't', playerheight, playerwidth) && pixel < speed)
                    {
                        if (collisionproof.CollisionCheck(position, 'r', playerheight, playerwidth))
                        {
                            position.X = Convert.ToInt32(position.X + 1);
                        }

                        if (collisionproof.CollisionCheck(position, 't', playerheight, playerwidth))
                        {
                            position.Y = Convert.ToInt32(position.Y - 1);
                        }

                        pixel++;
                    }
                }
                else
                {
                    while (collisionproof.CollisionCheck(position, 't', playerheight, playerwidth) && pixel < speed)
                    {
                        position.Y = Convert.ToInt32(position.Y - 1);
                        pixel++;
                    }
                }
            }
        }
    }
}
