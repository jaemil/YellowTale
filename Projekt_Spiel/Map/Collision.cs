using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YellowTale
{
    class Collision
    {

        private int[,] CollisionLayer = new int[60, 34];


        Vector2 topleft, topright; //Obere Ecken der Hitbox
        Vector2 bottomleft, bottomright; //Untere Ecken der Hitbox
        Vector2 midright, midleft, midbottom, midtop;
        Vector2 bulletEdge1, bulletEdge2, VectorEdges;

        public string MapPath;

        public void Read_Collision()
        {
            int readerchar = 0;
            string CollisionReader;

            Clear_Layer();
            StreamReader reader = new StreamReader(MapPath);
            CollisionReader = reader.ReadToEnd();
            reader.Close();

            for (int y = 0; y < 34; y++)
            {
                for (int x = 0; x < 60; x++)
                {
                    if (CollisionReader[readerchar] != 32 && CollisionReader[readerchar] != 13 && CollisionReader[readerchar] != 10 && (CollisionReader[readerchar] != 32 && CollisionReader[readerchar + 1] != 13 || CollisionReader[readerchar + 1] != 10))
                    {

                    }
                    else if (CollisionReader[readerchar] == 13 && CollisionReader[readerchar + 1] == 10)
                    {
                        readerchar += 2;
                    }
                    else
                    {
                        readerchar++;
                    }

                    while (CollisionReader[readerchar] != 32 && CollisionReader[readerchar] != 13 && CollisionReader[readerchar] != 10)
                    {
                        switch (CollisionReader[readerchar])
                        {
                            case '1':
                                CollisionLayer[x, y] = CollisionLayer[x, y] * 10 + 1;
                                break;
                            case '2':
                                CollisionLayer[x, y] = CollisionLayer[x, y] * 10 + 2;
                                break;
                            case '3':
                                CollisionLayer[x, y] = CollisionLayer[x, y] * 10 + 3;
                                break;
                            case '4':
                                CollisionLayer[x, y] = CollisionLayer[x, y] * 10 + 4;
                                break;
                            case '5':
                                CollisionLayer[x, y] = CollisionLayer[x, y] * 10 + 5;
                                break;
                            case '6':
                                CollisionLayer[x, y] = CollisionLayer[x, y] * 10 + 6;
                                break;
                            case '7':
                                CollisionLayer[x, y] = CollisionLayer[x, y] * 10 + 7;
                                break;
                            case '8':
                                CollisionLayer[x, y] = CollisionLayer[x, y] * 10 + 8;
                                break;
                            case '9':
                                CollisionLayer[x, y] = CollisionLayer[x, y] * 10 + 9;
                                break;
                            case '0':
                                CollisionLayer[x, y] *= 10;
                                break;

                            default:
                                break;
                        }

                        if (readerchar + 1 < CollisionReader.Length)
                        {
                            readerchar++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    readerchar++;
                }
            }
            readerchar = 0;


        }

        public bool CollisionCheck(Vector2 position, char cSide, int height, int width)
        {
            topleft = Vector2.Zero;
            topright = Vector2.Zero;
            bottomleft = Vector2.Zero;
            bottomright = Vector2.Zero;
            midright = Vector2.Zero;
            midleft = Vector2.Zero;

            topleft.X = position.X;
            topleft.Y = position.Y;

            topright.Y = position.Y;
            topright.X = position.X + (width - 1); //32 = Spielerbreite - 1 um Array [0] bis [59] anpsprechen zu können 

            bottomleft.Y = position.Y + (height - 1);
            bottomleft.X = position.X;

            bottomright.Y = position.Y + (height - 1);
            bottomright.X = position.X + (width - 1);

            if (height > 32)
            {
                midleft.X = topleft.X;
                midleft.Y = topleft.Y + 32;
                midright.X = topright.X;
                midright.Y = topright.Y + 32;
            }
            else
            {
                midleft = bottomleft;
                midright = bottomright;
            }

            if (width > 32)
            {
                midbottom.X = bottomleft.X + 32;
                midbottom.Y = bottomleft.Y;
                midtop.X = topleft.X + 32;
                midtop.Y = topleft.Y;
            }
            else
            {
                midtop = topright;
                midbottom = bottomright;
            }

            /*  cSide = t/r/b/l
                t = top
                r = right
                b = bottom
                l = left         */

            if (cSide == 't')
            {
                if (topleft.Y % 32 == 0)
                {
                    if ((int)((topleft.Y / 32) - 1) != -1)
                    {
                        if ((CollisionLayer[(int)(topleft.X / 32), (int)(topleft.Y / 32) - 1] == 1) || (CollisionLayer[(int)(topright.X / 32), (int)(topright.Y / 32) - 1] == 1 || CollisionLayer[(int)(topleft.X / 32), (int)(topleft.Y / 32) - 1] == 2) 
                            || (CollisionLayer[(int)(topright.X / 32), (int)(topright.Y / 32) - 1] == 2))
                        {
                            return false;
                        }
                        else
                        {
                            while (midtop.X < topright.X)
                            {
                                if ((CollisionLayer[(int)(midtop.X / 32), (int)(midtop.Y / 32) - 1] == 1) || (CollisionLayer[(int)(midtop.X / 32), (int)(midtop.Y / 32) - 1] == 2))
                                {
                                    return false;
                                }

                                midtop.X += 32;                                
                            }

                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (cSide == 'r')
            {
                if ((width % 32) != 0)
                {
                    if (topleft.X % 32 == Math.Abs(32 - (width % 32)))
                    {
                        if ((int)((topright.X / 32) + 1) <= 59) //59 max Arraygröße
                        {
                            if ((CollisionLayer[(int)(topright.X / 32) + 1, (int)(topright.Y / 32)] == 1) || (CollisionLayer[(int)(bottomright.X / 32) + 1, (int)(bottomright.Y / 32)] == 1)
                                 || (CollisionLayer[(int)(topright.X / 32) + 1, (int)(topright.Y / 32)] == 2) || (CollisionLayer[(int)(bottomright.X / 32) + 1, (int)(bottomright.Y / 32)] == 2))
                            {
                                return false;
                            }
                            else
                            {
                                while (midright.Y < bottomright.Y)
                                {
                                    if ((CollisionLayer[(int)(midright.X / 32) + 1, (int)(midright.Y / 32)] == 1) || (CollisionLayer[(int)(midright.X / 32) + 1, (int)(midright.Y / 32)] == 2))
                                    {
                                        return false;
                                    }

                                    midright.Y += 32;                                    
                                }

                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if (topleft.X % 32 == 0)
                    {
                        if ((int)((topright.X / 32) + 1) <= 59) //59 max Arraygröße
                        {
                            if ((CollisionLayer[(int)(topright.X / 32) + 1, (int)(topright.Y / 32)] == 1) || (CollisionLayer[(int)(bottomright.X / 32) + 1, (int)(bottomright.Y / 32)] == 1) || (CollisionLayer[(int)(midright.X / 32) + 1, (int)(midright.Y / 32)] == 1 || CollisionLayer[(int)(topright.X / 32) + 1, (int)(topright.Y / 32)] == 2) || (CollisionLayer[(int)(bottomright.X / 32) + 1, (int)(bottomright.Y / 32)] == 2) || (CollisionLayer[(int)(midright.X / 32) + 1, (int)(midright.Y / 32)] == 2))
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else if (cSide == 'b')
            {
                if ((height % 32) != 0)
                {
                    if (topleft.Y % 32 == Math.Abs(32 - (height % 32)))
                    {
                        if ((int)((bottomright.Y / 32) + 1) <= 33) //31 max Arraygröße
                        {
                            if ((CollisionLayer[(int)(bottomleft.X / 32), (int)(bottomleft.Y / 32) + 1] == 1) || (CollisionLayer[(int)(bottomright.X / 32), (int)(bottomright.Y / 32) + 1] == 1 || CollisionLayer[(int)(bottomleft.X / 32), (int)(bottomleft.Y / 32) + 1] == 2) || (CollisionLayer[(int)(bottomright.X / 32), (int)(bottomright.Y / 32) + 1] == 2))
                            {
                                return false;
                            }
                            else
                            {
                                while (midbottom.X < bottomright.X)
                                {
                                    if ((CollisionLayer[(int)(midbottom.X / 32), (int)(midbottom.Y / 32) - 1] == 1) || (CollisionLayer[(int)(midbottom.X / 32), (int)(midbottom.Y / 32) - 1] == 2))
                                    {
                                        return false;
                                    }

                                    midbottom.X += 32;
                                }

                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if (topleft.Y % 32 == 0)
                    {
                        if ((int)((bottomright.Y / 32) + 1) <= 33) //31 max Arraygröße
                        {
                            if ((CollisionLayer[(int)(bottomleft.X / 32), (int)(bottomleft.Y / 32) + 1] == 1) || (CollisionLayer[(int)(bottomright.X / 32), (int)(bottomright.Y / 32) + 1] == 1 || CollisionLayer[(int)(bottomleft.X / 32), (int)(bottomleft.Y / 32) + 1] == 2) || (CollisionLayer[(int)(bottomright.X / 32), (int)(bottomright.Y / 32) + 1] == 2))
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else if (cSide == 'l')
            {
                if (topleft.X % 32 == 0)
                {
                    if ((int)((topleft.X / 32) - 1) != -1)
                    {
                        if ((CollisionLayer[(int)(topleft.X / 32) - 1, (int)(topleft.Y / 32)] == 1) || (CollisionLayer[(int)(bottomleft.X / 32) - 1, (int)(bottomleft.Y / 32)] == 1) || (CollisionLayer[(int)(midleft.X / 32) - 1, (int)(midleft.Y / 32)] == 1 || CollisionLayer[(int)(topleft.X / 32) - 1, (int)(topleft.Y / 32)] == 2) || (CollisionLayer[(int)(bottomleft.X / 32) - 1, (int)(bottomleft.Y / 32)] == 2) || (CollisionLayer[(int)(midleft.X / 32) - 1, (int)(midleft.Y / 32)] == 2))
                        {
                            return false;
                        }
                        else
                        {
                            while (midleft.Y < bottomleft.Y)
                            {
                                if ((CollisionLayer[(int)(midleft.X / 32) - 1, (int)(midleft.Y / 32)] == 1) || (CollisionLayer[(int)(midleft.X / 32) - 1, (int)(midleft.Y / 32)] == 2))
                                {
                                    return false;
                                }

                                midleft.Y += 32;
                            }

                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }


        public bool BulletCollision(Vector2 position, int height, int width, float rotation)
        {
            int winkel = (int)MathHelper.ToDegrees(rotation);

            if (winkel >= -45 && winkel <= 45)
            {
                bulletEdge1 = new Vector2(position.X + width, position.Y);
                bulletEdge2 = new Vector2(position.X + width, position.Y + height);
            }
            else if (winkel >= -135 && winkel <= -45)
            {
                bulletEdge1 = new Vector2(position.X, position.Y - height);
                bulletEdge2 = new Vector2(position.X + height, position.Y - width);
            }
            else if (winkel <= 135 && winkel >= 45)
            {
                bulletEdge1 = new Vector2(position.X, position.Y + height);
                bulletEdge2 = new Vector2(position.X - height, position.Y + width);
            }
            else if (winkel <= -135 && winkel >= 135)
            {
                bulletEdge1 = new Vector2(position.X - width, position.Y - height);
                bulletEdge2 = new Vector2(position.X - width, position.Y);
            }
            else
            {
                bulletEdge1 = new Vector2(position.X, position.Y - height);
                bulletEdge2 = new Vector2(position.X + height, position.Y - width);
            }


            VectorEdges = bulletEdge1;
            VectorEdges = Vector2.Transform(VectorEdges, Matrix.CreateRotationX(rotation));
            bulletEdge1.X = Math.Abs(VectorEdges.X);
            VectorEdges = bulletEdge1;
            VectorEdges = Vector2.Transform(VectorEdges, Matrix.CreateRotationY(rotation));
            bulletEdge1.Y = Math.Abs(VectorEdges.Y);

            VectorEdges = bulletEdge2;
            VectorEdges = Vector2.Transform(VectorEdges, Matrix.CreateRotationX(rotation));
            bulletEdge2.X = Math.Abs(VectorEdges.X);
            VectorEdges = bulletEdge1;
            VectorEdges = Vector2.Transform(VectorEdges, Matrix.CreateRotationY(rotation));
            bulletEdge2.Y = Math.Abs(VectorEdges.Y);

            if (bulletEdge1.Y < 1080 && bulletEdge2.Y < 1080 && bulletEdge1.X < 1920 && bulletEdge2.X < 1920)
            {
                if (CollisionLayer[(int)bulletEdge1.X / 32, (int)bulletEdge1.Y / 32] == 1 || CollisionLayer[(int)bulletEdge2.X / 32, (int)bulletEdge2.Y / 32] == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool KnockbackCollision(Vector2 position, int height, int width)
        {
            topleft = Vector2.Zero;
            topright = Vector2.Zero;
            bottomleft = Vector2.Zero;
            bottomright = Vector2.Zero;
            midright = Vector2.Zero;
            midleft = Vector2.Zero;

            topleft.X = position.X;
            topleft.Y = position.Y;

            topright.Y = position.Y;
            topright.X = position.X + (width - 1); //32 = Spielerbreite - 1 um Array [0] bis [59] anpsprechen zu können 

            bottomleft.Y = position.Y + (height - 1);
            bottomleft.X = position.X;

            bottomright.Y = position.Y + (height - 1);
            bottomright.X = position.X + (width - 1);

            if (height > 32)
            {
                midleft.X = topleft.X;
                midleft.Y = topleft.Y + 32;
                midright.X = topright.X;
                midright.Y = topright.Y + 32;
            }
            else
            {
                midleft = bottomleft;
                midright = bottomright;
            }

            if (width > 32)
            {
                midbottom.X = bottomleft.X + 32;
                midbottom.Y = bottomleft.Y;
                midtop.X = topleft.X + 32;
                midtop.Y = topleft.Y;
            }
            else
            {
                midtop = topright;
                midbottom = bottomright;
            }

            if (CollisionLayer[(int)(topleft.X / 32), (int)(topleft.Y / 32)] == 2 || CollisionLayer[(int)(topright.X / 32), (int)(topright.Y / 32)] == 2 || CollisionLayer[(int)(topright.X / 32), (int)(topright.Y / 32)] == 2 ||
                CollisionLayer[(int)(bottomleft.X / 32), (int)(bottomleft.Y / 32)] == 2 || CollisionLayer[(int)(bottomright.X / 32), (int)(bottomright.Y / 32)] == 2 || CollisionLayer[(int)(topleft.X / 32), (int)(topleft.Y / 32)] == 1 
                || CollisionLayer[(int)(topright.X / 32), (int)(topright.Y / 32)] == 1 || CollisionLayer[(int)(topright.X / 32), (int)(topright.Y / 32)] == 1 ||
                CollisionLayer[(int)(bottomleft.X / 32), (int)(bottomleft.Y / 32)] == 1 || CollisionLayer[(int)(bottomright.X / 32), (int)(bottomright.Y / 32)] == 1)
            {
                return false;
            }
            else
            {
                while (midleft.Y < bottomleft.Y)
                {
                    if ((CollisionLayer[(int)(midleft.X / 32) - 1, (int)(midleft.Y / 32)] == 1) || (CollisionLayer[(int)(midleft.X / 32) - 1, (int)(midleft.Y / 32)] == 2))
                    {
                        return false;
                    }

                    midleft.Y += 32;
                }

                while (midbottom.X < bottomright.X)
                {
                    if ((CollisionLayer[(int)(midbottom.X / 32), (int)(midbottom.Y / 32) - 1] == 1) || (CollisionLayer[(int)(midbottom.X / 32), (int)(midbottom.Y / 32) - 1] == 2))
                    {
                        return false;
                    }

                    midbottom.X += 32;
                }

                while (midright.Y < bottomright.Y)
                {
                    if ((CollisionLayer[(int)(midright.X / 32) + 1, (int)(midright.Y / 32)] == 1) || (CollisionLayer[(int)(midright.X / 32) + 1, (int)(midright.Y / 32)] == 2))
                    {
                        return false;
                    }

                    midright.Y += 32;
                }

                while (midtop.X < topright.X)
                {
                    if ((CollisionLayer[(int)(midtop.X / 32), (int)(midtop.Y / 32) - 1] == 1) || (CollisionLayer[(int)(midtop.X / 32), (int)(midtop.Y / 32) - 1] == 2))
                    {
                        return false;
                    }

                    midtop.X += 32;
                }

                return true;
            }
        }

        public int MapChangeCheck(ref Vector2 position, int height, int width, Vector2 rightChange = default(Vector2), Vector2 leftChange = default(Vector2), Vector2 topChange = default(Vector2), Vector2 botChange = default(Vector2))
        {
            topleft = Vector2.Zero;
            topright = Vector2.Zero;
            bottomleft = Vector2.Zero;
            bottomright = Vector2.Zero;

            topleft.X = position.X;
            topleft.Y = position.Y;

            topright.Y = position.Y;
            topright.X = position.X + (width - 1); //32 = Spielerbreite - 1 um Array [0] bis [59] anpsprechen zu können 

            bottomleft.Y = position.Y + (height - 1);
            bottomleft.X = position.X;

            bottomright.Y = position.Y + (height - 1);
            bottomright.X = position.X + (width - 1);

            if (CollisionLayer[(int)topleft.X / 32, (int)topleft.Y / 32] == 3)
            {
                if (topChange == default(Vector2))
                {
                    position = new Vector2(position.X, 1080 - 96);
                }
                else
                {
                    position = topChange;
                }

                return 3;
            }
            else if (CollisionLayer[(int)topleft.X / 32, (int)topleft.Y / 32] == 6)
            {
                if (leftChange == default(Vector2))
                {
                    position = new Vector2(1920 - 64, position.Y);
                }
                else
                {
                    position = leftChange;
                }

                return 6;
            }
            else if (CollisionLayer[(int)topright.X / 32, (int)topright.Y / 32] == 5)
            {
                if (rightChange == default(Vector2))
                {
                    position = new Vector2(0 + 32, position.Y);
                }
                else
                {
                    position = rightChange;
                }

                return 5;
            }
            else if (CollisionLayer[(int)bottomright.X / 32, (int)bottomright.Y / 32] == 4)
            {
                if (botChange == default(Vector2))
                {
                    position = new Vector2(position.X, 0 + 48);
                }
                else
                {
                    position = botChange;
                }

                return 4;
            }
            else
            {
            }

            return 0;
        }
       
        private void Clear_Layer()
        {
            for (int q = 0; q < 34; q++)
            {
                for (int qq = 0; qq < 60; qq++)
                {
                    CollisionLayer[qq, q] = 0;
                }
            }
        }

    }
}