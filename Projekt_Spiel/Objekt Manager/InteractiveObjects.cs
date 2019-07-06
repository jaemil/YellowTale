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
    abstract class InteractiveObjects
    {
        protected Texture2D texture;//Texture
        protected Vector2 position;//Position

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public InteractiveObjects(Texture2D _texture, Vector2 _position)
        {
            texture = _texture;
            position = _position;
        }

        abstract public void Update(GameTime gameTime);

        abstract public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }

    class Dynamit : InteractiveObjects
    {
        private bool exploded = false;//Wird True wenn Dynamit ausgelöst wurde
        private bool explosion = false;//Wird True wenn Dynamit ausgelöst wird
        private Texture2D dynamitexplode1;
        private Texture2D dynamitexplode2;
        private Texture2D dynamitexplode3;
        private int auswahl;

        public bool Explosion
        {
            get { return explosion; }
            set { explosion = value; }
        }

        public bool Exploded
        {
            get { return exploded; }
            set { exploded = value; }
        }

        public Dynamit(Texture2D dynamit, Texture2D _dynamitexplode1, Texture2D _dynamitexplode2, Texture2D _dynamitexplode3, Vector2 position, int _auswahl) : base(dynamit, position)
        {
            dynamitexplode1 = _dynamitexplode1;
            dynamitexplode2 = _dynamitexplode2;
            dynamitexplode3 = _dynamitexplode3;
            auswahl = _auswahl;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (exploded)
            {
                if (auswahl == 1)//Verschiedene explosions Texturen
                {
                    spriteBatch.Draw(dynamitexplode1, Position, Color.White);
                }
                else if (auswahl == 2)
                {
                    spriteBatch.Draw(dynamitexplode2, Position, Color.White);
                }
                else if (auswahl == 3)
                {
                    spriteBatch.Draw(dynamitexplode3, Position, Color.White);
                }
            }
            else
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
        }
    }

    class Trap : InteractiveObjects
    {
        private Animations animations = new Animations();
        private float cooldown = 0f;

        public float Cooldown
        {
            get { return cooldown; }
            set { cooldown = value; }
        }

        public Trap(Texture2D texture, Vector2 position) : base(texture, position) { }

        public override void Update(GameTime gameTime)
        {
            if (cooldown <= 0.5f)
            {
                cooldown += (float)gameTime.ElapsedGameTime.TotalSeconds;//Cooldown aktualisieren
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            animations.drawanimation(Texture, Position, spriteBatch, animations.getanimation(gameTime, 12, 6), 64,64);
        }
    }

    class Chest : InteractiveObjects
    {
        private bool opened = false;
        private Texture2D close;

        public bool Opened
        {
            get { return opened; }
            set { opened = value; }
        }

        public Chest(Texture2D texture, Texture2D textureclose, Vector2 position) : base(texture, position)
        {
            close = textureclose;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (opened)
            {
                spriteBatch.Draw(close, Position, Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
        }
    }

    class ArrowTrap : InteractiveObjects
    {
        private int direction;
        private float cooldown = 0f;

        private Texture2D textureUpLoaded;
        private Texture2D textureUpUnloaded;

        private Texture2D textureRightLoaded;
        private Texture2D textureRightUnloaded;

        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public float Cooldown
        {
            get { return cooldown; }
            set { cooldown = value; }
        }

        public ArrowTrap(Texture2D _textureUpLoaded, Texture2D _textureUpUnloaded, Texture2D _textureRightLoaded, Texture2D _textureRightUnloaded, Vector2 position,int _direction) : base(_textureUpLoaded, position)
        {
            direction = _direction;
            textureUpLoaded = _textureUpLoaded;
            textureUpUnloaded = _textureUpUnloaded;

            textureRightLoaded = _textureRightLoaded;
            textureRightUnloaded = _textureRightUnloaded;
        }

        public override void Update(GameTime gameTime)
        {
            if (cooldown <= 1.0f)
            {
                cooldown += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (cooldown >= 0 && cooldown <= 0.5)//Pfeil nicht geladen
            {
                if (direction == 0)//Oben
                {
                    spriteBatch.Draw(textureUpUnloaded, Position, null, Color.White, 0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1.0f);
                }
                else if (direction == 1)//Rechts
                {
                    spriteBatch.Draw(textureRightUnloaded, Position, null, Color.White, 0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1.0f);
                }
                else if (direction == 2)//Unten
                {
                    spriteBatch.Draw(textureUpUnloaded, Position, null, Color.White, 0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipVertically, 1.0f);
                }
                else//Links
                {
                    spriteBatch.Draw(textureRightUnloaded, Position, null, Color.White, 0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 1.0f);
                }
            }
            else if (cooldown >= 0.5 && cooldown <= 1.0f)//Pfeil geladen
            {
                if (direction == 0)//Oben
                {
                    spriteBatch.Draw(textureUpLoaded, Position, null, Color.White, 0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1.0f);
                }
                else if (direction == 1)//Rechts
                {
                    spriteBatch.Draw(textureRightLoaded, Position, null, Color.White, 0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1.0f);
                }
                else if (direction == 2)//Unten
                {
                    spriteBatch.Draw(textureUpLoaded, Position, null, Color.White, 0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipVertically, 1.0f);
                }
                else//Links
                {
                    spriteBatch.Draw(textureRightLoaded, Position, null, Color.White, 0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 1.0f);
                }
            }
        }
    }
}
