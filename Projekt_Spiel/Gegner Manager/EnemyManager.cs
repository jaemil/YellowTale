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
    class EnemyManager
    {
        //public List<ShotEngine> lstEnemyShot = new List<ShotEngine>();
        public List<Melee> lstGegnerMelee = new List<Melee>();
        public List<Ranged> lstGegnerRanged = new List<Ranged>();
        public List<Boss> lstBoss = new List<Boss>();

        public List<ShotEngine> lstGegnerShot = new List<ShotEngine>();

        Random random = new Random();
        float speed1;
        Vector2 DirectionXY;

        #region Texture
        //Lebensanzeige
        public Texture2D FrameSmall, FrameMiddle, FrameBig;
        public Texture2D FillSmall, FillMiddle, FillBig;
        public Texture2D Shadow;

        //Wald
        public Texture2D OrkBigIdle;
        public Texture2D OrkBigRun;
        public Texture2D OrkSmallIdle;
        public Texture2D OrkSmallRun;
        public Texture2D ZombieBigIdle;
        public Texture2D OrcMaskedIdle;
        public Texture2D OrcMaskedRun;
        public Texture2D ShamanIdle;


        //Eis
        public Texture2D IceZombie1Idle;
        public Texture2D IceZombie1Run;
        public Texture2D IceZombie2Idle;
        public Texture2D IceZombie2Run;

        //Lava
        public Texture2D DemonBigIdle;
        public Texture2D DemonBigRun;
        public Texture2D WogolIdle;
        public Texture2D WogolRun;
        public Texture2D ImpIdle;
        public Texture2D ImpRun;
        public Texture2D MuddyIdle;
        public Texture2D MuddyRun;
        public Texture2D ChortIdle;

        //Dungeon
        public Texture2D SwampyIdle;
        public Texture2D SwampyRun;
        public Texture2D NecromancerIdle;
        public Texture2D NecromancerRun;
        public Texture2D SkeletonIdle;
        public Texture2D SkeletonRun;
        public Texture2D ZombieSmallIdle;
        public Texture2D ZombieSmallRun;
        public Texture2D ZombieTinyIdle;
        public Texture2D ZombieTinyRun;

        //Others
        public Texture2D GoblinIdle;//Dropt Münzen
        public Texture2D GoblinRun;

        //Bosse
        public Texture2D EggFlap;
        public Texture2D EggCracking;
        public Texture2D EggCrack;

        public Texture2D YetiIdle;
        public Texture2D YetiCharge;

        public Texture2D DemonIdle;
        public Texture2D DemonSword;

        //Projektile
        public Texture2D Bullet;
        public Texture2D Knife;
        public Texture2D Arrow;
        public Texture2D Bow;
        public Texture2D Fireball;
        public Texture2D fireball, fireball2, fireball3, fireball4;
        public Texture2D snowball;
        public Texture2D iceshard;

        public Texture2D demonshot1;
        public Texture2D demonshot2ani;
        public Texture2D demonshot3;

        #endregion

        int r2 = 0;
        int counterEgg = 0;
        bool boolEgg = false;
        int counterDemon = 100;
        bool boolDemon = true;

        #region SpawnMethoden
        //Wald
        public void SpawnOgre(Vector2 position)
        {
            lstGegnerMelee.Add(new Melee(position, OrkBigIdle, OrkBigRun, FillMiddle, FrameMiddle, 2f, new Vector2(64, 64), 15, 300, 0.5f, "Ogre", random, 5));
        }

        public void SpawnOrc(Vector2 position)
        {
            lstGegnerRanged.Add(new Ranged(position, OrkSmallIdle, OrkSmallRun, FillSmall, FrameSmall, 2f, new Vector2(32, 40), 2, 400, 2f, 2f, "Orc", random, 2));
        }

        public void SpawnOrcMasked(Vector2 position)
        {
            lstGegnerRanged.Add(new Ranged(position, OrcMaskedIdle, OrcMaskedRun, FillSmall, FrameSmall, 1f, new Vector2(32, 40), 5, 400, 2f, 2f, "OrcMasked", random, 3));
        }

        public void SpawnShaman(Vector2 position)
        {
            lstGegnerRanged.Add(new Ranged(position, ShamanIdle, ShamanIdle, FillSmall, FrameSmall, 1f, new Vector2(64, 64), 8, 500, 2f, 2f, "Shamen", random, 1));
        }

        public void SpawnEgg(Vector2 position)//Boss
        {
            lstBoss.Add(new Egg(position, EggCrack, EggFlap, EggCracking, FillBig, FrameBig, 2f, new Vector2(176, 176), 100, 2000, 0.2f, 2f, "Egg", random, 3));
        }


        //Eis
        public void SpawnIceZombie1(Vector2 position)
        {
            lstGegnerRanged.Add(new Ranged(position, IceZombie1Idle, IceZombie1Run, FillSmall, FrameSmall, 2f, new Vector2(64, 64), 9, 400, 2f, 2f, "IceZombie1", random, 6));
        }

        public void SpawnIceZombie2(Vector2 position)
        {
            lstGegnerMelee.Add(new Melee(position, IceZombie2Idle, IceZombie2Run, FillSmall, FrameSmall, 3f, new Vector2(64, 64), 12, 500, 0.5f, "IceZombie2", random, 6));
        }

        public void SpawnYeti(Vector2 position)//Boss
        {
            lstBoss.Add(new Yeti(position, YetiIdle, YetiCharge, FillBig, FrameBig, 10f, new Vector2(176, 176), 200, 2000, 0.125f, 2f, "Yeti", random, 6));
        }

        //Lava
        public void SpawnDemonBig(Vector2 position)
        {
            lstGegnerMelee.Add(new Melee(position, DemonBigIdle, DemonBigRun, FillMiddle, FrameMiddle, 2f, new Vector2(64, 64), 25, 400, 0.5f, "DemonBig", random, 10));
        }

        public void SpawnChort(Vector2 position)
        {
            lstGegnerRanged.Add(new Ranged(position, ChortIdle, ChortIdle, FillSmall, FrameSmall, 2f, new Vector2(32, 40), 15, 200, 0.75f, 2f, "Chort", random, 7));
        }

        public void SpawnImp(Vector2 position)
        {
            lstGegnerRanged.Add(new Ranged(position, ImpIdle, ImpRun, FillSmall, FrameSmall, 3f, new Vector2(32, 32), 10, 300, 1.5f, 2f, "Imp", random, 5));
        }

        public void SpawnWogol(Vector2 position)
        {
            lstGegnerRanged.Add(new Ranged(position, WogolIdle, WogolRun, FillSmall, FrameSmall, 1f, new Vector2(32, 40), 15, 400, 1f, 2f, "Wogol", random, 8));
        }

        public void SpawnDemon(Vector2 position)//Boss
        {
            lstBoss.Add(new Demon(position, DemonIdle, DemonSword, FillBig, FrameBig, 3f, new Vector2(176, 176), 400, 2000, 0.358f, 2.0f, "Demon", random, 8));
        }

        //Dungeon
        public void SpawnZombieBig(Vector2 position)
        {
            lstGegnerMelee.Add(new Melee(position, ZombieBigIdle, ZombieBigIdle, FillMiddle, FrameMiddle, 1f, new Vector2(64, 64), 20, 500, 0.4f, "ZombieBig", random, 1));
        }

        public void SpawnSkeleton(Vector2 position)
        {
            lstGegnerRanged.Add(new Ranged(position, SkeletonIdle, SkeletonRun, FillSmall, FrameSmall, 1f, new Vector2(32, 40), 5, 300, 2f, 2f, "Skeleton", random, 2));
        }

        public void SpawnZombie(Vector2 position)
        {
            lstGegnerMelee.Add(new Melee(position, ZombieSmallIdle, ZombieSmallRun, FillSmall, FrameSmall, 2f, new Vector2(32, 40), 5, 500, 0.5f, "Zombie", random, 6));
        }

        public void SpawnZombieTiny(Vector2 position)
        {
            lstGegnerMelee.Add(new Melee(position, ZombieTinyIdle, ZombieTinyRun, FillSmall, FrameSmall, 3f, new Vector2(32, 32), 1, 200, 2f, "ZombieTiny", random, 1));
        }

        public void SpawnMuddy(Vector2 position)
        {
            lstGegnerMelee.Add(new Melee(position, MuddyIdle, MuddyRun, FillSmall, FrameSmall, 1f, new Vector2(32, 40), 20, 300, 0.5f, "Muddy", random, 5));
        }

        public void SpawnSwampy(Vector2 position)
        {
            lstGegnerMelee.Add(new Melee(position, SwampyIdle, SwampyRun, FillSmall, FrameSmall, 1f, new Vector2(32, 40), 10, 300, 0.5f, "Swampy", random, 3));
        }

        public void SpawnNecromancer(Vector2 position)
        {
            lstGegnerRanged.Add(new Ranged(position, NecromancerIdle, NecromancerRun, FillSmall, FrameSmall, 1f, new Vector2(32, 40), 6, 400, 1f, 1.5f, "Necromancer", random, 3));
        }

        public void SpawnGoblin(Vector2 position)
        {
            lstGegnerMelee.Add(new Melee(position, GoblinIdle, GoblinRun, FillSmall, FrameSmall, 4f, new Vector2(32, 32), 3, 800, 0.5f, "Goblin", random, 1));
        }
        #endregion

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < lstGegnerRanged.Count; i++)
            {
                lstGegnerRanged[i].Draw(spriteBatch, gameTime);//Ranged Gegner zeichnen
            }

            for (int i = 0; i < lstGegnerMelee.Count; i++)
            {
                lstGegnerMelee[i].Draw(spriteBatch, gameTime);//Melee Gegner zeichnen
            }

            for (int i = 0; i < lstBoss.Count; i++)
            {
                lstBoss[i].Draw(spriteBatch, gameTime);//Boss Zeichnen
            }

            for (int i = 0; i < lstGegnerShot.Count; i++)
            {
                lstGegnerShot[i].Draw(spriteBatch, gameTime);//Gegner Schüsse zeichnen
            }
        }
        


        public void Update(GameTime gameTime, Vector2 playerPosition, Collision collision, KeyboardState keyState, int speed, ObjectManager objectManager)
        {
            for (int i = 0; i < lstGegnerRanged.Count; i++)//Ranged(Fernkämpfer)
            {
                lstGegnerRanged[i].Update(gameTime, playerPosition, collision);//Gegner Position aktualisieren


                if (lstGegnerRanged[i].EnemyCooldown <= lstGegnerRanged[i].EnemyCooldownMax)
                {
                    lstGegnerRanged[i].EnemyCooldown += (float)gameTime.ElapsedGameTime.TotalSeconds;//Cooldown aktualisieren
                }

                if (lstGegnerRanged[i].EnemyCooldown >= lstGegnerRanged[i].EnemyCooldownMax && lstGegnerRanged[i].EnemyTarget)
                {
                    if (lstGegnerRanged[i].EnemyName == "Orc")
                    {
                        lstGegnerShot.Add(new ShotStandard(playerPosition + new Vector2(16, 24), lstGegnerRanged[i].EnemyXY + lstGegnerRanged[i].EnemySize / 2, 4, Knife, new Vector2(Knife.Width, Knife.Height), lstGegnerRanged[i].EnemyDamage, "Orc"));
                        lstGegnerRanged[i].EnemyCooldown = 0f;
                    }
                    else if (lstGegnerRanged[i].EnemyName == "Skeleton")
                    {
                        lstGegnerShot.Add(new ShotStandard(playerPosition + new Vector2(16, 24), lstGegnerRanged[i].EnemyXY + lstGegnerRanged[i].EnemySize / 2, lstGegnerRanged[i].EnemyShotSpeed, Bow, new Vector2(Bow.Width, Bow.Height), lstGegnerRanged[i].EnemyDamage, "Skeleton"));
                        lstGegnerRanged[i].EnemyCooldown = 0f;
                    }
                    else if (lstGegnerRanged[i].EnemyName == "Necromancer")
                    {
                        lstGegnerShot.Add(new ShotAnimation(playerPosition + new Vector2(16, 24), lstGegnerRanged[i].EnemyXY + lstGegnerRanged[i].EnemySize / 2, lstGegnerRanged[i].EnemyShotSpeed, Fireball, 8, 4, 32, 14, new Vector2(32, 14), lstGegnerRanged[i].EnemyDamage, "Necromancer"));

                        lstGegnerRanged[i].EnemyCooldown = 0f;
                    }
                    else if (lstGegnerRanged[i].EnemyName == "Imp")
                    {
                        lstGegnerShot.Add(new ShotAnimation(playerPosition + new Vector2(16, 24), lstGegnerRanged[i].EnemyXY + lstGegnerRanged[i].EnemySize / 2, lstGegnerRanged[i].EnemyShotSpeed, Fireball, 8, 4, 32, 14, new Vector2(32, 14), lstGegnerRanged[i].EnemyDamage, "Imp"));

                        lstGegnerRanged[i].EnemyCooldown = 0f;
                    }
                    else if (lstGegnerRanged[i].EnemyName == "Chort")
                    {
                        lstGegnerShot.Add(new ShotAnimation(playerPosition + new Vector2(16, 24), lstGegnerRanged[i].EnemyXY + lstGegnerRanged[i].EnemySize / 2, lstGegnerRanged[i].EnemyShotSpeed, Fireball, 8, 4, 32, 14, new Vector2(32, 14), lstGegnerRanged[i].EnemyDamage, "Chort"));

                        lstGegnerRanged[i].EnemyCooldown = 0f;
                    }
                    else if (lstGegnerRanged[i].EnemyName == "Wogol")
                    {
                        lstGegnerShot.Add(new ShotStandard(playerPosition + new Vector2(16, 24), lstGegnerRanged[i].EnemyXY + lstGegnerRanged[i].EnemySize / 2, lstGegnerRanged[i].EnemyShotSpeed, demonshot1, new Vector2(demonshot1.Width, demonshot1.Height), lstGegnerRanged[i].EnemyDamage, "Wogol"));

                        lstGegnerRanged[i].EnemyCooldown = 0f;
                    }
                    else if (lstGegnerRanged[i].EnemyName == "OrcMasked")
                    {
                        lstGegnerShot.Add(new ShotStandard(playerPosition + new Vector2(16, 24), lstGegnerRanged[i].EnemyXY + lstGegnerRanged[i].EnemySize / 2, lstGegnerRanged[i].EnemyShotSpeed, demonshot3, new Vector2(demonshot3.Width, demonshot3.Height), lstGegnerRanged[i].EnemyDamage, "OrcMasked"));

                        lstGegnerRanged[i].EnemyCooldown = 0f;
                    }
                    else if (lstGegnerRanged[i].EnemyName == "IceZombie1")
                    {
                        lstGegnerShot.Add(new ShotStandard(playerPosition + new Vector2(16, 24), lstGegnerRanged[i].EnemyXY + lstGegnerRanged[i].EnemySize / 2, lstGegnerRanged[i].EnemyShotSpeed, iceshard, new Vector2(iceshard.Width, iceshard.Height), lstGegnerRanged[i].EnemyDamage, "OrcMasked"));

                        lstGegnerRanged[i].EnemyCooldown = 0f;
                    }
                    else if (lstGegnerRanged[i].EnemyName == "Shamen")
                    {
                        lstGegnerShot.Add(new ShotAnimation(playerPosition + new Vector2(16, 24), lstGegnerRanged[i].EnemyXY + lstGegnerRanged[i].EnemySize / 2, lstGegnerRanged[i].EnemyShotSpeed, Fireball, 8, 4, 32, 14, new Vector2(32, 14), lstGegnerRanged[i].EnemyDamage, "Shamen"));

                        lstGegnerRanged[i].EnemyCooldown = 0f;
                    }
                }

            }

            for (int i = 0; i < lstGegnerMelee.Count; i++)//Melee(Nahkämpfer)
            {
                lstGegnerMelee[i].Update(gameTime, playerPosition, collision);//Gegner Position aktualisieren
                lstGegnerMelee[i].EnemyCooldown += (float)gameTime.ElapsedGameTime.TotalSeconds;//Cooldown aktualisieren

                if (lstGegnerMelee[i].EnemyCooldown >= lstGegnerMelee[i].EnemyCooldownMax && lstGegnerMelee[i].EnemyTarget)
                {
                    if (lstGegnerMelee[i].EnemyName == "ZombieBig")
                    {
                        SpawnZombieTiny(new Vector2((int)(lstGegnerMelee[i].EnemyXY.X + 16), (int)(lstGegnerMelee[i].EnemyXY.Y + 16)));
                        lstGegnerMelee[lstGegnerMelee.Count - 1].EnemyTarget = true;
                        lstGegnerMelee[i].EnemyCooldown = 0f;
                    }

                    if (lstGegnerMelee[i].EnemyName == "Goblin")
                    {
                        for (float j = 0f; j < 5; j += 0.50f)
                        {
                            if (lstGegnerMelee[i].EnemyCooldown >= j && lstGegnerMelee[i].EnemyCooldown <= j + 0.02)
                            {
                                objectManager.SpawnCoin(lstGegnerMelee[i].EnemyXY);
                            }
                        }

                        if (lstGegnerMelee[i].EnemyCooldown >= 5)
                        {
                            lstGegnerMelee.RemoveAt(i);
                        }
                    }
                }
            }

            for (int i = 0; i < lstBoss.Count; i++)
            {
                lstBoss[i].Update(gameTime, playerPosition, collision);//Gegner Position aktualisieren
                lstBoss[i].EnemyCooldown += (float)gameTime.ElapsedGameTime.TotalSeconds;//Cooldown aktualisieren
                lstBoss[i].StateCooldown += (float)gameTime.ElapsedGameTime.TotalSeconds;//Cooldown aktualisieren


                if (lstBoss[i].EnemyName == "Egg" && lstBoss[i].State == 1 && lstBoss[i].EnemyCooldown >= lstBoss[i].EnemyCooldownMax)
                {
                    int x = 0, y = 0, r = 500;
                    for (int w = 0; w < 360; w += 20)
                    {
                        x = Convert.ToInt32(88 + lstBoss[i].EnemyXY.X + r * Math.Sin(r2 + w * (Math.PI / 180)));
                        y = Convert.ToInt32(88 + lstBoss[i].EnemyXY.Y + r * Math.Cos(r2 + w * (Math.PI / 180)));
                        if (counterEgg == 0)
                        {
                            lstGegnerShot.Add(new ShotAnimation(new Vector2(x, y), lstBoss[i].EnemyXY + new Vector2(88, 88), 2f, fireball, 8, 4, 32, 14, new Vector2(32, 14), lstBoss[i].EnemyDamage, ""));
                            counterEgg = 1;
                        }
                        else if (counterEgg == 1)
                        {
                            lstGegnerShot.Add(new ShotAnimation(new Vector2(x, y), lstBoss[i].EnemyXY + new Vector2(88, 88), 2f, fireball2, 8, 4, 32, 14, new Vector2(32, 14), lstBoss[i].EnemyDamage, ""));
                            counterEgg = 2;
                        }
                        else if (counterEgg == 2)
                        {
                            lstGegnerShot.Add(new ShotAnimation(new Vector2(x, y), lstBoss[i].EnemyXY + new Vector2(88, 88), 2f, fireball3, 8, 4, 32, 14, new Vector2(32, 14), lstBoss[i].EnemyDamage, ""));
                            counterEgg = 3;
                        }
                        else
                        {
                            lstGegnerShot.Add(new ShotAnimation(new Vector2(x, y), lstBoss[i].EnemyXY + new Vector2(88, 88), 2f, fireball4, 8, 4, 32, 14, new Vector2(32, 14), lstBoss[i].EnemyDamage, ""));
                            counterEgg = 0;
                        }
                    }

                    if (r2 == 200)
                    {
                        boolEgg = true;
                    }
                    else if (r2 == 0)
                    {
                        boolEgg = false;
                    }

                    if (boolEgg)
                    {
                        r2 -= 50;
                    }
                    else
                    {
                        r2 += 50;
                    }


                    lstBoss[i].EnemyCooldown = 0f;
                }
                else if (lstBoss[i].EnemyName == "Yeti" && lstBoss[i].State == 1 && lstBoss[i].EnemyCooldown >= lstBoss[i].EnemyCooldownMax)
                {
                    lstGegnerShot.Add(new ShotStandard(playerPosition + new Vector2(16, 24), lstBoss[i].EnemyXY + lstBoss[i].EnemySize / 2 + new Vector2(0, 25), 4, snowball, new Vector2(snowball.Width, snowball.Height), lstBoss[i].EnemyDamage, "Yeti"));

                    lstBoss[i].EnemyCooldown = 0f;
                }
                else if (lstBoss[i].EnemyName == "Demon")
                {
                    if (lstBoss[i].State == 1 && lstBoss[i].EnemyCooldown >= lstBoss[i].EnemyCooldownMax)
                    {
                        for (int j = 100; j < 1920; j += 131)
                        {

                            int x = 0, y = 0, r = 50;
                            int x1 = 0, y1 = 0;

                            for (int w = 0; w < 360; w += 40)
                            {
                                x = Convert.ToInt32(j + r * Math.Sin(w * (Math.PI / 180)));
                                y = Convert.ToInt32(80 + r * Math.Cos(w * (Math.PI / 180)));

                                x1 = Convert.ToInt32(j + r * Math.Sin(w * (Math.PI / 180)));
                                y1 = Convert.ToInt32(1000 + r * Math.Cos(w * (Math.PI / 180)));

                                lstGegnerShot.Add(new ShotAnimation(new Vector2(x1, y1), new Vector2(x, y), lstBoss[i].EnemyShotSpeed, demonshot2ani, 16, 6, 32, 32, new Vector2(32, 32), lstBoss[i].EnemyDamage, "Demon"));
                                lstGegnerShot[lstGegnerShot.Count - 1].Rotation = 0;
                            }


                            if (j == counterDemon)
                            {
                                j += 2 * 131;

                                if (counterDemon >= 1400)
                                {
                                    boolDemon = false;
                                }
                                else if (counterDemon <= 100)
                                {
                                    boolDemon = true;
                                }

                                if (boolDemon)
                                {
                                    counterDemon += 131;
                                }
                                else
                                {
                                    counterDemon -= 131;
                                }


                            }

                            lstBoss[i].EnemyCooldown = 0f;
                        }
                    }
                    else if (lstBoss[i].State == 2)
                    {
                        for (int j = 0; j < lstGegnerShot.Count; j++)
                        {
                            if (lstGegnerShot[j].ShotName == "Demon")
                            {
                                lstGegnerShot[j].CurrentTime = 10;//Auf 10 setzen damit der SChuss entfernt wird
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < lstGegnerShot.Count; i++)
            {
                lstGegnerShot[i].Update(gameTime);//Gegner Schüsse aktualisieren

                if (lstGegnerShot[i].ShotName == "Orc")
                {
                    lstGegnerShot[i].Rotation += 0.25f;
                }
                else if (lstGegnerShot[i].ShotName == "Skeleton")
                {
                    lstGegnerShot[i].Rotation = (float)Math.Atan2((double)playerPosition.Y - lstGegnerShot[i].ShotXY.Y, (double)playerPosition.X - lstGegnerShot[i].ShotXY.X);
                    if (lstGegnerShot[i].CurrentTime >= 1)
                    {
                        lstGegnerShot.Add(new ShotStandard(playerPosition + new Vector2(16, 24), lstGegnerShot[i].ShotXY, 8, Arrow, new Vector2(Arrow.Width, Arrow.Height), 1, "Skeleton2"));

                        lstGegnerShot[i].CurrentTime = 0;
                    }
                }
                else if (lstGegnerShot[i].ShotName == "Necromancer")
                {
                    DirectionXY = playerPosition + new Vector2(16, 24) - lstGegnerShot[i].ShotXY;
                    lstGegnerShot[i].Rotation = (float)Math.Atan2((double)playerPosition.Y - lstGegnerShot[i].ShotXY.Y + 24, (double)playerPosition.X - lstGegnerShot[i].ShotXY.X + 16);

                    speed1 = DirectionXY.Length();
                    speed1 += speed1 / 100;

                    DirectionXY = DirectionXY * (100 / speed1);

                    lstGegnerShot[i].DirectionXY = DirectionXY;
                }
                else if (lstGegnerShot[i].ShotName == "Imp")
                {
                    if (lstGegnerShot[i].CurrentTime >= 1.0 && lstGegnerShot[i].CurrentTime <= 1.8)
                    {
                        lstGegnerShot[i].ShotSpeed = 0f;
                        lstGegnerShot[i].DirectionXY = Vector2.Zero;
                        lstGegnerShot[i].Rotation = (float)Math.Atan2((double)playerPosition.Y - lstGegnerShot[i].ShotXY.Y + 24, (double)playerPosition.X - lstGegnerShot[i].ShotXY.X + 16);
                    }
                    else if (lstGegnerShot[i].CurrentTime >= 1.8 && lstGegnerShot[i].CurrentTime <= 1.9)
                    {
                        DirectionXY = playerPosition + new Vector2(16, 24) - lstGegnerShot[i].ShotXY;
                        speed1 = DirectionXY.Length();
                        speed1 += speed1 / 350;

                        DirectionXY = DirectionXY * (350 / speed1);

                        lstGegnerShot[i].DirectionXY = DirectionXY;
                    }
                }
                else if (lstGegnerShot[i].ShotName == "Chort")
                {
                    if (lstGegnerShot[i].CurrentTime <= 0.02f)
                    {
                        if (playerPosition.X - lstGegnerShot[i].ShotXY.X > 200 || playerPosition.Y - lstGegnerShot[i].ShotXY.Y > 200 || playerPosition.X - lstGegnerShot[i].ShotXY.X < -200 || playerPosition.Y - lstGegnerShot[i].ShotXY.Y < -200)
                        {
                            ShotPrediction(keyState, playerPosition, i, speed, 75);

                            speed1 = DirectionXY.Length();
                            speed1 += speed1 / 200;

                            DirectionXY = DirectionXY * (200 / speed1);

                            lstGegnerShot[i].DirectionXY = DirectionXY;
                            lstGegnerShot[i].Rotation = (float)Math.Atan2((double)DirectionXY.Y, (double)DirectionXY.X);
                        }
                    }
                }
                else if (lstGegnerShot[i].ShotName == "Yeti")
                {
                    if (lstGegnerShot[i].CurrentTime <= 0.02f)
                    {
                        if (playerPosition.X - lstGegnerShot[i].ShotXY.X > 300 || playerPosition.Y - lstGegnerShot[i].ShotXY.Y > 300 || playerPosition.X - lstGegnerShot[i].ShotXY.X < -300 || playerPosition.Y - lstGegnerShot[i].ShotXY.Y < -300)
                        {
                            ShotPrediction(keyState, playerPosition, i, speed, random.Next(30, 60));
                        }
                        else
                        {
                            ShotPrediction(keyState, playerPosition, i, speed, random.Next(10, 20));
                        }
                            speed1 = DirectionXY.Length();
                            speed1 += speed1 / 400;

                            DirectionXY = DirectionXY * (400 / speed1);

                            lstGegnerShot[i].DirectionXY = DirectionXY;
                    }

                    lstGegnerShot[i].Rotation += 0.05f;
                }
                else if (lstGegnerShot[i].ShotName == "Wogol")
                {
                    lstGegnerShot[i].Rotation += 0.1f;

                    if (lstGegnerShot[i].CurrentTime >= 1f && lstGegnerShot[i].CurrentTime <= 1.1f)
                    {
                        if (playerPosition.X - lstGegnerShot[i].ShotXY.X > 100 || playerPosition.Y - lstGegnerShot[i].ShotXY.Y > 100 || playerPosition.X - lstGegnerShot[i].ShotXY.X < -100 || playerPosition.Y - lstGegnerShot[i].ShotXY.Y < -100)
                        {
                            ShotPrediction(keyState, playerPosition, i, speed, random.Next(30, 40));
                        }
                        else
                        {
                            DirectionXY = playerPosition + new Vector2(16, 24) - lstGegnerShot[i].ShotXY;
                        }

                        speed1 = DirectionXY.Length();
                        speed1 += speed1 / 350;

                        DirectionXY = DirectionXY * (350 / speed1);

                        lstGegnerShot[i].DirectionXY = DirectionXY;
                    }
                }
            }
        }

        public void ShotPrediction(KeyboardState keyState, Vector2 playerPosition, int i, int speed, int weite)//Schuss Richtung wo der Spieler hinlaufen könnte
        {
            if ((keyState.IsKeyDown(Keys.W) && keyState.IsKeyDown(Keys.A) && keyState.IsKeyDown(Keys.S) && keyState.IsKeyDown(Keys.D)))//Alle Tasten gedrückt
            {
                DirectionXY = lstGegnerShot[i].DirectionXY;
            }
            else if(keyState.IsKeyDown(Keys.A) && keyState.IsKeyDown(Keys.S) && keyState.IsKeyDown(Keys.D))//Unten
            {
                DirectionXY = playerPosition + new Vector2(16, 24) + new Vector2(0, weite * speed) - lstGegnerShot[i].ShotXY;
            }
            else if ((keyState.IsKeyDown(Keys.W) && keyState.IsKeyDown(Keys.A) && keyState.IsKeyDown(Keys.D)))//Oben
            {
                DirectionXY = playerPosition + new Vector2(16, 24) + new Vector2(0, -weite * speed) - lstGegnerShot[i].ShotXY;
            }
            else if (keyState.IsKeyDown(Keys.W) && keyState.IsKeyDown(Keys.D))//Oben Rechts
            {
                DirectionXY = playerPosition + new Vector2(16, 24) + new Vector2(weite * speed, -weite * speed) - lstGegnerShot[i].ShotXY;
            }
            else if (keyState.IsKeyDown(Keys.D) && keyState.IsKeyDown(Keys.S))//Unten Rechts
            {
                DirectionXY = playerPosition + new Vector2(16, 24) + new Vector2(weite * speed, weite * speed) - lstGegnerShot[i].ShotXY;
            }
            else if (keyState.IsKeyDown(Keys.S) && keyState.IsKeyDown(Keys.A))//Unten Links
            {
                DirectionXY = playerPosition + new Vector2(16, 24) + new Vector2(-weite * speed, weite * speed) - lstGegnerShot[i].ShotXY;
            }
            else if (keyState.IsKeyDown(Keys.A) && keyState.IsKeyDown(Keys.W))//Oben Links
            {
                DirectionXY = playerPosition + new Vector2(16, 24) + new Vector2(-weite * speed, -weite * speed) - lstGegnerShot[i].ShotXY;
            }
            else if (keyState.IsKeyDown(Keys.W) && !keyState.IsKeyDown(Keys.S))//Oben
            {
                DirectionXY = playerPosition + new Vector2(16, 24) + new Vector2(0, -weite * speed) - lstGegnerShot[i].ShotXY;
            }
            else if (keyState.IsKeyDown(Keys.D) && !keyState.IsKeyDown(Keys.A))//Rechts
            {
                DirectionXY = playerPosition + new Vector2(16, 24) + new Vector2(weite * speed, 0) - lstGegnerShot[i].ShotXY;
            }
            else if (keyState.IsKeyDown(Keys.S) && !keyState.IsKeyDown(Keys.W))//Unten
            {
                DirectionXY = playerPosition + new Vector2(16, 24) + new Vector2(0, weite * speed) - lstGegnerShot[i].ShotXY;
            }
            else if (keyState.IsKeyDown(Keys.A) && !keyState.IsKeyDown(Keys.D))//Links
            {
                DirectionXY = playerPosition + new Vector2(16, 24) + new Vector2(-weite * speed, 0) - lstGegnerShot[i].ShotXY;
            }
            else//Keine Taste gedrückt
            {
                DirectionXY = lstGegnerShot[i].DirectionXY;
            }
        }

        public void EnemyDelete()
        {
            lstGegnerMelee.RemoveRange(0, lstGegnerMelee.Count);
            lstGegnerRanged.RemoveRange(0, lstGegnerRanged.Count);
            lstBoss.RemoveRange(0, lstBoss.Count);
        }
    }
}
