// add these and any more you may need
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// needed for user input
using Microsoft.Xna.Framework.Content;

namespace NanoscopicKnight
{
    //idea from http://www.xnadevelopment.com/tutorials/notsohealthy/NotSoHealthy.shtml
    class HealthBar

    {
        Texture2D healthBar;
        
        
        public void LoadContent(ContentManager cm)
        {
            // load the image for the sprite

            healthBar = cm.Load<Texture2D>("healthBar");
            
            


        }
        public void Draw(SpriteBatch sb, int health)
        {
            sb.Begin(); 
            
            sb.Draw(healthBar, new Rectangle(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - healthBar.Width / 2, 30, healthBar.Width, 44), new Rectangle(0, 45, healthBar.Width, 44), Color.Gray);
            sb.Draw(healthBar, new Rectangle(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - healthBar.Width / 2, 30, (int)(healthBar.Width * ((double)health / 100)), 44), new Rectangle(0, 45, healthBar.Width, 44), Color.Lime );
            sb.Draw(healthBar, new Rectangle(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - healthBar.Width / 2, 30, healthBar.Width, 44), new Rectangle(0, 0, healthBar.Width, 44), Color.White);
            sb.End(); 
        }

        }
}
