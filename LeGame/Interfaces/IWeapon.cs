using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LeGame.Models;
using LeGame.Models.Characters.Player;

namespace LeGame.Interfaces
{
    public interface IWeapon
    {
        int Damage { get; set; }
        int Range { get; set; }

        void Attack(Level level, Player player);
    }
}
