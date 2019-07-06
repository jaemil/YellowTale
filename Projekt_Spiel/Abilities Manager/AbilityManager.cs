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
    class AbilityManager
    {
        public List<ShotEngine> lstAbility = new List<ShotEngine>();//Liste in der alle Schüsse gespeichert werden

        public List<ShotEngine> lstNoCollision = new List<ShotEngine>();//Archer Ability3 einzelner Shot

        public Texture2D arrow, arrowice, arrowtoxic, arrowpierce, fireball, fireball2, fireball3, fireball4, arrowbig;

        public Rectangle[,] knightRectangles = new Rectangle[3, 3];//Knight Rectangles

        private float maxCooldownAutoAttackArcher = 1;
        private float maxCooldownAbility1Archer = 2.5f;
        private float maxCooldownAbility2Archer = 2.5f;
        private float maxCooldownAbility3Archer = 2.5f;
        private float maxCooldownSpecialArcher = 0.5f;//Dash

        private float maxCooldownAutoAttackWizard = 1;
        private float maxCooldownAbility1Wizard = 1f;
        private float maxCooldownAbility2Wizard = 2.5f;
        private float maxCooldownAbility3Wizard = 2.5f;
        private float maxCooldownSpecialWizard = 0.5f;//Teleport

        private float maxCooldownAutoAttackKnight = 2;
        private float maxCooldownAbility1Knight = 2.5f;
        private float maxCooldownAbility2Knight = 2.5f;
        private float maxCooldownAbility3Knight = 2.5f;
        private float maxCooldownSpecialKnight = 0.5f;//Block


        private float cooldownAutoAttackWizard;
        private float cooldownAbility1Wizard;
        private float cooldownAbility2Wizard;
        private float cooldownAbility3Wizard;
        private float cooldownSpecialWizard;//Teleport

        private float cooldownAutoAttackKnight;
        private float cooldownAbility1Knight;
        private float cooldownAbility2Knight;
        private float cooldownAbility3Knight;
        private float cooldownSpecialKnight;//Block

        private float cooldownAutoAttackArcher;
        private float cooldownAbility1Archer;
        private float cooldownAbility2Archer;
        private float cooldownAbility3Archer;
        private float cooldownSpecialArcher;

        private int WizarReihenfolge = 0;


        #region Eigenschaften
        public float CooldownAutoAttackWizard
        {
            get { return cooldownAutoAttackWizard; }
            set { cooldownAutoAttackWizard = value; }
        }

        public float CooldownAbility1Wizard
        {
            get { return cooldownAbility1Wizard; }
            set { cooldownAbility1Wizard = value; }
        }

        public float CooldownAbility2Wizard
        {
            get { return cooldownAbility2Wizard; }
            set { cooldownAbility2Wizard = value; }
        }

        public float CooldownAbility3Wizard
        {
            get { return cooldownAbility3Wizard; }
            set { cooldownAbility3Wizard = value; }
        }

        public float CooldownSpecialWizard
        {
            get { return cooldownSpecialWizard; }
            set { cooldownSpecialWizard = value; }
        }


        public float CooldownAutoAttackArcher
        {
            get { return cooldownAutoAttackArcher; }
            set { cooldownAutoAttackArcher = value; }
        }

        public float CooldownAbility1Archer
        {
            get { return cooldownAbility1Archer; }
            set { cooldownAbility1Archer = value; }
        }

        public float CooldownAbility2Archer
        {
            get { return cooldownAbility2Archer; }
            set { cooldownAbility2Archer = value; }
        }

        public float CooldownAbility3Archer
        {
            get { return cooldownAbility3Archer; }
            set { cooldownAbility3Archer = value; }
        }

        public float CooldownSpecialArcher
        {
            get { return cooldownSpecialArcher; }
            set { cooldownSpecialArcher = value; }
        }


        public float CooldownAutoAttackKnight
        {
            get { return cooldownAutoAttackKnight; }
            set { cooldownAutoAttackKnight = value; }
        }

        public float CooldownAbility1Knight
        {
            get { return cooldownAbility1Knight; }
            set { cooldownAbility1Knight = value; }
        }

        public float CooldownAbility2Knight
        {
            get { return cooldownAbility2Knight; }
            set { cooldownAbility2Knight = value; }
        }

        public float CooldownAbility3Knight
        {
            get { return cooldownAbility3Knight; }
            set { cooldownAbility3Knight = value; }
        }

        public float CooldownSpecialKnight
        {
            get { return cooldownSpecialKnight; }
            set { cooldownSpecialKnight = value; }
        }


        public float MaxCooldownAutoAttackWizard
        {
            get { return maxCooldownAutoAttackWizard; }
            set { maxCooldownAutoAttackWizard = value; }
        }

        public float MaxCooldownAbility1Wizard
        {
            get { return maxCooldownAbility1Wizard; }
            set { maxCooldownAbility1Wizard = value; }
        }

        public float MaxCooldownAbility2Wizard
        {
            get { return maxCooldownAbility2Wizard; }
            set { maxCooldownAbility2Wizard = value; }
        }

        public float MaxCooldownAbility3Wizard
        {
            get { return maxCooldownAbility3Wizard; }
            set { maxCooldownAbility3Wizard = value; }
        }

        public float MaxCooldownSpecialWizard
        {
            get { return maxCooldownSpecialWizard; }
            set { maxCooldownSpecialWizard = value; }
        }


        public float MaxCooldownAutoAttackArcher
        {
            get { return maxCooldownAutoAttackArcher; }
            set { maxCooldownAutoAttackArcher = value; }
        }

        public float MaxCooldownAbility1Archer
        {
            get { return maxCooldownAbility1Archer; }
            set { maxCooldownAbility1Archer = value; }
        }

        public float MaxCooldownAbility2Archer
        {
            get { return maxCooldownAbility2Archer; }
            set { maxCooldownAbility2Archer = value; }
        }

        public float MaxCooldownAbility3Archer
        {
            get { return maxCooldownAbility3Archer; }
            set { maxCooldownAbility3Archer = value; }
        }

        public float MaxCooldownSpecialArcher
        {
            get { return maxCooldownSpecialArcher; }
            set { maxCooldownSpecialArcher = value; }
        }


        public float MaxCooldownAutoAttackKnight
        {
            get { return maxCooldownAutoAttackKnight; }
            set { maxCooldownAutoAttackKnight = value; }
        }

        public float MaxCooldownAbility1Knight
        {
            get { return maxCooldownAbility1Knight; }
            set { maxCooldownAbility1Knight = value; }
        }

        public float MaxCooldownAbility2Knight
        {
            get { return maxCooldownAbility2Knight; }
            set { maxCooldownAbility2Knight = value; }
        }

        public float MaxCooldownAbility3Knight
        {
            get { return maxCooldownAbility3Knight; }
            set { maxCooldownAbility3Knight = value; }
        }

        public float MaxCooldownSpecialKnight
        {
            get { return maxCooldownSpecialKnight; }
            set { maxCooldownSpecialKnight = value; }
        }
        #endregion

        public AbilityManager()
        {
            cooldownAutoAttackArcher = maxCooldownAutoAttackArcher;
            cooldownAbility1Archer = maxCooldownAbility1Archer;
            cooldownAbility2Archer = maxCooldownAbility2Archer;
            cooldownAbility3Archer = maxCooldownAbility3Archer;
            cooldownSpecialArcher = maxCooldownSpecialArcher;

            cooldownAutoAttackWizard = maxCooldownAutoAttackWizard;
            cooldownAbility1Wizard = maxCooldownAbility1Wizard;
            cooldownAbility2Wizard = maxCooldownAbility2Wizard;
            cooldownAbility3Wizard = maxCooldownAbility3Wizard;
            cooldownSpecialWizard = maxCooldownSpecialWizard;

            cooldownAutoAttackKnight = maxCooldownAutoAttackKnight;
            cooldownAbility1Knight = maxCooldownAbility1Knight;
            cooldownAbility2Knight = maxCooldownAbility2Knight;
            cooldownAbility3Knight = maxCooldownAbility3Knight;
            cooldownSpecialKnight = maxCooldownSpecialKnight;
        }

        #region Archer Abilities
        public void AutoAttackArcher(Vector2 mouse, Vector2 player, Texture2D texture, int lvl)
        {
            lstAbility.Add(new ShotStandard(mouse, player + new Vector2(16, 24), 6.0f, texture, new Vector2(16, 5), lvl, ""));
        }

        public void Ability1Archer(Vector2 mouse, Vector2 player, Texture2D texture, int lvl)
        {
            lstAbility.Add(new ShotStandard(mouse, player + new Vector2(16, 24), 6.0f, texture, new Vector2(16, 5), lvl, ""));
        }

        public void Ability2Archer(Vector2 mouse, Vector2 player, Texture2D texture, int lvl)
        {
            int x = 0, y = 0, r = 50;
            for (int w = 0; w < 360; w += 5)
            {
                x = Convert.ToInt32(16 + player.X + r * Math.Sin(w * (Math.PI / 100)));
                y = Convert.ToInt32(24 + player.Y + r * Math.Cos(w * (Math.PI / 100)));
                lstAbility.Add(new ShotStandard(new Vector2(x, y), player + new Vector2(16, 24), 2f, texture, new Vector2(16, 5), lvl, ""));
            }
        }

        public void Ability3Archer(bool auswahl, Vector2 mouse, Vector2 player, Texture2D texture1, Texture2D texture2, Texture2D texture3, int lvl)
        {
            Random random = new Random();
            if (auswahl)//Wird Aufgerufen wenn man e drückt
            {
                lstNoCollision.Add(new ShotStandard(mouse, player + new Vector2(16, 24), 10.0f, texture1, new Vector2(16, 5), 1, ""));//Einzelner Pfeil
            }
            else//Wird Aufgerufen wenn cooldownAbility3Archer = 0.5 ist oder der einzelne Pfeil (mit Rand) kollidiert
            {
                int x = 0, y = 0, r = 50;
                for (int w = 0; w <= 360; w += 20)
                {
                    x = Convert.ToInt32(lstNoCollision[0].ShotXY.X + r * Math.Sin(w * (Math.PI / 180)));
                    y = Convert.ToInt32(lstNoCollision[0].ShotXY.Y + r * Math.Cos(w * (Math.PI / 180)));

                    lstAbility.Add(new ShotStandard(new Vector2(x, y), lstNoCollision[0].ShotXY, 2.5f + Convert.ToSingle(random.NextDouble()), texture1, new Vector2(16, 5), lvl, ""));
                    lstAbility.Add(new ShotStandard(new Vector2(x, y), lstNoCollision[0].ShotXY, 3f + Convert.ToSingle(random.NextDouble()), texture2, new Vector2(16, 5), lvl, ""));
                    lstAbility.Add(new ShotStandard(new Vector2(x, y), lstNoCollision[0].ShotXY, 3.5f + Convert.ToSingle(random.NextDouble()), texture3, new Vector2(16, 5), lvl, ""));
                }

                lstNoCollision.RemoveAt(0);
            }

        }
        #endregion

        #region Wizard Abilities
        public void AutoAtackWizard(Vector2 mouse, Vector2 player, Texture2D texture, int lvl)
        {
            lstAbility.Add(new ShotAnimation(mouse, player + new Vector2(16, 24), 3.0f, texture, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));
        }

        public void Ability1Wizard(Vector2 mouse, Vector2 player, Texture2D texture, int lvl)
        {
            int x = 0, y = 0, r = 50;
            int x1 = 0, y1 = 0;
            for (int w = 0; w < 360; w += 20)
            {
                x = Convert.ToInt32(player.X + r * Math.Sin(w * (Math.PI / 180)));
                y = Convert.ToInt32(player.Y + r * Math.Cos(w * (Math.PI / 180)));

                x1 = Convert.ToInt32(mouse.X + r * Math.Sin(w * (Math.PI / 180)));
                y1 = Convert.ToInt32(mouse.Y + r * Math.Cos(w * (Math.PI / 180)));

                lstAbility.Add(new ShotAnimation(new Vector2(x1, y1), new Vector2(x, y) + new Vector2(16, 24), 5.0f, texture, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));
            }

        }

        public void Ability2Wizard(Vector2 mouse, Vector2 player, Texture2D texture, Texture2D texture2, Texture2D texture3, Texture2D texture4, int lvl)
        {
            int x = 0, y = 0, r = 50;
            for (int w = 0; w < 360; w += 20)
            {
                x = Convert.ToInt32(mouse.X + r * Math.Sin(w * (Math.PI / 180)));
                y = Convert.ToInt32(mouse.Y + r * Math.Cos(w * (Math.PI / 180)));
                if (WizarReihenfolge == 0)
                {
                    lstAbility.Add(new ShotAnimation(new Vector2(x, y), mouse, 2f, texture, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));
                    WizarReihenfolge = 1;
                }
                else if (WizarReihenfolge == 1)
                {
                    lstAbility.Add(new ShotAnimation(new Vector2(x, y), mouse, 2f, texture2, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));
                    WizarReihenfolge = 2;
                }
                else if (WizarReihenfolge == 2)
                {
                    lstAbility.Add(new ShotAnimation(new Vector2(x, y), mouse, 2f, texture3, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));
                    WizarReihenfolge = 3;
                }
                else
                {
                    lstAbility.Add(new ShotAnimation(new Vector2(x, y), mouse, 2f, texture4, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));
                    WizarReihenfolge = 0;
                }
            }
        }

        public void Ability3Wizard(Vector2 mouse, Vector2 player, Texture2D texture1, Texture2D texture2, Texture2D texture3, int lvl)
        {
            Random random = new Random();
            float j = 1.50f;
            bool anordnung = false;
            int x = 0, y = 0, r = 500;
            for (int w = 0; w <= 360; w += 5)
            {

                x = Convert.ToInt32(16 + player.X + r * Math.Sin(w * (Math.PI / 180)));
                y = Convert.ToInt32(24 + player.Y + r * Math.Cos(w * (Math.PI / 180)));
                lstAbility.Add(new ShotAnimation(new Vector2(x, y), player + new Vector2(16, 24), j + 1, texture1, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));
                lstAbility.Add(new ShotAnimation(new Vector2(x, y), player + new Vector2(16, 24), j + 2, texture2, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));
                lstAbility.Add(new ShotAnimation(new Vector2(x, y), player + new Vector2(16, 24), j + 3, texture3, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));

                if (w % 40 == 20)
                {
                    anordnung = true;
                }
                else if (w % 40 == 0)
                {
                    anordnung = false;
                }

                if (anordnung)
                {
                    j += 0.25f;
                }
                else
                {
                    j -= 0.25f;
                }

            }
        }
        #endregion

        #region Ritter Abilities
        public void AutoAtackRitter(GameTime gameTime, Vector2 mouse, Vector2 player, Texture2D texture, EnemyManager enemyManager, WeaponManager weapon, int lvl)
        {

            for (int i = 0; i < enemyManager.lstGegnerShot.Count; i++)
            {
                if (knightRectangles[1, 0].X + 64 > mouse.X && knightRectangles[1, 0].X - 32 < mouse.X && knightRectangles[1, 0].Y + 32 > mouse.Y)
                {
                    if (new Rectangle((int)knightRectangles[1, 0].X, (int)knightRectangles[1, 0].Y, 32, 32).Intersects(new Rectangle((int)enemyManager.lstGegnerShot[i].ShotXY.X, (int)enemyManager.lstGegnerShot[i].ShotXY.Y, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y)))
                    {
                        if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotStandard))
                        {
                            lstAbility.Add(new ShotStandard(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }
                        else if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotAnimation))
                        {
                            lstAbility.Add(new ShotAnimation(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, enemyManager.lstGegnerShot[i].animations.Fps, enemyManager.lstGegnerShot[i].animations.Frames, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }

                        enemyManager.lstGegnerShot.RemoveAt(i);
                    }
                    break;
                }
                else if (knightRectangles[0, 1].X + 32 > mouse.X && knightRectangles[0, 1].Y + 48 + 32 > mouse.Y && knightRectangles[0, 1].Y - 32 < mouse.Y)
                {
                    if (new Rectangle((int)knightRectangles[0, 1].X, (int)knightRectangles[0, 1].Y, 32, 48).Intersects(new Rectangle((int)enemyManager.lstGegnerShot[i].ShotXY.X, (int)enemyManager.lstGegnerShot[i].ShotXY.Y, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y)))
                    {
                        if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotStandard))
                        {
                            lstAbility.Add(new ShotStandard(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }
                        else if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotAnimation))
                        {
                            lstAbility.Add(new ShotAnimation(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, enemyManager.lstGegnerShot[i].animations.Fps, enemyManager.lstGegnerShot[i].animations.Frames, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }

                        enemyManager.lstGegnerShot.RemoveAt(i);
                    }
                    break;
                }
                else if (knightRectangles[2, 1].X <= mouse.X && knightRectangles[2, 1].Y + 48 + 32 > mouse.Y && knightRectangles[2, 1].Y - 32 < mouse.Y)
                {
                    if (new Rectangle((int)knightRectangles[2, 1].X, (int)knightRectangles[2, 1].Y, 32, 48).Intersects(new Rectangle((int)enemyManager.lstGegnerShot[i].ShotXY.X, (int)enemyManager.lstGegnerShot[i].ShotXY.Y, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y)))
                    {
                        if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotStandard))
                        {
                            lstAbility.Add(new ShotStandard(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }
                        else if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotAnimation))
                        {
                            lstAbility.Add(new ShotAnimation(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, enemyManager.lstGegnerShot[i].animations.Fps, enemyManager.lstGegnerShot[i].animations.Frames, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }

                        enemyManager.lstGegnerShot.RemoveAt(i);
                    }
                    break;
                }
                else if (knightRectangles[1, 2].X + 64 > mouse.X && knightRectangles[1, 2].X - 32 < mouse.X && knightRectangles[1, 2].Y < mouse.Y)
                {
                    if (new Rectangle((int)knightRectangles[1, 2].X, (int)knightRectangles[1, 2].Y, 32, 32).Intersects(new Rectangle((int)enemyManager.lstGegnerShot[i].ShotXY.X, (int)enemyManager.lstGegnerShot[i].ShotXY.Y, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y)))
                    {
                        if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotStandard))
                        {
                            lstAbility.Add(new ShotStandard(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }
                        else if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotAnimation))
                        {
                            lstAbility.Add(new ShotAnimation(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, enemyManager.lstGegnerShot[i].animations.Fps, enemyManager.lstGegnerShot[i].animations.Frames, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }

                        enemyManager.lstGegnerShot.RemoveAt(i);
                    }
                    break;
                }


                if (knightRectangles[2, 0].X <= mouse.X && knightRectangles[2, 0].Y + 32 > mouse.Y)
                {
                    if (new Rectangle((int)knightRectangles[2, 0].X, (int)knightRectangles[2, 0].Y, 32, 32).Intersects(new Rectangle((int)enemyManager.lstGegnerShot[i].ShotXY.X, (int)enemyManager.lstGegnerShot[i].ShotXY.Y, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y)))
                    {
                        if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotStandard))
                        {
                            lstAbility.Add(new ShotStandard(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }
                        else if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotAnimation))
                        {
                            lstAbility.Add(new ShotAnimation(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, enemyManager.lstGegnerShot[i].animations.Fps, enemyManager.lstGegnerShot[i].animations.Frames, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }

                        enemyManager.lstGegnerShot.RemoveAt(i);
                    }
                    break;
                }
                else if (knightRectangles[0, 2].X + 32 > mouse.X && knightRectangles[0, 2].Y < mouse.Y)
                {
                    if (new Rectangle((int)knightRectangles[0, 2].X, (int)knightRectangles[0, 2].Y, 32, 32).Intersects(new Rectangle((int)enemyManager.lstGegnerShot[i].ShotXY.X, (int)enemyManager.lstGegnerShot[i].ShotXY.Y, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y)))
                    {
                        if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotStandard))
                        {
                            lstAbility.Add(new ShotStandard(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }
                        else if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotAnimation))
                        {
                            lstAbility.Add(new ShotAnimation(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, enemyManager.lstGegnerShot[i].animations.Fps, enemyManager.lstGegnerShot[i].animations.Frames, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }

                        enemyManager.lstGegnerShot.RemoveAt(i);
                    }
                    break;
                }
                else if (knightRectangles[2, 2].X <= mouse.X && knightRectangles[2, 2].Y < mouse.Y)
                {
                    if (new Rectangle((int)knightRectangles[2, 2].X, (int)knightRectangles[2, 2].Y, 32, 32).Intersects(new Rectangle((int)enemyManager.lstGegnerShot[i].ShotXY.X, (int)enemyManager.lstGegnerShot[i].ShotXY.Y, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y)))
                    {
                        if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotStandard))
                        {
                            lstAbility.Add(new ShotStandard(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }
                        else if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotAnimation))
                        {
                            lstAbility.Add(new ShotAnimation(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, enemyManager.lstGegnerShot[i].animations.Fps, enemyManager.lstGegnerShot[i].animations.Frames, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }

                        enemyManager.lstGegnerShot.RemoveAt(i);
                    }
                    break;
                }
                else if (knightRectangles[0, 0].X + 32 > mouse.X && knightRectangles[0, 0].Y + 32 > mouse.Y)
                {
                    if (new Rectangle((int)knightRectangles[0, 0].X, (int)knightRectangles[0, 0].Y, 32, 32).Intersects(new Rectangle((int)enemyManager.lstGegnerShot[i].ShotXY.X, (int)enemyManager.lstGegnerShot[i].ShotXY.Y, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y)))
                    {
                        if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotStandard))
                        {
                            lstAbility.Add(new ShotStandard(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }
                        else if (enemyManager.lstGegnerShot[i].GetType() == typeof(ShotAnimation))
                        {
                            lstAbility.Add(new ShotAnimation(-enemyManager.lstGegnerShot[i].DirectionXY + player + new Vector2(16, 24), player + new Vector2(16, 24), enemyManager.lstGegnerShot[i].OldSpeed + 5, enemyManager.lstGegnerShot[i].ShotTexture, enemyManager.lstGegnerShot[i].animations.Fps, enemyManager.lstGegnerShot[i].animations.Frames, (int)enemyManager.lstGegnerShot[i].ShotSize.X, (int)enemyManager.lstGegnerShot[i].ShotSize.Y, new Vector2(16, 5), enemyManager.lstGegnerShot[i].ShotDamage + lvl, ""));
                        }

                        enemyManager.lstGegnerShot.RemoveAt(i);
                    }
                    break;
                }
            }
        }


        public void Ability1Ritter(Vector2 mouse, Vector2 player, Texture2D texture, int lvl)
        {
            int x = 0, y = 0, r = 50;
            for (int w = 0; w < 360; w += 60)
            {
                x = Convert.ToInt32(mouse.X + r * Math.Sin(w * (Math.PI / 180)));
                y = Convert.ToInt32(mouse.Y + r * Math.Cos(w * (Math.PI / 180)));

                lstAbility.Add(new ShotAnimation(new Vector2(x, y), player + new Vector2(16, 24), 5.0f, texture, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));
            }
        }

        public void Ability2Ritter(Vector2 mouse, Vector2 player, Texture2D texture, int lvl)
        {
            int x = 0, y = 0, r = 50;
            for (int w = 0; w < 360; w += 60)
            {
                x = Convert.ToInt32(mouse.X + 16 + r * Math.Sin(w * (Math.PI / 180)));
                y = Convert.ToInt32(mouse.Y + 24 + r * Math.Cos(w * (Math.PI / 180)));

                lstAbility.Add(new ShotAnimation(new Vector2(x, y), player + new Vector2(16, 24), 5.0f, texture, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));
            }
        }

        public void Ability3Ritter(Vector2 mouse, Vector2 player, Texture2D texture, int lvl)
        {
            int x = 0, y = 0, r = 50;
            for (int w = 0; w < 360; w += 60)
            {
                x = Convert.ToInt32(mouse.X + r * Math.Sin(w * (Math.PI / 180)));
                y = Convert.ToInt32(mouse.Y + r * Math.Cos(w * (Math.PI / 180)));

                lstAbility.Add(new ShotAnimation(new Vector2(x, y), player + new Vector2(16, 24), 5.0f, texture, 8, 4, 32, 14, new Vector2(32, 14), lvl, ""));
            }
        }
        #endregion


        public void UpdateCooldown(GameTime gameTime, int currentplayer)//0 = archer, 1 = wizard, 2 = knight
        {
            if (currentplayer == 0)//archer
            {
                if (cooldownAutoAttackArcher < maxCooldownAutoAttackArcher)//AutoAttack cooldown
                {
                    cooldownAutoAttackArcher += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (cooldownAbility1Archer < maxCooldownAbility1Archer)//Ability1 cooldown
                {
                    cooldownAbility1Archer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (cooldownAbility2Archer < maxCooldownAbility2Archer)//Ability2 cooldown
                {
                    cooldownAbility2Archer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (cooldownAbility3Archer < maxCooldownAbility3Archer)//Ability3 cooldown
                {
                    cooldownAbility3Archer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (cooldownSpecialArcher < maxCooldownSpecialArcher)//Special cooldown: Archer: Speed, Wizard: Teleport, Knight: Block
                {
                    cooldownSpecialArcher += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            else if (currentplayer == 1)//wizard
            {
                if (cooldownAutoAttackWizard < maxCooldownAutoAttackWizard)//AutoAttack cooldown
                {
                    cooldownAutoAttackWizard += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (cooldownAbility1Wizard < maxCooldownAbility1Wizard)//Ability1 cooldown
                {
                    cooldownAbility1Wizard += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (cooldownAbility2Wizard < maxCooldownAbility2Wizard)//Ability2 cooldown
                {
                    cooldownAbility2Wizard += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (cooldownAbility3Wizard < maxCooldownAbility3Wizard)//Ability3 cooldown
                {
                    cooldownAbility3Wizard += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (CooldownSpecialWizard < maxCooldownSpecialWizard)//Special cooldown: Archer: Speed, Wizard: Teleport, Knight: Block
                {
                    cooldownSpecialWizard += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            else if (currentplayer == 2)//archer
            {
                if (cooldownAutoAttackKnight < maxCooldownAutoAttackKnight)//AutoAttack cooldown
                {
                    cooldownAutoAttackKnight += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (cooldownAbility1Knight < maxCooldownAbility1Knight)//Ability1 cooldown
                {
                    cooldownAbility1Knight += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (cooldownAbility2Knight < maxCooldownAbility2Knight)//Ability2 cooldown
                {
                    cooldownAbility2Knight += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (cooldownAbility3Knight < maxCooldownAbility3Knight)//Ability3 cooldown
                {
                    cooldownAbility3Knight += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (cooldownSpecialKnight < maxCooldownSpecialKnight)//Special cooldown: Archer: Speed, Wizard: Teleport, Knight: Block
                {
                    cooldownSpecialKnight += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
        }

        public void UpdateAbilities(GameTime gameTime, MouseState mouseState, KeyboardState keyState, Movement movement, Vector2 mouseposition, Player _player, int currentplayer, EnemyManager enemyManager, WeaponManager weapon)//Aktualisiert alle AbilitySchüsse
        {
            if (currentplayer == 0)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)//AutoAttack Archer
                {
                    if (CooldownAutoAttackArcher >= maxCooldownAutoAttackArcher)
                    {
                        AutoAttackArcher(mouseposition, movement.position, arrowbig, _player.LvlArcher);
                        CooldownAutoAttackArcher = 0f;//Cooldown auf 0 setzen damit neu hochgezählt wird
                    }
                }

                if (_player.LvlArcher >= 2)//Ability1 Archer Freigeschaltet ab Level 2
                {
                    if (keyState.IsKeyDown(Keys.LeftShift))
                    {
                        if (CooldownAbility1Archer >= maxCooldownAbility1Archer)
                        {
                            CooldownAbility1Archer = 0f;
                        }
                    }

                    for (float i = 0.0f; i < 0.9f; i += 0.1f)//Archer Ability1 -> einzelne Schüsse
                    {
                        if (CooldownAbility1Archer >= i && CooldownAbility1Archer <= i + 0.01f)
                        {
                            Ability1Archer(mouseposition, movement.position, arrowbig, _player.ArcherAbility1lvl);
                        }
                    }
                }


                if (_player.LvlArcher >= 4)//Ability2 Archer Freigeschaltet ab Level 4
                {
                    if (keyState.IsKeyDown(Keys.Q))
                    {
                        if (CooldownAbility2Archer >= maxCooldownAbility2Archer)
                        {
                            Ability2Archer(mouseposition, movement.position, arrowtoxic, _player.ArcherAbility2lvl);
                            CooldownAbility2Archer = 0f;
                        }
                    }
                }

                if (_player.LvlArcher >= 6)//Ability3 Archer Freigeschaltet ab Level 6
                {
                    if (keyState.IsKeyDown(Keys.E))//Ability3 Archer einzelner Pfeil
                    {
                        if (CooldownAbility3Archer >= maxCooldownAbility3Archer)
                        {
                            Ability3Archer(true, mouseposition, movement.position, arrowbig, arrowpierce, arrowice, _player.ArcherAbility3lvl);//Auswahl = true d.h. einzelner Pfeil ohne Collision
                            CooldownAbility3Archer = 0f;//Cooldown startet
                        }
                    }


                    for (int i = 0; i < lstNoCollision.Count; i++)
                    {
                        lstNoCollision[i].Update(gameTime);

                        if (lstNoCollision[i].ShotXY.X > 1920 - 45 || lstNoCollision[i].ShotXY.Y > 1080 - 45
                            || lstNoCollision[i].ShotXY.X < 0 + 45 || lstNoCollision[i].ShotXY.Y < 0 + 45)//Wenn Rand getroffen wird. +-45 weil sonst die Schüsse wegen der Collision sofort verschwinden
                        {
                            lstNoCollision[i].CurrentTime = 0.9f;//Auf 0.9 setzen damit Ability3 Explosion ausgeführt wird.
                        }
                        else if (keyState.IsKeyDown(Keys.E) && lstNoCollision[i].CurrentTime >= 0.2)//0.2 sec Cooldown bevor man die Explosion auslösen kann.
                        {
                            lstNoCollision[i].CurrentTime = 0.9f;//Auf 0.9 setzen damit Ability3 Explosion ausgeführt wird.
                        }

                        if (lstNoCollision[i].CurrentTime >= 0.9f && lstNoCollision[i].CurrentTime < 0.91f)//Ability3 Explosion
                        {
                            Ability3Archer(false, mouseposition, movement.position, arrowtoxic, arrowpierce, arrowice, _player.ArcherAbility3lvl);
                        }
                    }
                }

                if (mouseState.RightButton == ButtonState.Pressed)//Special Ability
                {
                    if (CooldownSpecialArcher >= maxCooldownSpecialArcher && CooldownSpecialArcher < CooldownSpecialArcher + 0.01f)
                    {
                        movement.speed = 96;
                        CooldownSpecialArcher = 0f;
                    }
                }

                if (CooldownSpecialArcher >= 0.01f)
                {
                    movement.speed = 5;
                }
            }
            else if (currentplayer == 1)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)//AutoAttack
                {
                    if (CooldownAutoAttackWizard >= maxCooldownAutoAttackWizard)
                    {
                        AutoAtackWizard(mouseposition, movement.position, fireball, _player.LvlWizard);
                        CooldownAutoAttackWizard = 0f;
                    }
                }

                if (_player.LvlWizard >= 2)//Ability1 Wizard Freigeschaltet ab Level 2
                {
                    if (keyState.IsKeyDown(Keys.LeftShift))//Ability1
                    {
                        if (CooldownAbility1Wizard >= maxCooldownAbility1Wizard)
                        {
                            Ability1Wizard(mouseposition, movement.position, fireball, _player.WizardAbility1lvl);
                            CooldownAbility1Wizard = 0f;
                        }
                    }
                }

                if (_player.LvlWizard >= 4)//Ability2 Wizard Freigeschaltet ab Level 4
                {
                    if (keyState.IsKeyDown(Keys.Q))//Ability2
                    {
                        if (CooldownAbility2Wizard >= maxCooldownAbility2Wizard)
                        {
                            Ability2Wizard(mouseposition, new Vector2(mouseState.X, mouseState.Y), fireball, fireball2, fireball3, fireball4, _player.WizardAbility2lvl);
                            CooldownAbility2Wizard = 0f;
                        }
                    }
                }

                if (_player.LvlWizard >= 6)//Ability3 Wizard Freigeschaltet ab Level 6
                {
                    if (keyState.IsKeyDown(Keys.E))//Ability3
                    {
                        if (CooldownAbility3Wizard >= maxCooldownAbility3Wizard)
                        {
                            Ability3Wizard(mouseposition, movement.position, fireball, fireball2, fireball4, _player.WizardAbility3lvl);
                            CooldownAbility3Wizard = 0f;
                        }
                    }
                }

                if (mouseState.RightButton == ButtonState.Pressed)//Special Ability
                {
                    if (CooldownSpecialWizard >= maxCooldownSpecialWizard)
                    {
                        movement.speed = 96;
                        CooldownSpecialWizard = 0f;
                    }
                }

                if (CooldownSpecialWizard >= 0.01f)
                {
                    movement.speed = 5;
                }
            }
            else if (currentplayer == 2)
            {
                knightRectangles[0, 0] = new Rectangle((int)movement.position.X - 32, (int)movement.position.Y - 32, 32, 32);
                knightRectangles[1, 0] = new Rectangle((int)movement.position.X, (int)movement.position.Y - 32, 32, 32);
                knightRectangles[2, 0] = new Rectangle((int)movement.position.X + 32, (int)movement.position.Y - 32, 32, 32);

                knightRectangles[0, 1] = new Rectangle((int)movement.position.X - 32, (int)movement.position.Y, 32, 48);
                knightRectangles[2, 1] = new Rectangle((int)movement.position.X + 32, (int)movement.position.Y, 32, 48);

                knightRectangles[0, 2] = new Rectangle((int)movement.position.X - 32, (int)movement.position.Y + 48, 32, 32);
                knightRectangles[1, 2] = new Rectangle((int)movement.position.X, (int)movement.position.Y + 48, 32, 32);
                knightRectangles[2, 2] = new Rectangle((int)movement.position.X + 32, (int)movement.position.Y + 48, 32, 32);


                if (mouseState.LeftButton == ButtonState.Pressed)//AutoAttack
                {
                    if (CooldownAutoAttackKnight >= CooldownAutoAttackKnight)
                    {
                        CooldownAutoAttackKnight = 0f;
                        AutoAtackRitter(gameTime, mouseposition, movement.position, arrow, enemyManager, weapon, _player.LvlKnight);
                        weapon.Burn = true;
                    }
                }

                if (CooldownAutoAttackKnight > 1f)
                {
                    weapon.Burn = false;
                }



                if (_player.LvlKnight >= 2)//Ability1 Knight Freigeschaltet ab Level 2
                {
                    if (keyState.IsKeyDown(Keys.LeftShift))//Ability1
                    {
                        if (CooldownAbility1Knight >= maxCooldownAbility1Knight)
                        {
                            Ability1Ritter(mouseposition, movement.position, fireball, _player.KnightAbility1lvl);
                            CooldownAbility1Knight = 0f;
                        }
                    }
                }

                if (_player.LvlKnight >= 4)//Ability2 Knight Freigeschaltet ab Level 4
                {
                    if (keyState.IsKeyDown(Keys.Q))//Ability2
                    {
                        if (CooldownAbility2Knight >= maxCooldownAbility2Knight)
                        {
                            Ability2Ritter(mouseposition, movement.position, fireball2, _player.KnightAbility2lvl);

                            CooldownAbility2Knight = 0f;
                        }
                    }
                }

                if (_player.LvlKnight >= 6)//Ability3 Knight Freigeschaltet ab Level 6
                {
                    if (keyState.IsKeyDown(Keys.E))//Ability3
                    {
                        if (CooldownAbility3Knight >= maxCooldownAbility2Knight)
                        {
                            Ability2Ritter(mouseposition, movement.position, fireball3, _player.KnightAbility2lvl);

                            CooldownAbility3Knight = 0f;
                        }
                    }
                }

                if (mouseState.RightButton == ButtonState.Pressed)//Special Ability
                {
                    if (CooldownSpecialKnight >= maxCooldownSpecialKnight)
                    {
                        movement.speed = 96;
                        CooldownSpecialKnight = 0f;
                    }
                }

                if (CooldownSpecialKnight >= 0.01f)
                {
                    movement.speed = 5;
                }
            }

        }

        public void DrawAbilities(SpriteBatch spriteBatch, GameTime gameTime)//Zeichnet alle AbilitySchüsse
        {
            for (int i = 0; i < lstAbility.Count; i++)
            {
                lstAbility[i].Draw(spriteBatch, gameTime);//Zeichnet alle Items in lstAutoAttack
            }
        }
    }
}