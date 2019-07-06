using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YellowTale
{
    class MainMenu
    {
        Button Load;
        Button newGame;
        Button exitGame;
        Button options;
        Button back;
        Button save1;
        Button save2;
        Button save3;
        Button load1;
        Button load2;
        Button load3;
        Button ResRight;
        Button ResLeft;
        Button WinRight;
        Button WinLeft;
        Button graphicChanges;
        Button volume;
        Button Yes;
        Button No;
        Button german;
        Button english;

        int saveFile = 0;

        enum MenuState { main, newGame, load, confirm, options }
        MenuState menuState = MenuState.main;

        /*
        800x600 SVGA
		1024x768 XGA
		1280x720 WXGA
		1920x1080 FHD
		2560x1440 QHD
		3840x2160 UHD
        */
        enum Resolution { Auto, SVGA, XGA, WXGA, FHD, QHD, UHD }
        Resolution resolution = Resolution.Auto;

        enum WindowState { Full, Window, Borderless }
        WindowState windowstate = WindowState.Full;

        public Texture2D ButtonTexture;
        public Texture2D arrowLeft;
        public Texture2D arrowRight;
        public Texture2D menuBackground;
        public Texture2D de;
        public Texture2D en;
        public Texture2D Trackbar;
        public Texture2D Logo;
        public Texture2D messageBox;

        int mitte;
        string[] lines = new string[18];
        enum Language { english, german };
        Language language = Language.english;

        LoadLanguage languageLoader = new LoadLanguage();

        public MainMenu(float musicVolume, string lan)
        {
            mitte = (1920 / 2) - (300 / 2);
            newGame = new Button(new Rectangle(mitte, 430, 300, 100));
            Load = new Button(new Rectangle(mitte, 560, 300, 100));
            options = new Button(new Rectangle(mitte, 690, 300, 100));
            exitGame = new Button(new Rectangle(mitte, 820, 300, 100));
            back = new Button(new Rectangle(mitte, 750, 300, 100));
            save1 = new Button(new Rectangle(mitte, 330, 300, 100));
            save2 = new Button(new Rectangle(mitte, 460, 300, 100));
            save3 = new Button(new Rectangle(mitte, 590, 300, 100));
            load1 = new Button(new Rectangle(mitte, 330, 300, 100));
            load2 = new Button(new Rectangle(mitte, 460, 300, 100));
            load3 = new Button(new Rectangle(mitte, 590, 300, 100));
            Yes = new Button(new Rectangle(655, 590, 300, 100));
            No = new Button(new Rectangle(965, 590, 300, 100));
            volume = new Button(new Rectangle(mitte - 100, 130, 500, 100));
            volume.TrackRectangle = volume.buttonRectangle;
            volume.TrackRectangle.Width = (int)(musicVolume * 500); //config load;
            ResLeft = new Button(new Rectangle(mitte - 100, 250, 100, 100));
            ResRight = new Button(new Rectangle(mitte + 300, 250, 100, 100));
            WinLeft = new Button(new Rectangle(mitte - 100, 400, 100, 100));
            WinRight = new Button(new Rectangle(mitte + 300, 400, 100, 100));
            graphicChanges = new Button(new Rectangle(mitte, 525, 300, 100));
            german = new Button(new Rectangle(mitte + 400, 600, 100, 100));
            english = new Button(new Rectangle(mitte - 200, 600, 100, 100));
            languageLoader.loadLanguage(ref lines, lan);
            
            if (lan == "en_EN")
            {
                language = Language.english;
            }

            if (lan == "de_DE")
            {
                language = Language.german;
            }
        }

        public void draw(int gamestate, SpriteBatch spriteBatch, SpriteFont font, Point mousePosition)
        {
            spriteBatch.Draw(menuBackground, Vector2.Zero, Color.White);

            switch (gamestate)
            {
                case 0:
                    switch (Convert.ToInt32(menuState))
                    {
                        case 0: //Hauptmenü

                            #region Buttondraw

                            spriteBatch.Draw(Logo, new Rectangle((1920 / 2) - (700 / 2), -130, 700, 700), Color.White);

                            if (newGame.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, newGame.buttonRectangle, Color.Gold);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[0], new Vector2(newGame.buttonRectangle.X + 100, newGame.buttonRectangle.Y + 40), Color.AntiqueWhite); //New Game
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[0], new Vector2(newGame.buttonRectangle.X + 85, newGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, newGame.buttonRectangle, Color.DarkGoldenrod);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[0], new Vector2(newGame.buttonRectangle.X + 100, newGame.buttonRectangle.Y + 40), Color.Black); //New Game
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[0], new Vector2(newGame.buttonRectangle.X + 85, newGame.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (Load.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, Load.buttonRectangle, Color.Gold);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[1], new Vector2(Load.buttonRectangle.X + 95, Load.buttonRectangle.Y + 40), Color.AntiqueWhite); //Load Game
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[1], new Vector2(Load.buttonRectangle.X + 95, Load.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, Load.buttonRectangle, Color.DarkGoldenrod);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[1], new Vector2(Load.buttonRectangle.X + 95, Load.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[1], new Vector2(Load.buttonRectangle.X + 95, Load.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (options.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, options.buttonRectangle, Color.Gold);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, options.buttonRectangle, Color.DarkGoldenrod);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (exitGame.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, exitGame.buttonRectangle, Color.Gold);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 120, exitGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 65, exitGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, exitGame.buttonRectangle, Color.DarkGoldenrod);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 120, exitGame.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 65, exitGame.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            #endregion

                            break;
                        case 1: //Neues Spiel

                            #region Buttondraw
                            if (save1.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, save1.buttonRectangle, Color.PaleVioletRed);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[5] + " 1", new Vector2(save1.buttonRectangle.X + 85, save1.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[5] + " 1", new Vector2(save1.buttonRectangle.X + 60, save1.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, save1.buttonRectangle, Color.IndianRed);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[5] + " 1", new Vector2(save1.buttonRectangle.X + 85, save1.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[5] + " 1", new Vector2(save1.buttonRectangle.X + 60, save1.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (save2.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, save2.buttonRectangle, Color.PaleVioletRed);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[5] + " 2", new Vector2(save2.buttonRectangle.X + 85, save2.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[5] + " 2", new Vector2(save2.buttonRectangle.X + 60, save2.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, save2.buttonRectangle, Color.IndianRed);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[5] + " 2", new Vector2(save2.buttonRectangle.X + 85, save2.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[5] + " 2", new Vector2(save2.buttonRectangle.X + 60, save2.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (save3.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, save3.buttonRectangle, Color.PaleVioletRed);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[5] + " 3", new Vector2(save3.buttonRectangle.X + 85, save3.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[5] + " 3", new Vector2(save3.buttonRectangle.X + 60, save3.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, save3.buttonRectangle, Color.IndianRed);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[5] + " 3", new Vector2(save3.buttonRectangle.X + 85, save3.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[5] + " 3", new Vector2(save3.buttonRectangle.X + 60, save3.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (back.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.PaleVioletRed);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 125, back.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 105, back.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.IndianRed);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 125, back.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 105, back.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            #endregion

                            break;
                        case 2: //Laden

                            #region Buttondraw

                            if (load1.enabled)
                            {
                                if (load1.ButtonHover(mousePosition))
                                {
                                    spriteBatch.Draw(ButtonTexture, load1.buttonRectangle, Color.DodgerBlue);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, lines[5] + " 1", new Vector2(load1.buttonRectangle.X + 85, load1.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, lines[5] + " 1", new Vector2(load1.buttonRectangle.X + 60, load1.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    spriteBatch.Draw(ButtonTexture, load1.buttonRectangle, Color.RoyalBlue);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, lines[5] + " 1", new Vector2(load1.buttonRectangle.X + 85, load1.buttonRectangle.Y + 40), Color.Black);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, lines[5] + " 1", new Vector2(load1.buttonRectangle.X + 60, load1.buttonRectangle.Y + 40), Color.Black);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, load1.buttonRectangle, Color.BlueViolet);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[16], new Vector2(load1.buttonRectangle.X + 80, load1.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[16], new Vector2(load1.buttonRectangle.X + 35, load1.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (load2.enabled)
                            {
                                if (load2.ButtonHover(mousePosition))
                                {
                                    spriteBatch.Draw(ButtonTexture, load2.buttonRectangle, Color.DodgerBlue);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, lines[5] + " 2", new Vector2(load2.buttonRectangle.X + 85, load2.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, lines[5] + " 2", new Vector2(load2.buttonRectangle.X + 60, load2.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    spriteBatch.Draw(ButtonTexture, load2.buttonRectangle, Color.RoyalBlue);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, lines[5] + " 2", new Vector2(load2.buttonRectangle.X + 85, load2.buttonRectangle.Y + 40), Color.Black);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, lines[5] + " 2", new Vector2(load2.buttonRectangle.X + 60, load2.buttonRectangle.Y + 40), Color.Black);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, load2.buttonRectangle, Color.BlueViolet);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[16], new Vector2(load1.buttonRectangle.X + 80, load2.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[16], new Vector2(load1.buttonRectangle.X + 35, load2.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (load3.enabled)
                            {
                                if (load3.ButtonHover(mousePosition))
                                {
                                    spriteBatch.Draw(ButtonTexture, load3.buttonRectangle, Color.DodgerBlue);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, lines[5] + " 3", new Vector2(load3.buttonRectangle.X + 85, load3.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, lines[5] + " 3", new Vector2(load3.buttonRectangle.X + 60, load3.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    spriteBatch.Draw(ButtonTexture, load3.buttonRectangle, Color.RoyalBlue);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, lines[5] + " 3", new Vector2(load3.buttonRectangle.X + 85, load3.buttonRectangle.Y + 40), Color.Black);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, lines[5] + " 3", new Vector2(load3.buttonRectangle.X + 60, load3.buttonRectangle.Y + 40), Color.Black);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, load3.buttonRectangle, Color.BlueViolet);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[16], new Vector2(load3.buttonRectangle.X + 80, load3.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[16], new Vector2(load3.buttonRectangle.X + 35, load3.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }


                            if (back.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.DodgerBlue);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 125, back.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 105, back.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.RoyalBlue);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 125, back.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 105, back.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            #endregion

                            break;
                        case 3: //Speicherstände speichern

                            #region Buttondraw

                            spriteBatch.Draw(ButtonTexture, save1.buttonRectangle, Color.IndianRed);
                            switch (language)
                            {
                                case Language.english:
                                    spriteBatch.DrawString(font, lines[5] + " 1", new Vector2(save1.buttonRectangle.X + 85, save1.buttonRectangle.Y + 40), Color.Black);
                                    break;
                                case Language.german:
                                    spriteBatch.DrawString(font, lines[5] + " 1", new Vector2(save1.buttonRectangle.X + 60, save1.buttonRectangle.Y + 40), Color.Black);
                                    break;
                                default:
                                    break;
                            }

                            spriteBatch.Draw(ButtonTexture, save2.buttonRectangle, Color.IndianRed);
                            switch (language)
                            {
                                case Language.english:
                                    spriteBatch.DrawString(font, lines[5] + " 2", new Vector2(save2.buttonRectangle.X + 85, save2.buttonRectangle.Y + 40), Color.Black);
                                    break;
                                case Language.german:
                                    spriteBatch.DrawString(font, lines[5] + " 2", new Vector2(save2.buttonRectangle.X + 60, save2.buttonRectangle.Y + 40), Color.Black);
                                    break;
                                default:
                                    break;
                            }

                            spriteBatch.Draw(ButtonTexture, save3.buttonRectangle, Color.IndianRed);
                            switch (language)
                            {
                                case Language.english:
                                    spriteBatch.DrawString(font, lines[5] + " 3", new Vector2(save3.buttonRectangle.X + 85, save3.buttonRectangle.Y + 40), Color.Black);
                                    break;
                                case Language.german:
                                    spriteBatch.DrawString(font, lines[5] + " 3", new Vector2(save3.buttonRectangle.X + 60, save3.buttonRectangle.Y + 40), Color.Black);
                                    break;
                                default:
                                    break;
                            }

                            spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.IndianRed);
                            switch (language)
                            {
                                case Language.english:
                                    spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 125, back.buttonRectangle.Y + 40), Color.Black);
                                    break;
                                case Language.german:
                                    spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 105, back.buttonRectangle.Y + 40), Color.Black);
                                    break;
                                default:
                                    break;
                            }

                            if (Yes.enabled == true && No.enabled == true)
                            {
                                spriteBatch.Draw(messageBox, new Rectangle(Yes.buttonRectangle.X + 100, Yes.buttonRectangle.Y - 170, 410, 150), Color.LightGray);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, "     Start a new Game ?\n(Old File will get deleted.)", new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y - 120), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, "    Neues Spiel starten ?\n" +
                                                                     "  (Der alte Speicherstand\n" +
                                                                     "      wird geloescht)", new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y - 120), Color.Black);
                                        break;
                                    default:
                                        break;
                                }

                                if (Yes.ButtonHover(mousePosition))
                                {
                                    spriteBatch.Draw(ButtonTexture, Yes.buttonRectangle, Color.LightGray);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, lines[7], new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, lines[7], new Vector2(Yes.buttonRectangle.X + 130, Yes.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    spriteBatch.Draw(ButtonTexture, Yes.buttonRectangle, Color.Gray);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, lines[7], new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y + 40), Color.Black);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, lines[7], new Vector2(Yes.buttonRectangle.X + 130, Yes.buttonRectangle.Y + 40), Color.Black);
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                if (No.ButtonHover(mousePosition))
                                {
                                    spriteBatch.Draw(ButtonTexture, No.buttonRectangle, Color.LightGray);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, lines[6], new Vector2(No.buttonRectangle.X + 125, No.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, lines[6], new Vector2(No.buttonRectangle.X + 125, No.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    spriteBatch.Draw(ButtonTexture, No.buttonRectangle, Color.Gray);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, lines[6], new Vector2(No.buttonRectangle.X + 125, No.buttonRectangle.Y + 40), Color.Black);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, lines[6], new Vector2(No.buttonRectangle.X + 125, No.buttonRectangle.Y + 40), Color.Black);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 4: //Optionen

                            #region ButtonDraw

                            if (volume.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(Trackbar, volume.buttonRectangle, Color.White);
                                spriteBatch.Draw(Trackbar, new Rectangle(volume.buttonRectangle.X, volume.buttonRectangle.Y, volume.TrackRectangle.Width, volume.TrackRectangle.Height), new Rectangle(0, 0, volume.TrackRectangle.Width, volume.TrackRectangle.Height), Color.Cyan);
                                spriteBatch.DrawString(font, lines[8] + ": " + (100 * Math.Round((volume.TrackRectangle.Width / 500.0), 2)).ToString(),
                                                       new Vector2(volume.buttonRectangle.Center.X - 75, volume.buttonRectangle.Center.Y - 10), Color.AntiqueWhite);
                            }
                            else
                            {
                                spriteBatch.Draw(Trackbar, volume.buttonRectangle, Color.White);
                                spriteBatch.Draw(Trackbar, new Rectangle(volume.buttonRectangle.X, volume.buttonRectangle.Y, volume.TrackRectangle.Width, volume.TrackRectangle.Height), new Rectangle(0, 0, volume.TrackRectangle.Width, volume.TrackRectangle.Height), Color.DarkCyan);
                                spriteBatch.DrawString(font, lines[8] + ": " + (100 * Math.Round((volume.TrackRectangle.Width / 500.0), 2)).ToString(),
                                                       new Vector2(volume.buttonRectangle.Center.X - 75, volume.buttonRectangle.Center.Y - 10), Color.Wheat);
                            }


                            if (ResLeft.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(arrowLeft, ResLeft.buttonRectangle, Color.Cyan);
                            }
                            else
                            {
                                spriteBatch.Draw(arrowLeft, ResLeft.buttonRectangle, Color.DarkCyan);
                            }

                            if (ResRight.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(arrowRight, ResRight.buttonRectangle, Color.Cyan);
                            }
                            else
                            {
                                spriteBatch.Draw(arrowRight, ResRight.buttonRectangle, Color.DarkCyan);
                            }

                            switch (language)
                            {
                                case Language.english:
                                    if (resolution == Resolution.Auto)
                                    {
                                        spriteBatch.DrawString(font, resolutionString(), new Vector2(mitte + 115, ResRight.buttonRectangle.Center.Y), Color.White);
                                    }
                                    else
                                    {
                                        spriteBatch.DrawString(font, resolutionString(), new Vector2(mitte + 95, ResRight.buttonRectangle.Center.Y), Color.White);
                                    }
                                    break;
                                case Language.german:
                                    if (resolution == Resolution.Auto)
                                    {
                                        spriteBatch.DrawString(font, resolutionString(), new Vector2(mitte + 80, ResRight.buttonRectangle.Center.Y), Color.White);
                                    }
                                    else
                                    {
                                        spriteBatch.DrawString(font, resolutionString(), new Vector2(mitte + 95, ResRight.buttonRectangle.Center.Y), Color.White);
                                    }
                                    break;
                                default:
                                    break;
                            }

                            if (WinLeft.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(arrowLeft, WinLeft.buttonRectangle, Color.Cyan);
                            }
                            else
                            {
                                spriteBatch.Draw(arrowLeft, WinLeft.buttonRectangle, Color.DarkCyan);
                            }

                            if (WinRight.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(arrowRight, WinRight.buttonRectangle, Color.Cyan);
                            }
                            else
                            {
                                spriteBatch.Draw(arrowRight, WinRight.buttonRectangle, Color.DarkCyan);
                            }

                            switch (language)
                            {
                                case Language.english:
                                    switch (windowstate)
                                    {
                                        case WindowState.Full:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 80, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        case WindowState.Window:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 105, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        case WindowState.Borderless:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 40, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case Language.german:
                                    switch (windowstate)
                                    {
                                        case WindowState.Full:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 90, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        case WindowState.Window:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 105, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        case WindowState.Borderless:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 40, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }

                            if (graphicChanges.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, graphicChanges.buttonRectangle, Color.Cyan);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[9], new Vector2(graphicChanges.buttonRectangle.Center.X - 40, graphicChanges.buttonRectangle.Center.Y - 10), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[9], new Vector2(graphicChanges.buttonRectangle.Center.X - 70, graphicChanges.buttonRectangle.Center.Y - 10), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, graphicChanges.buttonRectangle, Color.DarkCyan);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[9], new Vector2(graphicChanges.buttonRectangle.Center.X - 40, graphicChanges.buttonRectangle.Center.Y - 10), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[9], new Vector2(graphicChanges.buttonRectangle.Center.X - 70, graphicChanges.buttonRectangle.Center.Y - 10), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (back.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.Cyan);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 125, back.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 105, back.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.DarkCyan);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 125, back.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 105, back.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (german.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(de, german.buttonRectangle, Color.WhiteSmoke);
                            }
                            else
                            {
                                spriteBatch.Draw(de, german.buttonRectangle, Color.LightGray);
                            }

                            if (english.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(en, english.buttonRectangle, Color.WhiteSmoke);
                            }
                            else
                            {
                                spriteBatch.Draw(en, english.buttonRectangle, Color.LightGray);
                            }

                            #endregion

                            break;
                        default:
                            break;
                    }
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }

        }

        public void update(int gamestate)
        {
            if (gamestate == 0) //Wenn gamestate = Hauptmenü ist dann sollen die Knöpfe Save, Load, newGamge, exitGame und back verfügbar sein
            {
                newGame.enabled = true;
                Load.enabled = true;
                newGame.enabled = true;
                exitGame.enabled = true;
                back.enabled = true;
                options.enabled = true;
            }
            else if (gamestate == 1) //Wenn gamestate = Spiel sollen alle Knöpfe aus sein
            {
                disableButtons();
            }
            else if (gamestate == 2)
            {
            }

            if (menuState == MenuState.newGame)
            {
                Load.enabled = false;
                newGame.enabled = false;
                save1.enabled = true;
                save2.enabled = true;
                save3.enabled = true;
                exitGame.enabled = false;
            }

            if (menuState == MenuState.load)
            {
                Load.enabled = false;
                newGame.enabled = false;

                if (File.Exists(@"Content/savegames/1.sv"))
                {
                    load1.enabled = true;
                }
                else
                {
                    load1.enabled = false;
                }

                if (File.Exists(@"Content/savegames/2.sv"))
                {
                    load2.enabled = true;
                }
                else
                {
                    load2.enabled = false;
                }

                if (File.Exists(@"Content/savegames/3.sv"))
                {
                    load3.enabled = true;
                }
                else
                {
                    load3.enabled = false;
                }

                exitGame.enabled = false;
            }

            if (menuState == MenuState.confirm)
            {
                confirm();
            }

            if (menuState == MenuState.options)
            {
                newGame.enabled = false;
                Load.enabled = false;
                newGame.enabled = false;
                exitGame.enabled = false;
                options.enabled = false;
                back.enabled = true;
                volume.enabled = true;
                english.enabled = true;
                german.enabled = true;

                if (Convert.ToInt32(windowstate) < 2)
                {
                    WinRight.enabled = true;
                }
                else
                {
                    WinRight.enabled = false;
                }

                if (Convert.ToInt32(windowstate) > 0)
                {
                    WinLeft.enabled = true;
                }
                else
                {
                    WinLeft.enabled = false;
                }

                if (Convert.ToInt32(resolution) < 6 && (windowstate == WindowState.Window || windowstate == WindowState.Borderless))
                {
                    ResRight.enabled = true;
                }
                else
                {
                    ResRight.enabled = false;
                }

                if (Convert.ToInt32(resolution) > 0 && (windowstate == WindowState.Window || windowstate == WindowState.Borderless))
                {
                    ResLeft.enabled = true;
                }
                else
                {
                    ResLeft.enabled = false;
                }

                graphicChanges.enabled = true;
            }

            if (menuState == MenuState.main)
            {
                newGame.enabled = true;
                Load.enabled = true;
                newGame.enabled = true;
                exitGame.enabled = true;
                options.enabled = true;
                back.enabled = false;
            }

            if (windowstate == WindowState.Full)
            {
                resolution = Resolution.Auto;
            }
        }

        public void clickCheck(Point mousePosition, Game1 game1, string loadedWidth, string windowMode)
        {
            if (newGame.ButtonClick(mousePosition))
            {
                menuState = MenuState.newGame;
                save1.enabled = true;
                save2.enabled = true;
                save3.enabled = true;
                return;
            }

            if (Load.ButtonClick(mousePosition))
            {
                menuState = MenuState.load;
                load1.enabled = true;
                load2.enabled = true;
                load3.enabled = true;
                return;
            }

            if (back.ButtonClick(mousePosition))//Zurück Button
            {
                switch (menuState)
                {
                    case MenuState.newGame:
                        menuState = MenuState.main;
                        backClick();
                        break;
                    case MenuState.load:
                        menuState = MenuState.main;
                        backClick();
                        break;
                    case MenuState.options:
                        menuState = MenuState.main;
                        backClick();
                        break;
                    default:
                        break;
                }
                return;
            }

            if (english.ButtonClick(mousePosition))
            {
                languageLoader.loadLanguage(ref lines, "en_EN");
                language = Language.english;
                game1.graphicChange(3, "en_EN");
            }

            if (german.ButtonClick(mousePosition))
            {
                languageLoader.loadLanguage(ref lines, "de_DE");
                language = Language.german;
                game1.graphicChange(3, "de_DE");
            }

            if (save1.ButtonClick(mousePosition))
            {
                saveFile = 1;
                menuState = MenuState.confirm;
                confirm();
                return;
            }

            if (save2.ButtonClick(mousePosition))
            {
                saveFile = 2;
                menuState = MenuState.confirm;
                confirm();
                return;
            }

            if (save3.ButtonClick(mousePosition))
            {
                saveFile = 3;
                menuState = MenuState.confirm;
                confirm();
                return;
            }

            if (load1.ButtonClick(mousePosition))
            {
                game1.Load(1);
                disableButtons();
                return;
            }

            if (load2.ButtonClick(mousePosition))
            {
                game1.Load(2);
                disableButtons();
                return;
            }

            if (load3.ButtonClick(mousePosition))
            {
                game1.Load(3);
                disableButtons();
                return;
            }

            if (Yes.ButtonClick(mousePosition) && Convert.ToInt32(menuState) - 2 == 1)
            {
                if (saveFile == 0)
                {
                }
                else
                {
                    game1.newGame(saveFile, "archer");
                    disableButtons();
                    return;
                }
            }

            if (No.ButtonClick(mousePosition) && Convert.ToInt32(menuState) - 2 == 1)
            {
                saveFile = 0;
                Yes.enabled = false;
                No.enabled = false;
                if (menuState == MenuState.confirm)
                {
                    menuState = MenuState.newGame;
                }
            }

            if (options.ButtonClick(mousePosition))
            {
                config(loadedWidth, windowMode);
                menuState = MenuState.options;
            }

            if (volume.TrackButton(mousePosition))
            {
                game1.resetClickCooldown();
                game1.musicVolume = (float)(.1 * Math.Round((volume.TrackRectangle.Width / 500.0), 2));
            }

            if (ResLeft.ButtonClick(mousePosition))
            {
                switch (resolution)
                {
                    case Resolution.Auto:
                        break;
                    case Resolution.SVGA:
                        resolution = Resolution.Auto;
                        break;
                    case Resolution.XGA:
                        resolution = Resolution.SVGA;
                        break;
                    case Resolution.WXGA:
                        resolution = Resolution.XGA;
                        break;
                    case Resolution.FHD:
                        resolution = Resolution.WXGA;
                        break;
                    case Resolution.QHD:
                        resolution = Resolution.FHD;
                        break;
                    case Resolution.UHD:
                        resolution = Resolution.QHD;
                        break;
                    default:
                        break;
                }
            }

            if (ResRight.ButtonClick(mousePosition))
            {
                switch (resolution)
                {
                    case Resolution.Auto:
                        resolution = Resolution.SVGA;
                        break;
                    case Resolution.SVGA:
                        resolution = Resolution.XGA;
                        break;
                    case Resolution.XGA:
                        resolution = Resolution.WXGA;
                        break;
                    case Resolution.WXGA:
                        resolution = Resolution.FHD;
                        break;
                    case Resolution.FHD:
                        resolution = Resolution.QHD;
                        break;
                    case Resolution.QHD:
                        resolution = Resolution.UHD;
                        break;
                    case Resolution.UHD:
                        break;
                    default:
                        break;
                }
            }

            if (WinRight.ButtonClick(mousePosition))
            {
                switch (windowstate)
                {
                    case WindowState.Full:
                        windowstate = WindowState.Window;
                        break;
                    case WindowState.Window:
                        windowstate = WindowState.Borderless;
                        break;
                    case WindowState.Borderless:
                        break;
                    default:
                        break;
                }
            }

            if (WinLeft.ButtonClick(mousePosition))
            {
                switch (windowstate)
                {
                    case WindowState.Full:
                        break;
                    case WindowState.Window:
                        windowstate = WindowState.Full;
                        break;
                    case WindowState.Borderless:
                        windowstate = WindowState.Window;
                        break;
                    default:
                        break;
                }
            }

            if (graphicChanges.ButtonClick(mousePosition))
            {
                switch (resolution)
                {
                    case Resolution.Auto:
                        game1.autoResolution();
                        break;
                    case Resolution.SVGA:
                        game1.ResolutionWidth = 800;
                        game1.ResolutionHeight = 600;
                        break;
                    case Resolution.XGA:
                        game1.ResolutionWidth = 1024;
                        game1.ResolutionHeight = 768;
                        break;
                    case Resolution.WXGA:
                        game1.ResolutionWidth = 1280;
                        game1.ResolutionHeight = 720;
                        break;
                    case Resolution.FHD:
                        game1.ResolutionWidth = 1920;
                        game1.ResolutionHeight = 1080;
                        break;
                    case Resolution.QHD:
                        game1.ResolutionWidth = 2560;
                        game1.ResolutionHeight = 1440;
                        break;
                    case Resolution.UHD:
                        game1.ResolutionWidth = 3840;
                        game1.ResolutionHeight = 2160;
                        break;
                    default:
                        break;
                }

                switch (windowstate)
                {
                    case WindowState.Full:
                        if (language == Language.english)
                        {
                            game1.graphicChange(0, "en_EN");
                        }
                        else if (language == Language.german)
                        {
                            game1.graphicChange(0, "de_DE");
                        }
                        break;
                    case WindowState.Window:
                        if (language == Language.english)
                        {
                            game1.graphicChange(1, "en_EN");
                        }
                        else if (language == Language.german)
                        {
                            game1.graphicChange(1, "de_DE");
                        }
                        break;
                    case WindowState.Borderless:
                        if (language == Language.english)
                        {
                            game1.graphicChange(2, "en_EN");
                        }
                        else if (language == Language.german)
                        {
                            game1.graphicChange(2, "de_DE");
                        }
                        break;
                    default:
                        break;
                }
            }

            if (exitGame.ButtonClick(mousePosition))
            {
                game1.Exit();
                return;
            }
        }

        public void backMainMenu()
        {
            menuState = MenuState.main;
        }

        private void backClick()
        {
            newGame.enabled = true;
            Load.enabled = true;
            newGame.enabled = true;
            exitGame.enabled = true;
            options.enabled = true;
            back.enabled = false;
            save1.enabled = false;
            save2.enabled = false;
            save3.enabled = false;
            load1.enabled = false;
            load2.enabled = false;
            load3.enabled = false;
            WinRight.enabled = false;
            WinLeft.enabled = false;
            volume.enabled = false;
            ResRight.enabled = false;
            ResLeft.enabled = false;
            english.enabled = false;
            german.enabled = false;
        }

        private void disableButtons()
        {
            Load.enabled = false;
            newGame.enabled = false;
            exitGame.enabled = false;
            options.enabled = false;
            back.enabled = false;
            save1.enabled = false;
            save2.enabled = false;
            save3.enabled = false;
            load1.enabled = false;
            load2.enabled = false;
            load3.enabled = false;
            Yes.enabled = false;
            No.enabled = false;
            german.enabled = false;
            english.enabled = false;
            WinRight.enabled = false;
            WinLeft.enabled = false;
            volume.enabled = false;
            ResRight.enabled = false;
            ResLeft.enabled = false;
            graphicChanges.enabled = false;
            menuState = MenuState.main;
        }

        private void config(string loadedWidth, string windowMode)
        {
            switch (loadedWidth)
            {
                case "800":
                    resolution = Resolution.SVGA;
                    break;
                case "1024":
                    resolution = Resolution.XGA;
                    break;
                case "1280":
                    resolution = Resolution.WXGA;
                    break;
                case "1920":
                    resolution = Resolution.FHD;
                    break;
                case "2560":
                    resolution = Resolution.QHD;
                    break;
                case "3840":
                    resolution = Resolution.UHD;
                    break;
                case "auto":
                    resolution = Resolution.Auto;
                    break;
                default:
                    break;
            }

            switch (windowMode)
            {
                case "fullscreen":
                    windowstate = WindowState.Full;
                    break;
                case "window":
                    windowstate = WindowState.Window;
                    break;
                case "borderless":
                    windowstate = WindowState.Borderless;
                    break;
                default:
                    break;
            }
        }

        private void confirm()
        {
            Load.enabled = false;
            newGame.enabled = false;
            exitGame.enabled = false;
            options.enabled = false;
            back.enabled = false;
            save1.enabled = false;
            save2.enabled = false;
            save3.enabled = false;
            load1.enabled = false;
            load2.enabled = false;
            load3.enabled = false;
            Yes.enabled = true;
            No.enabled = true;
            german.enabled = false;
            english.enabled = false;
            WinRight.enabled = false;
            WinLeft.enabled = false;
            volume.enabled = false;
            ResRight.enabled = false;
            ResLeft.enabled = false;
            graphicChanges.enabled = false;
        }

        private string windowString()
        {
            switch (windowstate)
            {
                case WindowState.Full:
                    return lines[10];
                case WindowState.Window:
                    return lines[11];
                case WindowState.Borderless:
                    return lines[12];
                default:
                    return "";
            }
        }

        private string resolutionString()
        {
            switch (resolution)
            {
                case Resolution.Auto:
                    return lines[13];
                case Resolution.SVGA:
                    return "800x600";
                case Resolution.XGA:
                    return "1024x768";
                case Resolution.WXGA:
                    return "1280x720";
                case Resolution.FHD:
                    return "1920x1080";
                case Resolution.QHD:
                    return "2560x1440";
                case Resolution.UHD:
                    return "3840x2160";
                default:
                    return "";
            }
        }
    }

    class PauseMenu
    {
        //Button saveGame;
        Button mainMenu;
        Button exitGame;
        Button options;
        Button back;
        Button ResRight;
        Button ResLeft;
        Button WinRight;
        Button WinLeft;
        Button graphicChanges;
        Button volume;
        Button Yes;
        Button No;
        Button german;
        Button english;


        enum MenuState { main, options, load, confirm }
        MenuState menuState = MenuState.main;

        enum Resolution { Auto, SVGA, XGA, WXGA, FHD, QHD, UHD }
        Resolution resolution = Resolution.Auto;

        enum WindowState { Full, Window, Borderless }
        WindowState windowstate = WindowState.Full;

        enum ConfirmState { none, exit, backMenu, save, load }
        ConfirmState confirmState = ConfirmState.none;

        public Texture2D ButtonTexture;
        public Texture2D arrowLeft;
        public Texture2D arrowRight;
        public Texture2D de;
        public Texture2D en;
        public Texture2D Trackbar;
        public Texture2D messageBox;


        int mitte;
        int loadgame;
        string[] lines = new string[18];
        public enum Language { english, german };
        public Language language = Language.english;

        LoadLanguage languageLoader = new LoadLanguage();

        public PauseMenu(float musicVolume, string lan)
        {
            mitte = (1920 / 2) - (300 / 2);
            //saveGame = new Button(new Rectangle(mitte, 430, 300, 100));
            options = new Button(new Rectangle(mitte, 430, 300, 100));
            mainMenu = new Button(new Rectangle(mitte, 560, 300, 100));
            exitGame = new Button(new Rectangle(mitte, 690, 300, 100));
            back = new Button(new Rectangle(mitte, 750, 300, 100));
            volume = new Button(new Rectangle(mitte - 100, 130, 500, 100));
            volume.TrackRectangle = volume.buttonRectangle;
            volume.TrackRectangle.Width = (int)(musicVolume * 500); //config load;
            ResLeft = new Button(new Rectangle(mitte - 100, 250, 100, 100));
            ResRight = new Button(new Rectangle(mitte + 300, 250, 100, 100));
            WinLeft = new Button(new Rectangle(mitte - 100, 400, 100, 100));
            WinRight = new Button(new Rectangle(mitte + 300, 400, 100, 100));
            graphicChanges = new Button(new Rectangle(mitte, 525, 300, 100));
            Yes = new Button(new Rectangle(655, 590, 300, 100));
            No = new Button(new Rectangle(965, 590, 300, 100));
            german = new Button(new Rectangle(mitte + 400, 600, 100, 100));
            english = new Button(new Rectangle(mitte - 200, 600, 100, 100));


            languageLoader.loadLanguage(ref lines, lan);

            if (lan == "en_EN")
            {
                language = Language.english;
            }

            if (lan == "de_DE")
            {
                language = Language.german;
            }
        }

        public void update(int gamestate)
        {
            if (gamestate == 0) //Wenn gamestate = Hauptmenü ist dann sollen die Knöpfe Save, Load, newGamge, exitGame und back verfügbar sein
            {
            }
            else if (gamestate == 1) //Wenn gamestate = Spiel sollen alle Knöpfe aus sein
            {
                disableButtons();
            }
            else if (gamestate == 2)
            {
                //saveGame.enabled = true;
                mainMenu.enabled = true;
                exitGame.enabled = true;
                back.enabled = false;
                options.enabled = true;
            }

            if (menuState == MenuState.load)
            {
                //saveGame.enabled = false;
                back.enabled = true;
                mainMenu.enabled = false;
                exitGame.enabled = false;
            }

            if (menuState == MenuState.main)
            {
                disableButtons();
                //saveGame.enabled = true;
                mainMenu.enabled = true;
                exitGame.enabled = true;
                options.enabled = true;
            }

            if (menuState == MenuState.confirm)
            {
                switch (confirmState)
                {
                    case ConfirmState.none:
                        break;
                    case ConfirmState.exit:
                        //saveGame.enabled = false;
                        mainMenu.enabled = false;
                        exitGame.enabled = false;
                        back.enabled = false;
                        options.enabled = false;
                        Yes.enabled = true;
                        No.enabled = true;
                        break;
                    case ConfirmState.backMenu:
                        //saveGame.enabled = false;
                        mainMenu.enabled = false;
                        exitGame.enabled = false;
                        back.enabled = false;
                        options.enabled = false;
                        Yes.enabled = true;
                        No.enabled = true;
                        break;
                    case ConfirmState.save:
                        //saveGame.enabled = false;
                        mainMenu.enabled = false;
                        exitGame.enabled = false;
                        back.enabled = false;
                        options.enabled = false;
                        Yes.enabled = true;
                        No.enabled = true;
                        break;
                    case ConfirmState.load:
                        //saveGame.enabled = false;
                        back.enabled = false;
                        mainMenu.enabled = false;
                        exitGame.enabled = false;
                        Yes.enabled = true;
                        No.enabled = true;
                        break;
                    default:
                        break;
                }
            }

            if (menuState == MenuState.options)
            {
                //saveGame.enabled = false;
                mainMenu.enabled = false;
                exitGame.enabled = false;
                options.enabled = false;
                back.enabled = true;
                volume.enabled = true;
                german.enabled = true;
                english.enabled = true;

                if (Convert.ToInt32(windowstate) < 2)
                {
                    WinRight.enabled = true;
                }
                else
                {
                    WinRight.enabled = false;
                }

                if (Convert.ToInt32(windowstate) > 0)
                {
                    WinLeft.enabled = true;
                }
                else
                {
                    WinLeft.enabled = false;
                }

                if (Convert.ToInt32(resolution) < 6 && (windowstate == WindowState.Window || windowstate == WindowState.Borderless))
                {
                    ResRight.enabled = true;
                }
                else
                {
                    ResRight.enabled = false;
                }

                if (Convert.ToInt32(resolution) > 0 && (windowstate == WindowState.Window || windowstate == WindowState.Borderless))
                {
                    ResLeft.enabled = true;
                }
                else
                {
                    ResLeft.enabled = false;
                }

                graphicChanges.enabled = true;
            }

            if (windowstate == WindowState.Full)
            {
                resolution = Resolution.Auto;
            }

        }

        public void clickCheck(Point mousePosition, Game1 game1, string loadedWidth, string windowMode)
        {
            /*if (saveGame.ButtonClick(mousePosition))
            {
                confirmState = ConfirmState.save;
                menuState = MenuState.confirm;
                return;
            }*/

            if (english.ButtonClick(mousePosition))
            {
                languageLoader.loadLanguage(ref lines, "en_EN");
                language = Language.english;
            }

            if (german.ButtonClick(mousePosition))
            {
                languageLoader.loadLanguage(ref lines, "de_DE");
                language = Language.german;
            }

            if (back.ButtonClick(mousePosition))//Zurück Button
            {
                switch (menuState)
                {
                    case MenuState.load:
                        menuState = MenuState.main;
                        backClick();
                        break;
                    case MenuState.options:
                        menuState = MenuState.main;
                        backClick();
                        break;
                    default:
                        break;
                }
                return;
            }

            if (options.ButtonClick(mousePosition))
            {
                config(loadedWidth, windowMode);
                menuState = MenuState.options;
                back.enabled = true;
                exitGame.enabled = false;
            }

            if (volume.TrackButton(mousePosition))
            {
                game1.resetClickCooldown();
                game1.musicVolume = (float)(.1 * Math.Round((volume.TrackRectangle.Width / 500.0), 2));
            }

            if (ResLeft.ButtonClick(mousePosition))
            {
                switch (resolution)
                {
                    case Resolution.Auto:
                        break;
                    case Resolution.SVGA:
                        resolution = Resolution.Auto;
                        break;
                    case Resolution.XGA:
                        resolution = Resolution.SVGA;
                        break;
                    case Resolution.WXGA:
                        resolution = Resolution.XGA;
                        break;
                    case Resolution.FHD:
                        resolution = Resolution.WXGA;
                        break;
                    case Resolution.QHD:
                        resolution = Resolution.FHD;
                        break;
                    case Resolution.UHD:
                        resolution = Resolution.QHD;
                        break;
                    default:
                        break;
                }
            }

            if (ResRight.ButtonClick(mousePosition))
            {
                switch (resolution)
                {
                    case Resolution.Auto:
                        resolution = Resolution.SVGA;
                        break;
                    case Resolution.SVGA:
                        resolution = Resolution.XGA;
                        break;
                    case Resolution.XGA:
                        resolution = Resolution.WXGA;
                        break;
                    case Resolution.WXGA:
                        resolution = Resolution.FHD;
                        break;
                    case Resolution.FHD:
                        resolution = Resolution.QHD;
                        break;
                    case Resolution.QHD:
                        resolution = Resolution.UHD;
                        break;
                    case Resolution.UHD:
                        break;
                    default:
                        break;
                }
            }

            if (WinRight.ButtonClick(mousePosition))
            {
                switch (windowstate)
                {
                    case WindowState.Full:
                        windowstate = WindowState.Window;
                        break;
                    case WindowState.Window:
                        windowstate = WindowState.Borderless;
                        break;
                    case WindowState.Borderless:
                        break;
                    default:
                        break;
                }
            }

            if (WinLeft.ButtonClick(mousePosition))
            {
                switch (windowstate)
                {
                    case WindowState.Full:
                        break;
                    case WindowState.Window:
                        windowstate = WindowState.Full;
                        break;
                    case WindowState.Borderless:
                        windowstate = WindowState.Window;
                        break;
                    default:
                        break;
                }
            }

            if (graphicChanges.ButtonClick(mousePosition))
            {
                switch (resolution)
                {
                    case Resolution.Auto:
                        game1.autoResolution();
                        break;
                    case Resolution.SVGA:
                        game1.ResolutionWidth = 800;
                        game1.ResolutionHeight = 600;
                        break;
                    case Resolution.XGA:
                        game1.ResolutionWidth = 1024;
                        game1.ResolutionHeight = 768;
                        break;
                    case Resolution.WXGA:
                        game1.ResolutionWidth = 1280;
                        game1.ResolutionHeight = 720;
                        break;
                    case Resolution.FHD:
                        game1.ResolutionWidth = 1920;
                        game1.ResolutionHeight = 1080;
                        break;
                    case Resolution.QHD:
                        game1.ResolutionWidth = 2560;
                        game1.ResolutionHeight = 1440;
                        break;
                    case Resolution.UHD:
                        game1.ResolutionWidth = 3840;
                        game1.ResolutionHeight = 2160;
                        break;
                    default:
                        break;
                }

                switch (windowstate)
                {
                    case WindowState.Full:
                        switch (language)
                        {
                            case Language.english:
                                game1.graphicChange(0, "en_EN");
                                break;
                            case Language.german:
                                game1.graphicChange(0, "de_DE");
                                break;
                            default:
                                break;
                        }
                        break;
                    case WindowState.Window:
                        switch (language)
                        {
                            case Language.english:
                                game1.graphicChange(1, "en_EN");
                                break;
                            case Language.german:
                                game1.graphicChange(1, "de_DE");
                                break;
                            default:
                                break;
                        }
                        break;
                    case WindowState.Borderless:
                        switch (language)
                        {
                            case Language.english:
                                game1.graphicChange(2, "en_EN");
                                break;
                            case Language.german:
                                game1.graphicChange(2, "de_DE");
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (Yes.ButtonClick(mousePosition))
            {
                switch (confirmState)
                {
                    case ConfirmState.none:
                        break;
                    case ConfirmState.exit:
                        game1.Exit();
                        break;
                    case ConfirmState.backMenu:
                        game1.BackMainMenu();
                        disableButtons();
                        break;
                    case ConfirmState.save:
                        game1.Save();
                        disableButtons();
                        break;
                    case ConfirmState.load:
                        game1.Load(loadgame);
                        disableButtons();
                        break;
                    default:
                        break;
                }
            }

            if (No.ButtonClick(mousePosition))
            {
                switch (confirmState)
                {
                    case ConfirmState.none:
                        break;
                    case ConfirmState.exit:
                    case ConfirmState.backMenu:
                    case ConfirmState.save:
                        menuState = MenuState.main;
                        break;
                    case ConfirmState.load:
                        menuState = MenuState.load;
                        break;
                    default:
                        break;
                }
            }

            if (exitGame.ButtonClick(mousePosition))
            {
                confirmState = ConfirmState.exit;
                menuState = MenuState.confirm;
                return;
            }

            if (mainMenu.ButtonClick(mousePosition))
            {
                confirmState = ConfirmState.backMenu;
                menuState = MenuState.confirm;
                confirm();
                return;
            }
        }

        public void draw(int gamestate, SpriteBatch spriteBatch, SpriteFont font, Point mousePosition)
        {
            switch (gamestate)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:

                    switch (Convert.ToInt32(menuState))
                    {
                        case 0: //Menu

                            #region Buttondraw
                            /*if (saveGame.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, saveGame.buttonRectangle, Color.Gold);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[14], new Vector2(saveGame.buttonRectangle.X + 125, saveGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[14], new Vector2(saveGame.buttonRectangle.X + 95, saveGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, saveGame.buttonRectangle, Color.DarkGoldenrod);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[14], new Vector2(saveGame.buttonRectangle.X + 125, saveGame.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[14], new Vector2(saveGame.buttonRectangle.X + 95, saveGame.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }*/

                            if (options.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, options.buttonRectangle, Color.Gold);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, options.buttonRectangle, Color.DarkGoldenrod);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (mainMenu.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, mainMenu.buttonRectangle, Color.Gold);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 58, mainMenu.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 13, mainMenu.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, mainMenu.buttonRectangle, Color.DarkGoldenrod);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 58, mainMenu.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 13, mainMenu.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (exitGame.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, exitGame.buttonRectangle, Color.Gold);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 125, exitGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 55, exitGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, exitGame.buttonRectangle, Color.DarkGoldenrod);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 125, exitGame.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 55, exitGame.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            #endregion

                            break;
                        case 1: //Optionen

                            #region ButtonDraw

                            if (volume.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(Trackbar, volume.buttonRectangle, Color.White);
                                spriteBatch.Draw(Trackbar, new Rectangle(volume.buttonRectangle.X, volume.buttonRectangle.Y, volume.TrackRectangle.Width, volume.TrackRectangle.Height), new Rectangle(0, 0, volume.TrackRectangle.Width, volume.TrackRectangle.Height), Color.Cyan);
                                spriteBatch.DrawString(font, lines[8] + ": " + (100 * Math.Round((volume.TrackRectangle.Width / 500.0), 2)).ToString(),
                                                       new Vector2(volume.buttonRectangle.Center.X - 75, volume.buttonRectangle.Center.Y - 10), Color.AntiqueWhite);
                            }
                            else
                            {
                                spriteBatch.Draw(Trackbar, volume.buttonRectangle, Color.White);
                                spriteBatch.Draw(Trackbar, new Rectangle(volume.buttonRectangle.X, volume.buttonRectangle.Y, volume.TrackRectangle.Width, volume.TrackRectangle.Height), new Rectangle(0, 0, volume.TrackRectangle.Width, volume.TrackRectangle.Height), Color.DarkCyan);
                                spriteBatch.DrawString(font, lines[8] + ": " + (100 * Math.Round((volume.TrackRectangle.Width / 500.0), 2)).ToString(),
                                                       new Vector2(volume.buttonRectangle.Center.X - 75, volume.buttonRectangle.Center.Y - 10), Color.Wheat);
                            }


                            if (ResLeft.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(arrowLeft, ResLeft.buttonRectangle, Color.Cyan);
                            }
                            else
                            {
                                spriteBatch.Draw(arrowLeft, ResLeft.buttonRectangle, Color.DarkCyan);
                            }

                            if (ResRight.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(arrowRight, ResRight.buttonRectangle, Color.Cyan);
                            }
                            else
                            {
                                spriteBatch.Draw(arrowRight, ResRight.buttonRectangle, Color.DarkCyan);
                            }

                            switch (language)
                            {
                                case Language.english:
                                    if (resolution == Resolution.Auto)
                                    {
                                        spriteBatch.DrawString(font, resolutionString(), new Vector2(mitte + 115, ResRight.buttonRectangle.Center.Y), Color.White);
                                    }
                                    else
                                    {
                                        spriteBatch.DrawString(font, resolutionString(), new Vector2(mitte + 95, ResRight.buttonRectangle.Center.Y), Color.White);
                                    }
                                    break;
                                case Language.german:
                                    if (resolution == Resolution.Auto)
                                    {
                                        spriteBatch.DrawString(font, resolutionString(), new Vector2(mitte + 80, ResRight.buttonRectangle.Center.Y), Color.White);
                                    }
                                    else
                                    {
                                        spriteBatch.DrawString(font, resolutionString(), new Vector2(mitte + 95, ResRight.buttonRectangle.Center.Y), Color.White);
                                    }
                                    break;
                                default:
                                    break;
                            }

                            if (WinLeft.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(arrowLeft, WinLeft.buttonRectangle, Color.Cyan);
                            }
                            else
                            {
                                spriteBatch.Draw(arrowLeft, WinLeft.buttonRectangle, Color.DarkCyan);
                            }

                            if (WinRight.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(arrowRight, WinRight.buttonRectangle, Color.Cyan);
                            }
                            else
                            {
                                spriteBatch.Draw(arrowRight, WinRight.buttonRectangle, Color.DarkCyan);
                            }

                            switch (language)
                            {
                                case Language.english:
                                    switch (windowstate)
                                    {
                                        case WindowState.Full:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 80, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        case WindowState.Window:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 105, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        case WindowState.Borderless:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 40, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case Language.german:
                                    switch (windowstate)
                                    {
                                        case WindowState.Full:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 90, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        case WindowState.Window:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 105, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        case WindowState.Borderless:
                                            spriteBatch.DrawString(font, windowString(), new Vector2(mitte + 40, WinRight.buttonRectangle.Center.Y), Color.White);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }

                            if (graphicChanges.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, graphicChanges.buttonRectangle, Color.Cyan);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[9], new Vector2(graphicChanges.buttonRectangle.Center.X - 40, graphicChanges.buttonRectangle.Center.Y - 10), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[9], new Vector2(graphicChanges.buttonRectangle.Center.X - 70, graphicChanges.buttonRectangle.Center.Y - 10), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, graphicChanges.buttonRectangle, Color.DarkCyan);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[9], new Vector2(graphicChanges.buttonRectangle.Center.X - 40, graphicChanges.buttonRectangle.Center.Y - 10), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[9], new Vector2(graphicChanges.buttonRectangle.Center.X - 70, graphicChanges.buttonRectangle.Center.Y - 10), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (back.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.Cyan);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 125, back.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 105, back.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.DarkCyan);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 125, back.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[4], new Vector2(back.buttonRectangle.X + 105, back.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (german.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(de, german.buttonRectangle, Color.WhiteSmoke);
                            }
                            else
                            {
                                spriteBatch.Draw(de, german.buttonRectangle, Color.LightGray);
                            }

                            if (english.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(en, english.buttonRectangle, Color.WhiteSmoke);
                            }
                            else
                            {
                                spriteBatch.Draw(en, english.buttonRectangle, Color.LightGray);
                            }

                            #endregion


                            break;
                        case 2: //Laden

                            #region Buttondraw
                            if (back.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.Blue);
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.Blue);
                            }
                            spriteBatch.DrawString(font, "Back", new Vector2(back.buttonRectangle.X + 100, back.buttonRectangle.Y + 40), Color.Black);
                            #endregion

                            break;
                        case 3: //Bestätigung

                            #region Buttondraw
                            switch (confirmState)
                            {
                                case ConfirmState.none:
                                    break;
                                case ConfirmState.exit:

                                    #region Buttondraw

                                    if (options.ButtonHover(mousePosition))
                                    {
                                        spriteBatch.Draw(ButtonTexture, options.buttonRectangle, Color.Gold);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(ButtonTexture, options.buttonRectangle, Color.DarkGoldenrod);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    if (mainMenu.ButtonHover(mousePosition))
                                    {
                                        spriteBatch.Draw(ButtonTexture, mainMenu.buttonRectangle, Color.Gold);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 58, mainMenu.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 13, mainMenu.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(ButtonTexture, mainMenu.buttonRectangle, Color.DarkGoldenrod);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 58, mainMenu.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 13, mainMenu.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    if (exitGame.ButtonHover(mousePosition))
                                    {
                                        spriteBatch.Draw(ButtonTexture, exitGame.buttonRectangle, Color.Gold);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 125, exitGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 55, exitGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(ButtonTexture, exitGame.buttonRectangle, Color.DarkGoldenrod);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 125, exitGame.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 55, exitGame.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    spriteBatch.Draw(messageBox, new Rectangle(Yes.buttonRectangle.X + 100, Yes.buttonRectangle.Y - 170, 410, 150), Color.LightGray);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, "        Leave Game ?", new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y - 105), Color.Black);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, "      Spiel verlassen ?\n", new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y - 105), Color.Black);
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    break;

                                case ConfirmState.backMenu:

                                    #region Buttondraw

                                    if (options.ButtonHover(mousePosition))
                                    {
                                        spriteBatch.Draw(ButtonTexture, options.buttonRectangle, Color.Gold);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(ButtonTexture, options.buttonRectangle, Color.DarkGoldenrod);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    if (mainMenu.ButtonHover(mousePosition))
                                    {
                                        spriteBatch.Draw(ButtonTexture, mainMenu.buttonRectangle, Color.Gold);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 58, mainMenu.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 13, mainMenu.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(ButtonTexture, mainMenu.buttonRectangle, Color.DarkGoldenrod);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 58, mainMenu.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 13, mainMenu.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    if (exitGame.ButtonHover(mousePosition))
                                    {
                                        spriteBatch.Draw(ButtonTexture, exitGame.buttonRectangle, Color.Gold);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 125, exitGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 55, exitGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(ButtonTexture, exitGame.buttonRectangle, Color.DarkGoldenrod);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 125, exitGame.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 55, exitGame.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    spriteBatch.Draw(messageBox, new Rectangle(Yes.buttonRectangle.X + 100, Yes.buttonRectangle.Y - 170, 410, 150), Color.LightGray);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, "     Back to Mainmenu ?", new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y - 105), Color.Black);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, "  Zurueck zum Hauptmenu ?\n", new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y - 105), Color.Black);
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    break;

                                case ConfirmState.save:

                                    #region Buttondraw

                                    #region
                                    /*if (saveGame.ButtonHover(mousePosition))
                                    {
                                        spriteBatch.Draw(ButtonTexture, saveGame.buttonRectangle, Color.Gold);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[14], new Vector2(saveGame.buttonRectangle.X + 125, saveGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[14], new Vector2(saveGame.buttonRectangle.X + 95, saveGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(ButtonTexture, saveGame.buttonRectangle, Color.DarkGoldenrod);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[14], new Vector2(saveGame.buttonRectangle.X + 125, saveGame.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[14], new Vector2(saveGame.buttonRectangle.X + 95, saveGame.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            default:
                                                break;
                                        }
                                    }*/
                                    #endregion

                                    if (options.ButtonHover(mousePosition))
                                    {
                                        spriteBatch.Draw(ButtonTexture, options.buttonRectangle, Color.Gold);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(ButtonTexture, options.buttonRectangle, Color.DarkGoldenrod);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[2], new Vector2(options.buttonRectangle.X + 105, options.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    if (mainMenu.ButtonHover(mousePosition))
                                    {
                                        spriteBatch.Draw(ButtonTexture, mainMenu.buttonRectangle, Color.Gold);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 58, mainMenu.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 13, mainMenu.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(ButtonTexture, mainMenu.buttonRectangle, Color.DarkGoldenrod);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 58, mainMenu.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[15], new Vector2(mainMenu.buttonRectangle.X + 13, mainMenu.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    if (exitGame.ButtonHover(mousePosition))
                                    {
                                        spriteBatch.Draw(ButtonTexture, exitGame.buttonRectangle, Color.Gold);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 125, exitGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 55, exitGame.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(ButtonTexture, exitGame.buttonRectangle, Color.DarkGoldenrod);
                                        switch (language)
                                        {
                                            case Language.english:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 125, exitGame.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            case Language.german:
                                                spriteBatch.DrawString(font, lines[3], new Vector2(exitGame.buttonRectangle.X + 55, exitGame.buttonRectangle.Y + 40), Color.Black);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    
                                    spriteBatch.Draw(messageBox, new Rectangle(Yes.buttonRectangle.X + 100, Yes.buttonRectangle.Y - 170, 410, 150), Color.LightGray);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, "     Start a new Game ?\n(Old File will get deleted.)", new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y - 120), Color.Black);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, "    Neues Spiel starten ?\n" +
                                                                         "  (Der alte Speicherstand\n" +
                                                                         "      wird geloescht)", new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y - 120), Color.Black);
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    break;
                                case ConfirmState.load:

                                    #region Buttondraw

                                    spriteBatch.Draw(messageBox, new Rectangle(Yes.buttonRectangle.X + 100, Yes.buttonRectangle.Y - 170, 410, 150), Color.LightGray);
                                    switch (language)
                                    {
                                        case Language.english:
                                            spriteBatch.DrawString(font, "     Start a new Game ?\n(Old File will get deleted.)", new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y - 120), Color.Black);
                                            break;
                                        case Language.german:
                                            spriteBatch.DrawString(font, "    Neues Spiel starten ?\n" +
                                                                         "  (Der alte Speicherstand\n" +
                                                                         "      wird geloescht)", new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y - 120), Color.Black);
                                            break;
                                        default:
                                            break;
                                    }

                                    if (back.ButtonHover(mousePosition))
                                    {
                                        spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.Blue);
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(ButtonTexture, back.buttonRectangle, Color.Blue);
                                    }
                                    spriteBatch.DrawString(font, "Back", new Vector2(back.buttonRectangle.X + 100, back.buttonRectangle.Y + 40), Color.Black);
                                    #endregion

                                    break;
                                default:
                                    break;
                            }

                            if (Yes.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, Yes.buttonRectangle, Color.LightGray);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[7], new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[7], new Vector2(Yes.buttonRectangle.X + 130, Yes.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, Yes.buttonRectangle, Color.Gray);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[7], new Vector2(Yes.buttonRectangle.X + 125, Yes.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[7], new Vector2(Yes.buttonRectangle.X + 130, Yes.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (No.ButtonHover(mousePosition))
                            {
                                spriteBatch.Draw(ButtonTexture, No.buttonRectangle, Color.LightGray);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[6], new Vector2(No.buttonRectangle.X + 125, No.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[6], new Vector2(No.buttonRectangle.X + 125, No.buttonRectangle.Y + 40), Color.AntiqueWhite);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(ButtonTexture, No.buttonRectangle, Color.Gray);
                                switch (language)
                                {
                                    case Language.english:
                                        spriteBatch.DrawString(font, lines[6], new Vector2(No.buttonRectangle.X + 125, No.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    case Language.german:
                                        spriteBatch.DrawString(font, lines[6], new Vector2(No.buttonRectangle.X + 125, No.buttonRectangle.Y + 40), Color.Black);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            break;
                    }
                    #endregion

                    break;
                default:
                    break;
            }
        }

        private void disableButtons()
        {
            //saveGame.enabled = false;
            mainMenu.enabled = false;
            exitGame.enabled = false;
            options.enabled = false;
            back.enabled = false;
            WinRight.enabled = false;
            WinLeft.enabled = false;
            volume.enabled = false;
            ResRight.enabled = false;
            ResLeft.enabled = false;
            graphicChanges.enabled = false;
            german.enabled = false;
            english.enabled = false;
            Yes.enabled = false;
            No.enabled = false;
            menuState = MenuState.main;
        }

        private void backClick()
        {
            //saveGame.enabled = true;
            mainMenu.enabled = true;
            exitGame.enabled = true;
            options.enabled = false;
            back.enabled = true;
            WinRight.enabled = false;
            WinLeft.enabled = false;
            volume.enabled = false;
            ResRight.enabled = false;
            ResLeft.enabled = false;
            Yes.enabled = false;
            No.enabled = false;
            english.enabled = false;
            german.enabled = false;
        }

        /*
        800x600 SVGA
		1024x768 XGA
		1280x720 WXGA
		1920x1080 FHD
		2560x1440 QHD
		3840x2160 UHD
        */

        private void config(string loadedWidth, string windowMode)
        {
            switch (loadedWidth)
            {
                case "800":
                    resolution = Resolution.SVGA;
                    break;
                case "1024":
                    resolution = Resolution.XGA;
                    break;
                case "1280":
                    resolution = Resolution.WXGA;
                    break;
                case "1920":
                    resolution = Resolution.FHD;
                    break;
                case "2560":
                    resolution = Resolution.QHD;
                    break;
                case "3840":
                    resolution = Resolution.UHD;
                    break;
                case "auto":
                    resolution = Resolution.Auto;
                    break;
                default:
                    break;
            }

            switch (windowMode)
            {
                case "fullscreen":
                    windowstate = WindowState.Full;
                    break;
                case "window":
                    windowstate = WindowState.Window;
                    break;
                case "borderless":
                    windowstate = WindowState.Borderless;
                    break;
                default:
                    break;
            }
        }

        private string windowString()
        {
            switch (windowstate)
            {
                case WindowState.Full:
                    return "Fullscreen";
                case WindowState.Window:
                    return "Window";
                case WindowState.Borderless:
                    return "Window (Borderless)";
                default:
                    return "";
            }
        }

        private string resolutionString()
        {
            switch (resolution)
            {
                case Resolution.Auto:
                    return "Auto";
                case Resolution.SVGA:
                    return "800x600";
                case Resolution.XGA:
                    return "1024x768";
                case Resolution.WXGA:
                    return "1280x720";
                case Resolution.FHD:
                    return "1920x1080";
                case Resolution.QHD:
                    return "2560x1440";
                case Resolution.UHD:
                    return "3840x2160";
                default:
                    return "";
            }
        }

        private void confirm()
        {
            exitGame.enabled = false;
            options.enabled = false;
            back.enabled = false;
            Yes.enabled = true;
            No.enabled = true;
            german.enabled = false;
            english.enabled = false;
            WinRight.enabled = false;
            WinLeft.enabled = false;
            volume.enabled = false;
            ResRight.enabled = false;
            ResLeft.enabled = false;
            graphicChanges.enabled = false;
        }

        public void lang(string lan)
        {
            languageLoader.loadLanguage(ref lines, lan);

            if (lan == "en_EN")
            {
                language = Language.english;
            }

            if (lan == "de_DE")
            {
                language = Language.german;
            }
        }
    }
}
