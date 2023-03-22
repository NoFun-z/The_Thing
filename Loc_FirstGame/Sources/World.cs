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
        public Basic2D hero;

        public World()
        {
            hero = new Basic2D("2D/Hero", new Vector2(300, 300), new Vector2(40, 40));
        }

        public virtual void Update()
        {
            hero.Update();
        }

        public virtual void Draw()
        {
            hero.Draw();
        }
    }
}
