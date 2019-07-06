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
    class Textbox
    {
        private string text;
        private string temp = "";
        private Vector2 position;
        private SpriteFont font;
        private float time = 0f;
        private int i = 0;

        public Textbox(string _text, Vector2 _position, SpriteFont _font)
        {
            text = _text;
            position = _position;
            font = _font;
        }

        public void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time > 0.1f)
            {
                if (i < text.Length)
                {
                    temp += text[i];
                    i++;
                }
                time = 0f;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, temp, position, Color.White);
        }
    }
}
