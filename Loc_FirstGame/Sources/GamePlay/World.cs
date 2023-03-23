using Microsoft.Xna.Framework;
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

        public World()
        {
            hero = new Hero("2D/MainChar", new Vector2(100, 200), new Vector2(220, 180));
        }

        public virtual void Update()
        {
            hero.Update();
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(OFFSET);
        }
    }
}
