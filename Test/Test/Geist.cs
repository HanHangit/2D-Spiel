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
    class Geist : GameObject
    {
        public Geist (String auswahl)
            {
            if (auswahl == "Geist")
                textur = new Texture("geist.png");
            if (auswahl == "Zombie")
                textur = new Texture("Zombie.png");
        sprite = new Sprite(textur);
        sprite.Origin = new Vector2f(textur.Size.X / 2, textur.Size.Y / 2);
    }
        public override void update()
        {

        }
}
}
