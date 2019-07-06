using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YellowTale
{
    class HUD
    {
        public Texture2D xpFill, xpFrame, hpFill, hpFrame, coin;
        public Texture2D abilityload, abilitylocked;
        public Texture2D ability1Archer, ability2Archer, ability3Archer;
        public Texture2D ability1Wizard, ability2Wizard, ability3Wizard;
        public Texture2D ability1Knight, ability2Knight, ability3Knight;
        public Texture2D abilityLevel;
        public Texture2D headArcher, headWizard, headKnight;
        public Texture2D borderArcher, borderWizard, borderKnight;
        public Texture2D crosshair;

        Animations animations = new Animations();
        public SpriteFont font;


        private void drawxpbar(Vector2 Position, SpriteBatch spriteBatch, double current_XP, double levelUP)
        {
            spriteBatch.Draw(xpFrame, Position, Color.White);

            spriteBatch.Draw(xpFill, Position, new Rectangle(0, 0, Convert.ToInt32(128 * (current_XP / levelUP)), 32), Color.White);
        }

        private void drawhpBar(Vector2 Position, SpriteBatch spriteBatch, double current_HP, double maxHP)
        {
            spriteBatch.Draw(hpFrame, Position, Color.White);

            //Füllung zeichnen
            spriteBatch.Draw(hpFill, Position, new Rectangle(0, 0, Convert.ToInt32(128 * (current_HP / maxHP)), 32), Color.White);
        }

        private void drawAbility(Texture2D texture, Vector2 position, SpriteBatch spriteBatch, double currentTime, double maxTime)
        {
            spriteBatch.Draw(texture, position, Color.White);

            //Füllung zeichnen
            spriteBatch.Draw(abilityload, position, new Rectangle(0, 0, 60, Convert.ToInt32(60 * (currentTime / maxTime))), Color.White);
        }


        public void DrawHUD(SpriteBatch spriteBatch, GameTime gameTime, Vector2 mouseposition,int currentSpieler, AbilityManager abilityManager, Player _player)
        {
            if (currentSpieler == 0)
            {
                if (_player.LvlArcher >= 2)//Freigeschaltet ab lvl 2
                {
                    drawAbility(ability1Archer, new Vector2(950, 965), spriteBatch, abilityManager.CooldownAbility1Archer, abilityManager.MaxCooldownAbility1Archer);

                    if (_player.ArcherAbility1lvl == 1)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(950, 1030), Color.White);
                    }
                    else if (_player.ArcherAbility1lvl == 2)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(950, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(970, 1030), Color.White);
                    }
                    else if (_player.ArcherAbility1lvl == 3)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(950, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(970, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(990, 1030), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(abilitylocked, new Vector2(950, 975), Color.White);
                }


                if (_player.LvlArcher >= 4)//Freigeschaltet ab lvl 4
                {
                    drawAbility(ability2Archer, new Vector2(1030, 965), spriteBatch, abilityManager.CooldownAbility2Archer, abilityManager.MaxCooldownAbility2Archer);

                    if (_player.ArcherAbility2lvl == 1)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1030, 1030), Color.White);
                    }
                    else if (_player.ArcherAbility2lvl == 2)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1030, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1050, 1030), Color.White);
                    }
                    else if (_player.ArcherAbility2lvl == 3)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1030, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1050, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1070, 1030), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(abilitylocked, new Vector2(1030, 975), Color.White);
                }


                if (_player.LvlArcher >= 6)//Freigeschaltet ab lvl 6
                {
                    drawAbility(ability3Archer, new Vector2(1110, 965), spriteBatch, abilityManager.CooldownAbility3Archer, abilityManager.MaxCooldownAbility3Archer);

                    if (_player.ArcherAbility3lvl == 1)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1110, 1030), Color.White);
                    }
                    else if (_player.ArcherAbility3lvl == 2)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1110, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1130, 1030), Color.White);
                    }
                    else if (_player.ArcherAbility3lvl == 3)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1110, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1130, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1150, 1030), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(abilitylocked, new Vector2(1110, 975), Color.White);
                }

                drawhpBar(new Vector2(810, 1010), spriteBatch, _player.HpArcher, _player.HpArcherMax);
                drawxpbar(new Vector2(810, 970), spriteBatch, _player.XpArcher, _player.XpArcherMax);

                spriteBatch.DrawString(font, Convert.ToString(_player.XpArcher), new Vector2(865, 975), Color.Green);
                spriteBatch.Draw(headArcher, new Rectangle(690, 950, 100, 100), Color.White);
                spriteBatch.DrawString(font, Convert.ToString(_player.LvlArcher), new Vector2(765, 990), Color.Black);
            }
            else if (currentSpieler == 1)
            {
                if (_player.LvlWizard >= 2)//Freigeschaltet ab lvl 2
                {
                    drawAbility(ability1Wizard, new Vector2(950, 965), spriteBatch, abilityManager.CooldownAbility1Wizard, abilityManager.MaxCooldownAbility1Wizard);

                    if (_player.WizardAbility1lvl == 1)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(950, 1030), Color.White);
                    }
                    else if (_player.WizardAbility1lvl == 2)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(950, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(970, 1030), Color.White);
                    }
                    else if (_player.WizardAbility1lvl == 3)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(950, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(970, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(990, 1030), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(abilitylocked, new Vector2(950, 975), Color.White);

                }

                if (_player.LvlWizard >= 4)//Freigeschaltet ab lvl 4
                {
                    drawAbility(ability2Wizard, new Vector2(1030, 965), spriteBatch, abilityManager.CooldownAbility2Wizard, abilityManager.MaxCooldownAbility2Wizard);

                    if (_player.WizardAbility2lvl == 1)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1030, 1030), Color.White);
                    }
                    else if (_player.WizardAbility2lvl == 2)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1030, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1050, 1030), Color.White);
                    }
                    else if (_player.WizardAbility2lvl == 3)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1030, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1050, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1070, 1030), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(abilitylocked, new Vector2(1030, 975), Color.White);
                }

                if (_player.LvlWizard >= 6)//Freigeschaltet ab lvl 6
                {

                    drawAbility(ability3Wizard, new Vector2(1110, 965), spriteBatch, abilityManager.CooldownAbility3Wizard, abilityManager.MaxCooldownAbility3Wizard);

                    if (_player.WizardAbility3lvl == 1)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1110, 1030), Color.White);
                    }
                    else if (_player.WizardAbility3lvl == 2)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1110, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1130, 1030), Color.White);
                    }
                    else if (_player.WizardAbility3lvl == 3)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1110, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1130, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1150, 1030), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(abilitylocked, new Vector2(1110, 975), Color.White);
                }

                drawhpBar(new Vector2(810, 1010), spriteBatch, _player.HpWizard, _player.HpWizardMax);
                drawxpbar(new Vector2(810, 970), spriteBatch, _player.XpWizard, _player.XpWizardMax);

                spriteBatch.DrawString(font, Convert.ToString(_player.XpWizard), new Vector2(865, 975), Color.Green);
                spriteBatch.Draw(headWizard, new Rectangle(690, 950, 100, 100), Color.White);
                spriteBatch.DrawString(font, Convert.ToString(_player.LvlWizard), new Vector2(740, 1020), Color.White);
            }
            else if (currentSpieler == 2)
            {
                if (_player.LvlKnight >= 2)//Freigeschaltet ab lvl 2
                {
                    drawAbility(ability1Knight, new Vector2(950, 965), spriteBatch, abilityManager.CooldownAbility1Knight, abilityManager.MaxCooldownAbility1Knight);

                    if (_player.KnightAbility1lvl == 1)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(950, 1030), Color.White);
                    }
                    else if (_player.KnightAbility1lvl == 2)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(950, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(970, 1030), Color.White);
                    }
                    else if (_player.KnightAbility1lvl == 3)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(950, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(970, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(990, 1030), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(abilitylocked, new Vector2(950, 975), Color.White);

                }

                if (_player.LvlKnight >= 4)//Freigeschaltet ab lvl 4
                {
                    drawAbility(ability2Knight, new Vector2(1030, 965), spriteBatch, abilityManager.CooldownAbility2Knight, abilityManager.MaxCooldownAbility2Knight);

                    if (_player.KnightAbility2lvl == 1)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1030, 1030), Color.White);
                    }
                    else if (_player.KnightAbility2lvl == 2)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1030, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1050, 1030), Color.White);
                    }
                    else if (_player.KnightAbility2lvl == 3)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1030, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1050, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1070, 1030), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(abilitylocked, new Vector2(1030, 975), Color.White);

                }

                if (_player.LvlKnight >= 6)//Freigeschaltet ab lvl 6
                {
                    drawAbility(ability3Knight, new Vector2(1110, 965), spriteBatch, abilityManager.CooldownAbility3Knight, abilityManager.MaxCooldownAbility3Knight);

                    if (_player.KnightAbility3lvl == 1)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1110, 1030), Color.White);
                    }
                    else if (_player.KnightAbility3lvl == 2)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1110, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1130, 1030), Color.White);
                    }
                    else if (_player.KnightAbility3lvl == 3)
                    {
                        spriteBatch.Draw(abilityLevel, new Vector2(1110, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1130, 1030), Color.White);
                        spriteBatch.Draw(abilityLevel, new Vector2(1150, 1030), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(abilitylocked, new Vector2(1110, 975), Color.White);
                }

                drawhpBar(new Vector2(810, 1010), spriteBatch, _player.HpKnight, _player.HpKnightMax);
                drawxpbar(new Vector2(810, 970), spriteBatch, _player.XpKnight, _player.XpKnightMax);

                spriteBatch.DrawString(font, Convert.ToString(_player.XpKnight), new Vector2(865, 975), Color.Green);
                spriteBatch.Draw(headKnight, new Vector2(690, 930), Color.White);
                spriteBatch.DrawString(font, Convert.ToString(_player.LvlKnight), new Vector2(740, 1020), Color.White);
            }

            animations.drawanimation(coin, new Vector2(1820, 40), spriteBatch, animations.getanimation(gameTime, 8, 4), 30,30);
            spriteBatch.DrawString(font, Convert.ToString(_player.Coin), new Vector2(1850, 45), Color.Black);
        }
    }
}
