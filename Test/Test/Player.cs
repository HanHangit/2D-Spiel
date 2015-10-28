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
    class Player
    {
        Texture textur;
        Sprite sprite;

        public Player()
        {
            textur = new Texture("Cookie2.png");
            sprite = new Sprite(textur);

        }

        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
    }
}
