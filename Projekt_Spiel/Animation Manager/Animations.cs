using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YellowTale
{
    class Animations
    {
        int animation; //Bildzahl der Animation
        TimeSpan zeit; //Verzögerungszeit
        public int Fps, Frames;

        public Animations()
        {
            animation = 0;
        }

        public int getanimation(GameTime gameTime, int fps, int frames) //fps = Bilder pro sekunde ; frames = Bilderanzahl
        {
            if (gameTime != null)//Bug bei Bullet Collision
            {
                Fps = fps;
                Frames = frames;

                if (zeit + TimeSpan.FromMilliseconds((1000 / fps)) < gameTime.TotalGameTime) // 1000/fps = 1 Sekunde geteilt durch Bilder pro Sekunde
                {                                                                            // gameTime.TotalGameTime = Gesamt vergangene Zeit
                    if (animation + 1 < frames)
                    {
                        animation++;                                                         //Bildzahl hochzählen um nächstes Bild zu laden
                        zeit = gameTime.TotalGameTime;                                       //Zeit = Gesamte Zeit setzen um Verzögerung nochmal zu erzeugen
                    }
                    else
                    {
                        animation = 0;                                                       //Maximales Bild wird erreicht
                        zeit = gameTime.TotalGameTime;
                    }
                }
            }

            return animation; //Bildzahl zurückgeben
        }

        //width = Texturbreite : height = Texturhöhe : frame = Animationsframe = Welcher Frame in der Bildfolge soll gelesen werden ?
        public void drawanimation(Texture2D textur, Vector2 Position, SpriteBatch spriteBatch, int frame, int width, int height)
        {
            spriteBatch.Draw(textur, Position, new Rectangle(0, height * frame, width, height), Color.White); //Rectangle ist ein Ausgeschnittener Bereich in der Bildfolge
        }

        public void drawanimationrotation(Texture2D textur, Vector2 Position, SpriteBatch spriteBatch, int frame, int width, int height, float rotation)
        {
            spriteBatch.Draw(textur, Position, new Rectangle(0, height * frame, width, height), Color.White, rotation, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1.0f); //Rectangle ist ein Ausgeschnittener Bereich in der Bildfolge
        }

        public void drawanimationrotationknight(Texture2D textur, Vector2 Position, SpriteBatch spriteBatch, int frame, int width, int height, float rotation)
        {
            spriteBatch.Draw(textur, Position, new Rectangle(0, height * frame, width, height), Color.White, rotation, new Vector2(15, 15), 1.0f, SpriteEffects.None, 1.0f); //Rectangle ist ein Ausgeschnittener Bereich in der Bildfolge
        }

        public void drawanimationGespiegelt(Texture2D textur, Vector2 Position, SpriteBatch spriteBatch, int frame, int width, int height, float rotation)
        {
            spriteBatch.Draw(textur, Position, new Rectangle(0, height * frame, width, height), Color.White, rotation, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 1.0f); //Rectangle ist ein Ausgeschnittener Bereich in der Bildfolge
        }

        public void drawanimationGespiegeltVertically(Texture2D textur, Vector2 Position, SpriteBatch spriteBatch, int frame, int width, int height, float rotation)
        {
            spriteBatch.Draw(textur, Position, new Rectangle(0, height * frame, width, height), Color.White, rotation, new Vector2(0, 0), 1.0f, SpriteEffects.FlipVertically, 1.0f); //Rectangle ist ein Ausgeschnittener Bereich in der Bildfolge
        }
    }
}
