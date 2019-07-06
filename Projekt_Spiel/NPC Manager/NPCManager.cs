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
    class NPCManager
    {
        public Texture2D tutorialNPC;
        public Texture2D shopNPC;
        public SpriteFont font;

        public List<Tutorial> lstNPCTutorial = new List<Tutorial>();
        public List<Shop> lstNPCShop = new List<Shop>();


        public void SpawnShopNPC(Vector2 position, HUD hud, Player player)
        {
            lstNPCShop.Add(new Shop(shopNPC, position, font, hud, player));
        }

        public void SpawnTutorialNPC(Vector2 position)
        {
            lstNPCTutorial.Add(new Tutorial(tutorialNPC, position, font));
        }

        public void Update(GameTime gameTime, int playerClass, Player player, int language)
        {
            for (int i = 0; i < lstNPCShop.Count; i++)
            {
                lstNPCShop[i].Update(gameTime, playerClass, player);
            }

            for (int i = 0; i < lstNPCTutorial.Count; i++)
            {
                lstNPCTutorial[i].Update(gameTime, language);
            }
        }

        public void clickCheck(ref Player player, Point mousePosition, Game1 game)
        {
            for (int i = 0; i < lstNPCShop.Count; i++)
            {
                lstNPCShop[i].clickCheck(mousePosition, ref player, game);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Point mousePosition, SpriteFont spriteFont)
        {
            for (int i = 0; i < lstNPCShop.Count; i++)
            {
                lstNPCShop[i].Draw(spriteBatch, gameTime, mousePosition, font);
            }

            for (int i = 0; i < lstNPCTutorial.Count; i++)
            {
                lstNPCTutorial[i].Draw(spriteBatch, gameTime);
            }
        }

        public void NPCDelete()
        {
            lstNPCShop.RemoveRange(0, lstNPCShop.Count);
            lstNPCTutorial.RemoveRange(0, lstNPCTutorial.Count);
        }
    }
}
