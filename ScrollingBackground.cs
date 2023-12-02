// add these and any more you may need
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// needed for user input
using Microsoft.Xna.Framework.Content;

namespace NanoscopicKnight
{
    class ScrollingBackground
    {
        //properties
        Texture2D background;
        public Vector2 position;
        public int radius = 2000; 

        public ScrollingBackground()
        {
            position = Vector2.Zero;
            
        }
        public void LoadContent(ContentManager cm)
        {
            // load the image for the sprite
            background = cm.Load<Texture2D>("finalBackground");
        }

        public void Draw(SpriteBatch sb,Vector2 playerPosition)
        {
            Rectangle destinationRectangle = new Rectangle(-radius+ 2*GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - (int)playerPosition.X,-radius + 2*GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - (int)playerPosition.Y, 2*radius, 2*radius);
            
            sb.Begin();
            sb.Draw(background, destinationRectangle, Color.White);
            sb.End();
        }
       
       
    }
}
