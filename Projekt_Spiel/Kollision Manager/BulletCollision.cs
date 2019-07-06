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
    class BulletCollision
    {
        public void UpdateBulletCollision(GameTime gameTime, AbilityManager abilityManager, ObjectManager objectManager, Collision collision, ParticleManager particleManager, EnemyManager enemyManager, Movement movement, int currentSpieler, Player _player, Game1 game)
        {
            for (int i = 0; i < abilityManager.lstAbility.Count || i < enemyManager.lstGegnerShot.Count || i < objectManager.lstDynamitArrowTrapBullets.Count; i++)//Wenn sich ein Objekt in einer der Listen befindet
            {
                if (i < abilityManager.lstAbility.Count)//Spieler Schüsse
                {
                    abilityManager.lstAbility[i].Update(gameTime);

                    if (abilityManager.lstAbility[i].ShotXY.X > 1920 || abilityManager.lstAbility[i].ShotXY.Y > 1080 ||
                     abilityManager.lstAbility[i].ShotXY.X < 0 || abilityManager.lstAbility[i].ShotXY.Y < 0 || abilityManager.lstAbility[i].CurrentTime > 10f
                     || collision.BulletCollision(new Vector2(Convert.ToInt32(abilityManager.lstAbility[i].ShotXY.X), Convert.ToInt32(abilityManager.lstAbility[i].ShotXY.Y)), (int)abilityManager.lstAbility[i].ShotSize.Y, (int)abilityManager.lstAbility[i].ShotSize.X, abilityManager.lstAbility[i].Rotation))
                    {
                        particleManager.SpawnStandardParticle(abilityManager.lstAbility[i].ShotXY - abilityManager.lstAbility[i].ShotSize / 2);
                        abilityManager.lstAbility.Remove(abilityManager.lstAbility[i]);//lstAbility entfernen
                        continue;
                    }

                    for (int j = 0; j < objectManager.lstDynamit.Count; j++)
                    {
                        if (new Rectangle((int)abilityManager.lstAbility[i].ShotXY.X - (int)abilityManager.lstAbility[i].ShotSize.X / 2, (int)abilityManager.lstAbility[i].ShotXY.Y - (int)abilityManager.lstAbility[i].ShotSize.Y / 2, (int)abilityManager.lstAbility[i].ShotSize.X / 2, (int)abilityManager.lstAbility[i].ShotSize.Y / 2).Intersects
                            (new Rectangle((int)objectManager.lstDynamit[j].Position.X, (int)objectManager.lstDynamit[j].Position.Y, 64, 64)) && !objectManager.lstDynamit[j].Exploded)
                        {
                            objectManager.lstDynamit[j].Explosion = true;
                            abilityManager.lstAbility.Remove(abilityManager.lstAbility[i]);//lstAbility entfernen
                            break;
                        }
                    }
                }

                if (i < enemyManager.lstGegnerShot.Count)//Gegner Schüsse
                {
                    enemyManager.lstGegnerShot[i].Update(gameTime);

                    if (enemyManager.lstGegnerShot[i].ShotXY.X > 1920 || enemyManager.lstGegnerShot[i].ShotXY.Y > 1080
                    || enemyManager.lstGegnerShot[i].ShotXY.X < 0 || enemyManager.lstGegnerShot[i].ShotXY.Y < 0 || enemyManager.lstGegnerShot[i].CurrentTime > 10f
                    || collision.BulletCollision(new Vector2(Convert.ToInt32(enemyManager.lstGegnerShot[i].ShotXY.X), Convert.ToInt32(enemyManager.lstGegnerShot[i].ShotXY.Y)), (int)enemyManager.lstGegnerShot[i].ShotSize.Y, (int)enemyManager.lstGegnerShot[i].ShotSize.X, enemyManager.lstGegnerShot[i].Rotation))
                    {
                        particleManager.SpawnStandardParticle(enemyManager.lstGegnerShot[i].ShotXY - enemyManager.lstGegnerShot[i].ShotSize / 2);
                        enemyManager.lstGegnerShot.Remove(enemyManager.lstGegnerShot[i]);//EnemyShot entfernen
                        continue;
                    }

                    if (new Rectangle((int)(enemyManager.lstGegnerShot[i].ShotXY.X), (int)(enemyManager.lstGegnerShot[i].ShotXY.Y), (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y).Intersects
                        (new Rectangle((int)movement.position.X, (int)movement.position.Y, 32, 48)))
                    {
                        _player.LebenAbziehen(enemyManager.lstGegnerShot[i].ShotDamage, (int)currentSpieler, particleManager, enemyManager.lstGegnerShot[i].ShotXY, game);
                        enemyManager.lstGegnerShot.Remove(enemyManager.lstGegnerShot[i]);//EnemyShot entfernen
                    }
                }

                if (i < objectManager.lstDynamitArrowTrapBullets.Count)//Dynamit
                {
                    objectManager.lstDynamitArrowTrapBullets[i].Update(gameTime);

                    if (objectManager.lstDynamitArrowTrapBullets[i].ShotXY.X > 1920 || objectManager.lstDynamitArrowTrapBullets[i].ShotXY.Y > 1080
                    || objectManager.lstDynamitArrowTrapBullets[i].ShotXY.X < 0 || objectManager.lstDynamitArrowTrapBullets[i].ShotXY.Y < 0 || objectManager.lstDynamitArrowTrapBullets[i].CurrentTime > 10f
                    || collision.BulletCollision(new Vector2(Convert.ToInt32(objectManager.lstDynamitArrowTrapBullets[i].ShotXY.X), Convert.ToInt32(objectManager.lstDynamitArrowTrapBullets[i].ShotXY.Y)), (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.Y, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.X, objectManager.lstDynamitArrowTrapBullets[i].Rotation))
                    {
                        particleManager.SpawnStandardParticle(objectManager.lstDynamitArrowTrapBullets[i].ShotXY - objectManager.lstDynamitArrowTrapBullets[i].ShotSize / 2);
                        objectManager.lstDynamitArrowTrapBullets.Remove(objectManager.lstDynamitArrowTrapBullets[i]);//EnemyShot entfernen

                        continue;
                    }

                    if (new Rectangle(Convert.ToInt32(objectManager.lstDynamitArrowTrapBullets[i].ShotXY.X - (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.X / 2), Convert.ToInt32(objectManager.lstDynamitArrowTrapBullets[i].ShotXY.Y - (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.Y / 2), (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.X / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.Y / 2).Intersects
                        (new Rectangle((int)movement.position.X, (int)movement.position.Y, 32, 48)))
                    {
                        _player.LebenAbziehen(objectManager.lstDynamitArrowTrapBullets[i].ShotDamage, (int)currentSpieler, particleManager, objectManager.lstDynamitArrowTrapBullets[i].ShotXY, game);

                        objectManager.lstDynamitArrowTrapBullets.Remove(objectManager.lstDynamitArrowTrapBullets[i]);//EnemyShot entfernen

                        continue;
                    }

                    for (int j = 0; j < objectManager.lstDynamit.Count; j++)
                    {
                        if (new Rectangle((int)objectManager.lstDynamitArrowTrapBullets[i].ShotXY.X - (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.X / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotXY.Y - (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.Y / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.X / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.Y / 2).Intersects
                            (new Rectangle((int)objectManager.lstDynamit[j].Position.X, (int)objectManager.lstDynamit[j].Position.Y, 64, 64)) && !objectManager.lstDynamit[j].Exploded)
                        {
                            objectManager.lstDynamit[j].Explosion = true;
                            objectManager.lstDynamitArrowTrapBullets.Remove(objectManager.lstDynamitArrowTrapBullets[i]);//AutoAttack entfernen
                            break;
                        }
                    }
                }
            }

            for (int j = 0; j < enemyManager.lstGegnerRanged.Count; j++)//Bullet Collision
            {
                for (int i = 0; i < abilityManager.lstAbility.Count || i < objectManager.lstDynamitArrowTrapBullets.Count; i++)
                {
                    if (i < abilityManager.lstAbility.Count)
                    {
                        if (new Rectangle((int)abilityManager.lstAbility[i].ShotXY.X - (int)abilityManager.lstAbility[i].ShotSize.X / 2, (int)abilityManager.lstAbility[i].ShotXY.Y - (int)abilityManager.lstAbility[i].ShotSize.Y / 2, (int)abilityManager.lstAbility[i].ShotSize.X / 2, (int)abilityManager.lstAbility[i].ShotSize.Y / 2).Intersects
                            (new Rectangle((int)enemyManager.lstGegnerRanged[j].EnemyXY.X, (int)enemyManager.lstGegnerRanged[j].EnemyXY.Y, (int)enemyManager.lstGegnerRanged[j].EnemySize.X, (int)enemyManager.lstGegnerRanged[j].EnemySize.Y)))
                        {
                            particleManager.SpawnHitParticle(abilityManager.lstAbility[i].ShotXY, -abilityManager.lstAbility[i].ShotDamage, Color.LightBlue);
                            particleManager.SpawnStandardParticle(abilityManager.lstAbility[i].ShotXY - abilityManager.lstAbility[i].ShotSize / 2);

                            if (enemyManager.lstGegnerRanged[j].EnemyXY.X + abilityManager.lstAbility[i].DirectionXY.X / 64 < 1920 - 64 && enemyManager.lstGegnerRanged[j].EnemyXY.Y + abilityManager.lstAbility[i].DirectionXY.Y / 64 < 1080 - 64
                            && enemyManager.lstGegnerRanged[j].EnemyXY.X + abilityManager.lstAbility[i].DirectionXY.X / 64 > 0 + 64 && enemyManager.lstGegnerRanged[j].EnemyXY.Y + abilityManager.lstAbility[i].DirectionXY.Y / 64 > 0 + 64)//+-64 = 2*RandCollision
                            {
                                if (abilityManager.lstAbility[i].DirectionXY.X < 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstGegnerRanged[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstGegnerRanged[j].EnemyXY.Y), (int)enemyManager.lstGegnerRanged[j].EnemySize.Y, (int)enemyManager.lstGegnerRanged[j].EnemySize.X))
                                {
                                    enemyManager.lstGegnerRanged[j].EnemyXY = new Vector2(enemyManager.lstGegnerRanged[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstGegnerRanged[j].EnemyXY.Y);
                                }

                                if (abilityManager.lstAbility[i].DirectionXY.X >= 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstGegnerRanged[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstGegnerRanged[j].EnemyXY.Y), (int)enemyManager.lstGegnerRanged[j].EnemySize.Y, (int)enemyManager.lstGegnerRanged[j].EnemySize.X))
                                {
                                    enemyManager.lstGegnerRanged[j].EnemyXY = new Vector2(enemyManager.lstGegnerRanged[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstGegnerRanged[j].EnemyXY.Y);
                                }

                                if (abilityManager.lstAbility[i].DirectionXY.Y < 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstGegnerRanged[j].EnemyXY.X, enemyManager.lstGegnerRanged[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64), (int)enemyManager.lstGegnerRanged[j].EnemySize.Y, (int)enemyManager.lstGegnerRanged[j].EnemySize.X))
                                {
                                    enemyManager.lstGegnerRanged[j].EnemyXY = new Vector2(enemyManager.lstGegnerRanged[j].EnemyXY.X, enemyManager.lstGegnerRanged[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64);
                                }

                                if (abilityManager.lstAbility[i].DirectionXY.Y >= 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstGegnerRanged[j].EnemyXY.X, enemyManager.lstGegnerRanged[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64), (int)enemyManager.lstGegnerRanged[j].EnemySize.Y, (int)enemyManager.lstGegnerRanged[j].EnemySize.X))
                                {
                                    enemyManager.lstGegnerRanged[j].EnemyXY = new Vector2(enemyManager.lstGegnerRanged[j].EnemyXY.X, enemyManager.lstGegnerRanged[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64);
                                }
                            }

                            enemyManager.lstGegnerRanged[j].EnemyHP -= abilityManager.lstAbility[i].ShotDamage;//Leben abziehen
                            enemyManager.lstGegnerRanged[j].EnemyTarget = true;//Damit Spieler im visier ist auch wenn der Spieler nicht in range ist


                            if (enemyManager.lstGegnerRanged[j].EnemyHP <= 0)
                            {
                                objectManager.SpawnCoinXP(enemyManager.lstGegnerRanged[j].EnemyXY);
                                enemyManager.lstGegnerRanged.RemoveAt(j);
                                abilityManager.lstAbility.Remove(abilityManager.lstAbility[i]);
                                break;
                            }
                            abilityManager.lstAbility.Remove(abilityManager.lstAbility[i]);

                            continue;
                        }

                    }

                    if (i < objectManager.lstDynamitArrowTrapBullets.Count)
                    {
                        if (new Rectangle((int)objectManager.lstDynamitArrowTrapBullets[i].ShotXY.X - (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.X / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotXY.Y - (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.Y / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.X / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.Y / 2).Intersects
                            (new Rectangle((int)enemyManager.lstGegnerRanged[j].EnemyXY.X, (int)enemyManager.lstGegnerRanged[j].EnemyXY.Y, (int)enemyManager.lstGegnerRanged[j].EnemySize.X, (int)enemyManager.lstGegnerRanged[j].EnemySize.Y)))
                        {
                            particleManager.SpawnStandardParticle(objectManager.lstDynamitArrowTrapBullets[i].ShotXY - objectManager.lstDynamitArrowTrapBullets[i].ShotSize / 2);
                            particleManager.SpawnHitParticle(objectManager.lstDynamitArrowTrapBullets[i].ShotXY, -objectManager.lstDynamitArrowTrapBullets[i].ShotDamage, Color.LightBlue);

                            enemyManager.lstGegnerRanged[j].EnemyHP -= objectManager.lstDynamitArrowTrapBullets[i].ShotDamage;
                            enemyManager.lstGegnerRanged[j].EnemyTarget = true;

                            if (enemyManager.lstGegnerRanged[j].EnemyHP <= 0)
                            {
                                objectManager.SpawnCoinXP(enemyManager.lstGegnerRanged[j].EnemyXY);
                                enemyManager.lstGegnerRanged.RemoveAt(j);
                                objectManager.lstDynamitArrowTrapBullets.Remove(objectManager.lstDynamitArrowTrapBullets[i]);
                                break;
                            }

                            objectManager.lstDynamitArrowTrapBullets.Remove(objectManager.lstDynamitArrowTrapBullets[i]);

                            continue;
                        }

                    }
                }
            }

            for (int j = 0; j < enemyManager.lstGegnerMelee.Count; j++)//Bullet Collision
            {
                if (new Rectangle((int)enemyManager.lstGegnerMelee[j].EnemyXY.X, (int)enemyManager.lstGegnerMelee[j].EnemyXY.Y, (int)enemyManager.lstGegnerMelee[j].EnemySize.X, (int)enemyManager.lstGegnerMelee[j].EnemySize.Y).Intersects(new Rectangle((int)movement.position.X, (int)movement.position.Y, 32, 48)) && enemyManager.lstGegnerMelee[j].EnemyCooldown >= enemyManager.lstGegnerMelee[j].EnemyCooldownMax)
                {
                    _player.LebenAbziehen(enemyManager.lstGegnerMelee[j].EnemyDamage, currentSpieler, particleManager, movement.position, game);
                    enemyManager.lstGegnerMelee[j].EnemyCooldown = 0f;
                }

                for (int i = 0; i < abilityManager.lstAbility.Count || i < objectManager.lstDynamitArrowTrapBullets.Count; i++)
                {
                    if (i < abilityManager.lstAbility.Count)
                    {
                        if (new Rectangle((int)abilityManager.lstAbility[i].ShotXY.X - (int)abilityManager.lstAbility[i].ShotSize.X / 2, (int)abilityManager.lstAbility[i].ShotXY.Y - (int)abilityManager.lstAbility[i].ShotSize.Y / 2, (int)abilityManager.lstAbility[i].ShotSize.X / 2, (int)abilityManager.lstAbility[i].ShotSize.Y / 2).Intersects
                            (new Rectangle((int)enemyManager.lstGegnerMelee[j].EnemyXY.X, (int)enemyManager.lstGegnerMelee[j].EnemyXY.Y, (int)enemyManager.lstGegnerMelee[j].EnemySize.X, (int)enemyManager.lstGegnerMelee[j].EnemySize.Y)))
                        {
                            particleManager.SpawnHitParticle(abilityManager.lstAbility[i].ShotXY, -abilityManager.lstAbility[i].ShotDamage, Color.LightBlue);
                            particleManager.SpawnStandardParticle(abilityManager.lstAbility[i].ShotXY);

                            if (enemyManager.lstGegnerMelee[j].EnemyXY.X + abilityManager.lstAbility[i].DirectionXY.X / 64 < 1920 - 64 && enemyManager.lstGegnerMelee[j].EnemyXY.Y + abilityManager.lstAbility[i].DirectionXY.Y / 64 < 1080 - 64
                            && enemyManager.lstGegnerMelee[j].EnemyXY.X + abilityManager.lstAbility[i].DirectionXY.X / 64 > 0 + 64 && enemyManager.lstGegnerMelee[j].EnemyXY.Y + abilityManager.lstAbility[i].DirectionXY.Y / 64 > 0 + 64)//+-64 = 2*RandCollision
                            {
                                if (abilityManager.lstAbility[i].DirectionXY.X < 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstGegnerMelee[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstGegnerMelee[j].EnemyXY.Y), (int)enemyManager.lstGegnerMelee[j].EnemySize.Y, (int)enemyManager.lstGegnerMelee[j].EnemySize.X))
                                {
                                    enemyManager.lstGegnerMelee[j].EnemyXY = new Vector2(enemyManager.lstGegnerMelee[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstGegnerMelee[j].EnemyXY.Y);
                                }

                                if (abilityManager.lstAbility[i].DirectionXY.X >= 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstGegnerMelee[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstGegnerMelee[j].EnemyXY.Y), (int)enemyManager.lstGegnerMelee[j].EnemySize.Y, (int)enemyManager.lstGegnerMelee[j].EnemySize.X))
                                {
                                    enemyManager.lstGegnerMelee[j].EnemyXY = new Vector2(enemyManager.lstGegnerMelee[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstGegnerMelee[j].EnemyXY.Y);
                                }

                                if (abilityManager.lstAbility[i].DirectionXY.Y < 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstGegnerMelee[j].EnemyXY.X, enemyManager.lstGegnerMelee[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64), (int)enemyManager.lstGegnerMelee[j].EnemySize.Y, (int)enemyManager.lstGegnerMelee[j].EnemySize.X))
                                {
                                    enemyManager.lstGegnerMelee[j].EnemyXY = new Vector2(enemyManager.lstGegnerMelee[j].EnemyXY.X, enemyManager.lstGegnerMelee[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64);
                                }

                                if (abilityManager.lstAbility[i].DirectionXY.Y >= 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstGegnerMelee[j].EnemyXY.X, enemyManager.lstGegnerMelee[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64), (int)enemyManager.lstGegnerMelee[j].EnemySize.Y, (int)enemyManager.lstGegnerMelee[j].EnemySize.X))
                                {
                                    enemyManager.lstGegnerMelee[j].EnemyXY = new Vector2(enemyManager.lstGegnerMelee[j].EnemyXY.X, enemyManager.lstGegnerMelee[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64);
                                }
                            }

                            enemyManager.lstGegnerMelee[j].EnemyHP -= abilityManager.lstAbility[i].ShotDamage;
                            enemyManager.lstGegnerMelee[j].EnemyTarget = true;

                            if (enemyManager.lstGegnerMelee[j].EnemyHP <= 0)
                            {
                                objectManager.SpawnCoinXP(enemyManager.lstGegnerMelee[j].EnemyXY);
                                enemyManager.lstGegnerMelee.RemoveAt(j);
                                abilityManager.lstAbility.Remove(abilityManager.lstAbility[i]);
                                break;
                            }


                            abilityManager.lstAbility.Remove(abilityManager.lstAbility[i]);


                            continue;
                        }
                    }

                    if (i < objectManager.lstDynamitArrowTrapBullets.Count)
                    {
                        if (new Rectangle((int)objectManager.lstDynamitArrowTrapBullets[i].ShotXY.X - (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.X / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotXY.Y - (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.Y / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.X / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.Y / 2).Intersects
                            (new Rectangle((int)enemyManager.lstGegnerMelee[j].EnemyXY.X, (int)enemyManager.lstGegnerMelee[j].EnemyXY.Y, (int)enemyManager.lstGegnerMelee[j].EnemySize.X, (int)enemyManager.lstGegnerMelee[j].EnemySize.Y)))
                        {
                            particleManager.SpawnHitParticle(objectManager.lstDynamitArrowTrapBullets[i].ShotXY, -objectManager.lstDynamitArrowTrapBullets[i].ShotDamage, Color.LightBlue);
                            particleManager.SpawnStandardParticle(objectManager.lstDynamitArrowTrapBullets[i].ShotXY);

                            enemyManager.lstGegnerMelee[j].EnemyHP -= objectManager.lstDynamitArrowTrapBullets[i].ShotDamage;
                            enemyManager.lstGegnerMelee[j].EnemyTarget = true;

                            if (enemyManager.lstGegnerMelee[j].EnemyHP <= 0)
                            {
                                objectManager.SpawnCoinXP(enemyManager.lstGegnerMelee[j].EnemyXY);
                                enemyManager.lstGegnerMelee.RemoveAt(j);
                                objectManager.lstDynamitArrowTrapBullets.Remove(objectManager.lstDynamitArrowTrapBullets[i]);

                                break;
                            }


                            objectManager.lstDynamitArrowTrapBullets.Remove(objectManager.lstDynamitArrowTrapBullets[i]);

                            continue;
                        }
                    }
                }
            }

            for (int j = 0; j < enemyManager.lstBoss.Count; j++)
            {
                if (enemyManager.lstBoss[j].State == 1)
                {
                    for (int i = 0; i < abilityManager.lstAbility.Count || i < abilityManager.lstNoCollision.Count || i < objectManager.lstDynamitArrowTrapBullets.Count; i++)
                    {
                        if (i < abilityManager.lstAbility.Count)
                        {
                            if (new Rectangle((int)abilityManager.lstAbility[i].ShotXY.X - (int)abilityManager.lstAbility[i].ShotSize.X / 2, (int)abilityManager.lstAbility[i].ShotXY.Y - (int)abilityManager.lstAbility[i].ShotSize.Y / 2, (int)abilityManager.lstAbility[i].ShotSize.X / 2, (int)abilityManager.lstAbility[i].ShotSize.Y / 2).Intersects
                                (new Rectangle((int)enemyManager.lstBoss[j].EnemyXY.X, (int)enemyManager.lstBoss[j].EnemyXY.Y, (int)enemyManager.lstBoss[j].EnemySize.X, (int)enemyManager.lstBoss[j].EnemySize.Y)))
                            {
                                particleManager.SpawnHitParticle(abilityManager.lstAbility[i].ShotXY, -abilityManager.lstAbility[i].ShotDamage, Color.LightBlue);
                                particleManager.SpawnStandardParticle(abilityManager.lstAbility[i].ShotXY);

                                if (enemyManager.lstBoss[j].EnemyXY.X + abilityManager.lstAbility[i].DirectionXY.X / 64 < 1920 - 64 && enemyManager.lstBoss[j].EnemyXY.Y + abilityManager.lstAbility[i].DirectionXY.Y / 64 < 1080 - 64
                                && enemyManager.lstBoss[j].EnemyXY.X + abilityManager.lstAbility[i].DirectionXY.X / 64 > 0 + 64 && enemyManager.lstBoss[j].EnemyXY.Y + abilityManager.lstAbility[i].DirectionXY.Y / 64 > 0 + 64)//+-64 = 2*RandCollision
                                {
                                    if (abilityManager.lstAbility[i].DirectionXY.X < 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstBoss[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstBoss[j].EnemyXY.Y), (int)enemyManager.lstBoss[j].EnemySize.Y, (int)enemyManager.lstBoss[j].EnemySize.X))
                                    {
                                        enemyManager.lstBoss[j].EnemyXY = new Vector2(enemyManager.lstBoss[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstBoss[j].EnemyXY.Y);
                                    }

                                    if (abilityManager.lstAbility[i].DirectionXY.X >= 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstBoss[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstBoss[j].EnemyXY.Y), (int)enemyManager.lstBoss[j].EnemySize.Y, (int)enemyManager.lstBoss[j].EnemySize.X))
                                    {
                                        enemyManager.lstBoss[j].EnemyXY = new Vector2(enemyManager.lstBoss[j].EnemyXY.X + (int)abilityManager.lstAbility[i].DirectionXY.X / 64, enemyManager.lstBoss[j].EnemyXY.Y);
                                    }

                                    if (abilityManager.lstAbility[i].DirectionXY.Y < 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstBoss[j].EnemyXY.X, enemyManager.lstBoss[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64), (int)enemyManager.lstBoss[j].EnemySize.Y, (int)enemyManager.lstBoss[j].EnemySize.X))
                                    {
                                        enemyManager.lstBoss[j].EnemyXY = new Vector2(enemyManager.lstBoss[j].EnemyXY.X, enemyManager.lstBoss[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64);
                                    }

                                    if (abilityManager.lstAbility[i].DirectionXY.Y >= 0 && collision.KnockbackCollision(new Vector2(enemyManager.lstBoss[j].EnemyXY.X, enemyManager.lstBoss[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64), (int)enemyManager.lstBoss[j].EnemySize.Y, (int)enemyManager.lstBoss[j].EnemySize.X))
                                    {
                                        enemyManager.lstBoss[j].EnemyXY = new Vector2(enemyManager.lstBoss[j].EnemyXY.X, enemyManager.lstBoss[j].EnemyXY.Y + (int)abilityManager.lstAbility[i].DirectionXY.Y / 64);
                                    }
                                }

                                enemyManager.lstBoss[j].EnemyHP -= abilityManager.lstAbility[i].ShotDamage;
                                enemyManager.lstBoss[j].EnemyTarget = true;

                                if (enemyManager.lstBoss[j].EnemyHP <= 0)
                                {
                                    objectManager.SpawnChest(enemyManager.lstBoss[j].EnemyXY + enemyManager.lstBoss[j].EnemySize / 2);
                                    enemyManager.lstBoss.RemoveAt(j);
                                    abilityManager.lstAbility.Remove(abilityManager.lstAbility[i]);
                                    break;
                                }


                                abilityManager.lstAbility.Remove(abilityManager.lstAbility[i]);


                                continue;
                            }
                        }

                        if (i < objectManager.lstDynamitArrowTrapBullets.Count)
                        {
                            if (new Rectangle((int)objectManager.lstDynamitArrowTrapBullets[i].ShotXY.X - (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.X / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotXY.Y - (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.Y / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.X / 2, (int)objectManager.lstDynamitArrowTrapBullets[i].ShotSize.Y / 2).Intersects
                                (new Rectangle((int)enemyManager.lstBoss[j].EnemyXY.X, (int)enemyManager.lstBoss[j].EnemyXY.Y, (int)enemyManager.lstBoss[j].EnemySize.X, (int)enemyManager.lstBoss[j].EnemySize.Y)))
                            {
                                particleManager.SpawnHitParticle(objectManager.lstDynamitArrowTrapBullets[i].ShotXY, -objectManager.lstDynamitArrowTrapBullets[i].ShotDamage, Color.LightBlue);
                                particleManager.SpawnStandardParticle(objectManager.lstDynamitArrowTrapBullets[i].ShotXY);

                                enemyManager.lstBoss[j].EnemyHP -= objectManager.lstDynamitArrowTrapBullets[i].ShotDamage;
                                enemyManager.lstBoss[j].EnemyTarget = true;

                                if (enemyManager.lstBoss[j].EnemyHP <= 0)
                                {
                                    objectManager.SpawnCoinXP(enemyManager.lstBoss[j].EnemyXY);
                                    enemyManager.lstBoss.RemoveAt(j);
                                    objectManager.lstDynamitArrowTrapBullets.Remove(objectManager.lstDynamitArrowTrapBullets[i]);

                                    break;
                                }


                                objectManager.lstDynamitArrowTrapBullets.Remove(objectManager.lstDynamitArrowTrapBullets[i]);

                                continue;
                            }
                        }

                        if (i < abilityManager.lstNoCollision.Count)
                        {
                            if (new Rectangle((int)abilityManager.lstNoCollision[i].ShotXY.X - (int)abilityManager.lstNoCollision[i].ShotSize.X / 2, (int)abilityManager.lstNoCollision[i].ShotXY.Y - (int)abilityManager.lstNoCollision[i].ShotSize.Y / 2, (int)abilityManager.lstNoCollision[i].ShotSize.X / 2, (int)abilityManager.lstNoCollision[i].ShotSize.Y / 2).Intersects
                                (new Rectangle((int)enemyManager.lstBoss[j].EnemyXY.X, (int)enemyManager.lstBoss[j].EnemyXY.Y, (int)enemyManager.lstBoss[j].EnemySize.X, (int)enemyManager.lstBoss[j].EnemySize.Y)))
                            {
                                abilityManager.lstNoCollision[i].CurrentTime = 0.89f;
                                abilityManager.lstNoCollision[i].ShotSpeed = 0f;
                            }
                        }
                    }
                }
            }
        }
    }
}
