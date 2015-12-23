namespace LeGame.Screens.Stats
{
    using Microsoft.Xna.Framework;

    public struct InventorySlot
    {
        public InventorySlot(int x, int y)
        {
            this.Position = new Vector2(x, y);
            this.IsOccupied = false;
        }

        public Vector2 Position { get; set; }

        public bool IsOccupied { get; set; }
    }
}
