namespace LeGame.Screens.StartScreen
{
    using LeGame.Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class StartScreen : Game
    {
        
        private Button startButton;
        Vector2 buttonPosition = new Vector2(GlobalVariables.WindowWidth / 2, GlobalVariables.WindowHeight / 2);

        public void DrawStartScreen(SpriteBatch sb, ContentManager content)
        {
            Texture2D tex = content.Load<Texture2D>(@"TestObjects/start_button");
            this.startButton = new Button(tex, this.buttonPosition);
            sb.Begin();
            sb.Draw(tex,this.startButton.BoundingBox,null, Color.White,0, this.buttonPosition, SpriteEffects.None, 1);
            sb.End();
        }
        public void Clickity()
        {

        }
        

    }
}
