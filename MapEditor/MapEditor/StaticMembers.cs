using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapEditor
{
    public static class StaticMembers
    {
        //MAP
        public static int DrawImageWidth = 30, DrawImageHeight = 17;//[drawImage.Width, drawImage.Height] -> must be the same value
        public static int tileWidth = 64, tileHeight = 64;//[drawImage.tileWidth, drawImage.tileHeight] -> must be the same value


        public static int[,] backgroundArray = new int[DrawImageWidth, DrawImageHeight];
        public static string backgroundPath;
        public static Bitmap backgroundBitmap = new Bitmap(DrawImageWidth * tileWidth, DrawImageHeight * tileHeight);

        public static int[,] layer1Array = new int[DrawImageWidth, DrawImageHeight];
        public static string layer1Path;
        public static Bitmap layer1Bitmap = new Bitmap(DrawImageWidth * tileWidth, DrawImageHeight * tileHeight);

        public static int[,] layer2Array = new int[DrawImageWidth, DrawImageHeight];
        public static string layer2Path;
        public static Bitmap layer2Bitmap = new Bitmap(DrawImageWidth * tileWidth, DrawImageHeight * tileHeight);

        public static int[,] layer3Array = new int[DrawImageWidth, DrawImageHeight];
        public static string layer3Path;
        public static Bitmap layer3Bitmap = new Bitmap(DrawImageWidth * tileWidth, DrawImageHeight * tileHeight);

        public static int[,] collisionArray = new int[DrawImageWidth * 2, DrawImageHeight * 2];
        public static string collisionPath;
        public static Bitmap collisionBitmap = new Bitmap(DrawImageWidth * tileWidth, DrawImageHeight * tileHeight);


        //TileMap
        public static int[,] tileMapArray = new int[4, 200];//[tileMap.Width, tileMap.Height]
        public static Bitmap bmSelectedTile;
        public static Bitmap bmTileMap;
    }
}
