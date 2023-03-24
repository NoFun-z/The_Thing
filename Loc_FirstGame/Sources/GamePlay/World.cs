using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loc_FirstGame
{
    public class World
    {
        public Hero hero;
        public Texture2D heroSpriteSheet = Globals.content.Load<Texture2D>("2D/MyMainIndle");
        public Rectangle[] heroIdleRectangles = { new Rectangle(0, 0, 130, 140), new Rectangle(130, 0, 130, 140), new Rectangle(260, 0, 130, 140), new Rectangle(390, 0, 130, 140) };

        public World()
        {
            hero = new Hero(heroSpriteSheet, new Vector2(150, 50), new Vector2(50, 40), heroIdleRectangles);
        }

        public virtual void Update()
        {
            hero.Update();
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(OFFSET, null, SpriteEffects.None);
        }
    }
}
