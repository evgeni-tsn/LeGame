using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LeGame.Screens.Stats
{
    public struct InventorySlot
    {
        private Vector2 position;
        private bool isOccupied;

        public InventorySlot(int x, int y)
        {
            this.position = new Vector2(x, y);
            isOccupied = false;
        }
        public Vector2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }
        public bool IsOccupied
        {
            get
            {
                return isOccupied;
            }

            set
            {
                isOccupied = value;
            }
        }   
    }
}
