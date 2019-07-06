using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YellowTale
{
    class SaveLoad
    {
        string[] saveContent = new string[29];
        string[] loadContent = new string[29];

        string[] configContent = new string[5];

        public void save(string mapname, string klasse, float positionX, float positionY, int healthA, int maxhealthA, int xpA, int xpMaxA, int levelA, int healthK, int maxhealthK, int xpK, int xpMaxK, int levelK, int healthW
                        , int maxhealthW, int xpW, int xpMaxW, int levelW, int coins, int archer1lvl, int archer2lvl, int archer3lvl, int wizard1lvl, int wizard2lvl, int wizard3lvl, int knight1lvl, int knight2lvl, int knight3lvl, int saveFile)
        {
            saveContent[0] = mapname;
            saveContent[1] = klasse;
            saveContent[2] = positionX.ToString();
            saveContent[3] = positionY.ToString();

            saveContent[4] = healthA.ToString();
            saveContent[5] = maxhealthA.ToString();
            saveContent[6] = xpA.ToString();
            saveContent[7] = xpMaxA.ToString();
            saveContent[8] = levelA.ToString();

            saveContent[9] = healthK.ToString();
            saveContent[10] = maxhealthK.ToString();
            saveContent[11] = xpK.ToString();
            saveContent[12] = xpMaxK.ToString();
            saveContent[13] = levelK.ToString();

            saveContent[14] = healthW.ToString();
            saveContent[15] = maxhealthW.ToString();
            saveContent[16] = xpW.ToString();
            saveContent[17] = xpMaxW.ToString();
            saveContent[18] = levelW.ToString();

            saveContent[19] = coins.ToString();

            saveContent[20] = archer1lvl.ToString();
            saveContent[21] = archer2lvl.ToString();
            saveContent[22] = archer3lvl.ToString();

            saveContent[23] = wizard1lvl.ToString();
            saveContent[24] = wizard2lvl.ToString();
            saveContent[25] = wizard3lvl.ToString();

            saveContent[26] = knight1lvl.ToString();
            saveContent[27] = knight2lvl.ToString();
            saveContent[28] = knight3lvl.ToString();

            switch (saveFile)
            {
                case 1:
                    File.WriteAllLines(@"Content/savegames/1.sv", saveContent);
                    break;
                case 2:
                    File.WriteAllLines(@"Content/savegames/2.sv", saveContent);
                    break;
                case 3:
                    File.WriteAllLines(@"Content/savegames/3.sv", saveContent);
                    break;

                default:
                    break;
            }         
        }

        public void saveDead(int saveFile, int klasse, int health)
        {
            switch (klasse)
            {
                case 0:
                    loadContent[4] = health.ToString();
                    break;
                case 1:
                    loadContent[9] = health.ToString();
                    break;
                case 2:
                    loadContent[14] = health.ToString();
                    break;

                default:
                    break;
            }

            switch (saveFile)
            {
                case 1:
                    File.WriteAllLines(@"Content/savegames/1.sv", loadContent);
                    break;
                case 2:
                    File.WriteAllLines(@"Content/savegames/2.sv", loadContent);
                    break;
                case 3:
                    File.WriteAllLines(@"Content/savegames/3.sv", loadContent);
                    break;

                default:
                    break;
            }
        }

        public string[] load(ref string mapname, ref string klasse, ref float positionX, ref float positionY, int loadFile)
        {
            switch (loadFile)
            {
                case 1:
                    loadContent = File.ReadAllLines(@"Content/savegames/1.sv");
                    break;
                case 2:
                    loadContent = File.ReadAllLines(@"Content/savegames/2.sv");
                    break;
                case 3:
                    loadContent = File.ReadAllLines(@"Content/savegames/3.sv");
                    break;
                default:
                    break;
            }

            mapname = loadContent[0];
            klasse = loadContent[1];
            positionX = float.Parse(loadContent[2]);
            positionY = float.Parse(loadContent[3]);

            return loadContent;
        }

        public int loadHealth(int klasse, int loadFile)
        {
            switch (loadFile)
            {
                case 1:
                    loadContent = File.ReadAllLines(@"Content/savegames/1.sv");
                    break;
                case 2:
                    loadContent = File.ReadAllLines(@"Content/savegames/2.sv");
                    break;
                case 3:
                    loadContent = File.ReadAllLines(@"Content/savegames/3.sv");
                    break;
                default:
                    break;
            }

            switch (klasse)
            {
                case 0:
                    return Convert.ToInt32(loadContent[5]);
                case 1:
                    return Convert.ToInt32(loadContent[10]);
                case 2:
                    return Convert.ToInt32(loadContent[15]);
                default:
                    return 0;
            }
        }

        public void configSave(string width, string height, string windowMode, float volume, string language)
        {
            configContent[0] = width;
            configContent[1] = height;
            configContent[2] = windowMode;
            configContent[3] = volume.ToString();
            configContent[4] = language;

            File.WriteAllLines(@"Content/configs/config.cfg",configContent);
        }

        public string[] configLoad()
        {
            configContent = File.ReadAllLines(@"Content/configs/config.cfg");
            return configContent;
        }
    }

    class LoadLanguage
    {
        public void loadLanguage(ref string[] languageArr, string lan)
        {
            languageArr = File.ReadAllLines(@"Content/language/" + lan + ".lg");
        }
    }
}
