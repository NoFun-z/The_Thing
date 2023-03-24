using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loc_FirstGame
{
    public class Basic2D
    {
        public float rot;
        public Vector2 pos, dims;
        public Texture2D myModel;
        public Rectangle[] idleRectangles;
        protected int CurrentFrame;

        public Basic2D(Texture2D MODEL, Vector2 POS, Vector2 DIMS, Rectangle[] IDLERECTANGLES)
        {
            pos = POS;
            dims = DIMS;

            myModel = MODEL;
            idleRectangles = IDLERECTANGLES;
            CurrentFrame = 0;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw(Vector2 OFFSET, Rectangle? sourceRectangle, SpriteEffects spriteEffects)
        {
            if (myModel != null)
            {
                Rectangle destinationRectangle = new Rectangle(
                    Convert.ToInt32(pos.X + OFFSET.X),
                    Convert.ToInt32(pos.Y + OFFSET.Y),
                    Convert.ToInt32(dims.X),
                    Convert.ToInt32(dims.Y));

                Globals.spriteBatch.Draw(myModel, destinationRectangle, sourceRectangle, Color.White, rot,
                    new Vector2(idleRectangles[CurrentFrame].Width / 2, idleRectangles[CurrentFrame].Height / 2), spriteEffects, 0);
            }
        }

        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN, SpriteEffects spriteEffects)
        {
            if (myModel != null)
            {
                Rectangle destinationRectangle = new Rectangle(Convert.ToInt32(pos.X + OFFSET.X), Convert.ToInt32(pos.Y + OFFSET.Y),
                    Convert.ToInt32(dims.X), Convert.ToInt32(dims.Y));

                Globals.spriteBatch.Draw(myModel, destinationRectangle, null, Color.White, rot,
                    new Vector2(ORIGIN.X, ORIGIN.Y), spriteEffects, 0);
            }

        }
    }
}
