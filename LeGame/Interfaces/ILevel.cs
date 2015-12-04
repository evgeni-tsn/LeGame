using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LeGame.Models.Characters;
using LeGame.Models.LevelAssets;

namespace LeGame.Interfaces
{
    public interface ILevel
    {
        Character Character { get; set; }
        List<Asset> Assets { get; set; }
        List<Tile> Tiles { get; set; }
    }
}
