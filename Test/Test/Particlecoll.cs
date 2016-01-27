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
    class Particlecoll
    {
        public bool isAlive { get; private set; }
        Sprite spr;
        Texture tex;
        float speed;
        double lifetime;
        Random r;
        Vector2f dir;
        public Particlecoll(Vector2f start, float speed)
        {
            r = new Random();
            lifetime = r.NextDouble() * 3000 + 1000f;
            this.speed = speed;
            tex = new Texture("Staub.bmp");
            spr = new Sprite(tex);
            isAlive = true;
            dir = new Vector2f((float)r.NextDouble() * 2 - 1, (float)r.NextDouble() * 2 - 1);
        }

        public void Update(GameTime gTime)
        {
            lifetime -= gTime.Ellapsed.Milliseconds;
            if (lifetime < 0)
                isAlive = false;
            spr.Position += dir * gTime.Ellapsed.Milliseconds * speed / 200;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(spr);
        }
    }
}
