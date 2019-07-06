using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace YellowTale
{
    class NPC
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected SpriteFont font;

        public NPC(Texture2D _texture, Vector2 _position, SpriteFont _font)
        {
            texture = _texture;
            position = _position;
            font = _font;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }

    class Tutorial : NPC
    {
        private float time;
        private int auswahl = 1;
        private List<Textbox> lstTextbox = new List<Textbox>();

        public Tutorial(Texture2D texture, Vector2 position, SpriteFont font) : base(texture, position, font)
        {

        }

        public void Update(GameTime gameTime, int language)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            switch (auswahl)
            {
                case 1:
                    {
                        if (lstTextbox.Count == 0)
                        {
                            if (language == 1)
                            {
                                lstTextbox.Add(new Textbox("W,A,S,D > Laufen", base.position - new Vector2(100, 50), base.font));
                            }
                            else
                            {
                                lstTextbox.Add(new Textbox("W,A,S,D > Move", base.position - new Vector2(100, 50), base.font));
                            }

                        }
                        else if (time >= 3.5f)
                        {
                            lstTextbox.RemoveRange(0, lstTextbox.Count);
                            time = 0f;
                            auswahl = 2;

                        }

                        break;
                    }
                case 2:
                    {
                        if (lstTextbox.Count == 0)
                        {
                            if (language == 1)
                            {
                                lstTextbox.Add(new Textbox("Linke Maustaste > Schuss", base.position - new Vector2(150, 50), base.font));
                            }
                            else
                            {
                                lstTextbox.Add(new Textbox("Left Click > Shot", base.position - new Vector2(150, 50), base.font));
                            }
                        }
                        else if (time >= 3.5f)
                        {
                            lstTextbox.RemoveRange(0, lstTextbox.Count);
                            time = 0f;

                            auswahl = 3;
                        }

                        break;
                    }
                case 3:
                    {
                        if (lstTextbox.Count == 0)
                        {
                            if (language == 1)
                            {
                                lstTextbox.Add(new Textbox("Rechte Maustaste > Dash", base.position - new Vector2(150, 50), base.font));
                            }
                            else
                            {
                                lstTextbox.Add(new Textbox("Right Click > Dash", base.position - new Vector2(150, 50), base.font));
                            }
                        }
                        else if (time >= 3.5f)
                        {
                            lstTextbox.RemoveRange(0, lstTextbox.Count);
                            time = 0f;

                            auswahl = 4;
                        }

                        break;
                    }
                case 4:
                    {
                        if (lstTextbox.Count == 0)
                        {
                            if (language == 1)
                            {
                                lstTextbox.Add(new Textbox("Shift, Q, E > Faehigkeiten", base.position - new Vector2(130, 50), base.font));
                            }
                            else
                            {
                                lstTextbox.Add(new Textbox("Shift, Q, E > Abilities", base.position - new Vector2(130, 50), base.font));
                            }
                        }
                        else if (time >= 3.5f)
                        {
                            lstTextbox.RemoveRange(0, lstTextbox.Count);
                            time = 0f;

                            auswahl = 5;
                        }

                        break;
                    }
                case 5:
                    {
                        if (lstTextbox.Count == 0)
                        {
                            if (language == 1)
                            {
                                lstTextbox.Add(new Textbox("Wald (links) > Level 0", base.position - new Vector2(130, 50), base.font));
                            }
                            else
                            {
                                lstTextbox.Add(new Textbox("Forrest (left) > level 0", base.position - new Vector2(130, 50), base.font));
                            }
                        }
                        else if (time >= 3.5f)
                        {
                            lstTextbox.RemoveRange(0, lstTextbox.Count);
                            time = 0f;

                            auswahl = 6;
                        }

                        break;
                    }
                case 6:
                    {
                        if (lstTextbox.Count == 0)
                        {
                            if (language == 1)
                            {
                                lstTextbox.Add(new Textbox("Eis (unten) > Level 6", base.position - new Vector2(130, 50), base.font));
                            }
                            else
                            {
                                lstTextbox.Add(new Textbox("Ice (bottom) > level 6", base.position - new Vector2(130, 50), base.font));
                            }
                        }
                        else if (time >= 3.5f)
                        {
                            lstTextbox.RemoveRange(0, lstTextbox.Count);
                            time = 0f;

                            auswahl = 7;
                        }

                        break;
                    }
                case 7:
                    {
                        if (lstTextbox.Count == 0)
                        {
                            if (language == 1)
                            {
                                lstTextbox.Add(new Textbox("Lava (rechts) > level 10", base.position - new Vector2(130, 50), base.font));
                            }
                            else
                            {
                                lstTextbox.Add(new Textbox("Lava (right) > level 10", base.position - new Vector2(130, 50), base.font));
                            }
                        }
                        else if (time >= 3.5f)
                        {
                            lstTextbox.RemoveRange(0, lstTextbox.Count);
                            time = 0f;

                            auswahl = 8;
                        }

                        break;
                    }
                case 8:
                    {
                        if (lstTextbox.Count == 0)
                        {
                            if (language == 1)
                            {
                                lstTextbox.Add(new Textbox("Vergess nicht den Shop zu benutzen!", base.position - new Vector2(150, 50), base.font));
                            }
                            else
                            {
                                lstTextbox.Add(new Textbox("Do not forget to use the shop!", base.position - new Vector2(150, 50), base.font));
                            }
                        }
                        else if (time >= 4f)
                        {
                            lstTextbox.RemoveRange(0, lstTextbox.Count);
                            time = 0f;

                            auswahl = 1;
                        }

                        break;
                    }
                default:
                    break;
            }


            for (int i = 0; i < lstTextbox.Count; i++)
            {
                lstTextbox[i].Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(base.texture, base.position, Color.White);

            for (int i = 0; i < lstTextbox.Count; i++)
            {
                lstTextbox[i].Draw(spriteBatch);
            }
        }
    }

    class Shop : NPC
    {
        HUD hud;
        Button upgrade1, upgrade2, upgrade3;
        Button switchClass1, switchClass2, switchClass3;
        Player player;
        Animations animations;
        enum Spieler { archer, wizard, knight }
        Spieler playerClass = Spieler.archer;

        int priceArcher1, priceArcher2, priceArcher3;
        int priceWizard1, priceWizard2, priceWizard3;
        int priceKnight1, priceKnight2, priceKnight3;

        public Shop(Texture2D texture, Vector2 position, SpriteFont font, HUD _hud, Player _player) : base(texture, position, font)
        {
            hud = _hud;
            upgrade1 = new Button(new Rectangle((int)position.X - 97, (int)position.Y + texture.Height + 10, 60, 60));
            upgrade2 = new Button(new Rectangle(upgrade1.buttonRectangle.X + upgrade1.buttonRectangle.Width + 20, upgrade1.buttonRectangle.Y, 60, 60));
            upgrade3 = new Button(new Rectangle(upgrade2.buttonRectangle.X + upgrade2.buttonRectangle.Width + 20, upgrade2.buttonRectangle.Y, 60, 60));

            switchClass1 = new Button(new Rectangle((int)position.X - 80, (int)position.Y - 70, 50, 60));
            switchClass2 = new Button(new Rectangle(switchClass1.buttonRectangle.X + switchClass1.buttonRectangle.Width + 20, switchClass1.buttonRectangle.Y, 50, 60));
            switchClass3 = new Button(new Rectangle(switchClass2.buttonRectangle.X + switchClass2.buttonRectangle.Width + 20, switchClass2.buttonRectangle.Y, 50, 60));
            animations = new Animations();
            player = _player;
        }

        public void Update(GameTime gameTime, int _playerClass, Player _player)
        {
            player = _player;
            switch (_playerClass)
            {
                case 0:
                    playerClass = Spieler.archer;
                    switchClass1.enabled = false;
                    switchClass2.enabled = true;
                    switchClass3.enabled = true;
                    break;
                case 1:
                    playerClass = Spieler.wizard;
                    switchClass1.enabled = true;
                    switchClass2.enabled = true;
                    switchClass3.enabled = false;
                    break;
                case 2:
                    playerClass = Spieler.knight;
                    switchClass1.enabled = true;
                    switchClass2.enabled = false;
                    switchClass3.enabled = true;
                    break;
                default:
                    break;
            }

            if (playerClass == Spieler.archer)
            {
                if (player.LvlArcher >= 2)
                {
                    switch (player.ArcherAbility1lvl)
                    {
                        case 1:
                            priceArcher1 = 10;
                            break;
                        case 2:
                            priceArcher1 = 20;
                            break;
                        default:
                            upgrade1.enabled = false;
                            priceArcher1 = player.Coin + 1;
                            break;
                    }
                }
                else
                {
                    upgrade1.enabled = false;
                    priceArcher1 = player.Coin + 1;
                }

                if (player.LvlArcher >= 4)
                {
                    switch (player.ArcherAbility2lvl)
                    {
                        case 1:
                            priceArcher2 = 15;
                            break;
                        case 2:
                            priceArcher2 = 30;
                            break;
                        default:
                            upgrade2.enabled = false;
                            priceArcher2 = player.Coin + 1;
                            break;
                    }
                }
                else
                {
                    upgrade2.enabled = false;
                    priceArcher2 = player.Coin + 1;
                }

                if (player.LvlArcher >= 6)
                {
                    switch (player.ArcherAbility3lvl)
                    {
                        case 1:
                            priceArcher3 = 20;
                            break;
                        case 2:
                            priceArcher3 = 40;
                            break;
                        default:
                            upgrade3.enabled = false;
                            priceArcher3 = player.Coin + 1;
                            break;
                    }
                }
                else
                {
                    upgrade3.enabled = false;
                    priceArcher3 = player.Coin + 1;
                }

                if (player.Coin < priceArcher1)
                {
                    upgrade1.enabled = false;
                }
                else
                {
                    upgrade1.enabled = true;
                }

                if (player.Coin < priceArcher2)
                {
                    upgrade2.enabled = false;
                }
                else
                {
                    upgrade2.enabled = true;
                }

                if (player.Coin < priceArcher3)
                {
                    upgrade3.enabled = false;
                }
                else
                {
                    upgrade3.enabled = true;
                }
            }
            else if (playerClass == Spieler.knight)
            {
                if (player.LvlKnight >= 2)
                {
                    switch (player.KnightAbility1lvl)
                    {
                        case 1:
                            priceKnight1 = 10;
                            break;
                        case 2:
                            priceKnight1 = 20;
                            break;
                        default:
                            upgrade1.enabled = false;
                            priceKnight1 = player.Coin + 1;
                            break;
                    }
                }
                else
                {
                    upgrade1.enabled = false;
                    priceKnight1 = player.Coin + 1;
                }

                if (player.LvlKnight >= 4)
                {
                    switch (player.KnightAbility2lvl)
                    {
                        case 1:
                            priceKnight2 = 15;
                            break;
                        case 2:
                            priceKnight2 = 30;
                            break;
                        default:
                            upgrade2.enabled = false;
                            priceKnight2 = player.Coin + 1;
                            break;
                    }
                }
                else
                {
                    upgrade2.enabled = false;
                    priceKnight2 = player.Coin + 1;
                }

                if (player.LvlKnight >= 6)
                {
                    switch (player.KnightAbility3lvl)
                    {
                        case 1:
                            priceKnight3 = 20;
                            break;
                        case 2:
                            priceKnight3 = 40;
                            break;
                        default:
                            upgrade3.enabled = false;
                            priceKnight3 = player.Coin + 1;
                            break;
                    }
                }
                else
                {
                    upgrade3.enabled = false;
                    priceKnight3 = player.Coin + 1;
                }


                if (player.Coin < priceKnight1)
                {
                    upgrade1.enabled = false;
                }
                else
                {
                    upgrade1.enabled = true;
                }

                if (player.Coin < priceKnight2)
                {
                    upgrade2.enabled = false;
                }
                else
                {
                    upgrade2.enabled = true;
                }

                if (player.Coin < priceKnight3)
                {
                    upgrade3.enabled = false;
                }
                else
                {
                    upgrade3.enabled = true;
                }

            }
            else if (playerClass == Spieler.wizard)
            {
                if (player.LvlWizard >= 2)
                {
                    switch (player.WizardAbility1lvl)
                    {
                        case 1:
                            priceWizard1 = 10;
                            break;
                        case 2:
                            priceWizard1 = 20;
                            break;
                        default:
                            upgrade1.enabled = false;
                            priceWizard1 = player.Coin + 1;
                            break;
                    }
                }
                else
                {
                    upgrade1.enabled = false;
                    priceWizard1 = player.Coin + 1;
                }

                if (player.LvlWizard >= 4)
                {
                    switch (player.WizardAbility2lvl)
                    {
                        case 1:
                            priceWizard2 = 15;
                            break;
                        case 2:
                            priceWizard2 = 30;
                            break;
                        default:
                            upgrade2.enabled = false;
                            priceWizard2 = player.Coin + 1;
                            break;
                    }
                }
                else
                {
                    upgrade2.enabled = false;
                    priceWizard2 = player.Coin + 1;
                }

                if (player.LvlWizard >= 6)
                {
                    switch (player.WizardAbility3lvl)
                    {
                        case 1:
                            priceWizard3 = 20;
                            break;
                        case 2:
                            priceWizard3 = 40;
                            break;
                        default:
                            upgrade3.enabled = false;
                            priceWizard3 = player.Coin + 1;
                            break;
                    }
                }
                else
                {
                    upgrade3.enabled = false;
                    priceWizard3 = player.Coin + 1;
                }


                if (player.Coin < priceWizard1)
                {
                    upgrade1.enabled = false;
                }
                else
                {
                    upgrade1.enabled = true;
                }

                if (player.Coin < priceWizard2)
                {
                    upgrade2.enabled = false;
                }
                else
                {
                    upgrade2.enabled = true;
                }

                if (player.Coin < priceWizard3)
                {
                    upgrade3.enabled = false;
                }
                else
                {
                    upgrade3.enabled = true;
                }

            }

        }

        public void clickCheck(Point mousePosition, ref Player player, Game1 game)
        {
            if (upgrade1.ButtonClick(mousePosition))
            {
                switch (playerClass)
                {
                    case Spieler.archer:
                        player.ArcherAbility1lvl++;
                        player.Coin -= priceArcher1;
                        break;
                    case Spieler.wizard:
                        player.WizardAbility1lvl++;
                        player.Coin -= priceWizard1;
                        break;
                    case Spieler.knight:
                        player.KnightAbility1lvl++;
                        player.Coin -= priceKnight1;
                        break;
                    default:
                        break;
                }
            }

            if (upgrade2.ButtonClick(mousePosition))
            {
                switch (playerClass)
                {
                    case Spieler.archer:
                        player.ArcherAbility2lvl++;
                        player.Coin -= priceArcher2;
                        break;
                    case Spieler.wizard:
                        player.WizardAbility2lvl++;
                        player.Coin -= priceWizard2;
                        break;
                    case Spieler.knight:
                        player.KnightAbility2lvl++;
                        player.Coin -= priceKnight2;
                        break;
                    default:
                        break;
                }
            }

            if (upgrade3.ButtonClick(mousePosition))
            {
                switch (playerClass)
                {
                    case Spieler.archer:
                        player.ArcherAbility3lvl++;
                        player.Coin -= priceArcher3;
                        break;
                    case Spieler.wizard:
                        player.WizardAbility3lvl++;
                        player.Coin -= priceWizard3;
                        break;
                    case Spieler.knight:
                        player.KnightAbility3lvl++;
                        player.Coin -= priceKnight3;
                        break;
                    default:
                        break;
                }
            }

            if (switchClass1.ButtonClick(mousePosition))
            {
                game.changeClass(0);
            }

            if (switchClass2.ButtonClick(mousePosition))
            {
                game.changeClass(1);
            }

            if (switchClass3.ButtonClick(mousePosition))
            {
                game.changeClass(2);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Point mousePosition, SpriteFont font)
        {
            switch (playerClass)
            {
                case Spieler.archer:

                    if (upgrade1.ButtonHover(mousePosition))
                    {
                        spriteBatch.Draw(hud.ability1Archer, upgrade1.buttonRectangle, Color.Gray);
                        spriteBatch.Draw(hud.abilityload, upgrade1.buttonRectangle, Color.Gray);

                        spriteBatch.DrawString(font, priceArcher1.ToString(), new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }
                    else if (!upgrade1.enabled)
                    {
                        spriteBatch.Draw(hud.ability1Archer, upgrade1.buttonRectangle, Color.IndianRed);
                        spriteBatch.Draw(hud.abilityload, upgrade1.buttonRectangle, Color.IndianRed);

                        if (player.ArcherAbility1lvl == 1)
                        {
                            spriteBatch.DrawString(font, "10", new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else if (player.ArcherAbility1lvl == 2)
                        {
                            spriteBatch.DrawString(font, "20", new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, "MAX", new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                        }
                    }
                    else
                    {
                        spriteBatch.Draw(hud.ability1Archer, upgrade1.buttonRectangle, Color.White);
                        spriteBatch.Draw(hud.abilityload, upgrade1.buttonRectangle, Color.White);

                        spriteBatch.DrawString(font, priceArcher1.ToString(), new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }

                    if (upgrade2.ButtonHover(mousePosition))
                    {
                        spriteBatch.Draw(hud.ability2Archer, upgrade2.buttonRectangle, Color.Gray);
                        spriteBatch.Draw(hud.abilityload, upgrade2.buttonRectangle, Color.Gray);

                        spriteBatch.DrawString(font, priceArcher2.ToString(), new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }
                    else if (!upgrade2.enabled)
                    {
                        spriteBatch.Draw(hud.ability2Archer, upgrade2.buttonRectangle, Color.IndianRed);
                        spriteBatch.Draw(hud.abilityload, upgrade2.buttonRectangle, Color.IndianRed);

                        if (player.ArcherAbility2lvl == 1)
                        {
                            spriteBatch.DrawString(font, "15", new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else if (player.ArcherAbility2lvl == 2)
                        {
                            spriteBatch.DrawString(font, "30", new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, "MAX", new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                        }
                    }
                    else
                    {
                        spriteBatch.Draw(hud.ability2Archer, upgrade2.buttonRectangle, Color.White);
                        spriteBatch.Draw(hud.abilityload, upgrade2.buttonRectangle, Color.White);

                        spriteBatch.DrawString(font, priceArcher2.ToString(), new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }

                    if (upgrade3.ButtonHover(mousePosition))
                    {
                        spriteBatch.Draw(hud.ability3Archer, upgrade3.buttonRectangle, Color.Gray);
                        spriteBatch.Draw(hud.abilityload, upgrade3.buttonRectangle, Color.Gray);

                        spriteBatch.DrawString(font, priceArcher3.ToString(), new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }
                    else if (!upgrade3.enabled)
                    {
                        spriteBatch.Draw(hud.ability3Archer, upgrade3.buttonRectangle, Color.IndianRed);
                        spriteBatch.Draw(hud.abilityload, upgrade3.buttonRectangle, Color.IndianRed);

                        if (player.ArcherAbility3lvl == 1)
                        {
                            spriteBatch.DrawString(font, "20", new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else if (player.ArcherAbility3lvl == 2)
                        {
                            spriteBatch.DrawString(font, "40", new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, "MAX", new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                        }
                    }
                    else
                    {
                        spriteBatch.Draw(hud.ability3Archer, upgrade3.buttonRectangle, Color.White);
                        spriteBatch.Draw(hud.abilityload, upgrade3.buttonRectangle, Color.White);

                        spriteBatch.DrawString(font, priceArcher3.ToString(), new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }

                    break;

                case Spieler.wizard:

                    if (upgrade1.ButtonHover(mousePosition))
                    {
                        spriteBatch.Draw(hud.ability1Wizard, upgrade1.buttonRectangle, Color.Gray);
                        spriteBatch.Draw(hud.abilityload, upgrade1.buttonRectangle, Color.Gray);

                        spriteBatch.DrawString(font, priceWizard1.ToString(), new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }
                    else if (!upgrade1.enabled)
                    {
                        spriteBatch.Draw(hud.ability1Wizard, upgrade1.buttonRectangle, Color.IndianRed);
                        spriteBatch.Draw(hud.abilityload, upgrade1.buttonRectangle, Color.IndianRed);

                        if (player.WizardAbility1lvl == 1)
                        {
                            spriteBatch.DrawString(font, "10", new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else if (player.WizardAbility1lvl == 2)
                        {
                            spriteBatch.DrawString(font, "20", new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, "MAX", new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                        }
                    }
                    else
                    {
                        spriteBatch.Draw(hud.ability1Wizard, upgrade1.buttonRectangle, Color.White);
                        spriteBatch.Draw(hud.abilityload, upgrade1.buttonRectangle, Color.White);

                        spriteBatch.DrawString(font, priceWizard1.ToString(), new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }

                    if (upgrade2.ButtonHover(mousePosition))
                    {
                        spriteBatch.Draw(hud.ability2Wizard, upgrade2.buttonRectangle, Color.Gray);
                        spriteBatch.Draw(hud.abilityload, upgrade2.buttonRectangle, Color.Gray);

                        spriteBatch.DrawString(font, priceWizard2.ToString(), new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }
                    else if (!upgrade2.enabled)
                    {
                        spriteBatch.Draw(hud.ability2Wizard, upgrade2.buttonRectangle, Color.IndianRed);
                        spriteBatch.Draw(hud.abilityload, upgrade2.buttonRectangle, Color.IndianRed);

                        if (player.WizardAbility2lvl == 1)
                        {
                            spriteBatch.DrawString(font, "15", new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else if (player.WizardAbility2lvl == 2)
                        {
                            spriteBatch.DrawString(font, "30", new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, "MAX", new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                        }
                    }
                    else
                    {
                        spriteBatch.Draw(hud.ability2Wizard, upgrade2.buttonRectangle, Color.White);
                        spriteBatch.Draw(hud.abilityload, upgrade2.buttonRectangle, Color.White);

                        spriteBatch.DrawString(font, priceWizard2.ToString(), new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }

                    if (upgrade3.ButtonHover(mousePosition))
                    {
                        spriteBatch.Draw(hud.ability3Wizard, upgrade3.buttonRectangle, Color.Gray);
                        spriteBatch.Draw(hud.abilityload, upgrade3.buttonRectangle, Color.Gray);

                        spriteBatch.DrawString(font, priceWizard3.ToString(), new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }
                    else if (!upgrade3.enabled)
                    {
                        spriteBatch.Draw(hud.ability3Wizard, upgrade3.buttonRectangle, Color.IndianRed);
                        spriteBatch.Draw(hud.abilityload, upgrade3.buttonRectangle, Color.IndianRed);

                        if (player.WizardAbility3lvl == 1)
                        {
                            spriteBatch.DrawString(font, "20", new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else if (player.WizardAbility3lvl == 2)
                        {
                            spriteBatch.DrawString(font, "40", new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, "MAX", new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                        }
                    }
                    else
                    {
                        spriteBatch.Draw(hud.ability3Wizard, upgrade3.buttonRectangle, Color.White);
                        spriteBatch.Draw(hud.abilityload, upgrade3.buttonRectangle, Color.White);

                        spriteBatch.DrawString(font, priceWizard3.ToString(), new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }

                    break;

                case Spieler.knight:

                    if (upgrade1.ButtonHover(mousePosition))
                    {
                        spriteBatch.Draw(hud.ability1Knight, upgrade1.buttonRectangle, Color.Gray);
                        spriteBatch.Draw(hud.abilityload, upgrade1.buttonRectangle, Color.Gray);

                        spriteBatch.DrawString(font, priceKnight1.ToString(), new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }
                    else if (!upgrade1.enabled)
                    {
                        spriteBatch.Draw(hud.ability1Knight, upgrade1.buttonRectangle, Color.IndianRed);
                        spriteBatch.Draw(hud.abilityload, upgrade1.buttonRectangle, Color.IndianRed);

                        if (player.KnightAbility1lvl == 1)
                        {
                            spriteBatch.DrawString(font, "10", new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else if (player.KnightAbility1lvl == 2)
                        {
                            spriteBatch.DrawString(font, "20", new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, "MAX", new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                        }
                    }
                    else
                    {
                        spriteBatch.Draw(hud.ability1Knight, upgrade1.buttonRectangle, Color.White);
                        spriteBatch.Draw(hud.abilityload, upgrade1.buttonRectangle, Color.White);

                        spriteBatch.DrawString(font, priceKnight1.ToString(), new Vector2(upgrade1.buttonRectangle.X + 10, upgrade1.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade1.buttonRectangle.X + 35, upgrade1.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }

                    if (upgrade2.ButtonHover(mousePosition))
                    {
                        spriteBatch.Draw(hud.ability2Knight, upgrade2.buttonRectangle, Color.Gray);
                        spriteBatch.Draw(hud.abilityload, upgrade2.buttonRectangle, Color.Gray);

                        spriteBatch.DrawString(font, priceKnight2.ToString(), new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }
                    else if (!upgrade2.enabled)
                    {
                        spriteBatch.Draw(hud.ability2Knight, upgrade2.buttonRectangle, Color.IndianRed);
                        spriteBatch.Draw(hud.abilityload, upgrade2.buttonRectangle, Color.IndianRed);

                        if (player.KnightAbility2lvl == 1)
                        {
                            spriteBatch.DrawString(font, "15", new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else if (player.KnightAbility2lvl == 2)
                        {
                            spriteBatch.DrawString(font, "30", new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, "MAX", new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                        }
                    }
                    else
                    {
                        spriteBatch.Draw(hud.ability2Knight, upgrade2.buttonRectangle, Color.White);
                        spriteBatch.Draw(hud.abilityload, upgrade2.buttonRectangle, Color.White);

                        spriteBatch.DrawString(font, priceKnight2.ToString(), new Vector2(upgrade2.buttonRectangle.X + 10, upgrade2.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade2.buttonRectangle.X + 35, upgrade2.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }

                    if (upgrade3.ButtonHover(mousePosition))
                    {
                        spriteBatch.Draw(hud.ability3Knight, upgrade3.buttonRectangle, Color.Gray);
                        spriteBatch.Draw(hud.abilityload, upgrade3.buttonRectangle, Color.Gray);

                        spriteBatch.DrawString(font, priceKnight3.ToString(), new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }
                    else if (!upgrade3.enabled)
                    {
                        spriteBatch.Draw(hud.ability3Knight, upgrade3.buttonRectangle, Color.IndianRed);
                        spriteBatch.Draw(hud.abilityload, upgrade3.buttonRectangle, Color.IndianRed);

                        if (player.KnightAbility3lvl == 1)
                        {
                            spriteBatch.DrawString(font, "20", new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else if (player.KnightAbility3lvl == 2)
                        {
                            spriteBatch.DrawString(font, "40", new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                            animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, "MAX", new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                        }
                    }
                    else
                    {
                        spriteBatch.Draw(hud.ability3Knight, upgrade3.buttonRectangle, Color.White);
                        spriteBatch.Draw(hud.abilityload, upgrade3.buttonRectangle, Color.White);

                        spriteBatch.DrawString(font, priceKnight3.ToString(), new Vector2(upgrade3.buttonRectangle.X + 10, upgrade3.buttonRectangle.Bottom + 11), Color.White);
                        animations.drawanimation(hud.coin, new Vector2(upgrade3.buttonRectangle.X + 35, upgrade3.buttonRectangle.Bottom + 5), spriteBatch, animations.getanimation(gameTime, 8, 4), 30, 30);
                    }

                    break;
                default:
                    break;
            }

            #region Klassenwechsel

            if (switchClass1.ButtonHover(mousePosition))
            {
                spriteBatch.Draw(hud.headArcher, switchClass1.buttonRectangle, Color.DarkSlateGray);
            }
            else if (!switchClass1.enabled)
            {
                spriteBatch.Draw(hud.headArcher, switchClass1.buttonRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(hud.headArcher, switchClass1.buttonRectangle, Color.White);
            }

            if (switchClass2.ButtonHover(mousePosition))
            {
                spriteBatch.Draw(hud.headKnight, switchClass2.buttonRectangle, Color.DarkSlateGray);
            }
            else if (!switchClass2.enabled)
            {
                spriteBatch.Draw(hud.headKnight, switchClass2.buttonRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(hud.headKnight, switchClass2.buttonRectangle, Color.White);
            }

            if (switchClass3.ButtonHover(mousePosition))
            {
                spriteBatch.Draw(hud.headWizard, switchClass3.buttonRectangle, Color.DarkSlateGray);
            }
            else if (!switchClass3.enabled)
            {
                spriteBatch.Draw(hud.headWizard, switchClass3.buttonRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(hud.headWizard, switchClass3.buttonRectangle, Color.White);
            }

            #endregion

            base.Draw(spriteBatch, gameTime);
        }

    }
}
