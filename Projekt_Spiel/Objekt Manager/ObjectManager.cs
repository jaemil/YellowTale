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
    class ObjectManager
    {
        Random random = new Random();
        public Texture2D dynamit, dynamitZerstört1, dynamitZerstört2, dynamitZerstört3, dynamitbullet, chestclosed, chestopen, trap, arrow;
        public Texture2D coinFlip, xpanimation, healthpotionsmall1, healthpotionsmall2, healthpotionbig1, healthpotionbig2, hourglass;

        public Texture2D ArrowTrapUpLoaded;
        public Texture2D ArrowTrapUpUnloaded;

        public Texture2D ArrowTrapRightLoaded;
        public Texture2D ArrowTrapRightUnloaded;

        //InteractiveObjects List
        public List<Dynamit> lstDynamit = new List<Dynamit>();
        public List<Chest> lstChest = new List<Chest>();
        public List<Trap> lstTrap = new List<Trap>();
        public List<ArrowTrap> lstArrowTrap = new List<ArrowTrap>();

        public List<ShotEngine> lstDynamitArrowTrapBullets = new List<ShotEngine>();

        //PickUpItems List 
        public List<Coin> lstCoin = new List<Coin>();
        public List<Experience> lstExperience = new List<Experience>();
        public List<HealthPotionBig> lstHealthPotionBig = new List<HealthPotionBig>();
        public List<HealthPotionSmall> lstHealthPotionSmall = new List<HealthPotionSmall>();
        public List<Hourglass> lstHourglass = new List<Hourglass>();


        public void SpawnCoinXP(Vector2 position)
        {
            if (random.Next(1, 6) == 1)//20% Chance
            {
                lstCoin.Add(new Coin(coinFlip, position + new Vector2(random.Next(1, 20), random.Next(1, 20)), new Vector2(20, 20)));
            }

            if (random.Next(1, 11) == 1)//10% Chance
            {
                lstHealthPotionSmall.Add(new HealthPotionSmall(healthpotionsmall1, healthpotionsmall2, position + new Vector2(random.Next(1, 20), random.Next(1, 20)), new Vector2(20, 20)));
            }

            lstExperience.Add(new Experience(xpanimation, position + new Vector2(random.Next(1, 20), random.Next(1, 20)), new Vector2(20, 20)));
        }

        public void SpawnCoin(Vector2 position)
        {
            lstCoin.Add(new Coin(coinFlip, position + new Vector2(random.Next(1, 20), random.Next(1, 20)), new Vector2(20, 20)));
        }

        public void SpawnChestItem(Vector2 position)
        {
            for (int i = 0; i < 5; i++)
            {
                lstCoin.Add(new Coin(coinFlip, position + new Vector2(random.Next(1, 64), random.Next(1, 64)) - new Vector2(32, 32), new Vector2(20, 20)));
                lstCoin[lstCoin.Count - 1].Radius = 1;//Radius verkleinern damit Items nicht direkt eingesammelt werden
            }

            for (int i = 0; i < 10; i++)
            {
                lstExperience.Add(new Experience(xpanimation, position + new Vector2(random.Next(1, 64), random.Next(1, 64)) - new Vector2(32, 32), new Vector2(20, 20)));
                lstExperience[lstExperience.Count - 1].Radius = 1;
            }


            lstHealthPotionBig.Add(new HealthPotionBig(healthpotionbig1, healthpotionbig2, position + new Vector2(random.Next(1, 64), random.Next(1, 64)) - new Vector2(32, 32), new Vector2(20, 20)));
            lstHealthPotionBig[lstHealthPotionBig.Count - 1].Radius = 1;
        }

        public void SpawnHourglass(Vector2 position)
        {
            lstHourglass.Add(new Hourglass(hourglass, position, new Vector2(32, 32)));
        }


        public void SpawnChest(Vector2 position)
        {
            lstChest.Add(new Chest(chestclosed, chestopen, position));
        }

        public void SpawnTrap(Vector2 position)
        {
            lstTrap.Add(new Trap(trap, position));
        }

        public void SpawnDynamit(Vector2 position)
        {
            lstDynamit.Add(new Dynamit(dynamit, dynamitZerstört1, dynamitZerstört2, dynamitZerstört3, position, random.Next(1, 4)));
        }

        public void SpawnArrowTrap(Vector2 position, int direction)//0 oben, 1 rechts, 2 unten, 3 links
        {
            lstArrowTrap.Add(new ArrowTrap(ArrowTrapUpLoaded, ArrowTrapUpUnloaded, ArrowTrapRightLoaded, ArrowTrapRightUnloaded, position, direction));
        }


        public void ObjectDelete()//Alle Interactive Objekte entfernen 
        {
            lstDynamit.RemoveRange(0, lstDynamit.Count);//Dynamit entfernen
            lstChest.RemoveRange(0, lstChest.Count);//Chest entfernen
            lstTrap.RemoveRange(0, lstTrap.Count);//Trap entfernen
            lstArrowTrap.RemoveRange(0, lstArrowTrap.Count);//ArrowTrap entfernen
            lstHourglass.RemoveRange(0, lstHourglass.Count);
        }


        public void Update(GameTime gameTime, Vector2 playerposition, Player player, int currentSpieler, ParticleManager particleManager, AbilityManager abilities, Game1 game)
        {
            #region InteractiveObjects
            for (int i = 0; i < lstDynamit.Count; i++)
            {
                lstDynamit[i].Update(gameTime);

                if (lstDynamit[i].Explosion && !lstDynamit[i].Exploded)
                {
                    int x = 0, y = 0, r = 100;

                    for (int w = 0; w < 360; w += 10)
                    {
                        x = Convert.ToInt32(32 + lstDynamit[i].Position.X + r * Math.Sin(w * (Math.PI / 180)));
                        y = Convert.ToInt32(32 + lstDynamit[i].Position.Y + r * Math.Cos(w * (Math.PI / 180)));
                        lstDynamitArrowTrapBullets.Add(new ShotAnimation(new Vector2(x, y), lstDynamit[i].Position + new Vector2(32, 32), 2f, dynamitbullet, 10, 5, 30, 30, new Vector2(30, 30), 4, ""));
                    }

                    lstDynamit[i].Exploded = true;//Damit sich das Dynamit nur einmal entzündet
                    lstDynamit[i].Explosion = false;
                }
            }

            for (int i = 0; i < lstArrowTrap.Count; i++)
            {
                lstArrowTrap[i].Update(gameTime);

                if (lstArrowTrap[i].Cooldown >= 1.0f)
                {
                    if (lstArrowTrap[i].Direction == 0)
                    {
                        lstDynamitArrowTrapBullets.Add(new ShotStandard(lstArrowTrap[i].Position + new Vector2(32, -32), lstArrowTrap[i].Position + new Vector2(32, 32), 2f, arrow, new Vector2(32, 10), 10, ""));
                    }
                    else if (lstArrowTrap[i].Direction == 1)
                    {
                        lstDynamitArrowTrapBullets.Add(new ShotStandard(lstArrowTrap[i].Position + new Vector2(32, 32), lstArrowTrap[i].Position + new Vector2(31, 32), 2f, arrow, new Vector2(32, 10), 10, ""));
                    }
                    else if (lstArrowTrap[i].Direction == 2)
                    {
                        lstDynamitArrowTrapBullets.Add(new ShotStandard(lstArrowTrap[i].Position + new Vector2(32, 33), lstArrowTrap[i].Position + new Vector2(32, 32), 2f, arrow, new Vector2(32, 10), 10, ""));
                    }
                    else
                    {
                        lstDynamitArrowTrapBullets.Add(new ShotStandard(lstArrowTrap[i].Position + new Vector2(-32, 32), lstArrowTrap[i].Position + new Vector2(32, 32), 2f, arrow, new Vector2(32, 10), 10, ""));
                    }

                    lstArrowTrap[i].Cooldown = 0f;
                }
            }

            for (int i = 0; i < lstChest.Count; i++)
            {
                lstChest[i].Update(gameTime);

                if (new Rectangle((int)playerposition.X, (int)playerposition.Y, 32, 48).Intersects(new Rectangle((int)lstChest[i].Position.X - 50, (int)lstChest[i].Position.Y - 50, 32 + 100, 32 + 100)) && !lstChest[i].Opened)
                {//Wenn Spieler mit Chest Kollidiert
                    lstChest[i].Opened = true;//Damit sich die Chest nur einmal öffnen lässt
                    SpawnChestItem(lstChest[i].Position);
                }
            }

            for (int i = 0; i < lstTrap.Count; i++)
            {
                lstTrap[i].Update(gameTime);

                if (new Rectangle((int)playerposition.X, (int)playerposition.Y, 32, 48).Intersects(new Rectangle((int)lstTrap[i].Position.X, (int)lstTrap[i].Position.Y, 64, 64)) && lstTrap[i].Cooldown >= 0.5f)//Alle 0.5 sec
                {//Wenn Spieler mit Falle Kollidiert
                    player.LebenAbziehen(10, currentSpieler, particleManager, playerposition, game);//10 hp abziehen
                    //particleManager.SpawnHitParticle(playerposition, -10, new Color(255, 0, 64));
                    lstTrap[i].Cooldown = 0f;
                }
            }

            for (int i = 0; i < lstDynamitArrowTrapBullets.Count; i++)
            {
                lstDynamitArrowTrapBullets[i].Update(gameTime);
            }

            #endregion

            #region PickUpItems
            for (int i = 0; i < lstCoin.Count; i++)
            {
                if (lstCoin[i].Collected)//Wenn vom Spieler eingesammelt
                {
                    lstCoin[i].Update(new Vector2(1820, 40));//Ziel zu Coin HUD Position änderen

                    if (new Rectangle(1820, 40, 30, 30).Intersects(new Rectangle((int)lstCoin[i].ItemPosition.X, (int)lstCoin[i].ItemPosition.Y, (int)lstCoin[i].ItemSize.X, (int)lstCoin[i].ItemSize.Y)))
                    {
                        player.Coin += 1;//Coin + 1
                        particleManager.SpawnHitParticle(new Vector2(1825, 40), 1, new Color(238, 190, 46));//Partikel erzeugen
                        lstCoin.RemoveAt(i);//Coin entfernen
                    }
                }
                else
                {
                    lstCoin[i].Update(playerposition);
                    if (new Rectangle((int)playerposition.X, (int)playerposition.Y, 32, 48).Intersects(new Rectangle((int)lstCoin[i].ItemPosition.X, (int)lstCoin[i].ItemPosition.Y, (int)lstCoin[i].ItemSize.X, (int)lstCoin[i].ItemSize.Y)))
                    {//Wenn Spieler mit Item Kollidiert
                        lstCoin[i].Radius = 2000;
                        lstCoin[i].Speed = 25;

                        lstCoin[i].Collected = true;
                    }
                }
            }

            for (int i = 0; i < lstExperience.Count; i++)
            {
                if (lstExperience[i].Collected)
                {
                    lstExperience[i].Update(new Vector2(875, 970));

                    if (new Rectangle(810, 970, 128, 128).Intersects(new Rectangle((int)lstExperience[i].ItemPosition.X, (int)lstExperience[i].ItemPosition.Y, (int)lstExperience[i].ItemSize.X, (int)lstExperience[i].ItemSize.Y)))
                    {
                        particleManager.SpawnHitParticle(new Vector2(865, 970), 10, new Color(211, 252, 126));
                        player.XpHinzufügen(10, currentSpieler);//10 xp hinzufügen
                        lstExperience.RemoveAt(i);//Xp entfernen
                    }
                }
                else
                {
                    lstExperience[i].Update(playerposition);
                    if (new Rectangle((int)playerposition.X, (int)playerposition.Y, 32, 48).Intersects(new Rectangle((int)lstExperience[i].ItemPosition.X, (int)lstExperience[i].ItemPosition.Y, (int)lstExperience[i].ItemSize.X, (int)lstExperience[i].ItemSize.Y)))
                    {//Wenn Spieler mit Item Kollidiert
                        lstExperience[i].Radius = 2000;
                        lstExperience[i].Speed = 25;

                        lstExperience[i].Collected = true;
                    }
                }
            }

            for (int i = 0; i < lstHealthPotionSmall.Count; i++)
            {
                if (lstHealthPotionSmall[i].Collected)
                {
                    lstHealthPotionSmall[i].Update(new Vector2(865, 1010));

                    if (new Rectangle(810, 1010, 128, 128).Intersects(new Rectangle((int)lstHealthPotionSmall[i].ItemPosition.X, (int)lstHealthPotionSmall[i].ItemPosition.Y, (int)lstHealthPotionSmall[i].ItemSize.X, (int)lstHealthPotionSmall[i].ItemSize.Y)))
                    {
                        particleManager.SpawnHitParticle(new Vector2(865, 1010), 50, new Color(255, 0, 64));
                        lstHealthPotionSmall.RemoveAt(i);//Xp entfernen
                    }
                }
                else
                {
                    lstHealthPotionSmall[i].Update(playerposition);
                    if (new Rectangle((int)playerposition.X, (int)playerposition.Y, 32, 48).Intersects(new Rectangle((int)lstHealthPotionSmall[i].ItemPosition.X, (int)lstHealthPotionSmall[i].ItemPosition.Y, (int)lstHealthPotionSmall[i].ItemSize.X, (int)lstHealthPotionSmall[i].ItemSize.Y)))
                    {//Wenn Spieler mit Item Kollidiert
                        lstHealthPotionSmall[i].Radius = 2000;
                        lstHealthPotionSmall[i].Speed = 25;
                        player.LebenHinzufügen(50, currentSpieler);//50 hp hinzufügen

                        lstHealthPotionSmall[i].Collected = true;
                    }
                }
            }

            for (int i = 0; i < lstHealthPotionBig.Count; i++)
            {
                if (lstHealthPotionBig[i].Collected)
                {
                    lstHealthPotionBig[i].Update(new Vector2(865, 1010));

                    if (new Rectangle(810, 1010, 128, 128).Intersects(new Rectangle((int)lstHealthPotionBig[i].ItemPosition.X, (int)lstHealthPotionBig[i].ItemPosition.Y, (int)lstHealthPotionBig[i].ItemSize.X, (int)lstHealthPotionBig[i].ItemSize.Y)))
                    {
                        particleManager.SpawnHitParticle(new Vector2(855, 1010), 100, new Color(255, 0, 64));
                        lstHealthPotionBig.RemoveAt(i);//Xp entfernen
                    }
                }
                else
                {
                    lstHealthPotionBig[i].Update(playerposition);
                    if (new Rectangle((int)playerposition.X, (int)playerposition.Y, 32, 48).Intersects(new Rectangle((int)lstHealthPotionBig[i].ItemPosition.X, (int)lstHealthPotionBig[i].ItemPosition.Y, (int)lstHealthPotionBig[i].ItemSize.X, (int)lstHealthPotionBig[i].ItemSize.Y)))
                    {//Wenn Spieler mit Item Kollidiert
                        lstHealthPotionBig[i].Radius = 2000;
                        lstHealthPotionBig[i].Speed = 25;
                        player.LebenHinzufügen(100, currentSpieler);//100 hp hinzufügen

                        lstHealthPotionBig[i].Collected = true;
                    }
                }
            }

            for (int i = 0; i < lstHourglass.Count; i++)
            {
                if (lstHourglass[i].Collected)
                {
                    lstHourglass[i].Update(new Vector2(865, 1010));

                    if (new Rectangle(810, 1010, 128, 128).Intersects(new Rectangle((int)lstHourglass[i].ItemPosition.X, (int)lstHourglass[i].ItemPosition.Y, (int)lstHourglass[i].ItemSize.X, (int)lstHourglass[i].ItemSize.Y)))
                    {
                        particleManager.SpawnHitParticle(new Vector2(855, 1010), 100, new Color(192, 192, 192));
                        lstHourglass.RemoveAt(i);
                    }
                }
                else
                {
                    lstHourglass[i].Update(playerposition);
                    if (new Rectangle((int)playerposition.X, (int)playerposition.Y, 32, 48).Intersects(new Rectangle((int)lstHourglass[i].ItemPosition.X, (int)lstHourglass[i].ItemPosition.Y, (int)lstHourglass[i].ItemSize.X, (int)lstHourglass[i].ItemSize.Y)))
                    {//Wenn Spieler mit Item Kollidiert
                        lstHourglass[i].Radius = 2000;
                        lstHourglass[i].Speed = 25;


                        //Abilities Cooldown Reset

                        abilities.CooldownAutoAttackArcher = abilities.MaxCooldownAutoAttackArcher;
                        abilities.CooldownAbility1Archer = abilities.MaxCooldownAbility1Archer;
                        abilities.CooldownAbility2Archer = abilities.MaxCooldownAbility1Archer;
                        abilities.CooldownAbility3Archer = abilities.MaxCooldownAbility1Archer;
                        abilities.CooldownSpecialArcher = abilities.MaxCooldownSpecialArcher;

                        abilities.CooldownAutoAttackWizard = abilities.MaxCooldownAutoAttackWizard;
                        abilities.CooldownAbility1Wizard = abilities.MaxCooldownAbility1Wizard;
                        abilities.CooldownAbility2Wizard = abilities.MaxCooldownAbility2Wizard;
                        abilities.CooldownAbility3Wizard = abilities.MaxCooldownAbility3Wizard;
                        abilities.CooldownSpecialWizard = abilities.MaxCooldownSpecialWizard;

                        abilities.CooldownAutoAttackKnight = abilities.MaxCooldownAutoAttackKnight;
                        abilities.CooldownAbility1Knight = abilities.MaxCooldownAbility1Knight;
                        abilities.CooldownAbility2Knight = abilities.MaxCooldownAbility2Knight;
                        abilities.CooldownAbility3Knight = abilities.MaxCooldownAbility3Knight;
                        abilities.CooldownSpecialKnight = abilities.MaxCooldownSpecialKnight;


                        lstHourglass[i].Collected = true;
                    }
                }
            }
            #endregion
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            #region InteractiveObjects
            for (int i = 0; i < lstDynamit.Count; i++)
            {
                lstDynamit[i].Draw(spriteBatch, gameTime);
            }

            for (int i = 0; i < lstArrowTrap.Count; i++)
            {
                lstArrowTrap[i].Draw(spriteBatch, gameTime);
            }

            for (int i = 0; i < lstDynamitArrowTrapBullets.Count; i++)
            {
                lstDynamitArrowTrapBullets[i].Draw(spriteBatch, gameTime);
            }

            for (int i = 0; i < lstChest.Count; i++)
            {
                lstChest[i].Draw(spriteBatch, gameTime);
            }

            for (int i = 0; i < lstTrap.Count; i++)
            {
                lstTrap[i].Draw(spriteBatch, gameTime);
            }
            #endregion

            #region PickUpItems
            for (int i = 0; i < lstCoin.Count; i++)
            {
                lstCoin[i].Draw(spriteBatch, gameTime);
            }

            for (int i = 0; i < lstExperience.Count; i++)
            {
                lstExperience[i].Draw(spriteBatch, gameTime);
            }

            for (int i = 0; i < lstHealthPotionSmall.Count; i++)
            {
                lstHealthPotionSmall[i].Draw(spriteBatch, gameTime);
            }

            for (int i = 0; i < lstHealthPotionBig.Count; i++)
            {
                lstHealthPotionBig[i].Draw(spriteBatch, gameTime);
            }

            for (int i = 0; i < lstHourglass.Count; i++)
            {
                lstHourglass[i].Draw(spriteBatch, gameTime);
            }
            #endregion
        }
    }
}
