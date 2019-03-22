using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Hurdles
{
    class ScreenHurdles
    {

        public Rectangle rec;
        public int x, y, width, height;

        public ScreenHurdles(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            rec = new Rectangle(_x, _y, _width, _height);

        }

        public void Move(int speed)
        {
            x -= speed;
        }

        public bool death(Runner r)
        {
            Rectangle rec1 = new Rectangle(r.x, r.y, r.width, r.height);
            Rectangle rec2 = new Rectangle(x, y, width, height);
            if (rec1.IntersectsWith(rec2))
            {
                return true;
            }
            return false;
        }
        
    }
}
