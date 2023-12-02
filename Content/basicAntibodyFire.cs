// add these and any more you may need
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// needed for user input
using Microsoft.Xna.Framework.Content;


namespace NanoscopicKnight
{
    class basicAntibodyFire
    {
        static Texture2D antibodyFire;
        public Vector2 position;
        Vector2 velocity;
        public Rectangle destinationRectangle;

        public basicAntibodyFire(Vector2 crosshairPosition, Vector2 playerPosition,int playerXRadius,int playerYRadius)
        {
            Vector2 v1 = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2-15, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2-35);
           
            velocity = crosshairPosition - v1;
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            position = new Vector2(playerPosition.X-playerXRadius/2,playerPosition.Y-playerYRadius/2);
            
            
        }

        public static void LoadContent(ContentManager cm)
        {
            antibodyFire = cm.Load<Texture2D>("basicAntibodyFire");
        }
        public void Draw(SpriteBatch sb, Vector2 playerPosition)
        {
            destinationRectangle = new Rectangle((int)position.X - (int)playerPosition.X+ GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, (int)position.Y-(int)playerPosition.Y+ GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2, 50, 50);
            sb.Begin();
            sb.Draw(antibodyFire, destinationRectangle, Color.White);
            sb.End();
        }
        public void Move()
        {

            position += 4*velocity;
           
        }
        
    }
}
