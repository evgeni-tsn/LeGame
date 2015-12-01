using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeGame.Interfaces
{
    public interface IWeapon
    {
        double Damage { get; set; }
        double Range { get; set; }

        void Attack();
    }
}
