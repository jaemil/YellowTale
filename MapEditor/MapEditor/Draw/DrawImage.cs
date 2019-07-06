using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace MapEditor.Draw
{
    class DrawImage
    {
        public Bitmap bmGrid;

        private Graphics gBackground;
        private Graphics gLayer1;
        private Graphics gLayer2;
        private Graphics gLayer3;
        private Graphics gCollision;

        private int mouseX = 0, mouseY = 0;

        private int width = StaticMembers.DrawImageWidth, height = StaticMembers.DrawImageHeight;
        private int tileWidth = StaticMembers.tileWidth, tileHeight = StaticMembers.tileHeight;

        private int currentTileX, currentTileY;
        private int currentTileCollisionX, currentTileCollisionY;

        private Color gridColor;


        #region Properties
        public int MouseX
        {
            get { return mouseX; }
            set { mouseX = value; }
        }
        public int MouseY
        {
            get { return mouseY; }
            set { mouseY = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int TileWidth
        {
            get { return tileWidth; }
            set { tileWidth = value; }
        }
        public int TileHeight
        {
            get { return tileHeight; }
            set { tileHeight = value; }
        }
        public int CurrentTileX
        {
            get { return currentTileX; }
            set { currentTileX = value; }
        }
        public int CurrentTileY
        {
            get { return currentTileY; }
            set { currentTileY = value; }
        }
        public Color GridColor
        {
            get { return gridColor; }
            set { gridColor = value; }
        }
        public int CurrentTileCollisionX
        {
            get { return currentTileCollisionX; }
            set { currentTileCollisionX = value; }
        }
        public int CurrentTileCollisionY
        {
            get { return currentTileCollisionY; }
            set { currentTileCollisionY = value; }
        }

        #endregion

        public void ShowGrid()
        {
            int _width = Convert.ToInt32(Width * TileWidth + 1);
            int _height = Convert.ToInt32(Height * TileHeight + 1);


            bmGrid = new Bitmap(_width, _height);
            

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (x % TileWidth == 0 || y % TileHeight == 0)
                    {
                        bmGrid.SetPixel(x, y, GridColor);
                    }
                }
            }
        }

        public void MoveBitmap(int direction)//Left = 0, Right = 1, Up = 2, Down = 3
        {
            switch (direction)
            {
                case 0:
                    {
                        MouseX -= Convert.ToInt32(TileWidth);
                        break;
                    }
                case 1:
                    {
                        MouseX += Convert.ToInt32(TileWidth);
                        break;
                    }
                case 2:
                    {
                        MouseY -= Convert.ToInt32(TileHeight);
                        break;
                    }
                case 3:
                    {
                        MouseY += Convert.ToInt32(TileHeight);
                        break;
                    }
                case 4:
                    {
                        MouseX -= Convert.ToInt32(TileWidth / 2);
                        break;
                    }
                case 5:
                    {
                        MouseX += Convert.ToInt32(TileWidth / 2);
                        break;
                    }
                case 6:
                    {
                        MouseY -= Convert.ToInt32(TileHeight / 2);
                        break;
                    }
                case 7:
                    {
                        MouseY += Convert.ToInt32(TileHeight / 2);
                        break;
                    }
            }
        }


        private void DrawAlgorithm(bool mode, Bitmap bmLayer, Graphics gLayer)
        {
            try
            {
                Rectangle rect = new Rectangle(currentTileX * TileWidth, currentTileY * TileHeight, TileWidth, TileHeight);

                if (mode)//Draw
                {
                    gLayer = Graphics.FromImage(bmLayer);//Create Graphics from bmLayer

                    for (int x = currentTileX * TileWidth; x < currentTileX * TileWidth + TileWidth; x++)
                    {
                        for (int y = currentTileY * TileHeight; y < currentTileY * TileHeight + TileHeight; y++)
                        {
                            bmLayer.SetPixel(x, y, Color.Empty);//Clear Current Tile -> Color.Empty
                        }
                    }

                    gLayer.DrawImage(StaticMembers.bmSelectedTile, rect);//DrawImage from Selected File to bmLayer
                }
                else//Erase
                {
                    for (int x = currentTileX * TileWidth; x < currentTileX * TileWidth + TileWidth; x++)
                    {
                        for (int y = currentTileY * TileHeight; y < currentTileY * TileHeight + TileHeight; y++)
                        {
                            bmLayer.SetPixel(x, y, Color.Empty);//Clear Current Tile -> Color.Empty
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        
        public void DrawBackground(bool mode)//draw = true, erase = false 
        {
            if (StaticMembers.backgroundPath != null)//It can only be drawn if path is not empty
            {
                DrawAlgorithm(mode, StaticMembers.backgroundBitmap, gBackground);
            }
            else
            {
                MessageBox.Show("Please open a File");
            }
        }

        public void DrawLayer1(bool mode)
        {
            if (StaticMembers.layer1Path != null)
            {
                DrawAlgorithm(mode, StaticMembers.layer1Bitmap, gLayer1);
            }
            else
            {
                MessageBox.Show("Please open a File");
            }
        }

        public void DrawLayer2(bool mode)
        {
            if (StaticMembers.layer2Path != null)
            {
                DrawAlgorithm(mode, StaticMembers.layer2Bitmap, gLayer2);
            }
            else
            {
                MessageBox.Show("Please open a File");
            }
        }

        public void DrawLayer3(bool mode)
        {
            if (StaticMembers.layer3Path != null)
            {
                DrawAlgorithm(mode, StaticMembers.layer3Bitmap, gLayer3);
            }
            else
            {
                MessageBox.Show("Please open a File");
            }
        }

        public void DrawCollision(bool mode)
        {
            if (StaticMembers.collisionPath != null)
            {
                Rectangle rect = new Rectangle(currentTileX * (TileWidth/2), currentTileY * (TileHeight/2), (TileWidth / 2), (TileHeight / 2));

                if (mode)//Draw
                {
                    gCollision = Graphics.FromImage(StaticMembers.collisionBitmap);

                    for (int x = currentTileX * (TileWidth / 2); x < currentTileX * (TileWidth / 2) + (TileWidth / 2); x++)
                    {
                        for (int y = currentTileY * (TileHeight / 2); y < currentTileY * (TileHeight / 2) + (TileHeight / 2); y++)
                        {
                            StaticMembers.collisionBitmap.SetPixel(x, y, Color.Empty);
                        }
                    }

                    gCollision.DrawImage(StaticMembers.bmSelectedTile, rect);
                }
                else//Erase
                {
                    for (int x = currentTileX * (TileWidth / 2); x < currentTileX * (TileWidth / 2) + (TileWidth / 2); x++)
                    {
                        for (int y = currentTileY * (TileHeight / 2); y < currentTileY * (TileHeight / 2) + (TileHeight / 2); y++)
                        {
                            StaticMembers.collisionBitmap.SetPixel(x, y, Color.Empty);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please open a File");
            }
        }


        private void ImportAlgorithm(Bitmap bmLayer, Graphics gLayer, int[,] arrLayer)
        {
            Graphics g = Graphics.FromImage(StaticMembers.bmSelectedTile);//Create Graphics from bmSelectedTile 
            Rectangle rectTile;//Rectangle for the TileMap
            Rectangle rectMap;//Rectangele for the Map

            gLayer.Clear(Color.Transparent);//Reset bmLayer

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    rectMap = new Rectangle(x * TileWidth, y * TileHeight, TileWidth, TileHeight);
                    rectTile = new Rectangle(Convert.ToInt32(arrLayer[x, y] % 4) * TileWidth,
                        Convert.ToInt32(arrLayer[x, y] / 4) * TileHeight, TileWidth, TileHeight);//ID % 4 -> x, Convert.ToInt32(ID / 4) -> y

                    g.DrawImage(StaticMembers.bmTileMap, rectTile);
                    StaticMembers.bmSelectedTile = new Bitmap(StaticMembers.bmTileMap.Clone(rectTile, StaticMembers.bmTileMap.PixelFormat));
                    gLayer.DrawImage(StaticMembers.bmSelectedTile, rectMap);
                }
            }
        }

        public void ImportBackground(bool mode)//draw = true, reset = false
        {
            gBackground = Graphics.FromImage(StaticMembers.backgroundBitmap);

            if (mode)
            {
                ImportAlgorithm(StaticMembers.backgroundBitmap, gBackground, StaticMembers.backgroundArray);
            }
            else
            {
                gBackground.Clear(Color.Transparent);
            }
            
        }

        public void ImportLayer1(bool mode)//draw = true, reset = false
        {
            gLayer1 = Graphics.FromImage(StaticMembers.layer1Bitmap);
            if (mode)
            {
                ImportAlgorithm(StaticMembers.layer1Bitmap, gLayer1, StaticMembers.layer1Array);
            }
            else
            {
                gLayer1.Clear(Color.Transparent);
            }
            
        }

        public void ImportLayer2(bool mode)//draw = true, reset = false
        {
            gLayer2 = Graphics.FromImage(StaticMembers.layer2Bitmap);

            if (mode)
            {
                ImportAlgorithm(StaticMembers.layer2Bitmap, gLayer2, StaticMembers.layer2Array);
            }
            else
            {
                gLayer2.Clear(Color.Transparent);
            }
            
        }

        public void ImportLayer3(bool mode)//draw = true, reset = false
        {
            gLayer3 = Graphics.FromImage(StaticMembers.layer3Bitmap);

            if (mode)
            {
                ImportAlgorithm(StaticMembers.layer3Bitmap, gLayer3, StaticMembers.layer3Array);
            }
            else
            {
                gLayer3.Clear(Color.Transparent);
            }

        }

        public void ImportCollision(bool mode)//draw = true, reset = false
        {
            gCollision = Graphics.FromImage(StaticMembers.collisionBitmap);
            if (mode)
            {
                Graphics g = Graphics.FromImage(StaticMembers.bmSelectedTile);//Create Graphics from bmCollision 
                Rectangle rectTile;//Rectangle for the TileMap
                Rectangle rectMap;//Rectangele for the Map

                gCollision.Clear(Color.Transparent);//Reset bmCollision

                for (int y = 0; y < Height *2; y++)
                {
                    for (int x = 0; x < Width * 2; x++)
                    {
                        rectMap = new Rectangle(x * (TileWidth/2), y * (TileHeight/2), TileWidth / 2, TileHeight / 2);
                        rectTile = new Rectangle(Convert.ToInt32(StaticMembers.collisionArray[x, y] % 4) * TileWidth,
                            Convert.ToInt32(StaticMembers.collisionArray[x, y] / 4) * TileHeight, TileWidth, TileHeight);//ID % 4 -> x, Convert.ToInt32(ID / 4) -> y

                        g.DrawImage(Collision.CollisionTileSet, rectTile);
                        StaticMembers.bmSelectedTile = new Bitmap(Collision.CollisionTileSet.Clone(rectTile, Collision.CollisionTileSet.PixelFormat));
                        gCollision.DrawImage(StaticMembers.bmSelectedTile, rectMap);
                    }
                }
            }
            else
            {
                gCollision.Clear(Color.Transparent);//Reset bmCollision
            }

        }
    }
}
