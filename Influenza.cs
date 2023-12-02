using System;
// add these and any more you may need
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// needed for user input
using Microsoft.Xna.Framework.Content;

namespace NanoscopicKnight

{
    class Influenza
    {
        static Texture2D influenza;
        public Vector2 position;
        Vector2 velocity;
        public Boolean hit = false;
        public Rectangle destinationRectangle;
        public Vector2 newPosition; 
        





        public Influenza(int radius,int angle)
        { 
      
            position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + radius * (float)Math.Cos(Math.PI / 180 * angle), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height + radius * (float)Math.Sin(Math.PI / 180 * angle));
            

        }
        public static void LoadContent(ContentManager cm)
        {
            // load the image for the sprite
            influenza = cm.Load<Texture2D>("influenza");
        }
        public void Draw(SpriteBatch sb, Vector2 playerPosition)
        {
            destinationRectangle = new Rectangle((int)position.X-(int)playerPosition.X-35, (int)position.Y-(int)playerPosition.Y-25, 70, 50);
            sb.Begin();
            sb.Draw(influenza, destinationRectangle, Color.White);
            sb.End();
        }
       
        public void Move(Vector2 playerPosition)
        
         {
            
            Vector2  v1 = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);
            velocity = playerPosition - position +v1;
            newPosition = position;



            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            Random random = new Random((int)position.X);
            Vector2 velocity2 = new Vector2(velocity.Y, -velocity.X);

           
            velocity2 = Vector2.Multiply(velocity2, (float)random.NextDouble()*5);


            
                newPosition += velocity += velocity2;
            
            if (Vector2.Distance(newPosition, 2*v1) < 1280)
            {
                position = newPosition;
               
            }
     

        }
        public void Move2(Vector2 playerPosition)

        {
            Vector2 v1 = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);
            Vector2 velocity = playerPosition - position + v1;
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            
                position += 2*velocity;
            
        }
    }
}
