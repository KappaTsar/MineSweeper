using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Settings
    {
        public int height;
        public int width;
        public int mines;
        public int clicks;
        public int R_clicks;
        public bool result;

        public Thread GameTimer;
    }

}
