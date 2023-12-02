// add these and any more you may need
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// needed for user input
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace NanoscopicKnight
{
    class Player
    {
        //properties
        Texture2D player;
        public Vector2 position; 
        public int playerXRadius = 50;
        public int playerYRadius = 40; 


        
       

        //constructor
        public Player()
        {
           /// position = Vector2.Zero;
           position = new Vector2 (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);  

        }
        //abilities
        public void LoadContent(ContentManager cm)
        {
            // load the image for the sprite
            player = cm.Load<Texture2D>("whitecell");
           

        

        }

        public void Draw(SpriteBatch sb,Vector2 backgroundPosition)
        {
            Rectangle destinationRectangle = new Rectangle(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width /2 -playerXRadius , GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height /2-playerYRadius, 2*playerXRadius, 2*playerYRadius);
            //Rectangle destinationRectangle = new Rectangle((int)position.X - playerXRadius, (int)position.Y - playerYRadius, 2 * playerXRadius, 2 * playerYRadius);

            sb.Begin();
            sb.Draw(player, destinationRectangle, Color.White);
            sb.End(); 
        }
        public void Move()
        {
            KeyboardState keys = Keyboard.GetState();// grab the current state of the keyboard
            Vector2 v1 = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);
            Vector2 newPosition = position;

            if (keys.IsKeyDown(Keys.D)) //right
            {
                newPosition = newPosition + new Vector2(3, 0);
            }
            if (keys.IsKeyDown(Keys.A)) //left
            {
                newPosition = newPosition + new Vector2(-3, 0);
            }
            if (keys.IsKeyDown(Keys.W)) //up
            {
                newPosition = newPosition + new Vector2(0, -3);
            }
            if (keys.IsKeyDown(Keys.S)) //down
            {
                newPosition = newPosition + new Vector2(0, 3);
            }
            if (Vector2.Distance(newPosition, v1) < 1280)
            {
                position = newPosition;
            }
            
        }
        
    }
}
