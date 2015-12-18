using System;
using System.Collections.Generic;
using LeGame.Handlers;
using LeGame.Interfaces;
using LeGame.Models.Characters.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Screens.Stats
{
    public class InventoryStat :IStat
    {
        private Texture2D invTexture;
        private Texture2D testItem;
        private InventorySlot[] slots;
        //[653, 105] [693, 105] [731, 105]
        //[653, 141] [693, 141] [731, 141]
       


        public InventoryStat()
        {
            this.slots = new InventorySlot[6]
            {
                new InventorySlot(653, 105),
                new InventorySlot(693, 105),
                new InventorySlot(731, 105),
                new InventorySlot(653, 141),
                new InventorySlot(693, 141),
                new InventorySlot(731, 141)
            };

        }
        public SpriteFont Font { get; set; }
        public void Load(ContentManager content)
        {
            invTexture = content.Load<Texture2D>(@"TestObjects/inventory3");
            testItem = content.Load<Texture2D>(@"Items/RedPotion");
        }

        public void Draw(ICharacter character, SpriteBatch spriteBatch)
        {
           spriteBatch.Begin();
           spriteBatch.DrawString(Font, "Inventory", new Vector2(670, 80),Color.DarkRed );
           spriteBatch.Draw(invTexture, new Vector2(650, 100), Color.White);
           PopulateInventory(character, spriteBatch);
           spriteBatch.End();
        }

        public void PopulateInventory(ICharacter character, SpriteBatch spriteBatch)
        {
            IPickable[] inv = (character as Player).Inventory;
            for (int i = 0; i < inv.Length; i++)
            {
                
                if (inv[i] != null)
                {
                    Texture2D uhm = GfxHandler.GetTexture(inv[i] as IGameObject);
                    spriteBatch.Draw(uhm, new Vector2(slots[i].Position.X, slots[i].Position.Y), Color.White);
                }
            }
            
        }
    }
}
