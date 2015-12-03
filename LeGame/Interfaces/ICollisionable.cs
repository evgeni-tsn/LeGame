using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeGame.Interfaces
{
    interface ICollisionable
    {
        bool CanCollide { get; set; }
    }
}
