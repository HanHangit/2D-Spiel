using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;

namespace Test
{
    class Enemy
    {
        Texture geisttext;
        Sprite geist;
        public Enemy()
        {
            geisttext = new Texture("Geist.png");
            geist = new Sprite(geisttext);
        }

        public void move()
        {
            
        }

        public void draw(RenderWindow window)
        {
            window.Draw(geist);
        }
    }
}
