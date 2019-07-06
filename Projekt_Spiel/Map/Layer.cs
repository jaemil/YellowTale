using System;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YellowTale
{
    class Layer
    {
        private int vtileWidth;
        private int vtileHeight;
        private int vWidth;
        private int vHeight;
        public Matrix scaling;

        private int[,] MapLayer; //Int Array für Texturenid's

        public string path = @"";

        int frame; //Animationframe für Frame in der Bildfolge
        Animations animation1 = new Animations();
        Animations animation2 = new Animations();
        Animations animation3 = new Animations();
        Animations animation4 = new Animations();
        Animations animation5 = new Animations();
        Animations animation6 = new Animations();
        Animations animation7 = new Animations();
        Animations animation8 = new Animations();
        Animations animation9 = new Animations();
        Animations animation10 = new Animations();
        Animations animation11 = new Animations();
        Animations animation12 = new Animations();
        Animations animation13 = new Animations();


        public Texture2D[] texturen = new Texture2D[336];

        public Texture2D missingtexture;
        
        public bool SpawnObject = true;
        

        public Layer()
        {
            vtileWidth = 64; //Tile = 64 Pixel
            vtileHeight = 64;
            vWidth = 30;
            vHeight = 17;

            MapLayer = new int[vWidth, vHeight];
        }

        

        public void draw(SpriteBatch spritebatch, GameTime gameTime, ObjectManager objectManager, EnemyManager enemyManager, NPCManager nPCManager, HUD hUD, Player _player)
        {

            Vector2 tilePosition = Vector2.Zero; // Startpunkt bei 0,0

            spritebatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, scaling);

            for (int x = 0; x < vWidth; x++) //vWidth = Mapbreite (X)
            {
                for (int y = 0; y < vHeight; y++) //vHeight = Maphöhe (Y)
                {
                    //umcodierung

                    if (MapLayer[x, y] > 0)
                    {
                        if (MapLayer[x, y] != 1 && MapLayer[x, y] != 2 && MapLayer[x, y] != 3 && MapLayer[x, y] != 4 && MapLayer[x, y] != 5 && MapLayer[x, y] != 6 && MapLayer[x, y] != 7 && MapLayer[x, y] != 8 && MapLayer[x, y] != 9 && MapLayer[x, y] != 10 
                            && MapLayer[x, y] != 11 && MapLayer[x, y] != 12 && MapLayer[x, y] != 13 && MapLayer[x, y] != 14 && MapLayer[x, y] != 15 && MapLayer[x, y] != 16 && MapLayer[x, y] != 17 && MapLayer[x, y] != 18 && MapLayer[x, y] != 19 && MapLayer[x, y] != 20 
                            && MapLayer[x, y] != 21 && MapLayer[x, y] != 22 && MapLayer[x, y] != 23 && MapLayer[x, y] != 24 && MapLayer[x, y] != 25 && MapLayer[x, y] != 26 && MapLayer[x, y] != 27 && MapLayer[x, y] != 28 && MapLayer[x, y] != 29 && MapLayer[x, y] != 30 
                            && MapLayer[x, y] != 31 && MapLayer[x, y] != 32 && MapLayer[x, y] != 33 && MapLayer[x, y] != 34 && MapLayer[x, y] != 36 && MapLayer[x, y] != 38 && MapLayer[x, y] != 40 
                            && MapLayer[x, y] != 41 && MapLayer[x, y] != 42 && MapLayer[x, y] != 43 && MapLayer[x, y] != 44 && MapLayer[x, y] != 45 && MapLayer[x, y] != 46 && MapLayer[x, y] != 47
                            && MapLayer[x, y] != 222 && MapLayer[x, y] != 223 && MapLayer[x, y] != 224 && MapLayer[x, y] != 225 && MapLayer[x, y] != 226 && MapLayer[x, y] != 228 && MapLayer[x, y] != 229 && MapLayer[x, y] != 227)
                        {
                            spritebatch.Draw(texturen[MapLayer[x, y]], tilePosition, Color.White);
                        }
                        else if (MapLayer[x, y] == 1)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnOrc(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 2)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnOrcMasked(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 3)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnShaman(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 4)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnZombieBig(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 5)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnZombieTiny(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 6)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnZombie(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 7)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnSkeleton(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 8)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnIceZombie1(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 9)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnIceZombie2(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 10)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnGoblin(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 11)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnNecromancer(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 12)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnDemonBig(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 13)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnChort(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 14)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnImp(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 15)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnWogol(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 16)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnMuddy(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 17)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnSwampy(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 18)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnOgre(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 19)
                        {
                            if (SpawnObject)
                            {
                                nPCManager.SpawnTutorialNPC(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 20)
                        {
                            if (SpawnObject)
                            {
                                nPCManager.SpawnShopNPC(tilePosition, hUD, _player);
                            }
                        }
                        else if (MapLayer[x, y] == 21)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnEgg(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 22)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnYeti(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 23)
                        {
                            if (SpawnObject)
                            {
                                enemyManager.SpawnDemon(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 24)
                        {
                            if (SpawnObject)
                            {
                                objectManager.SpawnDynamit(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 25)
                        {
                            if (SpawnObject)
                            {
                                objectManager.SpawnTrap(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 26)
                        {
                            if (SpawnObject)
                            {
                                objectManager.SpawnChest(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 27)
                        {
                            if (SpawnObject)
                            {
                                objectManager.SpawnHourglass(tilePosition);
                            }
                        }
                        else if (MapLayer[x, y] == 28)
                        {
                            if (SpawnObject)
                            {
                                objectManager.SpawnArrowTrap(tilePosition, 0);
                            }
                        }
                        else if (MapLayer[x, y] == 29)
                        {
                            if (SpawnObject)
                            {
                                objectManager.SpawnArrowTrap(tilePosition, 1);
                            }
                        }
                        else if (MapLayer[x, y] == 30)
                        {
                            if (SpawnObject)
                            {
                                objectManager.SpawnArrowTrap(tilePosition, 2);
                            }
                        }
                        else if (MapLayer[x, y] == 31)
                        {
                            if (SpawnObject)
                            {
                                objectManager.SpawnArrowTrap(tilePosition, 3);
                            }
                        }
                        else if (MapLayer[x, y] == 32)//Wasser
                        {
                            animation1.drawanimation(texturen[32], tilePosition, spritebatch, animation1.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 33)
                        {
                            animation2.drawanimation(texturen[33], tilePosition, spritebatch, animation2.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 34)
                        {
                            animation3.drawanimation(texturen[34], tilePosition, spritebatch, animation3.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 36)
                        {
                            animation4.drawanimation(texturen[36], tilePosition, spritebatch, animation4.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 38)
                        {
                            animation5.drawanimation(texturen[38], tilePosition, spritebatch, animation5.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 40)
                        {
                            animation7.drawanimation(texturen[40], tilePosition, spritebatch, animation7.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 41)
                        {
                            animation8.drawanimation(texturen[41], tilePosition, spritebatch, animation8.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 42)
                        {
                            animation9.drawanimation(texturen[42], tilePosition, spritebatch, animation9.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 43)
                        {

                        }
                        else if (MapLayer[x, y] == 44)//Torch
                        {
                            animation10.drawanimation(texturen[44], tilePosition, spritebatch, animation10.getanimation(gameTime, 8, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 45)
                        {
                            animation11.drawanimation(texturen[45], tilePosition, spritebatch, animation11.getanimation(gameTime, 8, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 46)
                        {
                            animation12.drawanimation(texturen[46], tilePosition, spritebatch, animation12.getanimation(gameTime, 8, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 47)
                        {
                            animation13.drawanimation(texturen[47], tilePosition, spritebatch, animation13.getanimation(gameTime, 8, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 222)//Lava
                        {
                            animation1.drawanimation(texturen[222], tilePosition, spritebatch, animation1.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 223)
                        {
                            animation2.drawanimation(texturen[223], tilePosition, spritebatch, animation2.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 224)
                        {
                            animation3.drawanimation(texturen[224], tilePosition, spritebatch, animation3.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 225)
                        {
                            animation4.drawanimation(texturen[225], tilePosition, spritebatch, animation4.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 226)
                        {
                            animation5.drawanimation(texturen[226], tilePosition, spritebatch, animation5.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 227)
                        {
                            animation7.drawanimation(texturen[227], tilePosition, spritebatch, animation7.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 228)
                        {
                            animation8.drawanimation(texturen[228], tilePosition, spritebatch, animation8.getanimation(gameTime, 16, 4), 64, 64);
                        }
                        else if (MapLayer[x, y] == 229)
                        {
                            animation9.drawanimation(texturen[229], tilePosition, spritebatch, animation9.getanimation(gameTime, 16, 4), 64, 64);
                        }
                    }
                    else
                    {
                    }

                    tilePosition.Y += vtileHeight; //Position hochzählen um Y-Linie zu beenden
                }

                tilePosition.Y = 0; //Y = 0 um wieder oben anzufangen
                tilePosition.X += vtileWidth; //X hochzählen um neue Linie rechts zu beginnen
            }

            SpawnObject = false;//Keine Objekte erstellen

        spritebatch.End();
        }

        public void ReadLayer()
        {
            int readerchar = 0; //Variable für den Mapreader string array
            string MapReader;

            Clear_Layer();
            //path = @"Content\Map-Prototyp.txt"; //MapLayer.txt Pfad

            StreamReader reader = new StreamReader(path); //Map einlesen
            MapReader = reader.ReadToEnd();
            reader.Close();



            for (int y = 0; y < vHeight; y++) //vHeight = Maphöhe (Y)
            {
                for (int x = 0; x < vWidth; x++) //vWidth = Mapbreite (X)
                {
                    if (MapReader[readerchar] != 32 && MapReader[readerchar] != 13 && MapReader[readerchar] != 10)
                    {

                    }
                    else if (MapReader[readerchar] == 13 && MapReader[readerchar + 1] == 10)
                    {
                        readerchar += 2;
                    }
                    else
                    {
                        readerchar++;
                    }

                    while (MapReader[readerchar] != 32 && MapReader[readerchar] != 13 && MapReader[readerchar] != 10)
                    {
                        switch (MapReader[readerchar])
                        {
                            /*
                               MapLayer[x, y] = MapLayer[x, y] * 10 + 1
                               *10 um die Zahl falls sie höherstellig wird eine Stelle zu erhöhen
                               + 1 1-9 wenn die Zahl in der TxT eine 1-9 sein sollte
                               Bei 0 z.B. 10 wird um eine Stelle erweitert ohne eine Zahl zu addieren
                            */
                            case '1':
                                MapLayer[x, y] = MapLayer[x, y] * 10 + 1;
                                break;
                            case '2':
                                MapLayer[x, y] = MapLayer[x, y] * 10 + 2;
                                break;
                            case '3':
                                MapLayer[x, y] = MapLayer[x, y] * 10 + 3;
                                break;
                            case '4':
                                MapLayer[x, y] = MapLayer[x, y] * 10 + 4;
                                break;
                            case '5':
                                MapLayer[x, y] = MapLayer[x, y] * 10 + 5;
                                break;
                            case '6':
                                MapLayer[x, y] = MapLayer[x, y] * 10 + 6;
                                break;
                            case '7':
                                MapLayer[x, y] = MapLayer[x, y] * 10 + 7;
                                break;
                            case '8':
                                MapLayer[x, y] = MapLayer[x, y] * 10 + 8;
                                break;
                            case '9':
                                MapLayer[x, y] = MapLayer[x, y] * 10 + 9;
                                break;
                            case '0':
                                MapLayer[x, y] *= 10;
                                break;

                            default:
                                break;
                        }

                        if (readerchar + 1 < MapReader.Length) //Readerchar muss kleiner als die MapReader Länge bleiben um Out of Array Fehler zu vermeiden 
                        {
                            readerchar++;
                        }
                        else
                        {
                            break; //Aus Schleife springen wenn readerchar maximale Größe erreicht
                        }
                    }
                    readerchar++;
                }
            }

            readerchar = 0;

        }

        private void Clear_Layer()
        {
            for (int q = 0; q < vHeight; q++)
            {
                for (int qq = 0; qq < vWidth; qq++)
                {
                    MapLayer[qq, q] = 0;
                }
            }
        }

    }
}
