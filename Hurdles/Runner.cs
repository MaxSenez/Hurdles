using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurdles
{
    class Runner
    {
        public int x, y, width, height;
        
        public Runner(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }

        public void Jump(int jumpHeight)
        {
            y -= 2 * jumpHeight;
        }
    }
}
