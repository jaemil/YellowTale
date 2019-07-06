using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YellowTale
{
    class AnimationManager
    {
        public Texture2D ArcherMove, ArcherIdle, ArcherHit;
        public Texture2D WizardMove, WizardIdle, WizardHit;
        public Texture2D KnightMove, KnightIdle, KnightHit;

        private Animations animations = new Animations();
        private Vector2 playerpositionoffset;

        public void PlayerAnimation(Vector2 playerposition, Vector2 mouseposition, int currentplayer,KeyboardState keyState, MouseState mouseState, SpriteBatch spriteBatch, GameTime gameTime)
        {
            playerpositionoffset = playerposition + new Vector2(16, 24);//Spieler Position mit Spieler Offset addieren

            if (playerpositionoffset.X - mouseposition.X < 0)//Animation Rechts
            {
                if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.A))//Wenn WASD gedrückt wird -> MOVE Animation
                {
                    if (currentplayer == 0)//Archer
                    {
                        animations.drawanimationrotation(ArcherMove, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                    if (currentplayer == 1)//Wizard
                    {
                        animations.drawanimationrotation(WizardMove, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                    if (currentplayer == 2)//Knight
                    {
                        animations.drawanimationrotation(KnightMove, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                }
                else//Wenn keine Taste gedrückt wird -> IDLE Animation
                {
                    if (currentplayer == 0)//Archer
                    {
                        animations.drawanimationrotation(ArcherIdle, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                    if (currentplayer == 1)//Wizard
                    {
                        animations.drawanimationrotation(WizardIdle, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                    if (currentplayer == 2)//Knight
                    {
                        animations.drawanimationrotation(KnightIdle, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                }
            }
            else if (playerpositionoffset.X - mouseposition.X >= 0)//Animation Links
            {
                if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.A))//Wenn WASD gedrückt wird -> MOVE Animation
                {
                    if (currentplayer == 0)//Archer
                    {
                        animations.drawanimationGespiegelt(ArcherMove, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                    if (currentplayer == 1)//Wizard
                    {
                        animations.drawanimationGespiegelt(WizardMove, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                    if (currentplayer == 2)//Knight
                    {
                        animations.drawanimationGespiegelt(KnightMove, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                }
                else//Wenn keine Taste gedrückt wird -> IDLE Animation
                {
                    if (currentplayer == 0)//Archer
                    {
                        animations.drawanimationGespiegelt(ArcherIdle, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                    if (currentplayer == 1)//Wizard
                    {
                        animations.drawanimationGespiegelt(WizardIdle, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                    if (currentplayer == 2)//Knight
                    {
                        animations.drawanimationGespiegelt(KnightIdle, playerposition, spriteBatch, animations.getanimation(gameTime, 8, 4), 32, 48, 0);
                    }
                }
            }
        }
    }
}
