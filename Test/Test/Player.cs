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
            sprite.Origin = new Vector2f (textur.Size.X / 2, textur.Size.Y / 2);
        }

        public Vector2f position()
        {
            return sprite.Position;
            
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }

        public Vector2f direction(Vector2f a,Vector2f b)
        {
            return b - a;
        }

        public float abstand(Vector2f dir)
        {
            return System.Convert.ToSingle(Math.Sqrt(Math.Pow(dir.X, 2) + Math.Pow(dir.Y, 2)));
        }

        public void Move(Vector2f kreis, Vector2f cookie)
        {

            sprite.Position -= (direction(kreis,cookie) / abstand(direction(kreis,cookie))) / 15f;
        }
    }
}
