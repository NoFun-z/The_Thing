using Loc_FirstGame.Sources.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loc_FirstGame
{
    public class Basic2D
    {
        public Vector2 pos, dims;
        public Texture2D myModel;

        public Basic2D(string PATH, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;

            myModel = Globals.content.Load<Texture2D>(PATH);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            if(myModel != null)
            {
                Rectangle destinationRectangle = new Rectangle(Convert.ToInt32(pos.X), Convert.ToInt32(pos.Y),
                    Convert.ToInt32(dims.X), Convert.ToInt32(dims.Y));

                Globals.spriteBatch.Draw(myModel, destinationRectangle, null, Color.White, 0.0f,
                    new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), SpriteEffects.None, 0);
            }

        }
    }
}
