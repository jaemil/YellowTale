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
    class WeaponManager
    {
        public Texture2D bow;
        public Texture2D magicstaff;
        public Texture2D sword;
        public Texture2D swordburn;
        

        private Vector2 positionPlayer;
        private Vector2 positionWeapon;
        private Vector2 directionXY;
        private float rotation = 0;
        private int richtung = 1;
        private bool burn = false;

        Animations animations = new Animations();

        public Vector2 PositionWeapon
        {
            get { return positionWeapon; }
            set { positionWeapon = value; }
        }

        public bool Burn
        {
            get { return burn; }
            set { burn = value; }
        }

        int r = 10;


        public void Update(Vector2 mouse, Vector2 player, int currentPlayer)
        {
            if (currentPlayer == 0)
            {
                richtung = 1;
            }
            else if (currentPlayer == 1)
            {
                richtung = -1;
            }
            else if (currentPlayer == 2)
            {
                richtung = -1;
            }

            positionPlayer = player+ new Vector2(16, 24);
            directionXY = positionPlayer - mouse;
            directionXY *= richtung;

            if (directionXY != Vector2.Zero)
            {
                directionXY.Normalize();
            }

            rotation = (float)Math.Atan2((double)directionXY.Y, (double)directionXY.X);
            positionWeapon.X = Convert.ToInt32(r * Math.Sin(Math.PI / 180));
            positionWeapon.Y = Convert.ToInt32(r * Math.Cos(Math.PI / 180));
        }

        public void DrawWeapon(SpriteBatch spriteBatch, int currentPlayer, GameTime gameTime)
        {
            if (currentPlayer == 0)
            {
                spriteBatch.Draw(bow, positionPlayer, null, Color.White, rotation, positionWeapon + new Vector2(21, 21), 1.0f, SpriteEffects.None, 1.0f);
            }
            else if (currentPlayer == 1)
            {
                spriteBatch.Draw(magicstaff, positionPlayer, null, Color.White, rotation, positionWeapon + new Vector2(-10, -10), 1.0f, SpriteEffects.None, 1.0f);
            }
            else if (currentPlayer == 2)
            {
                if (burn)
                {
                    animations.drawanimationrotationknight(swordburn, positionPlayer, spriteBatch, animations.getanimation(gameTime, 10, 5), 90, 30, rotation);
                }
                else
                {
                    spriteBatch.Draw(sword, positionPlayer, null, Color.White, rotation, new Vector2(15,15), 1.0f, SpriteEffects.None, 1.0f);
                }
            }
        }
    }
}
