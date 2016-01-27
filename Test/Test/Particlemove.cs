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
    class Particlemove
    {
        double lifetime;
        float speed;
        public bool isAlive { get; protected set; }
        Random r = new Random();
        Vector2f dir;
        Sprite spr;
        Texture tex;

        public Particlemove(Vector2f start, Vector2f dir, float speed)
        {
            lifetime = r.NextDouble() * 1500f + 500f; //Zufallsdauer
            this.dir = dir * -1;
            this.dir.Y += 10 * (float)r.NextDouble() - 5; //ZUfallswinkel
            this.speed = speed * (float)r.NextDouble();
            tex = new Texture("Staub.bmp"); //Textur wird erstellt
            spr = new Sprite(tex);
            spr.Scale = new Vector2f(3, 3);
            spr.Position = start;
            isAlive = true;
        }

        public void Update(GameTime gTime)
        {
            lifetime -= gTime.Ellapsed.Milliseconds;
            spr.Position += dir * speed * gTime.Ellapsed.Milliseconds / 120; //Pixel wird bewegt
            if (lifetime < 0) 
                isAlive = false;           
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(spr);
        }
    }
}
