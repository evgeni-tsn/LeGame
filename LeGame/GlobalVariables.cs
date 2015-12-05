using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeGame
{
    public static class GlobalVariables
    {
        public const int wINDOW_WIDTH = 640;
        public const int wINDOW_HEIGHT = 480;

        public static readonly string CONTENT_DIR = @"..\..\..\Content\";

        public static int WINDOW_WIDTH
        {
            get { return wINDOW_WIDTH; }
        }
        public static int WINDOW_HEIGHT
        {
            get { return wINDOW_HEIGHT; }
        }




    }
}
