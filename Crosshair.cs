// add these and any more you may need
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// needed for user input
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace NanoscopicKnight
{
    class Crosshair
    {
        //properties
        Texture2D crosshair;
        public Vector2 position; 
        MouseState mouseState; 

        public Crosshair()
        {
            position = Vector2.Zero;
            
        }
        //abilities
        public void LoadContent(ContentManager cm)
        {
            // load the image for the sprite
           
            crosshair = cm.Load<Texture2D>("crosshair");

        }
        public void Draw(SpriteBatch sb)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X -35, (int)position.Y -30, 70, 60);
            sb.Begin();
            sb.Draw(crosshair, destinationRectangle, Color.White);
            sb.End();
        }
        public void Update()
        {
            mouseState = Mouse.GetState();
            position.X = mouseState.X;
            position.Y = mouseState.Y; 
        }

    }
}
