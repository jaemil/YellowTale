using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace YellowTale
{
    class ShotEngine
    {
        private Vector2 shotXY;
        private Vector2 mouseXY;
        private Vector2 playerXY;
        private Vector2 directionXY;
        private Texture2D shotTexture;
        private float shotSpeed;
        private float oldSpeed;
        private float rotation = 0;
        private float currentTime = 0;
        private Vector2 shotSize;
        private int shotDamage;
        private string shotName;//Zur unterscheidung der Schüsse
        public Animations animations = new Animations();

        #region Eigenschaften
        public Vector2 ShotXY
        {
            get { return shotXY; }
            set { shotXY = value; }
        }
        public Vector2 MouseXY
        {
            get { return mouseXY; }
            set { mouseXY = value; }
        }
        public Vector2 PlayerXY
        {
            get { return playerXY; }
            set { playerXY = value; }
        }
        public Vector2 DirectionXY
        {
            get { return directionXY; }
            set { directionXY = value; }
        }
        public Texture2D ShotTexture
        {
            get { return shotTexture; }
            set { shotTexture = value; }
        }
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public float CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value; }
        }
        public Vector2 ShotSize
        {
            get { return shotSize; }
            set { shotSize = value; }
        }
        public float ShotSpeed
        {
            get { return shotSpeed; }
            set { shotSpeed = value; }
        }
        public float OldSpeed
        {
            get { return oldSpeed; }
            set { oldSpeed = value; }
        }
        public int ShotDamage
        {
            get { return shotDamage; }
            set { shotDamage = value; }
        }
        public string ShotName
        {
            get { return shotName; }
            set { shotName = value; }
        }
        #endregion

        public ShotEngine(Vector2 target, Vector2 start, float speed, Texture2D texture, Vector2 size, int damage, string name)
        {
            float speed1 = 0;

            shotName = name;
            oldSpeed = speed;
            shotDamage = damage;
            shotSize = size;
            speed *= 100;
            shotSpeed = speed;
            MouseXY = target;
            ShotTexture = texture;

            ShotXY = start;//Shot startet bei Player Position

            DirectionXY = MouseXY - start;

            rotation = (float)Math.Atan2((double)DirectionXY.Y, (double)DirectionXY.X);

            speed1 = DirectionXY.Length();
            //speed1 += speed1 / speed;

            DirectionXY = DirectionXY * (speed / speed1);
        }

        public void Update(GameTime gameTime)
        {
            ShotXY += DirectionXY * (float)gameTime.ElapsedGameTime.TotalSeconds;
            CurrentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }
    }

    class ShotStandard : ShotEngine
    {
        public ShotStandard(Vector2 target, Vector2 start, float speed, Texture2D texture, Vector2 _size, int _damage, string _name) : base(target, start, speed, texture, _size, _damage, _name)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(ShotTexture, ShotXY, null, Color.White, base.Rotation, new Vector2(ShotTexture.Width / 2, ShotTexture.Height / 2), 1.0f, SpriteEffects.None, 1.0f);
        }
    }

    class ShotAnimation : ShotEngine
    {
        int width, height, fps, frames;
        public ShotAnimation(Vector2 target, Vector2 start, float speed, Texture2D texture, int _fps, int _frames, int _width, int _height, Vector2 _size, int _damage, string _name) : base(target, start, speed, texture, _size, _damage, _name)
        {
            width = _width;
            height = _height;
            fps = _fps;
            frames = _frames;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            animations.drawanimationrotation(ShotTexture, ShotXY, spriteBatch, animations.getanimation(gameTime, fps, frames), width, height, base.Rotation);
        }
    }

    
}
