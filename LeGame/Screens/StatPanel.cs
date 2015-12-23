namespace LeGame.Screens
{
    using System.Collections.Generic;
    using LeGame.Interfaces;
    using LeGame.Screens.Stats;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class StatPanel
    {
        private readonly HealthStat healthStat;
        private readonly InventoryStat inventoryStat;
        private readonly KillsStat killsStat;
        private readonly List<IStat> stats;

        private SpriteFont font;

        public StatPanel()
        {
            this.stats = new List<IStat>();
            this.healthStat = new HealthStat();
            this.killsStat = new KillsStat();
            this.inventoryStat = new InventoryStat();
            this.Stats.Add(this.inventoryStat);
            this.Stats.Add(this.killsStat);
            this.Stats.Add(this.healthStat);
        }

        public ICollection<IStat> Stats => this.stats;

        public void Draw(ICharacter character, SpriteBatch spriteBatch)
        {
            foreach (IStat stat in this.Stats)
            {
                stat.Draw(character, spriteBatch);
            }
        }

        public void Load(ContentManager content)
        {
            this.font = content.Load<SpriteFont>(@"Fonts/SpriteFont");
            foreach (IStat stat in this.Stats)
            {
                stat.Load(content);
                stat.Font = this.font;
            }
        }
    }
}