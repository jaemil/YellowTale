using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor.Tiles
{
    class TileMap
    {
        public Bitmap bmCollisionTileSet;

        private int mouseX = 0, mouseY = 0;
        private int tileX, tileY;
        private int id = 0;

        private int currentTileX, currentTileY;

        private int width, height;
        private int tileWidth = 64, tileHeight = 64;

        public bool collisionChecked;

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

        public int TileX
        {
            get { return tileX; }
            set { tileX = value; }
        }
        public int TileY
        {
            get { return tileY; }
            set { tileY = value; }
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
        public int ID
        {
            get { return id; }
            set { id = value; }
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

        #endregion

        #region Methods

        public void DrawTileMap()
        {
            int i = 0;

            MainWindow mainWindow = new MainWindow();
            if (mainWindow.openFileDialogOpenTileSet.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StaticMembers.bmTileMap = new Bitmap(mainWindow.openFileDialogOpenTileSet.FileName);
            }
            else
            {
                StaticMembers.bmTileMap = new Bitmap(Collision.Clear);
            }

            bmCollisionTileSet = Collision.CollisionTileSet;

            Width = StaticMembers.bmTileMap.Width / tileWidth;
            Height = StaticMembers.bmTileMap.Height / tileHeight;


            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    StaticMembers.tileMapArray[x, y] = i;
                    i++;
                }
            }
        }

        public int TileID()
        {
            try
            {
                id = StaticMembers.tileMapArray[TileX, TileY];
                CurrentTileX = TileX;
                CurrentTileY = TileY;
            }
            catch (Exception)
            {
                throw;
            }
            return id;
        }

        public void DrawSelectedTile()
        {
            try
            {
                Rectangle rectangle = new Rectangle(CurrentTileX * TileWidth, CurrentTileY * TileHeight, TileWidth, TileHeight);

                if (collisionChecked)
                {
                    StaticMembers.bmSelectedTile = new Bitmap(bmCollisionTileSet.Clone(rectangle, bmCollisionTileSet.PixelFormat));
                }
                else
                {
                    StaticMembers.bmSelectedTile = new Bitmap(StaticMembers.bmTileMap.Clone(rectangle, StaticMembers.bmTileMap.PixelFormat));
                }
            }
            catch (Exception)
            {
            }
        }

        public void FillAllTiles(int mode)//0 = background, 1 = layer1, 2 = layer2, 3 = layer3, 4 = collision
        {
            Width = StaticMembers.backgroundBitmap.Width / tileWidth;
            Height = StaticMembers.backgroundBitmap.Height / tileHeight;

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    switch (mode)
                    {
                        case 0:
                            StaticMembers.backgroundArray[x, y] = id;
                            break;
                        case 1:
                            StaticMembers.layer1Array[x, y] = id;
                            break;
                        case 2:
                            StaticMembers.layer2Array[x, y] = id;
                            break;
                        case 3:
                            StaticMembers.layer3Array[x, y] = id;
                            break;
                        case 4:
                            StaticMembers.collisionArray[x, y] = id;
                            break;
                    }
                }
            }
        }

        #endregion
    }
}
