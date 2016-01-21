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
    class Enemy01
    {
        //TODO: Liste für weitere Monster
        List<Geist> geister; //Liste!!!!!!
        List<Zombie> zombies;
        public Enemy01()
        {
            geister = new List<Geist>();
            geister.Add(new Geist());
            geister.Add(new Geist(new Vector2f(300, 1200), new Vector2f(300, 1400)));
            zombies = new List<Zombie>();
            //zombies.Add(new Zombie(new Vector2f(200, 200)));
            //zombies.Add(new Zombie(new Vector2f(500, 200)));
            //zombies.Add(new Zombie(new Vector2f(800, 200)));
            zombies.Add(new Zombie(new Vector2f(1000, 200)));
            zombies.Add(new Zombie(new Vector2f(1200, 200)));
            zombies.Add(new Zombie(new Vector2f(1300, 200)));
            zombies.Add(new Zombie(new Vector2f(1378, 200)));
            zombies.Add(new Zombie(new Vector2f(1570, 200)));
            zombies.Add(new Zombie(new Vector2f(2000, 300)));
            zombies.Add(new Zombie(new Vector2f(2300, 300)));
            zombies.Add(new Zombie(new Vector2f(2500, 300)));
            zombies.Add(new Zombie(new Vector2f(2900, 200)));
            zombies.Add(new Zombie(new Vector2f(3000, 200)));
            zombies.Add(new Zombie(new Vector2f(3500, 200)));
            zombies.Add(new Zombie(new Vector2f(3600, 300)));
            zombies.Add(new Zombie(new Vector2f(3700, 200)));
            zombies.Add(new Zombie(new Vector2f(4000, 200)));
            zombies.Add(new Zombie(new Vector2f(4100, 200)));

            zombies.Add(new Zombie(new Vector2f(3400, 300)));
            zombies.Add(new Zombie(new Vector2f(3200, 300)));
            //zombies.Add(new Zombie(new Vector2f(400, 200)));
        }

        public void Draw(RenderWindow window)
        {
            //Alle Gegner Objekt KLassen werden gezeichnet.
            foreach (Geist t in geister)
            {
                
                t.Draw(window);
            }
            foreach (Zombie t in zombies)
            {
                t.Draw(window);
            }
        }

        public void Update(GameTime gTime)
        {
            //Alle Gegner Objekt Klassen kriegen update.
            foreach (Geist t in geister)
            {
                
                t.Update(gTime);

            }
            foreach (Zombie t in zombies)
            {
                t.Update(gTime);
            }
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
