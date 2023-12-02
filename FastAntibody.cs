using System;
// add these and any more you may need
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// needed for user input
using Microsoft.Xna.Framework.Content;

namespace NanoscopicKnight
{
    class FastAntibody
    {
        //properties
        public Vector2 position;
        public int fastAntibodyAmmo;  
       
        //Make Static
        static Texture2D fastAntibody;
        

        //constructor
        public FastAntibody(ScrollingBackground b1)
        {
            Random random = new Random(); 
           // position = new Vector2(random.Next(b1.leftXBound,b1.rightXBound),random.Next(b1.lowerYBound,b1.upperYBound));  // initialize it to (0,0)
        }
        public static void LoadContent(ContentManager cm)
        {
            // load the image for the sprite
            fastAntibody = cm.Load<Texture2D>("basicAntibody");
        }
        public void Draw(SpriteBatch sb, Vector2 playerPosition)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X-(int)playerPosition.X, (int)position.Y-(int)playerPosition.Y, 50, 50);
            sb.Begin();
            sb.Draw(fastAntibody, destinationRectangle, Color.White);
            sb.End();
        }

    }
}
