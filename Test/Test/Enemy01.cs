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
            zombies = new List<Zombie>();

            geister.Add(new Geist());
            geister.Add(new Geist(new Vector2f(300, 1200), new Vector2f(300, 1400)));
            geister.Add(new Geist(new Vector2f(6325, 600), new Vector2f(6325, 1070)));
            geister.Add(new Geist(new Vector2f(6250, 1350), new Vector2f(5800, 1350)));
            geister.Add(new Geist(new Vector2f(6875, 480), new Vector2f(7650, 480)));
            geister.Add(new Geist(new Vector2f(11500, 250), new Vector2f(11500, 450)));
            geister.Add(new Geist(new Vector2f(20250, 500), new Vector2f(20250, 800)));
            geister.Add(new Geist(new Vector2f(22500, 1000), new Vector2f(22800, 1000)));
            geister.Add(new Geist(new Vector2f(29600, 1000), new Vector2f(1000, 600)));
            
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
            zombies.Add(new Zombie(new Vector2f(4600, 1200)));
            zombies.Add(new Zombie(new Vector2f(5300, 700)));
            zombies.Add(new Zombie(new Vector2f(5700, 1200)));
            zombies.Add(new Zombie(new Vector2f(7500, 1000)));
            zombies.Add(new Zombie(new Vector2f(7800, 800)));
            zombies.Add(new Zombie(new Vector2f(7950, 800)));
            zombies.Add(new Zombie(new Vector2f(9500, 750)));
            zombies.Add(new Zombie(new Vector2f(9000, 1200)));
            zombies.Add(new Zombie(new Vector2f(10500, 1200)));
            zombies.Add(new Zombie(new Vector2f(13700, 600)));
            zombies.Add(new Zombie(new Vector2f(14000, 1200)));
            zombies.Add(new Zombie(new Vector2f(14800, 800)));
            zombies.Add(new Zombie(new Vector2f(15600, 400)));
            zombies.Add(new Zombie(new Vector2f(16400, 850)));
            zombies.Add(new Zombie(new Vector2f(17400, 600)));
            zombies.Add(new Zombie(new Vector2f(21500, 500)));
            zombies.Add(new Zombie(new Vector2f(22300, 600)));
            zombies.Add(new Zombie(new Vector2f(29800, 600)));
            zombies.Add(new Zombie(new Vector2f(31500, 1200)));
            zombies.Add(new Zombie(new Vector2f(31000, 1200)));
            zombies.Add(new Zombie(new Vector2f(30550, 1200)));
            zombies.Add(new Zombie(new Vector2f(29800, 1200)));
            zombies.Add(new Zombie(new Vector2f(32000, 1200)));
            zombies.Add(new Zombie(new Vector2f(33000, 1200)));
            zombies.Add(new Zombie(new Vector2f(33400, 1200)));

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
