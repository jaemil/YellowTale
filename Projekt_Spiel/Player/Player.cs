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
    class Player
    {
        private int hpArcher = 100;//Aktuelles Leben Archer
        private int hpWizard = 100;//Aktuelles Leben Archer
        private int hpKnight = 150;//Aktuelles Leben Archer

        private int hpArcherMax = 100;//Leben Maximal Archer
        private int hpWizardMax = 150;//Leben Maximal Wizard
        private int hpKnightMax = 200;//Leben Maximal Knight

        private int xpArcher = 0;//Aktuelle Erfahrung Archer
        private int xpWizard = 0;//Aktuelle Erfahrung Wizard
        private int xpKnight = 0;//Aktuelle Erfahrung Knight

        private int xpArcherMax = 100;//Erfahrung Maximal Archer
        private int xpWizardMax = 100;//Erfahrung Maximal Wizard
        private int xpKnightMax = 100;//Erfahrung Maximal Knight

        private int lvlArcher = 0;//Aktuelles Level Archer
        private int lvlWizard = 0;//Aktuelles Level Wizard
        private int lvlKnight = 0;//Aktuelles Level Knight

        private int archerAbility1lvl;//Aktuelles Level der Archer Ability1
        private int archerAbility2lvl;//Aktuelles Level der Archer Ability2
        private int archerAbility3lvl;//Aktuelles Level der Archer Ability3

        private int wizardAbility1lvl;//Aktuelles Level der wizard Ability1
        private int wizardAbility2lvl;//Aktuelles Level der wizard Ability2
        private int wizardAbility3lvl;//Aktuelles Level der wizard Ability3

        private int knightAbility1lvl;//Aktuelles Level der knight Ability1
        private int knightAbility2lvl;//Aktuelles Level der knight Ability2
        private int knightAbility3lvl;//Aktuelles Level der knight Ability3


        private int coin = 0;//Währung

        #region Eigenschaften
        public int HpArcher
        {
            get { return hpArcher; }
            set { hpArcher = value; }
        }
        public int HpWizard
        {
            get { return hpWizard; }
            set { hpWizard = value; }
        }
        public int HpKnight
        {
            get { return hpKnight; }
            set { hpKnight = value; }
        }
        //
        public int HpArcherMax
        {
            get { return hpArcherMax; }
            set { hpArcherMax = value; }
        }
        public int HpWizardMax
        {
            get { return hpWizardMax; }
            set { hpWizardMax = value; }
        }
        public int HpKnightMax
        {
            get { return hpKnightMax; }
            set { hpKnightMax = value; }
        }
        //
        public int XpArcher
        {
            get { return xpArcher; }
            set { xpArcher = value; }
        }
        public int XpWizard
        {
            get { return xpWizard; }
            set { xpWizard = value; }
        }
        public int XpKnight
        {
            get { return xpKnight; }
            set { xpKnight = value; }
        }
        //
        public int XpArcherMax
        {
            get { return xpArcherMax; }
            set { xpArcherMax = value; }
        }
        public int XpWizardMax
        {
            get { return xpWizardMax; }
            set { xpWizardMax = value; }
        }
        public int XpKnightMax
        {
            get { return xpKnightMax; }
            set { xpKnightMax = value; }
        }
        //
        public int LvlArcher
        {
            get { return lvlArcher; }
            set { lvlArcher = value; }
        }
        public int LvlWizard
        {
            get { return lvlWizard; }
            set { lvlWizard = value; }
        }
        public int LvlKnight
        {
            get { return lvlKnight; }
            set { lvlKnight = value; }
        }
        public int ArcherAbility1lvl
        {
            get { return archerAbility1lvl; }
            set { archerAbility1lvl = value; }
        }
        public int ArcherAbility2lvl
        {
            get { return archerAbility2lvl; }
            set { archerAbility2lvl = value; }
        }
        public int ArcherAbility3lvl
        {
            get { return archerAbility3lvl; }
            set { archerAbility3lvl = value; }
        }
        public int WizardAbility1lvl
        {
            get { return wizardAbility1lvl; }
            set { wizardAbility1lvl = value; }
        }
        public int WizardAbility2lvl
        {
            get { return wizardAbility2lvl; }
            set { wizardAbility2lvl = value; }
        }
        public int WizardAbility3lvl
        {
            get { return wizardAbility3lvl; }
            set { wizardAbility3lvl = value; }
        }
        public int KnightAbility1lvl
        {
            get { return knightAbility1lvl; }
            set { knightAbility1lvl = value; }
        }
        public int KnightAbility2lvl
        {
            get { return knightAbility2lvl; }
            set { knightAbility2lvl = value; }
        }
        public int KnightAbility3lvl
        {
            get { return knightAbility3lvl; }
            set { knightAbility3lvl = value; }
        }
        //
        public int Coin
        {
            get { return coin; }
            set { coin = value; }
        }


        #endregion


        public void LebenAbziehen(int dmg, int currentSpieler, ParticleManager particleManager, Vector2 position, Game1 game)
        {
            if (currentSpieler == 0)//Archer
            {
                hpArcher -= dmg;

                if (hpArcher <= 0)
                {
                    game.changeState(4);
                }
            }
            else if (currentSpieler == 1)//Wizard
            {
                hpWizard -= dmg;

                if (hpWizard <= 0)
                {
                    game.changeState(6);
                }
            }
            else if (currentSpieler == 2)//Knight
            {
                hpKnight -= dmg;

                if (hpKnight <= 0)
                {
                    game.changeState(5);
                }
            }

            particleManager.SpawnHitParticle(position, -dmg, new Color(255, 0, 64));
        }

        public void LebenHinzufügen(int wert, int currentSpieler)
        {
            if (currentSpieler == 0)//Archer
            {
                if (hpArcher + wert > hpArcherMax)//Prüfen ob der hpArcher+Wert größer als der MaximalWert ist 
                {
                    hpArcher = hpArcherMax;//hpArcher darf nicht größer als hpArcherMax Wert sein, somit hpArcher gleich hpArcherMax setzen
                }
                else if (HpArcher < hpArcherMax)//Wenn hpArcher kleiner als hpArcherMax ist
                {
                    hpArcher += wert;//Wert zu hpArcher addieren
                }
            }
            else if (currentSpieler == 1)//Wizard
            {
                if (hpWizard + wert > hpWizardMax)
                {
                    hpWizard = hpWizardMax;
                }
                else if (hpWizard < hpWizardMax)
                {
                    hpWizard += wert;
                }
            }
            else if (currentSpieler == 2)//Knight
            {
                if (hpKnight + wert > hpKnightMax)
                {
                    hpKnight = hpKnightMax;
                }
                else if (hpKnight < hpKnightMax)
                {
                    hpKnight += wert;
                }
            }
        }

        public void XpHinzufügen(int exp, int currentSpieler)
        {
            if (currentSpieler == 0)//Archer
            {
                xpArcher += exp;//XP hinzufügen

                if (xpArcher >= xpArcherMax)
                {
                    lvlArcher++;//Level hinzufügen
                    xpArcher -= xpArcherMax;//XP zurücksetzen
                    xpArcherMax += 20;//Für jedes Level wird 20 xp zu xpMax hinzugefügt
                }
            }
            else if (currentSpieler == 1)//Wizard
            {
                xpWizard += exp;

                if (xpWizard >= xpWizardMax)
                {
                    lvlWizard++;
                    xpWizard -= xpWizardMax;
                    xpWizardMax += 20;
                }
            }
            else if (currentSpieler == 2)//Knight
            {
                xpKnight += exp;

                if (xpKnight >= xpKnightMax)
                {
                    lvlKnight++;
                    xpKnight -= xpKnightMax;
                    xpKnightMax += 20;
                }
            }
        }

        public void loadPlayer(string[] content)
        {
            hpArcher = int.Parse(content[4]);
            hpArcherMax = int.Parse(content[5]);
            xpArcher = int.Parse(content[6]);
            xpArcherMax = int.Parse(content[7]);
            lvlArcher = int.Parse(content[8]);

            hpKnight = int.Parse(content[9]);
            hpKnightMax = int.Parse(content[10]);
            xpKnight = int.Parse(content[11]);
            xpKnightMax = int.Parse(content[12]);
            lvlKnight = int.Parse(content[13]);

            hpWizard = int.Parse(content[14]);
            hpWizardMax = int.Parse(content[15]);
            xpWizard = int.Parse(content[16]);
            xpWizardMax = int.Parse(content[17]);
            lvlWizard = int.Parse(content[18]);

            coin = int.Parse(content[19]);

            archerAbility1lvl = int.Parse(content[20]);
            archerAbility2lvl = int.Parse(content[21]);
            archerAbility3lvl = int.Parse(content[22]);

            wizardAbility1lvl = int.Parse(content[23]);
            wizardAbility2lvl = int.Parse(content[24]);
            wizardAbility3lvl = int.Parse(content[25]);

            knightAbility1lvl = int.Parse(content[26]);
            knightAbility2lvl = int.Parse(content[27]);
            knightAbility3lvl = int.Parse(content[28]);
        }
    }
}
