using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YellowTale
{
    abstract class Enemy
    {
        protected Animations animations = new Animations();

        protected Vector2 enemyXY;//Gegner Position
        protected Texture2D enemyTextureIdle;//Gegner Texture Idle
        protected Texture2D enemyTextureRun;//Gegner Texture Run
        protected float enemyspeed;//Gegner Geschwindigkeit
        protected Vector2 playerXY;//Spieler Position -> Ziel Position
        protected Vector2 enemySize;//Größe der Collision
        protected int enemyHP;//Gegner aktuelles Leben
        protected int enemyMaxHP;//Gegner Max Leben
        protected Texture2D enemyAnzeige;//Gegner Texture
        protected Texture2D enemyFrame;//Gegner Texture
        protected int enemyRadius;//Gegner Target erst wenn Spieler in einen Bestimmten Radius ist
        protected bool enemyTarget = false;//True = Gegner verfolgt Spieler
        protected float enemyCooldown;//Cooldown
        protected float enemyCooldownMax;//Cooldown Maximal
        protected string enemyName;//Zuteilung des Gegner Namen
        protected Random enemyRandom;//Random Objekt das übergeben wwurde
        protected int enemyDamage;//Schaden des Gegners


        #region Eigenschaften
        public Vector2 EnemyXY
        {
            get { return enemyXY; }
            set { enemyXY = value; }
        }

        public Vector2 EnemySize
        {
            get { return enemySize; }
            set { enemySize = value; }
        }

        public int EnemyHP
        {
            get { return enemyHP; }
            set { enemyHP = value; }
        }

        public int EnemyMaxHP
        {
            get { return enemyMaxHP; }
            set { enemyMaxHP = value; }
        }

        public float EnemyCooldown
        {
            get { return enemyCooldown; }
            set { enemyCooldown = value; }
        }

        public float EnemyCooldownMax
        {
            get { return enemyCooldownMax; }
            set { enemyCooldownMax = value; }
        }

        public bool EnemyTarget
        {
            get { return enemyTarget; }
            set { enemyTarget = value; }
        }

        public string EnemyName
        {
            get { return enemyName; }
            set { enemyName = value; }
        }

        public int EnemyDamage
        {
            get { return enemyDamage; }
            set { enemyDamage = value; }
        }
        #endregion

        public Enemy(Vector2 enemy, Texture2D textureIdle, Texture2D textureRun, Texture2D anzeige, Texture2D frame, float speed, Vector2 collision, int hp, int radius, float cooldownMax, string name, Random random, int dmg)
        {
            enemyXY = enemy;
            enemyTextureIdle = textureIdle;
            enemyTextureRun = textureRun;
            enemyspeed = speed;
            enemySize = collision;
            enemyMaxHP = hp;
            enemyAnzeige = anzeige;
            enemyFrame = frame;
            enemyHP = hp;
            enemyRadius = radius;
            enemyCooldownMax = cooldownMax;
            enemyCooldown = cooldownMax;
            enemyName = name;
            enemyRandom = random;
            enemyDamage = dmg;
        }

        public abstract void Update(GameTime gameTime, Vector2 player, Collision collision);


        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (playerXY.X - EnemyXY.X < 0)//Animation Rechts
            {
                if (enemyTarget)
                {
                    animations.drawanimationGespiegelt(enemyTextureRun, enemyXY, spriteBatch, animations.getanimation(gameTime, 10, 4), enemyTextureIdle.Width, enemyTextureIdle.Height / 4, 0);//Gegner zeichnen
                }
                else
                {
                    animations.drawanimationGespiegelt(enemyTextureIdle, enemyXY, spriteBatch, animations.getanimation(gameTime, 10, 4), enemyTextureIdle.Width, enemyTextureIdle.Height / 4, 0);//Gegner zeichnen
                }
            }
            else
            {
                if (enemyTarget)
                {
                    animations.drawanimation(enemyTextureRun, enemyXY, spriteBatch, animations.getanimation(gameTime, 10, 4), enemyTextureIdle.Width, enemyTextureIdle.Height / 4);//Gegner zeichnen
                }
                else
                {
                    animations.drawanimation(enemyTextureIdle, enemyXY, spriteBatch, animations.getanimation(gameTime, 10, 4), enemyTextureIdle.Width, enemyTextureIdle.Height / 4);//Gegner zeichnen
                }
            }

            spriteBatch.Draw(enemyFrame, new Vector2(enemyXY.X + 8, enemyXY.Y + enemyTextureIdle.Height / 4), Color.White);//Frame Zeichnen
            spriteBatch.Draw(enemyAnzeige, new Vector2(enemyXY.X + 8, enemyXY.Y + enemyTextureIdle.Height / 4), new Rectangle(0, 0, Convert.ToInt32(enemyAnzeige.Width * ((double)enemyHP / (double)enemyMaxHP)), 8), Color.White);//Füllung zeichnen
        }
    }

    class Ranged : Enemy
    {
        private float enemyShotSpeed;//Geschwindkeit des Projectiles
        int height = 0;
        bool up;
        int richtung;
        Random random = new Random();

        public float EnemyShotSpeed
        {
            get { return enemyShotSpeed; }
            set { enemyShotSpeed = value; }
        }

        public Ranged(Vector2 position, Texture2D textureIdle, Texture2D textureRun, Texture2D fill, Texture2D frame, float speed, Vector2 collision, int hp, int radius, float cooldownMax, float shotSpeed, string enemyName, Random random, int dmg) : base(position, textureIdle, textureRun, fill, frame, speed, collision, hp, radius, cooldownMax, enemyName, random, dmg)
        {
            EnemyShotSpeed = shotSpeed;
        }

        public override void Update(GameTime gameTime, Vector2 playerPosition, Collision collision)
        {
            playerXY = playerPosition;//Spieler Position(Ziel) Aktualisieren


            if (playerXY.X < enemyRadius + EnemyXY.X && playerXY.X > -enemyRadius + EnemyXY.X && playerXY.Y < enemyRadius + EnemyXY.Y && playerXY.Y > -enemyRadius + EnemyXY.Y)//Wenn Spieler in Gegner Radius ist
            {
                enemyTarget = true;
            }

            if (enemyTarget)
            {
                if (playerXY.X > enemyXY.X)
                {
                    if (playerXY.Y > enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X < playerXY.X)
                            {
                                enemyXY.X += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y < playerXY.Y)
                            {
                                enemyXY.Y += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (playerXY.Y < enemyXY.Y - 32)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X < playerXY.X)
                            {
                                enemyXY.X += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y > playerXY.Y)
                            {
                                enemyXY.Y -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X < playerXY.X)
                            {
                                enemyXY.X += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else if (playerXY.X < enemyXY.X)
                {
                    if (playerXY.Y > enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X > playerXY.X)
                            {
                                enemyXY.X -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y < playerXY.Y)
                            {
                                enemyXY.Y += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (playerXY.Y < enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X > playerXY.X)
                            {
                                enemyXY.X -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y > playerXY.Y)
                            {
                                enemyXY.Y -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X > playerXY.X)
                            {
                                enemyXY.X -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else if (playerXY.X == enemyXY.X)
                {
                    if (playerXY.Y > enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y < playerXY.Y)
                            {
                                enemyXY.Y += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (playerXY.Y < enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y > playerXY.Y)
                            {
                                enemyXY.Y -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                switch (richtung)
                {
                    case 0:
                        {
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y--;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X++;
                            }
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y--;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X++;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X++;
                            }
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y++;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y++;
                            }
                            break;
                        }
                    case 5:
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X--;
                            }
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y++;
                            }
                            break;
                        }
                    case 6:
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X--;
                            }
                            break;
                        }
                    case 7:
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X--;
                            }
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y--;
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }

                if (height == 0)
                {
                    richtung = enemyRandom.Next(1, 30);
                    up = true;
                }
                else if (height == 50)
                {
                    richtung = enemyRandom.Next(1, 30);
                    up = false;
                }

                if (up)
                {
                    height++;
                }
                else
                {
                    height--;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
        }
    }

    class Melee : Enemy
    {
        int height = 0;
        bool up;
        int richtung;
        Random random = new Random();

        public Melee(Vector2 position, Texture2D textureIdle, Texture2D textureRun, Texture2D fill, Texture2D frame, float speed, Vector2 collision, int hp, int radius, float cooldownMax, string enemyName, Random random, int dmg) : base(position, textureIdle, textureRun, fill, frame, speed, collision, hp, radius, cooldownMax, enemyName, random, dmg)
        {

        }

        public override void Update(GameTime gameTime, Vector2 playerPosition, Collision collision)//Auf Nähe gehen
        {
            playerXY = playerPosition;//Spieler Position(Ziel) Aktualisieren


            if (playerXY.X < enemyRadius + EnemyXY.X && playerXY.X > -enemyRadius + EnemyXY.X && playerXY.Y < enemyRadius + EnemyXY.Y && playerXY.Y > -enemyRadius + EnemyXY.Y)//Wenn Spieler in Gegner Radius ist
            {
                enemyTarget = true;
            }

            if (enemyTarget)
            {
                if (playerXY.X > enemyXY.X)
                {
                    if (playerXY.Y > enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X < playerXY.X)
                            {
                                enemyXY.X += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y < playerXY.Y)
                            {
                                enemyXY.Y += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (playerXY.Y < enemyXY.Y - 32)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X < playerXY.X)
                            {
                                enemyXY.X += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y > playerXY.Y)
                            {
                                enemyXY.Y -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X < playerXY.X)
                            {
                                enemyXY.X += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else if (playerXY.X < enemyXY.X)
                {
                    if (playerXY.Y > enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X > playerXY.X)
                            {
                                enemyXY.X -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y < playerXY.Y)
                            {
                                enemyXY.Y += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (playerXY.Y < enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X > playerXY.X)
                            {
                                enemyXY.X -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y > playerXY.Y)
                            {
                                enemyXY.Y -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X > playerXY.X)
                            {
                                enemyXY.X -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else if (playerXY.X == enemyXY.X)
                {
                    if (playerXY.Y > enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y < playerXY.Y)
                            {
                                enemyXY.Y += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (playerXY.Y < enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y > playerXY.Y)
                            {
                                enemyXY.Y -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                switch (richtung)
                {
                    case 0:
                        {
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y--;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X++;
                            }
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y--;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X++;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X++;
                            }
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y++;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y++;
                            }
                            break;
                        }
                    case 5:
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X--;
                            }
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y++;
                            }
                            break;
                        }
                    case 6:
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X--;
                            }
                            break;
                        }
                    case 7:
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.X--;
                            }
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X))
                            {
                                enemyXY.Y--;
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }

                if (height == 0)
                {
                    richtung = enemyRandom.Next(1, 30);
                    up = true;
                }
                else if (height == 50)
                {
                    richtung = enemyRandom.Next(1, 30);
                    up = false;
                }

                if (up)
                {
                    height++;
                }
                else
                {
                    height--;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
        }
    }

    class Boss : Ranged
    {
        Texture2D crack;
        int state = 0;//0 = unsterblich/Ei zu, 1 = sterblich/Ei offen, 2 = Ei bewegen
        float stateCooldown;
        public int State
        {
            get { return state; }
            set { state = value; }
        }

        public float StateCooldown
        {
            get { return stateCooldown; }
            set { stateCooldown = value; }
        }

        public Boss(Vector2 position, Texture2D textureIdle, Texture2D textureRun, Texture2D textureCrack, Texture2D fill, Texture2D frame, float speed, Vector2 collision, int hp, int radius, float cooldownMax, float shotSpeed, string enemyName, Random random, int dmg) : base(position, textureIdle, textureRun, fill, frame, speed, collision, hp, radius, cooldownMax, shotSpeed, enemyName, random, dmg)
        {
            crack = textureCrack;
            stateCooldown = 1f;
        }

        public override void Update(GameTime gameTime, Vector2 playerPosition, Collision collision)
        {
            if (state == 2)
            {
                base.Update(gameTime, playerPosition, collision);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            if (stateCooldown < 6)
            {
                state = 0;
                animations.drawanimation(crack, enemyXY, spriteBatch, animations.getanimation(gameTime, 1, 6), crack.Width, crack.Height / 6);//Gegner zeichnen
            }
            else if (stateCooldown >= 6 && stateCooldown < 10)
            {
                state = 1;
                animations.drawanimation(enemyTextureRun, enemyXY, spriteBatch, animations.getanimation(gameTime, 6, 3), enemyTextureRun.Width, enemyTextureRun.Height / 3);//Gegner zeichnen
            }
            else if (stateCooldown > 10 && stateCooldown <= 14)
            {
                state = 2;
                spriteBatch.Draw(enemyTextureIdle, enemyXY, Color.White);

                if (stateCooldown >= 13.9)
                {
                    stateCooldown = 6f;
                }
            }


            spriteBatch.Draw(enemyFrame, new Vector2(enemyXY.X + 36, enemyXY.Y + enemyTextureIdle.Height), Color.White);//Frame Zeichnen
            spriteBatch.Draw(enemyAnzeige, new Vector2(enemyXY.X + 36, enemyXY.Y + enemyTextureIdle.Height), new Rectangle(0, 0, Convert.ToInt32(enemyAnzeige.Width * ((double)enemyHP / (double)enemyMaxHP)), 8), Color.White);//Füllung zeichnen
        }
    }

    class Egg : Boss
    {
        Texture2D crack;

        public Egg(Vector2 position, Texture2D textureIdle, Texture2D textureRun, Texture2D textureCrack, Texture2D fill, Texture2D frame, float speed, Vector2 collision, int hp, int radius, float cooldownMax, float shotSpeed, string enemyName, Random random, int dmg) : base(position, textureIdle, textureRun, textureCrack, fill, frame, speed, collision, hp, radius, cooldownMax, shotSpeed, enemyName, random, dmg)
        {
            crack = textureCrack;
            StateCooldown = 0f;
        }

        public override void Update(GameTime gameTime, Vector2 playerPosition, Collision collision)
        {
            if (State == 2)
            {
                base.Update(gameTime, playerPosition, collision);

            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            if (StateCooldown < 5)
            {
                State = 0;
                animations.drawanimation(crack, enemyXY, spriteBatch, animations.getanimation(gameTime, 1, 6), crack.Width, crack.Height / 6);//Gegner zeichnen
            }
            else if (StateCooldown >= 5 && StateCooldown < 10)
            {
                State = 1;
                animations.drawanimation(enemyTextureRun, enemyXY, spriteBatch, animations.getanimation(gameTime, 6, 3), enemyTextureRun.Width, enemyTextureRun.Height / 3);//Gegner zeichnen
            }
            else if (StateCooldown > 10 && StateCooldown <= 14)
            {
                State = 2;
                spriteBatch.Draw(enemyTextureIdle, enemyXY, Color.White);

                if (StateCooldown >= 13.9)
                {
                    StateCooldown = 5f;
                }
            }


            spriteBatch.Draw(enemyFrame, new Vector2(enemyXY.X + 36, enemyXY.Y + enemyTextureIdle.Height), Color.White);//Frame Zeichnen
            spriteBatch.Draw(enemyAnzeige, new Vector2(enemyXY.X + 36, enemyXY.Y + enemyTextureIdle.Height), new Rectangle(0, 0, Convert.ToInt32(enemyAnzeige.Width * ((double)enemyHP / (double)enemyMaxHP)), 8), Color.White);//Füllung zeichnen
        }
    }

    class Yeti : Boss
    {
        bool target = false;

        public Yeti(Vector2 position, Texture2D textureIdle, Texture2D textureCharge, Texture2D fill, Texture2D frame, float speed, Vector2 collision, int hp, int radius, float cooldownMax, float shotSpeed, string enemyName, Random random, int dmg) : base(position, textureIdle, textureCharge, textureCharge, fill, frame, speed, collision, hp, radius, cooldownMax, shotSpeed, enemyName, random, dmg)
        {
            StateCooldown = 0f;
        }

        public override void Update(GameTime gameTime, Vector2 playerPosition, Collision collision)
        {
            if (State == 2)
            {
                if (target)
                {
                    playerXY = playerPosition;//Spieler Position(Ziel) Aktualisieren
                    target = false;
                }

                if (playerXY == enemyXY)
                {
                    State = 1;
                }

                if (playerXY.X > enemyXY.X)
                {
                    if (playerXY.Y > enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X < playerXY.X)
                            {
                                enemyXY.X += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y < playerXY.Y)
                            {
                                enemyXY.Y += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (playerXY.Y < enemyXY.Y - 32)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X < playerXY.X)
                            {
                                enemyXY.X += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y > playerXY.Y)
                            {
                                enemyXY.Y -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'r', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X < playerXY.X)
                            {
                                enemyXY.X += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else if (playerXY.X < enemyXY.X)
                {
                    if (playerXY.Y > enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X > playerXY.X)
                            {
                                enemyXY.X -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y < playerXY.Y)
                            {
                                enemyXY.Y += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (playerXY.Y < enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X > playerXY.X)
                            {
                                enemyXY.X -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y > playerXY.Y)
                            {
                                enemyXY.Y -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'l', (int)enemySize.Y, (int)enemySize.X) && enemyXY.X > playerXY.X)
                            {
                                enemyXY.X -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else if (playerXY.X == enemyXY.X)
                {
                    if (playerXY.Y > enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 'b', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y < playerXY.Y)
                            {
                                enemyXY.Y += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (playerXY.Y < enemyXY.Y)
                    {
                        for (int i = 0; i < enemyspeed; i++)
                        {
                            if (collision.CollisionCheck(enemyXY, 't', (int)enemySize.Y, (int)enemySize.X) && enemyXY.Y > playerXY.Y)
                            {
                                enemyXY.Y -= 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            if (StateCooldown < 3)
            {
                State = 0;
                animations.drawanimation(enemyTextureIdle, enemyXY, spriteBatch, animations.getanimation(gameTime, 6, 2), enemyTextureIdle.Width, enemyTextureIdle.Height / 2);//Gegner zeichnen
            }
            else if (StateCooldown >= 3 && StateCooldown < 10)
            {
                State = 1;
                animations.drawanimation(enemyTextureRun, enemyXY, spriteBatch, animations.getanimation(gameTime, 32, 4), enemyTextureRun.Width, enemyTextureRun.Height / 4);//Gegner zeichnen 4/16 = 0.25
            }
            else if (StateCooldown > 10 && StateCooldown <= 12)
            {
                State = 2;
                animations.drawanimation(enemyTextureRun, enemyXY, spriteBatch, animations.getanimation(gameTime, 32, 4), enemyTextureRun.Width, enemyTextureRun.Height / 4);//Gegner zeichnen 4/16 = 0.25

                if (StateCooldown >= 11.9)
                {
                    StateCooldown = 3f;
                }

                if (StateCooldown <= 10.1)
                {
                    target = true;
                }
            }


            spriteBatch.Draw(enemyFrame, new Vector2(enemyXY.X + 38, enemyXY.Y + enemyTextureIdle.Height/2+10), Color.White);//Frame Zeichnen
            spriteBatch.Draw(enemyAnzeige, new Vector2(enemyXY.X + 38, enemyXY.Y + enemyTextureIdle.Height/2+10), new Rectangle(0, 0, Convert.ToInt32(enemyAnzeige.Width * ((double)enemyHP / (double)enemyMaxHP)), 8), Color.White);//Füllung zeichnen
        }
    }

    class Demon : Boss
    {
        float rotation = 0f;
        public Demon(Vector2 position, Texture2D textureIdle, Texture2D textureCharge, Texture2D fill, Texture2D frame, float speed, Vector2 collision, int hp, int radius, float cooldownMax, float shotSpeed, string enemyName, Random random, int dmg) : base(position, textureIdle, textureCharge, textureCharge, fill, frame, speed, collision, hp, radius, cooldownMax, shotSpeed, enemyName, random, dmg)
        {
            StateCooldown = 0f;
            
        }

        public override void Update(GameTime gameTime, Vector2 playerPosition, Collision collision)
        {
            if (State == 0)
            {

            }
            else if (State == 1)
            {
                
            }
            else if (State == 2)
            {
                base.Update(gameTime, playerPosition, collision);
                rotation += 0.2f;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            animations.drawanimation(enemyTextureIdle, enemyXY, spriteBatch, animations.getanimation(gameTime, 6, 9), enemyTextureIdle.Width, enemyTextureIdle.Height / 9);//Gegner zeichnen
            if (StateCooldown < 3)//Spawn Demon 3 sec
            {
                State = 0;
            }
            else if (StateCooldown >= 3 && StateCooldown < 9)//Demon Bullet Hell
            {
                State = 1;
            }
            else if (StateCooldown > 9 && StateCooldown <= 15)//Demon Angriff
            {
                State = 2;
                spriteBatch.Draw(enemyTextureRun, EnemyXY + new Vector2(178/ 2, 178/2), null, Color.White, rotation, new Vector2(enemyTextureRun.Width/2, -10), 1.0f, SpriteEffects.FlipVertically, 1.0f);

                
                if (StateCooldown >= 14.9)
                {
                    StateCooldown = 3f;
                }
            }



            spriteBatch.Draw(enemyFrame, new Vector2(enemyXY.X + 38, enemyXY.Y + enemyTextureIdle.Height / 9+ 10), Color.White);//Frame Zeichnen
            spriteBatch.Draw(enemyAnzeige, new Vector2(enemyXY.X + 38, enemyXY.Y + enemyTextureIdle.Height / 9+ 10), new Rectangle(0, 0, Convert.ToInt32(enemyAnzeige.Width * ((double)enemyHP / (double)enemyMaxHP)), 8), Color.White);//Füllung zeichnen
        }
    }
}
