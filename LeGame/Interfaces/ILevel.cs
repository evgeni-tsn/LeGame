using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeGame.Interfaces
{
    public interface ILevel
    {
        char[,] Map { get; set; }
    }
}
