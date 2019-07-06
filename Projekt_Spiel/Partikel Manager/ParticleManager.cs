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
    class ParticleManager
    {
        public List<HitParticle> lstHitParticle = new List<HitParticle>();
        public List<StandardParticle> lstStandardParticle = new List<StandardParticle>();

        private Random random = new Random();
        private Texture2D standardParticle;
        private SpriteFont font;

        public Texture2D StandardParticle
        {
            get { return standardParticle; }
            set { standardParticle = value; }
        }

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }

        public void SpawnHitParticle(Vector2 position, int dmg, Color color)//Popup dmg
        {
            lstHitParticle.Add(new HitParticle(font, position, dmg, color));
            lstHitParticle[lstHitParticle.Count - 1].Zufall = random.Next(0, 3);
        }

        public void SpawnStandardParticle(Vector2 position)
        {
            lstStandardParticle.Add(new StandardParticle(standardParticle, position));
        }

        public void Update(GameTime gameTime)
        {
            #region Particle
            for (int i = 0; i < lstHitParticle.Count; i++)
            {
                lstHitParticle[i].Update(gameTime);

                if (lstHitParticle[i].Cooldown > 0.25f && lstHitParticle[i].Cooldown < 0.26f)
                {
                    lstHitParticle[i].Zufall = random.Next(0, 3);
                }

                if (lstHitParticle[i].Cooldown > 0.5f)
                {
                    lstHitParticle.RemoveAt(i);
                }
                else
                {
                    if (lstHitParticle[i].Zufall == 0)
                    {
                        lstHitParticle[i].Position -= new Vector2(1, 1);
                        lstHitParticle[i].Rotation += 0.015f;
                    }
                    else if(lstHitParticle[i].Zufall == 1)
                    {
                        lstHitParticle[i].Position -= new Vector2(-1, 1);
                    }
                    else
                    {
                        lstHitParticle[i].Position -= new Vector2(0, 1);
                        lstHitParticle[i].Rotation -= 0.015f;
                    }
                }
            }

            for (int i = 0; i < lstStandardParticle.Count; i++)
            {
                lstStandardParticle[i].Update(gameTime);

                if (lstStandardParticle[i].Cooldown > 0.2f)
                {
                    lstStandardParticle.RemoveAt(i);
                }
            }
            #endregion
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < lstHitParticle.Count; i++)
            {
                lstHitParticle[i].Draw(spriteBatch, gameTime);
            }

            for (int i = 0; i < lstStandardParticle.Count; i++)
            {
                lstStandardParticle[i].Draw(spriteBatch, gameTime);
            }
        }
    }
}
