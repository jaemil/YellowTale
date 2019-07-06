using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.Layers
{
    class Layer2
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
                StaticMembers.layer2Array[TileX, TileY] = Convert.ToInt32(TileID);
            }
            catch (Exception)
            {

            }
        }

        public void EraseArray()
        {
            try
            {
                StaticMembers.layer2Array[TileX, TileY] = 0;
            }
            catch (Exception)
            {
            }
        }

        public void ResetArray()
        {
            for (int y = 0; y < drawImage.Height; y++)
            {
                for (int x = 0; x < drawImage.Width; x++)
                {
                    StaticMembers.layer2Array[x, y] = 0;
                }
            }
        }

        #endregion
    }
}
