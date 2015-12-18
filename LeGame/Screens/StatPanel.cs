using System.Collections.Generic;
using LeGame.Screens.Stats;

namespace LeGame.Screens
{
    using LeGame.Core;
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class StatPanel
    {
        private List<IStat> stats;
        private HealthStat healthStat;
        private KillsStat killsStat;
        private InventoryStat inventoryStat;
        private SpriteFont font;

       

        public StatPanel()
        {
            this.stats = new List<IStat>();
            this.healthStat = new HealthStat();
            this.killsStat = new KillsStat();
            this.inventoryStat = new InventoryStat();
            this.Stats.Add(inventoryStat);
            this.Stats.Add(killsStat);
            this.Stats.Add(healthStat);
        }

        public ICollection<IStat> Stats
        {
            get
            {
                return stats;
            }

          
        }
        public void Load(ContentManager content)
        {
            this.font = content.Load<SpriteFont>(@"Fonts/SpriteFont");
            foreach (IStat stat in Stats)
            {
                stat.Load(content);
                stat.Font = font;
            }
        }
        public void Draw(ICharacter character, SpriteBatch spriteBatch)
        {
            foreach (IStat stat in Stats)
            {
                stat.Draw(character, spriteBatch);
            }
        }

        

        
    }
}

