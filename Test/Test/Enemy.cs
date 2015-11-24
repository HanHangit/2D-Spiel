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
        Geist[] geist;
        Zombie[] zombie;
        public Enemy()
        {
            int anzahlgeist = 5;
            geist = new Geist[anzahlgeist];
            zombie = new Zombie[9];
            for (int i = 0; i < anzahlgeist; ++i)
            {
                geist[i] = new Geist();
            }
            zombie[0] = new Zombie(new Vector2f(200,200));
            zombie[1] = new Zombie(new Vector2f(900,100));
            zombie[2] = new Zombie(new Vector2f(1100, 100));
            zombie[3] = new Zombie(new Vector2f(1200, 100));
            zombie[4] = new Zombie(new Vector2f(1300, 100));
            zombie[5] = new Zombie(new Vector2f(1500, 100));
            zombie[6] = new Zombie(new Vector2f(1700, 100));
            zombie[7] = new Zombie(new Vector2f(1600, 100));
            zombie[8] = new Zombie(new Vector2f(1800, 100));
        }

        public void Draw(RenderWindow window)
        {
            //Alle Gegner Objekt KLassen werden gezeichnet.
            foreach (Geist t in geist)
                t.Draw(window);
            foreach (Zombie t in zombie)
                t.Draw(window);
        }

        public void Update(GameTime gTime)
        {
            //Alle Gegner Objekt Klassen kriegen update.
            foreach (Geist t in geist)
                t.Update(gTime);
            foreach (Zombie t in zombie)
                t.Update(gTime);
        }
        /*
        public Vector2f move(Vector2f punkt1, Vector2f punkt2, float geschwindigkeit)
        {
            return (direction(punkt1, punkt2) / abstand(direction(punkt1, punkt2))) * geschwindigkeit;
        }

        public Vector2f position()
        {
            return sprite.Position;
        }

        public void setposition(Vector2f pos)
        {
            sprite.Position = pos;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public void verfolgen(Vector2f objekt1, Vector2f objekt2,float geschwindigkeit)
        {
            if (collision(objekt1, objekt2))
                sprite.Position += move(objekt1,objekt2,geschwindigkeit);
        }

        public float abstand(Vector2f dir)
        {
            return System.Convert.ToSingle(Math.Sqrt(Math.Pow(dir.X, 2) + Math.Pow(dir.Y, 2)));
        }

        public float abstandrand(float x, float y)
        {
            
            return abstand(new Vector2f(x,y));
        }

        public bool collision(Vector2f a, Vector2f b)
        {
            if (abstand(direction(a, b)) >= (abstand(direction(a, b)) - abstandrand(sprite.TextureRect.Width, sprite.TextureRect.Height)))
                return true;
            else
                return false;
        }

        public float toleranz(Vector2f a, Vector2f b)
        {
            return 50;
        }

        public Vector2f direction(Vector2f a, Vector2f b)
        {
            return b - a;
        }

        public void draw(RenderWindow window)
        {
            window.Draw(sprite);
        }

        public Vector2f pendeln(Vector2f start, Vector2f ziel, float geschwindigkeit)
        {
            while (true)
            {
                do
                {
                    this.move(start, ziel, geschwindigkeit);
                }while (this.position().X<ziel.X) ;

                do
                {
                    this.move(ziel, start, geschwindigkeit);
                } while (this.position().X > start.X);
            }
        }
        */
    }
}
