using System;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YellowTale
{
    abstract class Particle
    {
        protected Vector2 position;
        protected float cooldown = 0f;
        

        public float Cooldown
        {
            get { return cooldown; }
            set { cooldown = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Particle(Vector2 _position)
        {
            position = _position;
        }

        abstract public void Update(GameTime gameTime);

        abstract public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }

    class HitParticle : Particle
    {
        private Random random = new Random();
        private SpriteFont font;
        private int zufall;
        private float scale = 1.5f;
        private int damage;
        private float rotation = 0;
        private Color color;

        public int Zufall
        {
            get { return zufall; }
            set { zufall = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public HitParticle(SpriteFont _font, Vector2 _position, int _damage, Color _color) : base(_position)
        {
            font = _font;
            damage = _damage;
            color = _color;
        }

        public override void Update(GameTime gameTime)
        {
            Cooldown += (float)gameTime.ElapsedGameTime.TotalSeconds;
            scale -= 0.033f;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(font, Convert.ToString(damage), position, color, rotation, new Vector2(0,10), scale, SpriteEffects.None, 1f);
        }
    }

    class StandardParticle : Particle
    {
        private Animations animations = new Animations();
        private Texture2D standardTexture;

        public StandardParticle(Texture2D _texture, Vector2 _position) : base(_position)
        {
            standardTexture = _texture;
        }

        public override void Update(GameTime gameTime)
        {
            Cooldown += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            animations.drawanimation(standardTexture, position, spriteBatch, animations.getanimation(gameTime, 12, 7), 32, 32);//60 * 0.2 = 12;
        }
    }
}
