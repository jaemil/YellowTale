using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace MapEditor.Layers
{
    class Collision
    {
        Draw.DrawImage drawImage = new Draw.DrawImage();
        Tiles.TileMap tileMap = new Tiles.TileMap();

        private int tileX, tileY;
        private int tileID;

        #region Properties

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
        public int TileID
        {
            get { return tileID; }
            set { tileID = value; }
        }

        #endregion

        #region Methods

        public void WriteArray()
        {
            try
            {
                StaticMembers.collisionArray[TileX, TileY] = Convert.ToInt32(TileID);
            }
            catch (Exception)
            {

            }
        }

        public void EraseArray()
        {
            try
            {
                StaticMembers.collisionArray[TileX, TileY] = 0;
            }
            catch (Exception)
            {
            }
        }

        public void ResetArray()
        {
            for (int y = 0; y < drawImage.Height * 2; y++)
            {
                for (int x = 0; x < drawImage.Width * 2; x++)
                {
                    StaticMembers.collisionArray[x, y] = 0;
                }
            }
        }

        #endregion
    }
}
