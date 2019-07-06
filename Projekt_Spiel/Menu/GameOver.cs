using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowTale
{
    class GameOver
    {
        public Texture2D Button;

        Button Load;
        Button Quit;
        Button BackMainMenu;

        string[] lines = new string[18];
        enum Language { english, german };
        Language language = Language.english;

        LoadLanguage languageLoader = new LoadLanguage();
        string oldLanguage;

        int mitte;

        public GameOver(string lan)
        {
            mitte = (1920 / 2) - (300 / 2);
            Load = new Button(new Rectangle(mitte, 430, 300, 100));
            BackMainMenu = new Button(new Rectangle(mitte, 560, 300, 100));
            Quit = new Button(new Rectangle(mitte, 690, 300, 100));

            oldLanguage = lan;
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

        public void Update(string lan)
        {
            if (lan != oldLanguage)
            {
                languageLoader.loadLanguage(ref lines, lan);
                oldLanguage = lan;

                if (lan == "en_EN")
                {
                    language = Language.english;
                }

                if (lan == "de_DE")
                {
                    language = Language.german;
                }
            }

            Load.enabled = true;
            Quit.enabled = true;
            BackMainMenu.enabled = true;
        }

        public void ClickCheck(int sv, Point mousePosition, Game1 game)
        {
            if (Load.ButtonClick(mousePosition))
            {
                game.Load(sv);
            }

            if (Quit.ButtonClick(mousePosition))
            {
                game.Exit();
            }

            if (BackMainMenu.ButtonClick(mousePosition))
            {
                disableButtons();
                game.BackMainMenu();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point mousePosition, SpriteFont font)
        {

            if (Load.ButtonHover(mousePosition))
            {
                spriteBatch.Draw(Button, Load.buttonRectangle, Color.DarkGray);
                switch (language)
                {
                    case Language.english:
                        spriteBatch.DrawString(font, lines[17], new Vector2(Load.buttonRectangle.X + 108, Load.buttonRectangle.Y + 40), Color.AntiqueWhite);
                        break;
                    case Language.german:
                        spriteBatch.DrawString(font, lines[17], new Vector2(Load.buttonRectangle.X + 68, Load.buttonRectangle.Y + 40), Color.AntiqueWhite);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                spriteBatch.Draw(Button, Load.buttonRectangle, Color.White);
                switch (language)
                {
                    case Language.english:
                        spriteBatch.DrawString(font, lines[17], new Vector2(Load.buttonRectangle.X + 108, Load.buttonRectangle.Y + 40), Color.Black);
                        break;
                    case Language.german:
                        spriteBatch.DrawString(font, lines[17], new Vector2(Load.buttonRectangle.X + 68, Load.buttonRectangle.Y + 40), Color.Black);
                        break;
                    default:
                        break;
                }
            }

            if (BackMainMenu.ButtonHover(mousePosition))
            {
                spriteBatch.Draw(Button, BackMainMenu.buttonRectangle, Color.DarkGray);
                switch (language)
                {
                    case Language.english:
                        spriteBatch.DrawString(font, lines[15], new Vector2(BackMainMenu.buttonRectangle.X + 58, BackMainMenu.buttonRectangle.Y + 40), Color.AntiqueWhite);
                        break;
                    case Language.german:
                        spriteBatch.DrawString(font, lines[15], new Vector2(BackMainMenu.buttonRectangle.X + 13, BackMainMenu.buttonRectangle.Y + 40), Color.AntiqueWhite);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                spriteBatch.Draw(Button, BackMainMenu.buttonRectangle, Color.White);
                switch (language)
                {
                    case Language.english:
                        spriteBatch.DrawString(font, lines[15], new Vector2(BackMainMenu.buttonRectangle.X + 58, BackMainMenu.buttonRectangle.Y + 40), Color.Black);
                        break;
                    case Language.german:
                        spriteBatch.DrawString(font, lines[15], new Vector2(BackMainMenu.buttonRectangle.X + 13, BackMainMenu.buttonRectangle.Y + 40), Color.Black);
                        break;
                    default:
                        break;
                }
            }

            if (Quit.ButtonHover(mousePosition))
            {
                spriteBatch.Draw(Button, Quit.buttonRectangle, Color.DarkGray);
                switch (language)
                {
                    case Language.english:
                        spriteBatch.DrawString(font, lines[3], new Vector2(Quit.buttonRectangle.X + 125, Quit.buttonRectangle.Y + 40), Color.AntiqueWhite);
                        break;
                    case Language.german:
                        spriteBatch.DrawString(font, lines[3], new Vector2(Quit.buttonRectangle.X + 55, Quit.buttonRectangle.Y + 40), Color.AntiqueWhite);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                spriteBatch.Draw(Button, Quit.buttonRectangle, Color.White);
                switch (language)
                {
                    case Language.english:
                        spriteBatch.DrawString(font, lines[3], new Vector2(Quit.buttonRectangle.X + 125, Quit.buttonRectangle.Y + 40), Color.Black);
                        break;
                    case Language.german:
                        spriteBatch.DrawString(font, lines[3], new Vector2(Quit.buttonRectangle.X + 55, Quit.buttonRectangle.Y + 40), Color.Black);
                        break;
                    default:
                        break;
                }
            }
        }

        private void disableButtons()
        {
            Load.enabled = false;
            Quit.enabled = false;
            BackMainMenu.enabled = false;
        }
    }
}
