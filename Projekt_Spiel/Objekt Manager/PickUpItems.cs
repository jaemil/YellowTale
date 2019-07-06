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
    class PickUpItems
    {
        protected Animations animations = new Animations();

        private Texture2D itemTexture;

        private Vector2 itemPosition;
        private Vector2 itemSize;
        private Vector2 directionXY;

        private int radius = 100;//Einsammel Radius
        private int speed = 8;//Einsammel Geschwindigkeit
        private int height = 0;
        private bool collected = false;
        private bool down = false;//True = runter, false = hoch


        public Texture2D ItemTexture { get { return itemTexture; } set { itemTexture = value; } }
        public Vector2 ItemPosition { get { return itemPosition; } set { itemPosition = value; } }
        public Vector2 ItemSize { get { return itemSize; } set { itemSize = value; } }
        public int Radius { get { return radius; } set { radius = value; } }
        public int Speed { get { return speed; } set { speed = value; } }
        public bool Collected { get { return collected; } set { collected = value; } }

        public PickUpItems(Texture2D _coinTexture, Vector2 _coinPosition, Vector2 _coinSize)
        {
            itemTexture = _coinTexture;
            itemPosition = _coinPosition;
            itemSize = _coinSize;
        }

        public void Update(Vector2 _playerPosition)
        {
            directionXY = _playerPosition - itemPosition;

            if (directionXY.X < radius && directionXY.X > -radius && directionXY.Y < radius && directionXY.Y > -radius)//Item Magnet
            {
                if (directionXY != Vector2.Zero)
                {
                    directionXY.Normalize();
                }

                itemPosition += directionXY * speed;
            }
            else//Item bewegung
            {
                if (height == 0)
                {
                    down = true;
                }
                else if (height == 50)
                {
                    down = false;
                }

                if (down)
                {
                    height++;
                    if (height % 5 == 0)
                    {
                        itemPosition.Y++;
                    }
                }
                else
                {
                    height--;
                    if (height % 5 == 0)
                    {
                        itemPosition.Y--;
                    }
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }
    }

    class Coin : PickUpItems
    {
        public Coin(Texture2D _coinTexture, Vector2 _coinPosition, Vector2 _coinSize) : base(_coinTexture, _coinPosition, _coinSize)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.animations.drawanimation(base.ItemTexture, base.ItemPosition, spriteBatch, base.animations.getanimation(gameTime, 4, 4), 20, 20);
        }
    }

    class Experience : PickUpItems
    {
        public Experience(Texture2D _EXPTexture, Vector2 _EXPPosition, Vector2 _EXPSize) : base(_EXPTexture, _EXPPosition, _EXPSize)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.animations.drawanimation(base.ItemTexture, base.ItemPosition, spriteBatch, base.animations.getanimation(gameTime, 10, 10), 20, 20);
        }
    }

    class HealthPotionSmall : PickUpItems
    {
        Random random = new Random();
        int zufall;
        Texture2D potionTexture2;

        public HealthPotionSmall(Texture2D _PotionTexture1, Texture2D _PotionTexture2, Vector2 _PotionPosition, Vector2 _PotionSize) : base(_PotionTexture1, _PotionPosition, _PotionSize)
        {
            zufall = random.Next(0, 2); 
            potionTexture2 = _PotionTexture2;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (zufall == 0)
            {
                spriteBatch.Draw(base.ItemTexture, base.ItemPosition, Color.White);
            }
            else
            {
                spriteBatch.Draw(potionTexture2, base.ItemPosition, Color.White);
            }
        }
    }

    class HealthPotionBig : PickUpItems
    {
        Random random = new Random();
        int zufall;
        Texture2D potionTexture2;

        public HealthPotionBig(Texture2D _PotionTexture1, Texture2D _PotionTexture2, Vector2 _PotionPosition, Vector2 _PotionSize) : base(_PotionTexture1, _PotionPosition, _PotionSize)
        {
            zufall = random.Next(0, 2);
            potionTexture2 = _PotionTexture2;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (zufall == 0)
            {
                spriteBatch.Draw(base.ItemTexture, base.ItemPosition, Color.White);
            }
            else
            {
                spriteBatch.Draw(potionTexture2, base.ItemPosition, Color.White);
            }
        }
    }

    class Hourglass : PickUpItems
    {
        public Hourglass(Texture2D _hourglass, Vector2 _position, Vector2 _size) : base(_hourglass, _position, _size)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(base.ItemTexture, base.ItemPosition, Color.White);
        }
    }
}
