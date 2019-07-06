using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace YellowTale
{
    class Button
    {
        private Rectangle ButtonRectangle;
        public Rectangle TrackRectangle;
        public bool enabled;

        public Button(Rectangle rectangle)
        {
            ButtonRectangle = rectangle;
            enabled = false;
            TrackRectangle.Location = new Point(0, 0);
        }

        public Rectangle buttonRectangle { get { return ButtonRectangle; } }

        public bool ButtonClick(Point mousePosition)
        {
            if ((mousePosition.X >= ButtonRectangle.X && mousePosition.X <= (ButtonRectangle.X + ButtonRectangle.Width) && mousePosition.Y >= ButtonRectangle.Y && mousePosition.Y <= (ButtonRectangle.Y + ButtonRectangle.Height)) && (enabled == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ButtonHover(Point mousePosition)
        {
            if ((mousePosition.X >= ButtonRectangle.X && mousePosition.X <= (ButtonRectangle.X + ButtonRectangle.Width) && mousePosition.Y >= ButtonRectangle.Y && mousePosition.Y <= (ButtonRectangle.Y + ButtonRectangle.Height)) && (enabled == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TrackButton(Point mousePosition)
        {
            if ((mousePosition.X >= ButtonRectangle.X && mousePosition.X <= (ButtonRectangle.X + ButtonRectangle.Width) && mousePosition.Y >= ButtonRectangle.Y && mousePosition.Y <= (ButtonRectangle.Y + ButtonRectangle.Height)) && (enabled == true))
            {
                TrackRectangle.Width = (mousePosition.X - buttonRectangle.X);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

