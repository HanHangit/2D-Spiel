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
        Texture textur;
        Sprite sprite;
        public Enemy(String auswahl)
        {
            if(auswahl == "Geist")
                textur = new Texture("Geist.gif");
            if (auswahl == "Tofu")
                textur = new Texture("Tofu.gif");
            sprite = new Sprite(textur);
            sprite.Origin = new Vector2f(textur.Size.X / 2, textur.Size.Y / 2);
        }

        public Vector2f position()
        {
            return sprite.Position;
        }

        public void setposition(Vector2f pos)
        {
            sprite.Position = pos;
        }

        public void verfolgen(Vector2f kreis, Vector2f cookie)
        {
            if (collision(kreis, cookie))
                sprite.Position -= (direction(kreis, cookie) / abstand(direction(kreis, cookie))) / 15f;
        }

        public float abstand(Vector2f dir)
        {
            return System.Convert.ToSingle(Math.Sqrt(Math.Pow(dir.X, 2) + Math.Pow(dir.Y, 2)));
        }


        public bool collision(Vector2f a, Vector2f b)
        {
            if (abstand(direction(a, b)) >= toleranz())
                return true;
            else
                return false;
        }

        public float toleranz()
        {
            return 60;
        }

        public Vector2f direction(Vector2f a, Vector2f b)
        {
            return a - b;
        }

        public void draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
    }
}
