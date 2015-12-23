namespace LeGame.Screens.Stats
{
    using LeGame.Handlers;
    using LeGame.Interfaces;
    using LeGame.Models.Characters.Player;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class InventoryStat : IStat
    {
        private readonly InventorySlot[] slots;
        private Texture2D invTexture;
        
        /*[653, 105] [693, 105] [731, 105]
        [653, 141] [693, 141] [731, 141]*/
       
        public InventoryStat()
        {
            this.slots = new[]
            {
                new InventorySlot(653, 105),
                new InventorySlot(693, 105),
                new InventorySlot(731, 105),
                new InventorySlot(653, 141),
                new InventorySlot(693, 141),
                new InventorySlot(731, 141)
            };
        }

        public Texture2D TestItem { get; private set; }

        public SpriteFont Font { get; set; }

        public void Load(ContentManager content)
        {
            this.invTexture = content.Load<Texture2D>(@"TestObjects/inventory3");
            this.TestItem = content.Load<Texture2D>(@"Items/RedPotion");
        }

        public void Draw(ICharacter character, SpriteBatch spriteBatch)
        {
           spriteBatch.Begin();
            spriteBatch.DrawString(this.Font, "Inventory", new Vector2(670, 80), Color.DarkRed);
           spriteBatch.Draw(this.invTexture, new Vector2(650, 100), Color.White);
            this.PopulateInventory(character, spriteBatch);
           spriteBatch.End();
        }

        public void PopulateInventory(ICharacter character, SpriteBatch spriteBatch)
        {
            var inv = ((Player)character).Inventory;
            for (int i = 0; i < inv.Length; i++)
            {
                if (inv[i] != null)
                {
                    var uhm = GfxHandler.GetTexture(inv[i] as IGameObject);
                    spriteBatch.Draw(uhm, new Vector2(this.slots[i].Position.X, this.slots[i].Position.Y), Color.White);
                }
            }
        }
    }
}
